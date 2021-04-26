# BrunnerDX
## This is an app and Arduino sketch for making your Brunner base look like a DirectX joystick with Force Feedback

It will be detected by Windows as a standard USB joystick with advanced force feedback features without the need to install any device drivers.

You need to have an Arduino Micro (or any other Atmega32UX). Make sure to get the 5V version, not the 3.3V

The part of the code that involves the Arduino sketch/driver is in this other repo if you are interested: [Fino](https://github.com/jmriego/Fino)

## Installation

The easy way is just grab a [Release](https://github.com/jmriego/brunnerdx/releases) from this project page and install it somewhere in your computer.
If you don't have it already, you might want to install the [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net47-web-installer) for Windows

If it's your first time running this app you'll have to "Upload Firmware" and set up your Brunner CLS2Sim to talk to this app.

More details on the [wiki](https://github.com/jmriego/brunnerdx/wiki)

Just click on connect and that's it!

This has been tested with IL-2 Cliffs of Dover and Battle of Stalingrad and it works great in them. Please let me know if you find any issue in other games and I'll fix it

## TODO:

* This currently only reads the X and Y position of the Joystick and not the buttons. It's not an issue in modern games (you can play IL-2 BoX, CloDa and DCS for example) but any old game with no multi joystick support would need to map joystick buttons to key presses somehow.

## Ref

### This is based on some other libraries. Thanks a lot for your work!
* [Heironimus](https://github.com/MHeironimus/ArduinoJoystickLibrary)
* [hoantv](https://github.com/hoantv/VNWheel)
* [YukMingLaw](https://github.com/YukMingLaw/ArduinoJoystickWithFFBLibrary) 
