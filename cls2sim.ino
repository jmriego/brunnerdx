struct ResponseAxisPositions {
    int32_t command;
    float elevator;
    float aileron;
    float rudder;
    float collective;
};
#define sizeOfResponseAxisPositions 20

byte extractByteFromResponse(char c[], int offset) {
    union u_tag {
        char c;
        byte b;
    } u;
    u.c = c[offset];
    return u.b;
}

int32_t extractInt32FromResponse(char c[], int offset){
    union u_tag {
        char c[4];
        int32_t num;
    } u;
    for (int i = offset; i < offset+sizeof(int32_t); i++) {
        u.c[i] = c[i];
    }
    return u.num;
}

int32_t extractCommandFromResponse(char c[]){
    return extractInt32FromResponse(c, 0);
}

int32_t extractAxisFromReadResponse(char c[]){
    return extractInt32FromResponse(c, sizeof(int32_t));
}

ResponseAxisPositions parseBrunnerResponse(char c[]);
ResponseAxisPositions parseBrunnerResponse(char c[]) {
    union u_tag {
        char c[sizeOfResponseAxisPositions];
        ResponseAxisPositions r;
    } u;

    for (int i =0; i < sizeOfResponseAxisPositions; i++) {
        u.c[i] = c[i];
    }
    return u.r;
}

void processCLS2SIMMessage(char msg[], int msgLength) {
    int32_t command = extractCommandFromResponse(msg);

    if (command == 0xAF && msgLength == sizeOfResponseAxisPositions) {
            ResponseAxisPositions res = parseBrunnerResponse(msg);
            updateJoystickPos(
                (res.aileron-0.5) * 2.0 * maxX,
                (res.elevator-0.5) * 2.0 * maxY);

    } else if (command == 0x00) {
        int32_t axis = extractAxisFromReadResponse(msg);
        switch (axis) {
            case 0x00: // buttons
                byte b; 
                for (int i=sizeof(uint16_t); i<msgLength; i++) {
                    b = extractByteFromResponse(msg, i);
                    // TODO: maybe its reverse this
                    for (int j=8; i>0; i--) {
                        Joystick.setButton(i+j, b&1);
                        b >>=1;
                    }
                }
                break;
        }
    }
}

void sendCLS2SIMForces(){
    const int32_t external_control_command = 0xAF;
    const byte zero[1] = {B0};
    
    // Send external control forces
    int32_t brunnerForces[2];
    brunnerForces[0] = forces[1] * strength / 1000; // Brunner forces are specified aileron/roll
    brunnerForces[1] = forces[0] * strength / 1000; // instead of x/y. That's inversed order
    Udp.beginPacket(brunnerIP, port);
    Udp.write((byte*)&external_control_command, sizeof(external_control_command));
    Udp.write((byte*)&brunnerForces, sizeof(int32_t)*2);
    // write zeroes for rudder and collective forces
    for (int i = 0; i < 8; i++) {
        Udp.write(zero, sizeof(zero));
    }
    Udp.endPacket();

    // Request reading buttons and other axes
//    const int32_t read_command = 0xD0;
//    const int32_t all_axes = 0x04;
//    const int32_t data_id = 0x81;
//    Udp.beginPacket(brunnerIP, port);
//    Udp.write((byte*)&read_command, sizeof(read_command));
//    Udp.write((byte*)&all_axes, sizeof(all_axes));
//    Udp.write((byte*)&data_id, sizeof(data_id));
//    Udp.endPacket();
}
