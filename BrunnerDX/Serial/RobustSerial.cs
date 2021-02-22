using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.IO.Ports;

using NLog;

namespace BrunnerDX
{
    public enum Order
    {
        HELLO = 0,
        ALREADY_CONNECTED = 1,
        RECEIVED = 2,
        FORCES = 3,
        POSITION = 4,
        ERROR = 5,
        LOG = 6,
        VERSION = 7
    };

    public delegate void MessageReceivedEventHandler(Order ord, RobustSerial port);

    public class RobustSerial : IDisposable
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        SerialPort arduinoPort;
        private bool _connected = false;
        private int _semaphore = 10;

        MessageReceivedEventHandler OnMessageReceived;

        public RobustSerial(string port, MessageReceivedEventHandler onMessageReceived)
        {
            arduinoPort = new SerialPort(port);
            arduinoPort.BaudRate = 115200;
            arduinoPort.ReadTimeout = 500;
            arduinoPort.WriteTimeout = 500;
            arduinoPort.Handshake = Handshake.None;
            arduinoPort.RtsEnable = true;
            //arduinoPort.DtrEnable = true;

            this.OnMessageReceived = onMessageReceived;
            arduinoPort.DataReceived += DataReceivedHandler;
        }

        public void Dispose()
        {
            arduinoPort.Dispose();
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            while (arduinoPort.BytesToRead > 0)
            {
                lock (arduinoPort)
                {
                    Order ord = ReadOrder();
                    //logger.Debug($"Received order {ord}");
                    switch (ord)
                    {
                        case Order.HELLO:
                        case Order.ALREADY_CONNECTED:
                            _connected = true;
                            break;
                        case Order.RECEIVED:
                            Interlocked.Increment(ref _semaphore);
                            break;
                        default:
                            try
                            {
                                this.OnMessageReceived(ord, this);
                            }
                            catch (Exception ex)
                            {
                                logger.Error(ex, ex.Message);
                            }
                            break;
                    }
                }
            }
        }

        public bool connected => _connected;
        public int semaphore => _semaphore;
        public bool IsOpen => arduinoPort.IsOpen;

        public void WaitForConnection()
        {
            lock (arduinoPort)
            {
                if (!arduinoPort.IsOpen)
                {
                    arduinoPort.Open();
                }

                logger.Info("Waiting for device...");
                while (_connected)
                {
                    WriteOrder(Order.HELLO);
                    System.Threading.Thread.Sleep(500);
                }
                logger.Info("Connected to device");
            }
        }

        public int ReadInt8()
        {
            return arduinoPort.ReadByte();
        }

        public int ReadInt32()
        {
            Byte[] b = new Byte[4];
            for (int i=0; i < b.Length; ++i)
            {
                b[i] = (byte)arduinoPort.ReadByte();
            }
            return BitConverter.ToInt32(b, 0);
        }

        public string ReadLine()
        {
            return arduinoPort.ReadLine();
        }

        public void WriteInt8(int i)
        {
            Byte[] b = BitConverter.GetBytes((Int16)i);
            arduinoPort.Write(b, 0, 1);
        }

        public void WriteInt16(int i)
        {
            Byte[] b = BitConverter.GetBytes((Int16)i);
            arduinoPort.Write(b, 0, 2);
        }

        public Order ReadOrder()
        {
            return (Order)ReadInt8();
        }

        public bool WriteOrder(Order ord)
        {
            if (_semaphore > 0)
            {
                WriteInt8((int)ord);
                Interlocked.Decrement(ref _semaphore);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
