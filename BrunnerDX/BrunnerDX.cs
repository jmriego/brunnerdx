using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Net.Sockets;

using System.Diagnostics;

using HighPrecisionTimer;
using NLog;

using BrunnerDX.Helpers;
using BrunnerDX.Mapping;

namespace BrunnerDX
{
    class BrunnerDX
    {
        static public Version expectedArduinoSketchVersion = new Version(3, 0, 1);

        Version arduinoSketchVersion;
        Logger logger = LogManager.GetCurrentClassLogger();
        const int timerMs = 2; // 500 FPS
        const int forcedArduinoCalculation = 29; // even if not receiving a new position in 29ms we will calculate velocity, etc.
        const int minimumTimeBetweenCalculations = 12; // if we receive consecutive position changes in less than this time we'll wait before calculating

        public string cls2SimHost;
        public int cls2SimPort;
        public string arduinoPortName;
        public int delaySeconds;
        public Ratio forceMultiplier = 0.3;

        // Trim variables
        public Ratio trimForceMultiplierXY = 0.0;
        public Ratio trimForceMultiplierZ = 0.0;
        public PositionValue[] trimPosition;
        public ForceValue[] trimForces;

        // Position variables
        private PositionValue[] _position;
        private Queue<PositionValue[]> positionHistory = new Queue<PositionValue[]>();
        private ForceValue[] _force;
        private bool[] axisHasMoved = new bool[] { false, false };
        private bool _defaultSpring = false;

        // Buttons variables
        public bool[] buttons = new bool[64];
        public Dictionary<String, int> mapping = ButtonMapping.GenerateMapping();

        private bool _isArduinoConnected = false;
        private bool _isBrunnerConnected = false;
        private bool _requiresSendingConfig = false;
        private long _stopExecuting = 1;

        private int ticksToNextPositionChange = 0;

        private object lockObject = new object();

        public BrunnerDX()
        {
            this.Reset();
        }

        public void Reset()
        {
            _position = new PositionValue[3] { 0, 0, 0 };
            trimPosition = new PositionValue[3] { 0, 0, 0 };
            trimForces = new ForceValue[3] { 0, 0, 0 };
            _force = new ForceValue[3] { 0, 0, 0 };
            positionHistory.Enqueue(_position);

            buttons = new bool[64];
            for (int i = 0; i < 64; i++)
            {
                buttons[i] = false;
            }
        }

        public PositionValue[] position {
            get
            {
                if (delaySeconds == 0)
                {
                    return _position;
                }
                else
                {
                    int delayPosition = positionHistory.Count - delaySeconds * 500; // the most recent position is at the "Count" position in the Queue
                    var history = this.positionHistory.ToArray();
                    return history[delayPosition >= 0 ? delayPosition : 0];
                }
            }
        }

        public ForceValue[] force
        {
            get
            {
                return new ForceValue[3] { this._force[0] + this.trimForces[0], this._force[1] + this.trimForces[1], this.trimForces[2] };
            }
        }

        public bool defaultSpring
        {
            get
            {
                return this._defaultSpring;
            }
            set
            {
                this._defaultSpring = value;
                this._requiresSendingConfig = true;
            }
        }
        public bool isArduinoConnected => _isArduinoConnected;
        public bool isBrunnerConnected => _isBrunnerConnected;
        public bool stopExecuting
        {
            get
            {
                return Interlocked.Read(ref _stopExecuting) == 1;
            }
            set
            {
                Interlocked.Exchange(ref _stopExecuting, Convert.ToInt64(value));
            }
        }

        static public int BrunnerPosition2Arduino(float p)
        {
            PositionValue pos = new PositionValue();
            // Brunner returns an inverted value between 0.0 to 1.0 but PositionValue expects the range -1.0 to 1.0
            double ratio = (1.0 - p - 0.5) * 2.0;
            pos.ratio = ratio;
            return pos;
        }

        public int ArduinoForce2Brunner(ForceValue f)
        {
            return (int)(f * forceMultiplier);
        }

