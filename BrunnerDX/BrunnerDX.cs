using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Net.Sockets;

using System.Diagnostics;

using MultimediaTimer;
using NLog;


namespace BrunnerDX
{
    class BrunnerDX
    {
        static public Version expectedArduinoSketchVersion = new Version(2, 0, 1);

        Version arduinoSketchVersion;
        Logger logger = LogManager.GetCurrentClassLogger();
        const int timerMs = 5; // 200 FPS

        public string cls2SimHost;
        public int cls2SimPort;
        public string arduinoPortName;
        public double forceMultiplier = 0.3;

        private int[] _position;
        private int[] _force;

        private bool _isArduinoConnected = false;
        private bool _isBrunnerConnected = false;
        private long _stopExecuting = 1;

        private int timeSinceLastPositionChange = 0;

        private object lockObject = new object();

        public BrunnerDX()
        {
            this.Reset();
        }

        public void Reset()
        {
            _position = new int[2] { 0, 0 };
            _force = new int[2] { 0, 0 };
        }

        public int[] position => _position;
        public int[] force => _force;
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
            MessageReceivedEventHandler handler = new MessageReceivedEventHandler(this.DataReceivedHandler);
            return new RobustSerial(arduinoPortName, handler);
        }

        private Cls2SimSocket connectBrunner(bool required)
        {
                try
                {
                    Cls2SimSocket sock = new Cls2SimSocket(cls2SimHost, cls2SimPort);
                    sock.Connect();
                    return sock;
                }
                catch (Exception ex)
                {
                    if (required)
                    {
                        logger.Error(ex, ex.Message);
                        throw;
                    }
                    else
                    {
                        logger.Warn($"Couldn't connect to Brunner CLS2Sim: {ex.Message}");
                        return null;
                    }
                }
        }

        private void Communicate(RobustSerial arduinoPort, Cls2SimSocket brunnerSocket)
        {
            bool lockTaken = false;
            Monitor.TryEnter(lockObject, TimeSpan.FromMilliseconds(1), ref lockTaken);
            try
            {
                if (lockTaken)
                {
                    timeSinceLastPositionChange += timerMs;

                    // wait for receiving new position
                    bool brunnerMoved = false;
                    if (brunnerSocket != null)
                    {
                        // Notice we change the order of Aileron,Elevator
                        ForceMessage forceMessage = new ForceMessage(
                            ArduinoForce2Brunner(force[1]), ArduinoForce2Brunner(force[0]));
                        PositionMessage positionMessage = brunnerSocket.SendForcesReadPosition(forceMessage);
                        int x = BrunnerPosition2Arduino(positionMessage.aileron);
                        int y = BrunnerPosition2Arduino(positionMessage.elevator);
                        if (x != position[0] || y != position[1])
                        {
                            brunnerMoved = true;
                            position[0] = x;
                            position[1] = y;
                        }
                    }

                    // send the current position to the Arduino
                    if (arduinoPort.semaphore >= 1 && (brunnerMoved || timeSinceLastPositionChange >= 20))
                    {
                        arduinoPort.WriteOrder(Order.POSITION);
                        arduinoPort.WriteInt16(this.position[0]);
                        arduinoPort.WriteInt16(this.position[1]);
                        timeSinceLastPositionChange = 0;
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
                    logger.Warn($"Arduino sketch version is too old. Please Upload the Arduino Firmware");
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
                var timer = new MultimediaTimer.Timer(timerMs);
                timer.Resolution = TimeSpan.FromMilliseconds(2);
                //do what you need with the serial port here
                try
                {
                    arduinoPort.WaitForConnection();
                    logger.Info("Checking Arduino Firmware version");
                    CheckArduinoSketchVersion(arduinoPort, maxSeconds:3);
                    _isArduinoConnected = true;
                    if (brunnerSocket != null)
                    {
                        _isBrunnerConnected = true;
                    }

                    timer.Elapsed += (o, e) => Communicate(arduinoPort, brunnerSocket);
                    timer.Start();

                    while (arduinoPort.IsOpen && !stopExecuting)
                    {
                        System.Threading.Thread.Sleep(500);
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
                    logger.Info($"Received log: {line}");
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