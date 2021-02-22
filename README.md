# BrunnerDX
## This is an app and Arduino sketch for making your Brunner base look like a DirectX joystick with Force Feedback

It will be detected by Windows as a standard USB joystick with advanced force feedback features without the need to install any device drivers.

You need to have an Arduino Micro (or any other Atmega32UX).

The part of the code that involves the Arduino sketch/driver is in this other repo if you are interested: [Fino](https://github.com/jmriego/Fino)

## Installation

The easy way is just grab a Release from this project page and install it somewhere in your computer.

If it's your first time running this app you'll have to "Upload Firmware" and set up your Brunner CLS2Sim to talk to this app.

More details on the [wiki](https://github.com/jmriego/brunnerdx/wiki)

Just click on connect and that's it!

## Running it with Python (alternative to the GUI)
Install the [pyserial](https://pypi.org/project/pyserial/) library
Upload the sketch that you can build in [Fino](https://github.com/jmriego/Fino), run the `brunnerdx.py` file and enjoy!

These are more detailed steps, but it might be easier to just run the app:
1. Download the [Fino repo zip file](https://github.com/jmriego/Fino/archive/master.zip) file and save it somewhere in your hard drive (an option is clicking on Code->Download as ZIP and then unzipping it somewhere).
2. Install the [Arduino IDE](https://www.arduino.cc/en/software).
3. Open the Arduino IDE and open the brunnerdx.ino file that it's in the folder you extracted on step 1.
4. Click on Tools -> Boards and choose the "Arduino Micro"
5. Ensure the Arduino Micro port is selected in Tools -> Ports
6. Click on the verify icon (a check mark), then on the upload button (a right arrow).
7. Install [Python](https://www.python.org/downloads/). Make sure to mark the option "Add Python to environment variables"
8. Open a command prompt (Windows button, then open Command Prompt)
9. type `pip install pyserial`
10. Execute the `brunnerdx.py` file that it's on the folder you extracted on step 1. You can double click on it or right click->Edit with IDLE->Run->Run Module

The only modifications you might need are in the `brunnerdx.py` file:
1. Set the IP and port of CLS2Sim running locally (it should show up in the Brunner software).
2. Change the FORCE_MULTIPLIER if you want weaker or stronger forces

NOTES:
The Brunner CLS2SIM program should be running and allowing external control. In the image below the external control port is 15090. I have it running in Usb HID mode instead of Ethernet as shown in the image below.
![Connection Settings](https://cls2sim.brunner-innovation.swiss/images/settingsExtCtrl.png)

## TODO:

* This currently only reads the X and Y position of the Joystick and not the buttons. It's not an issue in modern games (you can play IL-2 BoX for example) but any old game with no multi joystick support would need to map joystick buttons to key presses somehow.
* Add a GUI so you can change the strength of the Force Feedback in real time.
* Improve the filtering of conditional forces. I'm sure this can be made a bit smoother though it acts similar to the MS FFB2 at the moment.

## Ref

### This is based on some other libraries. Thanks a lot for your work!
* [Heironimus](https://github.com/MHeironimus/ArduinoJoystickLibrary)
* [hoantv](https://github.com/hoantv/VNWheel)
* [YukMingLaw](https://github.com/YukMingLaw/ArduinoJoystickWithFFBLibrary) 
