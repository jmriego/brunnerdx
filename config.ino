#define POS_STRENGTH 0
#define POS_IP 4

const byte mac[] PROGMEM = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };

void readConfigFromSerial() {
    if (Serial.available() > 0) {
        // read the incoming byte:
        int incomingByte;
        incomingByte = Serial.read();

        // say what you got:
        if (incomingByte == 'S') {
            strength = Serial.parseInt(); 
            EEPROM.put(POS_STRENGTH, strength);
        } else if (incomingByte == 'I') {
            for (int i =0; i < 4; i++) {
                incomingByte = Serial.parseInt(); 
                EEPROM.put(POS_IP + i*4, incomingByte);
            }
        }
    }
}

void readConfigFromEEPROM() {
    // Read the configured strength
    EEPROM.get(0, strength);

    // Read the IP and refresh it
    int ip[4];
    EEPROM.get(POS_IP, ip);
    if (ip[0] >= 10 and ip[0] < 255) {
        Ethernet.begin(mac, ip);
    } else {
        Ethernet.begin(mac); // with DHCP requires 10% more space
    }
    #ifdef DEBUG_NET
    Serial.println(Ethernet.localIP()); // 192.168.3.167
    #endif
}
