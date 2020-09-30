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
    const int32_t command = 0xAF;
    const byte zero[1] = {B0};
    
    float brunnerForces[2];
    brunnerForces[0] = forces[0] * strength / 1000;
    brunnerForces[1] = forces[1] * strength / 1000;

    Udp.beginPacket(brunnerIP, port);
    Udp.write((byte*)&command, sizeof(command));
    Udp.write((byte*)&(brunnerForces[0]), sizeof(float));
    Udp.write((byte*)&(brunnerForces[1]), sizeof(float));
    // write zeroes for rudder and collective forces
    for (int i = 0; i < sizeof(zero)*2; i++) {
        Udp.write(zero, sizeof(zero));
    }
    Udp.endPacket();
}
