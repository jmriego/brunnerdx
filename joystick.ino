#define default_gain 100

void setupJoystick() {
    Joystick.setXAxisRange(minX, maxX);
    Joystick.setYAxisRange(minY, maxY);
    setupFFBEffects();
    Joystick.begin();
}

void setupFFBEffects(){
    Gains gain[2];
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

    effects[0].springMaxPosition = maxX;
    effects[1].springMaxPosition = maxY;
    effects[0].frictionMaxPositionChange = maxX; // TODO: test this works or should be = lastX - posX
    effects[1].frictionMaxPositionChange = maxY;
    effects[0].inertiaMaxAcceleration = 100; // TODO: find proper values for these
    effects[1].inertiaMaxAcceleration = 100;
    effects[0].damperMaxVelocity = 100;
    effects[1].damperMaxVelocity = 100;
    effects[0].damperVelocity=100;
    effects[1].damperVelocity=100;

}

void doJoystickStuff(){
    static int velX;
    static int velY;
    static int lastVelX = 0;
    static int lastVelY = 0;
    static int lastX = 0;
    static int lastY = 0;

    effects[0].springPosition = posX;
    effects[1].springPosition = posY;
    Joystick.setXAxis(posX);
    Joystick.setYAxis(posY);

    velX = lastX - posX;
    velY = lastY - posY;

    effects[0].frictionPositionChange = velX;
    effects[1].frictionPositionChange = velY;

    effects[0].inertiaAcceleration = velX - lastVelX;
    effects[1].inertiaAcceleration = velY - lastVelY;

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

    lastX = posX;
    lastY = posY;
    lastVelX = velX;
    lastVelY = velY;
}
