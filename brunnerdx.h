#ifndef BRUNNERDX_h
#define BRUNNERDX_h

typedef struct {
    int32_t command;
    int32_t elevator;
    int32_t aileron;
    int32_t rudder;
    int32_t collective;
} requestAxisForces, *prequestAxisForces;
const int sizeOfRequestAxisForces = 20; //sizeof(int32_t) * 5

typedef struct {
    int32_t command;
    float elevator;
    float aileron;
    float rudder;
    float collective;
} responseAxisPositions, *presponseAxisPositions;
const int sizeOfResponseAxisPositions = 20; //sizeof(int32_t) + sizeof(float) * 4
#endif