        private RobustSerial connectArduino()
        {
            this._isArduinoConnected = false;
            MessageReceivedEventHandler handler = new MessageReceivedEventHandler(this.DataReceivedHandler);
            var serial = new RobustSerial(arduinoPortName, handler);
            this._isArduinoConnected = true;
            return serial;
        }

        private Cls2SimSocket connectBrunner(bool required)
        {
            Cls2SimSocket sock = new Cls2SimSocket(cls2SimHost, cls2SimPort);
            return sock;
        }

        private ForceValue calculateSpring(PositionValue pos, PositionValue trimPos)
        {
            double normalizedPos = pos.ratio;
            double normalizedTrimPos = trimPos.ratio;

            ForceValue springForce = new ForceValue();
            springForce.ratio = normalizedTrimPos - normalizedPos;
            return springForce;
        }

        private bool IsButtonPressed(int b)
        {
            if (b >= 0 && b < this.buttons.Length)
            {
                return this.buttons[b];
            }
            return false;
        }

        private void UpdatePosition(PositionMessage positionMessage)
        {
            PositionValue x = BrunnerPosition2Arduino(positionMessage.aileron);
            PositionValue y = BrunnerPosition2Arduino(positionMessage.elevator);
            PositionValue z = BrunnerPosition2Arduino(positionMessage.rudder);

            // calculate trim
            trimForces[0] = calculateSpring(x, trimPosition[0]) * this.trimForceMultiplierXY;
            trimForces[1] = calculateSpring(y, trimPosition[1]) * this.trimForceMultiplierXY;
            trimForces[2] = calculateSpring(z, trimPosition[2]) * this.trimForceMultiplierZ;

            var currentPosition = new PositionValue[3] {x, y, z};
            positionHistory.Enqueue(currentPosition);
            if (positionHistory.Count > 10 * (1000 / timerMs) ) // only keep the last 10 seconds of positions
            {
                positionHistory.Dequeue();
            }

            // positions
            if (x != _position[0])
            {
                _position[0] = x;
                axisHasMoved[0] = true;
            }
            if (y != _position[1])
            {
                _position[1] = y;
                axisHasMoved[1] = true;
            }

            if (ticksToNextPositionChange < ((forcedArduinoCalculation - minimumTimeBetweenCalculations)/timerMs))
            {
                // if both axes have moved and at least minimumTimeBetweenCalculations has passed
                if (axisHasMoved[0] && axisHasMoved[1])
                {
                    Interlocked.Exchange(ref ticksToNextPositionChange, 0);
                }
                // If only one of the two axes has moved, we might want to wait up to 10ms to see if we get an update for the other
                // some times we get an update for only one of the two axes
                else if (axisHasMoved[0] || axisHasMoved[1])
                {
                    Interlocked.Exchange(ref ticksToNextPositionChange, Math.Min((9 / timerMs) + 1, ticksToNextPositionChange));
                }
            }
        }

        private void UpdateTrimPosition()
        {
            int step = 10;
            if (IsButtonPressed(this.mapping["DecTrimX"])) trimPosition[0] = trimPosition[0] - step;
            if (IsButtonPressed(this.mapping["IncTrimX"])) trimPosition[0] = trimPosition[0] + step;
            if (IsButtonPressed(this.mapping["DecTrimY"])) trimPosition[1] = trimPosition[1] - step;
            if (IsButtonPressed(this.mapping["IncTrimY"])) trimPosition[1] = trimPosition[1] + step;
            if (IsButtonPressed(this.mapping["ReleaseTrim"]))
            {
                trimPosition[0] = _position[0];
                trimPosition[1] = _position[1];
            }
            else if (IsButtonPressed(this.mapping["CenterTrim"]))
            {
                trimPosition[0] = 0;
                trimPosition[1] = 0;
            }
        }

        private void SaveButtonPresses(bool[] buttons)
        {
            this.buttons = buttons;
        }

