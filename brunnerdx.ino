#define DEBUGNO
#include "src/Joystick.h"
#include <Ethernet.h>

// -------------------------
// Various global variables
// -------------------------
unsigned long lastPositionUpdate;
unsigned long nextJoystickMillis;
unsigned long nextBrunnerMillis;

// --------------------------
// Network related variables
// --------------------------

// Enter a MAC address and IP address for your controller below.
// The IP address will be dependent on your local network:
const byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };
#define brunnerIP IPAddress (192, 168, 3, 194)
#define ip IPAddress (192, 168, 3, 167)
#define port 15090
EthernetUDP Udp; // An EthernetUDP instance to let us send and receive packets over UDP


// --------------------------
// Joystick related variables
// --------------------------
#define minX -32768
#define maxX 32767
#define minY -32768
#define maxY 32767
#define strength 4000

int lastVelX;
int lastVelY;
int lastX;
int lastY;

EffectParams effects[2];
int32_t forces[2] = {0, 0};

Joystick_ Joystick(
    JOYSTICK_DEFAULT_REPORT_ID, JOYSTICK_TYPE_JOYSTICK,
    19, 2, // Button Count, Hat Switch Count
    true, true, false, // X, Y, Z
    false, false, false, // Rx, Ry, Rz
    true, true); // rudder, throttle

void setup() {
    Ethernet.begin(mac, ip);

    setupJoystick();

    // setup network
    Udp.begin(port);

    // setup timing and run them as soon as possible
    lastPositionUpdate = 0;
    nextJoystickMillis = 0;
    nextBrunnerMillis = 0;
}

void loop(){
    doUDPStuff();

    unsigned long currentMillis;
    currentMillis = millis();
    // do not run more frequently than these many milliseconds
    if (currentMillis >= nextJoystickMillis) {
        updateEffects();
        nextJoystickMillis = currentMillis + 1;
    }
    if (currentMillis >= nextBrunnerMillis) {
        sendCLS2SIMForces();
        nextBrunnerMillis = currentMillis + 1;
    }
}

void doUDPStuff() {
    char packetBuffer[UDP_TX_PACKET_MAX_SIZE];  //buffer to hold incoming packet,
    int packetSize = Udp.parsePacket();

    if(packetSize)
    {
        // read the packet into packetBuffer
        Udp.read(packetBuffer, UDP_TX_PACKET_MAX_SIZE);
        processCLS2SIMMessage(packetBuffer, packetSize);
    }

}
