// --------------------------
// Network related variables
// --------------------------

// Enter a MAC address and IP address for your controller below.
// The IP address will be dependent on your local network:
const byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };
#define brunnerIP IPAddress (192, 168, 3, 194)
#define ip IPAddress (192, 168, 3, 167)
#define port 15090

// --------------------------
// Joystick related variables
// --------------------------

#define default_gain 100
#define totalGain default_gain
#define constantGain default_gain
#define rampGain default_gain
#define squareGain default_gain
#define sineGain default_gain
#define triangleGain default_gain
#define sawtoothdownGain default_gain
#define sawtoothupGain default_gain
#define springGain default_gain
#define damperGain default_gain
#define inertiaGain default_gain
#define frictionGain default_gain
