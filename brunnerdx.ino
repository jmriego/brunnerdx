#define DEBUG
#include "Joystick.h"
#include <SPI.h>
#include <Ethernet.h>
#include <EthernetUdp.h>
#include <EEPROM.h>

// -------------------------
// Various global variables
// -------------------------
unsigned long currentMillis;
unsigned long prevBrunnerMillis;

// --------------------------
// Network related variables
// --------------------------

// Enter a MAC address and IP address for your controller below.
// The IP address will be dependent on your local network:
byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };
IPAddress ip(192, 168, 3, 239);
unsigned int localPort = 8888;              // local port to listen on

// buffers for receiving and sending data
// TODO: actually make this buffer one byte and 4 int32_t
const int brunnerBufferSize = 1 + sizeof(int32_t)*4;
char brunnerBuffer[brunnerBufferSize];  //buffer to hold Brunner external control buffer
char packetBuffer[UDP_TX_PACKET_MAX_SIZE];  //buffer to hold incoming packet,

// An EthernetUDP instance to let us send and receive packets over UDP
EthernetUDP Udp;

// --------------------------
// Joystick related variables
// --------------------------
// TODO: get maxX and maxY
int minX = 0;
int maxX = 1023;
int minY = 0;
int maxY = 1023;
long posX;
long posY;
int centerX;
int centerY;
int lastX = 0;
int lastY = 0;

int strength = 100;
Gains gain[2];
EffectParams effects[2];
int32_t forces[2] = {0};

Joystick_ Joystick(
    JOYSTICK_DEFAULT_REPORT_ID, JOYSTICK_TYPE_JOYSTICK,
    11, 5, // Button Count, Hat Switch Count
    true, true, true, // X, Y and Z
    false, false, false, // No Rx, Ry, or Rz
    false, false, // No rudder or throttle
    false, false, false); // No accelerator, brake, or steering

void setup() {
    // setup connections
    Serial.begin(9600);
    delay(2000); //Give the serial port time to catch up so we can debug
    Serial.println("Setting up...");
    // Ethernet.begin(mac,ip);
    // Udp.begin(localPort);

    // setup joystick and FFB
    Joystick.setXAxisRange(minX, maxX);
    Joystick.setYAxisRange(minY, maxY);
    setupFFBEffects();
    Joystick.begin();

    // setup Brunner
    memset(brunnerBuffer, 0, brunnerBufferSize);
    brunnerBuffer[0] = 0xAF;
    prevBrunnerMillis = millis();
}

void setupFFBEffects(){
    //set x axis gains
    gain[0].totalGain = strength;
    gain[0].constantGain = strength;
    gain[0].rampGain = strength;
    gain[0].squareGain = strength;
    gain[0].sineGain = strength;
    gain[0].triangleGain = strength;
    gain[0].sawtoothdownGain = strength;
    gain[0].sawtoothupGain = strength;
    gain[0].springGain = strength;
    gain[0].damperGain = strength;
    gain[0].inertiaGain = strength;
    gain[0].frictionGain = strength;

    //set y axis gains
    gain[1].totalGain = strength;
    gain[1].constantGain = strength;
    gain[1].rampGain = strength;
    gain[1].squareGain = strength;
    gain[1].sineGain = strength;
    gain[1].triangleGain = strength;
    gain[1].sawtoothdownGain = strength;
    gain[1].sawtoothupGain = strength;
    gain[1].springGain = strength;
    gain[1].damperGain = strength;
    gain[1].inertiaGain = strength;
    gain[1].frictionGain = strength;

    Joystick.setGains(gain);

    effects[0].springMaxPosition = maxX/2;
    effects[1].springMaxPosition = maxY/2;
    effects[0].frictionMaxPositionChange = maxX; // TODO: test this works or should be = lastX - posX
    effects[1].frictionMaxPositionChange = maxY;
    effects[0].inertiaMaxAcceleration = maxX;
    effects[1].inertiaMaxAcceleration = 100;
    effects[0].damperMaxVelocity = 10;
    effects[1].damperMaxVelocity = 100;
    effects[0].inertiaAcceleration = 100;
    effects[1].inertiaAcceleration = 100;
    effects[0].damperVelocity=100;
    effects[1].damperVelocity=100;

}

void loop(){
    // doUDPStuff();
    doJoystickStuff();

    currentMillis = millis();
    // do not run this more often than these milliseconds
    if (currentMillis - prevBrunnerMillis >= 10) {
        // doBrunnerStuff();
        prevBrunnerMillis = currentMillis;
    }
}

float char2float(char txt[], int offset) {
    union u_tag {
        byte b[4];
        float fval;
    } u;

    u.b[0] = txt[offset];
    u.b[1] = txt[offset + 1];
    u.b[2] = txt[offset + 2];
    u.b[3] = txt[offset + 3];

    return u.fval;
}

void processMessage(char msg[]) {
    int msgLength = strlen(msg);
    if (msgLength == 17 && msg[0] == 0xAF) {
    }
}

void doUDPStuff() {
    int packetSize = Udp.parsePacket();
    if(packetSize)
    {
        Serial.print("Received packet of size ");
        Serial.println(packetSize);
        Serial.print("From ");
        IPAddress remote = Udp.remoteIP();
        for (int i =0; i < 4; i++)
        {
            Serial.print(remote[i], DEC);
            if (i < 3)
            {
                Serial.print(".");
            }
        }
        Serial.print(", port ");
        Serial.println(Udp.remotePort());

        // read the packet into packetBufffer
        Udp.read(packetBuffer, UDP_TX_PACKET_MAX_SIZE);
        Serial.println("Contents:");
        Serial.println(packetBuffer);
    }
    processMessage(packetBuffer);

    // TODO: read x and y positions
    // posX = encoderX.read();
    // posX = int32_t(array[0]) << 24 | int32_t(array[1]) << 16 | int32_t(array[2]) << 8 | int32_t(array[3]);
    // posX = *(int32_t*)&packetBuffer[Offset];
    // posY = encoderY.read();

}

void doJoystickStuff(){

    effects[0].springPosition = posX;
    effects[1].springPosition = posY;
    Joystick.setXAxis(posX);
    Joystick.setYAxis(posY);

    effects[0].frictionPositionChange = lastX - posX;
    effects[1].frictionPositionChange = lastY - posY;

    Joystick.setEffectParams(effects);
    Joystick.getForce(forces);

    //Get Force [-255,255] you can set PWM with this value
    #ifdef DEBUG
    Serial.println("");
    Serial.print(" - XF: ");
    Serial.print(forces[0]);
    Serial.print(" YF: ");
    Serial.print(forces[1]);
    #endif

    lastX = posX;
    lastY = posY;

}

void doBrunnerStuff(){
    Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
    memcpy(&brunnerBuffer, &posX, sizeof(int32_t));
    memcpy(&brunnerBuffer + sizeof(int32_t), &posY, sizeof(int32_t));
    Udp.write(brunnerBuffer, brunnerBufferSize);
    Udp.endPacket();
}
