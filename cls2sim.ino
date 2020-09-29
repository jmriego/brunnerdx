struct ResponseAxisPositions {
    int32_t command;
    float elevator;
    float aileron;
    float rudder;
    float collective;
};
const int sizeOfResponseAxisPositions = 20; //sizeof(int32_t) + sizeof(float) * 4

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
    if (msgLength == sizeOfResponseAxisPositions) {
        ResponseAxisPositions res = parseBrunnerResponse(msg);
        if (res.command == 0xAF) {
            posX = res.aileron * maxX;
            posY = res.elevator * maxY;
        }
    }
}

void sendCLS2SIMForces(){
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
