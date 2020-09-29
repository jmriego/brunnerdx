#ifndef BRUNNERDX_h
#define BRUNNERDX_h

typedef struct {
    int32_t command;
    float elevator;
    float aileron;
    float rudder;
    float collective;
} responseAxisPositions, *presponseAxisPositions;
const int sizeOfResponseAxisPositions = 20; //sizeof(int32_t) + sizeof(float) * 4
#endif
