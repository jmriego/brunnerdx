#include "brunnerdx.h"

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
