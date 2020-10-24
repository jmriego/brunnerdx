# Arduino Joystick with Force Feedback interface Brunner

## This is an Arduino sketch that will appear to Windows as a Force Feedback Joystick. It requires connecting an Ethernet module and it will use the Brunner API to send the forces to the joystick and receive from it the inputs from the joystick

## Installation

You need to have an Arduino Micro (or any other Atmega32UX)  connected to an Ethernet module. The instructions really depend on which one you are getting so it wouldn't be easy to give them here.

Then connect your Arduino to your PC, install the Arduino IDE.

The only modifications you might need are in the `config.h` file:
1. Set the IP of your Brunner base (it should show up in the Brunner software).
2. Set the IP of the Arduino itself. Usually same as the Brunner IP but changing the last number

Upload the sketch and enjoy!

## TODO:

* This currently only reads the X and Y position of the Joystick and not the buttons. It's not an issue in modern games (you can play IL-2 BoX for example) but any old game with no multi joystick support would need to map joystick buttons to key presses in another app.
* Add a configuration program so you can change the strength of the Force Feedback in real time and also be able to change the IP when needed with using the Arduino IDE. Not an easy task as I've already simplified lots of code to be able to fit in the Arduino memory.

## Ref

### This is based on some other libraries. Thanks a lot for your work!
* [Heironimus](https://github.com/MHeironimus/ArduinoJoystickLibrary)
* [hoantv](https://github.com/hoantv/VNWheel)
* [YukMingLaw](https://github.com/YukMingLaw/ArduinoJoystickWithFFBLibrary) 
