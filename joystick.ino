#define default_gain 100

void setupJoystick() {
    Joystick.setXAxisRange(minX, maxX);
    Joystick.setYAxisRange(minY, maxY);
    setupFFBEffects();
    Joystick.begin();
}

void setupFFBEffects(){
    //set x axis gains
    gain[0].totalGain = default_gain;
    gain[0].constantGain = default_gain;
    gain[0].rampGain = default_gain;
    gain[0].squareGain = default_gain;
    gain[0].sineGain = default_gain;
    gain[0].triangleGain = default_gain;
    gain[0].sawtoothdownGain = default_gain;
    gain[0].sawtoothupGain = default_gain;
    gain[0].springGain = default_gain;
    gain[0].damperGain = default_gain;
    gain[0].inertiaGain = default_gain;
    gain[0].frictionGain = default_gain;

    //set y axis gains
    gain[1].totalGain = default_gain;
    gain[1].constantGain = default_gain;
    gain[1].rampGain = default_gain;
    gain[1].squareGain = default_gain;
    gain[1].sineGain = default_gain;
    gain[1].triangleGain = default_gain;
    gain[1].sawtoothdownGain = default_gain;
    gain[1].sawtoothupGain = default_gain;
    gain[1].springGain = default_gain;
    gain[1].damperGain = default_gain;
    gain[1].inertiaGain = default_gain;
    gain[1].frictionGain = default_gain;

    Joystick.setGains(gain);

}

void updateJoystickPos(int16_t posX, int16_t posY) {
    effects[0].springMaxPosition = maxX;
    effects[1].springMaxPosition = maxY;
    effects[0].frictionMaxPositionChange = 250; // TODO: find proper values for these
    effects[1].frictionMaxPositionChange = 250;
    effects[0].inertiaMaxAcceleration = 250;
    effects[1].inertiaMaxAcceleration = 250;
    effects[0].damperMaxVelocity = 250;
    effects[1].damperMaxVelocity = 250;

    effects[0].springPosition = posX;
    effects[1].springPosition = posY;

    unsigned long currentMillis;
    currentMillis = millis();
    int16_t diffTime = currentMillis - lastPositionUpdate;
    if (diffTime > 0) {
        lastPositionUpdate = currentMillis;
        int16_t positionChangeX = lastX - posX;
        int16_t positionChangeY = lastY - posY;
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

    //Get Force [-255,255] you can set PWM with this value
    #ifdef DEBUG
      Serial.println("");
      Serial.print(" - XF: ");
      Serial.print(forces[0]);
      Serial.print(" YF: ");
      Serial.print(forces[1]);
    #endif
}
