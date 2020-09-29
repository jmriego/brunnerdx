#include "brunnerdx.h"

byte int2bytes(int i, byte b[]) {
    union u_tag {
        int32_t i;
        byte b[4];
    } u;

    u.i = i;
    b = u.b;
}

float bytes2float(char txt[]) {
    union u_tag {
        byte b[4];
        float f;
    } u;

    u.b[0] = txt[0];
    u.b[1] = txt[1];
    u.b[2] = txt[2];
    u.b[3] = txt[3];
    return u.f;
}

responseAxisPositions parseBrunnerResponse(char c[]) {
    union u_tag {
        char c[sizeOfResponseAxisPositions];
        responseAxisPositions r;
    } u;

    for (int i =0; i < sizeOfResponseAxisPositions; i++) {
        u.c[i] = c[i];
    }
    return u.r;
}
