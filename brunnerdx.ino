#define DEBUGNO
#include <Joystick.h>
#include <SPI.h>
#include <Ethernet.h>
#include <EthernetUdp.h>
#include <EEPROM.h>

// -------------------------
// Various global variables
// -------------------------
unsigned long nextJoystickMillis;
unsigned long nextBrunnerMillis;

// --------------------------
// Network related variables
// --------------------------

// Enter a MAC address and IP address for your controller below.
// The IP address will be dependent on your local network:
const IPAddress brunnerIP(192, 168, 3, 194);
const unsigned int port = 15090;              // local port to send msg to
EthernetUDP Udp; // An EthernetUDP instance to let us send and receive packets over UDP


// --------------------------
// Joystick related variables
// --------------------------
#define minX 0
#define maxX 1023
#define minY 0
#define maxY 1023
long posX;
long posY;

int strength = 4000;
EffectParams effects[2];
int32_t forces[2] = {0, 0};

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
    readConfigFromEEPROM();

    setupJoystick();

    #ifdef DEBUG
    Serial.print("Strength: ");
    Serial.println(strength); // 192.168.3.167
    Serial.print("IP: ");
    Serial.println(Ethernet.localIP()); // 192.168.3.167
    #endif
    // setup network
    Udp.begin(port);

    // setup timing and run them as soon as possible
    nextJoystickMillis = 0;
    nextBrunnerMillis = 0;
}

void loop(){
    doUDPStuff();
    readConfigFromSerial();

    unsigned long currentMillis;
    currentMillis = millis();
    // do not run more frequently than these many milliseconds
    if (currentMillis >= nextJoystickMillis) {
        doJoystickStuff();
        nextJoystickMillis = millis + 1;
    }
    if (currentMillis >= nextBrunnerMillis) {
        sendCLS2SIMForces();
        nextBrunnerMillis = currentMillis + 1000;
    }
}

void doUDPStuff() {
    char packetBuffer[UDP_TX_PACKET_MAX_SIZE];  //buffer to hold incoming packet,
    int packetSize = Udp.parsePacket();

    if(packetSize)
    {
        // read the packet into packetBuffer
        Udp.read(packetBuffer, UDP_TX_PACKET_MAX_SIZE);
        #ifdef DEBUG
        Serial.print("Received packet of size ");
        Serial.println(packetSize);
        Serial.println("Contents:");
        Serial.println(packetBuffer);
        #endif

        processCLS2SIMMessage(packetBuffer, packetSize);
    }

}
