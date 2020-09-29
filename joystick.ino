void setupFFBEffects(){
    //set x axis gains
    gain[0].totalGain = strength;
    gain[0].constantGain = strength;
    gain[0].rampGain = strength;
    gain[0].squareGain = strength;
    gain[0].sineGain = strength;
    gain[0].triangleGain = strength;
    gain[0].sawtoothdownGain = strength;
    gain[0].sawtoothupGain = strength;
    gain[0].springGain = strength;
    gain[0].damperGain = strength;
    gain[0].inertiaGain = strength;
    gain[0].frictionGain = strength;

    //set y axis gains
    gain[1].totalGain = strength;
    gain[1].constantGain = strength;
    gain[1].rampGain = strength;
    gain[1].squareGain = strength;
    gain[1].sineGain = strength;
    gain[1].triangleGain = strength;
    gain[1].sawtoothdownGain = strength;
    gain[1].sawtoothupGain = strength;
    gain[1].springGain = strength;
    gain[1].damperGain = strength;
    gain[1].inertiaGain = strength;
    gain[1].frictionGain = strength;

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
    #ifdef DEBUG_FORCE
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
