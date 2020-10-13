#define default_gain 100

void setupJoystick() {
    Joystick.setXAxisRange(minX, maxX);
    Joystick.setYAxisRange(minY, maxY);
    setupFFBEffects();
    Joystick.begin();
}

void setupFFBEffects(){
    Gains gain[2];
    //set x and y axis gains
    for (int i =0; i < 2; ++i) {
        gain[i].totalGain = default_gain;
        gain[i].constantGain = default_gain;
        gain[i].rampGain = default_gain;
        gain[i].squareGain = default_gain;
        gain[i].sineGain = default_gain;
        gain[i].triangleGain = default_gain;
        gain[i].sawtoothdownGain = default_gain;
        gain[i].sawtoothupGain = default_gain;
        gain[i].springGain = default_gain;
        gain[i].damperGain = default_gain;
        gain[i].inertiaGain = default_gain;
        gain[i].frictionGain = default_gain;
    }

    Joystick.setGains(gain);
}

void updateJoystickPos(int16_t posX, int16_t posY) {
    for (int i =0; i < 2; ++i) {
        effects[i].frictionMaxPositionChange = 250; // TODO: find proper values for these
        effects[i].inertiaMaxAcceleration = 250;
        effects[i].damperMaxVelocity = 250;
    }

    effects[0].springMaxPosition = maxX;
    effects[1].springMaxPosition = maxY;
    effects[0].springPosition = posX;
    effects[1].springPosition = posY;

    unsigned long currentMillis;
    currentMillis = millis();
    int16_t diffTime = currentMillis - lastPositionUpdate;
    if (diffTime > 0) {
        lastPositionUpdate = currentMillis;
        int16_t positionChangeX = posX - lastX;
        int16_t positionChangeY = posY - lastY;
        int16_t velX = positionChangeX / diffTime;
        int16_t velY = positionChangeY / diffTime;
    
        effects[0].frictionPositionChange = velX;
        effects[1].frictionPositionChange = velY;
        effects[0].inertiaAcceleration = (velX - lastVelX) / diffTime;
        effects[1].inertiaAcceleration = (velY - lastVelY) / diffTime;
        effects[0].damperVelocity = velX;
        effects[1].damperVelocity = velY;
        lastX = posX;
        lastY = posY;
        lastVelX = velX;
        lastVelY = velY;
    }

    Joystick.setXAxis(posX);
    Joystick.setYAxis(posY);
}

void updateEffects(){
    Joystick.setEffectParams(effects);
    Joystick.getForce(forces);
}
