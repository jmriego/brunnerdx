# BrunnerDX
## This folder is a method to run the program in Python instead of a .NET app

Install the [pyserial](https://pypi.org/project/pyserial/) library
Upload the sketch that you can build in [Fino](https://github.com/jmriego/Fino), run the `brunnerdx.py` file and enjoy!

# DISCLAIMER
Recommended to not use this Python script and instead just grab a [Release](https://github.com/jmriego/brunnerdx/releases) from this project page and install it somewhere in your computer.
The main issue is that Windows is not a real-time OS and it's not easy to run the calculations with enough frequency that the movement does not feel choppy with Python.

If you still want to go ahead...

# Instructions

These are more detailed steps, but it might be easier to just run the app:
1. Download the [Fino repo zip file](https://github.com/jmriego/Fino/archive/master.zip) file and save it somewhere in your hard drive (an option is clicking on Code->Download as ZIP and then unzipping it somewhere).
2. Install the [Arduino IDE](https://www.arduino.cc/en/software).
3. Open the Arduino IDE and open the Fino.ino file that it's in the folder you extracted on step 1.
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
