using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Net.Sockets;

using System.Diagnostics;

using HighPrecisionTimer;
using NLog;


namespace BrunnerDX
{
    class BrunnerDX
    {
        static public Version expectedArduinoSketchVersion = new Version(3, 0, 0);

        Version arduinoSketchVersion;
        Logger logger = LogManager.GetCurrentClassLogger();
        const int timerMs = 2; // 500 FPS
        const int forcedArduinoCalculation = 29; // even if not receiving a new position in 29ms we will calculate velocity, etc.
        const int minimumTimeBetweenCalculations = 12; // if we receive consecutive position changes in less than this time we'll wait before calculating

        public string cls2SimHost;
        public int cls2SimPort;
        public string arduinoPortName;
        public double forceMultiplier = 0.3;
        public int delaySeconds;

        private int[] _position;
        private Queue<int[]> positionHistory = new Queue<int[]>();
        private int[] _force;
        private bool[] axisHasMoved = new bool[] { false, false };
        private bool _defaultSpring = false;

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
            _position = new int[2] { 0, 0 };
            _force = new int[2] { 0, 0 };
            positionHistory.Enqueue(_position);
        }

        public int[] position {
            get
            {
                if (delaySeconds == 0)
                { 
                    return _position;
                }
                else
                {
                    int delayPosition = 60 - delaySeconds * 10;
                    var history = this.positionHistory.ToArray();
                    if (delayPosition < positionHistory.Count)
                    {
                        return history[delayPosition];
                    }
                    else
                    {
                        return history[positionHistory.Count - 1];
                    }
                }
            }
        }

        public int[] force => _force;
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
            return (int)((p - 0.5) * 2 * 32767 * -1);
        }

        public int ArduinoForce2Brunner(int f)
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

        private bool waitForBrunner(Cls2SimSocket sock, int timeout=1)
        {
            return sock.WaitForResponse(timeout);
        }

        private void UpdatePosition(PositionMessage positionMessage)
        {
            int x = BrunnerPosition2Arduino(positionMessage.aileron);
            int y = BrunnerPosition2Arduino(positionMessage.elevator);
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
                            ArduinoForce2Brunner(force[1]), ArduinoForce2Brunner(force[0]));
                        if (delaySeconds > 0)
                        {
                            forceMessage.aileron = 0;
                            forceMessage.elevator = 0;
                        }
                        PositionMessage positionMessage = brunnerSocket.SendForcesReadPosition(forceMessage);
                        UpdatePosition(positionMessage);
                    }

                    // send the current position to the Arduino
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

                    while (arduinoPort.IsOpen && !stopExecuting)
                    {
                        if (!_isBrunnerConnected && awaitingBrunnerWatch.IsRunning)
                        {
                            _isBrunnerConnected = waitForBrunner(brunnerSocket, timeout: 1);
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

                        var currentPosition = new int[2];
                        _position.CopyTo(currentPosition, 0);
                        positionHistory.Enqueue(currentPosition);
                        var prueba = positionHistory.ToArray();
                        if (positionHistory.Count > 60)
                        {
                            positionHistory.Dequeue();
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
                    force[0] = arduinoPort.ReadInt32();
                    force[1] = arduinoPort.ReadInt32();
                    break;

                default:
                    break;
            }
        }

    }
}