        private void Communicate(RobustSerial arduinoPort, Cls2SimSocket brunnerSocket)
        {
            bool lockTaken = false;
            Interlocked.Decrement(ref ticksToNextPositionChange);
            Monitor.TryEnter(lockObject, TimeSpan.FromMilliseconds(1), ref lockTaken);
            try
            {
                if (lockTaken && !this._requiresSendingConfig && !stopExecuting)
                {
                    // wait for receiving new position
                    if (_isBrunnerConnected)
                    {
                        // Notice we change the order of Aileron,Elevator
                        ForceMessage forceMessage = new ForceMessage(
                            ArduinoForce2Brunner(force[1]),
                            ArduinoForce2Brunner(force[0]),
                            ArduinoForce2Brunner(force[2])
                            );
                        if (delaySeconds > 0)
                        {
                            forceMessage.aileron = 0;
                            forceMessage.elevator = 0;
                        }
                        PositionMessage positionMessage = brunnerSocket.SendForcesReadPosition(forceMessage);
                        UpdatePosition(positionMessage);

                        ButtonReplyMessage buttonReplyMessage = brunnerSocket.GetButtonsPressed();
                        SaveButtonPresses(buttonReplyMessage.buttons);

                        UpdateTrimPosition();
                    }

                    // send the current position to the Arduino
                    if (arduinoPort.ready)
                    {
                        if (arduinoPort.semaphore >= 1 && ticksToNextPositionChange <= 0)
                        {
                            arduinoPort.WriteOrder(Order.POSITION);
                            arduinoPort.WriteInt16(this.position[0]);
                            arduinoPort.WriteInt16(this.position[1]);
                            Interlocked.Exchange(ref ticksToNextPositionChange, (forcedArduinoCalculation / timerMs) + 1);
                            axisHasMoved[0] = false;
                            axisHasMoved[1] = false;
                        }

                        if (arduinoPort.semaphore >= 1)
                        {
                            arduinoPort.WriteOrder(Order.FORCES);
                        }
                    }
                }
            }
            catch (Exception ex) when (ex is System.IO.IOException)
            {
                logger.Error(ex, ex.StackTrace);
                logger.Error(ex, ex.Message);
                _isArduinoConnected = false;
                arduinoPort.Close();
                logger.Warn("Arduino disconnected. Trying to reconnect...");
                arduinoPort.WaitForConnection(timeout: 5000);
                _isArduinoConnected = true;
            }
            catch (Exception ex) when (ex is System.Net.Sockets.SocketException)
            {
                logger.Error(ex, ex.StackTrace);
                logger.Error(ex, ex.Message);
                _isBrunnerConnected = false;
                logger.Warn("CLS2Sim disconnected. Trying to reconnect...");
                _isBrunnerConnected = brunnerSocket.WaitForResponse(60);
                if (!isBrunnerConnected) throw;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.StackTrace);
                logger.Error(ex, ex.Message);
                stopExecuting = true;
            }
        }

        private void SendArduinoConfig(RobustSerial arduinoPort)
        {
            logger.Debug("Sending the new config to the Arduino");
            try
            {
                arduinoPort.WriteOrder(Order.CONFIG);
                arduinoPort.WriteInt8(this._defaultSpring ? 100 : 0);
            }
            catch (Exception ex)
            {
            }
        }

