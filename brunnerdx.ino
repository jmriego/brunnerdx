#define DEBUGNO
#include "brunnerdx.h"
#include <Joystick.h>
#include <SPI.h>
#include <Ethernet.h>
#include <EthernetUdp.h>
#include <EEPROM.h>

// -------------------------
// Various global variables
// -------------------------
unsigned long currentMillis;
unsigned long prevJoystickMillis;
unsigned long prevBrunnerMillis;

// --------------------------
// Network related variables
// --------------------------

// Enter a MAC address and IP address for your controller below.
// The IP address will be dependent on your local network:
byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };
IPAddress ip(192, 168, 3, 167);
IPAddress brunnerIP(192, 168, 3, 194);
unsigned int port = 15090;              // local port to send msg to
char packetBuffer[UDP_TX_PACKET_MAX_SIZE];  //buffer to hold incoming packet,
EthernetUDP Udp; // An EthernetUDP instance to let us send and receive packets over UDP


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
int velX = 0;
int velY = 0;
int lastVelX = 0;
int lastVelY = 0;
int lastX = 0;
int lastY = 0;

int strength = 100;
Gains gain[2];
EffectParams effects[2];
int32_t forces[2] = {0};

Joystick_ Joystick(
    JOYSTICK_DEFAULT_REPORT_ID, JOYSTICK_TYPE_JOYSTICK,
    11, 5, // Button Count, Hat Switch Count
    true, true, false, // X, Y and Z
    false, false, false, // No Rx, Ry, or Rz
    true, true, // No rudder or throttle
    false, false, false); // No accelerator, brake, or steering

void setup() {
    // setup connections
    Serial.begin(9600);
    delay(2000); //Give the serial port time to catch up so we can debug
    Serial.println("Setting up...");

    // setup joystick and FFB
    Joystick.setXAxisRange(minX, maxX);
    Joystick.setYAxisRange(minY, maxY);
    setupFFBEffects();
    Joystick.begin();

    // setup FFB
    Ethernet.begin(mac,ip);
    //Ethernet.begin(mac); with DHCP requires 10% more space
    Serial.println(Ethernet.localIP()); // 192.168.3.167
    Udp.begin(port);

    // setup timing
    prevJoystickMillis = millis();
    prevBrunnerMillis = millis();
}

void loop(){
    doUDPStuff();

    currentMillis = millis();
    // do not run more frequently than many milliseconds
    if (currentMillis - prevJoystickMillis >= 1) {
        doJoystickStuff();
        prevJoystickMillis = currentMillis;
    }
    if (currentMillis - prevBrunnerMillis >= 1000) {
        doBrunnerStuff();
        prevBrunnerMillis = currentMillis;
    }
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

    effects[0].springMaxPosition = maxX;
    effects[1].springMaxPosition = maxY;
    effects[0].frictionMaxPositionChange = maxX; // TODO: test this works or should be = lastX - posX
    effects[1].frictionMaxPositionChange = maxY;
    effects[0].inertiaMaxAcceleration = 100;
    effects[1].inertiaMaxAcceleration = 100;
    effects[0].damperMaxVelocity = 100;
    effects[1].damperMaxVelocity = 100;
    effects[0].damperVelocity=100;
    effects[1].damperVelocity=100;

}

void processMessage(char msg[], int msgLength) {
    if (msgLength == sizeOfResponseAxisPositions) {
        responseAxisPositions res = parseBrunnerResponse(msg);
        if (res.command == 0xAF) {
            posX = res.aileron * maxX;
            posY = res.elevator * maxY;
        }
    }
}

void doUDPStuff() {
    int packetSize = Udp.parsePacket();

    if(packetSize)
    {
        // read the packet into packetBuffer
        IPAddress remote = Udp.remoteIP();
        Udp.read(packetBuffer, UDP_TX_PACKET_MAX_SIZE);
        #ifdef DEBUG_UDP
        Serial.print("Received packet of size ");
        Serial.println(packetSize);
        Serial.print("From ");
        for (int i =0; i < 4; i++) {
            Serial.print(remote[i], DEC);
            if (i < 3)
            {
                Serial.print(".");
            }
        }
        Serial.print(", port ");
        Serial.println(Udp.remotePort());


        Serial.println("Contents:");
        Serial.println(packetBuffer);
        #endif

        processMessage(packetBuffer, packetSize);
    }

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

    velX = lastX - posX;
    velY = lastY - posY;

    effects[0].frictionPositionChange = velX;
    effects[1].frictionPositionChange = velY;

    effects[0].inertiaAcceleration = velX - lastVelX;
    effects[1].inertiaAcceleration = velY - lastVelY;

    Joystick.setEffectParams(effects);
    Joystick.getForce(forces);

    //Get Force [-255,255] you can set PWM with this value
    #ifdef DEBUG_FORCE
    Serial.println("");
    Serial.print(" - XF: ");
    Serial.print(forces[0]);
    Serial.print(" YF: ");
    Serial.print(forces[1]);
    #endif

    lastX = posX;
    lastY = posY;
    lastVelX = velX;
    lastVelY = velY;
}

void doBrunnerStuff(){
    int32_t command = 0xAF;
    int32_t zero = 0;
    
    Udp.beginPacket(brunnerIP, port);
    Udp.write((byte*)&command, sizeof(command));
    Udp.write((byte*)&(forces[0]), sizeof(forces[0]));
    Udp.write((byte*)&(forces[1]), sizeof(forces[1]));
    Udp.write((byte*)&zero, sizeof(zero));
    Udp.write((byte*)&zero, sizeof(zero));
    Udp.endPacket();
}