        private void CheckArduinoSketchVersion(RobustSerial arduinoPort, int maxSeconds = 1)
        {
            arduinoSketchVersion = null;
            try
            {
                arduinoPort.WriteOrder(Order.VERSION);
            }
            catch (Exception ex)
            {
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            while (arduinoSketchVersion == null && stopwatch.ElapsedMilliseconds < maxSeconds * 1000)
            {
                System.Threading.Thread.Sleep(100);
            }
            if (arduinoSketchVersion == null)
            {
                logger.Error("Not possible to detect the Arduino Sketch version. Check the correct port or Upload the Arduino Firmware");
                throw new Exception("Arduino Joystick not detected");
            }

            logger.Info($"Arduino sketch version is v{arduinoSketchVersion}");
            switch (arduinoSketchVersion.CompareTo(expectedArduinoSketchVersion))
            {
                case -1:
                    logger.Warn($"Arduino sketch version is too old. Please click on Upload Firmware to update it");
                    break;
                case 1:
                    logger.Warn($"This program doesn't seem to be the last version. Please download the most recent one");
                    break;
            }
        }

        public void loop()
        {
            stopExecuting = false;
            using (RobustSerial arduinoPort = connectArduino())
            using (Cls2SimSocket brunnerSocket = connectBrunner(required: false))
            {
                var timer = new HighPrecisionTimer.MultimediaTimer();
                timer.Interval = timerMs;
                timer.Resolution = 2;
                //do what you need with the serial port here
                try
                {
                    arduinoPort.WaitForConnection();
                    logger.Info("Checking Arduino Firmware version");
                    CheckArduinoSketchVersion(arduinoPort, maxSeconds:3);
                    this._requiresSendingConfig = true;

                    timer.Elapsed += (o, e) => Communicate(arduinoPort, brunnerSocket);
                    timer.Start();

                    logger.Info("Waiting for connection to CLS2Sim...");
                    int secondsWaitBrunner = 60;
                    var awaitingBrunnerWatch = new Stopwatch();
                    awaitingBrunnerWatch.Start();

                    while (!stopExecuting)
                    {
                        if (!_isBrunnerConnected && awaitingBrunnerWatch.IsRunning)
                        {
                            _isBrunnerConnected = brunnerSocket.WaitForResponse(1);
                            if (_isBrunnerConnected) // We just connected so show a confirmation message
                            {
                                logger.Info("Connected to CLS2SIM");
                            }
                            if (awaitingBrunnerWatch.ElapsedMilliseconds > secondsWaitBrunner * 1000)
                            {
                                awaitingBrunnerWatch.Stop();
                                logger.Warn($"Was not able to connect to CLS2Sim after {secondsWaitBrunner} seconds");
                            }
                        }

                        if (this._requiresSendingConfig) {
                            SendArduinoConfig(arduinoPort);
                            this._requiresSendingConfig = false;
                        }

                        System.Threading.Thread.Sleep(100);
                    }
                    timer.Stop();
                    System.Threading.Thread.Sleep(500); // Give it time to the timer events to finish

                }
                catch (Exception ex)
                {
                    logger.Error(ex, ex.StackTrace);
                    logger.Error(ex, ex.Message);
                }
                finally
                {
                    _isArduinoConnected = false;
                    _isBrunnerConnected = false;
                    if (timer.IsRunning)
                    {
                        timer.Stop();
                    }
                }
            }
        }

        public void DataReceivedHandler(Order ord, RobustSerial arduinoPort)
        {

            switch (ord)
            {
                case Order.LOG:
                    string line = arduinoPort.ReadLine();
                    logger.Debug($"Received log: {line}");
                    break;

                case Order.VERSION:
                    string arduinoSketchVersionRaw = arduinoPort.ReadInt32().ToString();
                    int len = arduinoSketchVersionRaw.Length;
                    if (len < 7)
                    {
                        arduinoSketchVersionRaw = arduinoSketchVersionRaw.PadRight(7, '0');
                        len = 7;
                    };
                    int major = int.Parse(arduinoSketchVersionRaw.Substring(0, len - 6));
                    int minor = int.Parse(arduinoSketchVersionRaw.Substring(len - 6, 3));
                    int revision = int.Parse(arduinoSketchVersionRaw.Substring(len - 3, 3));
                    arduinoSketchVersion = new Version(major, minor, revision);
                    break;

                case Order.FORCES:
                    this._force[0] = arduinoPort.ReadInt32();
                    this._force[1] = arduinoPort.ReadInt32();
                    break;

                default:
                    break;
            }
        }

    }
}
