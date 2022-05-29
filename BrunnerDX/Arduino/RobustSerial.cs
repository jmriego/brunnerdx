using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.IO.Ports;

using NLog;
using System.Diagnostics;

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
        VERSION = 7,
        CONFIG = 8
    };

    public delegate void MessageReceivedEventHandler(Order ord, RobustSerial port);

    public class RobustSerial : IDisposable
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        SerialPort arduinoPort;
        private bool _ready = false;
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
        }

        public void Dispose()
        {
            arduinoPort.DataReceived -= DataReceivedHandler;
            System.Threading.Thread.Sleep(500); // Give it time to process remaining messages
            arduinoPort.Dispose();
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                while (arduinoPort.BytesToRead > 0)
                {
                    Order ord = ReadOrder();
                    //logger.Debug($"Received order {ord}");
                    switch (ord)
                    {
                        case Order.HELLO:
                        case Order.ALREADY_CONNECTED:
                            _ready = true;
                            break;
                        case Order.RECEIVED:
                            Interlocked.Increment(ref _semaphore);
                            break;
                        default:
                            lock (arduinoPort)
                            {
                                this.OnMessageReceived(ord, this);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.StackTrace);
                logger.Error(ex, ex.Message);
            }
        }

        public bool ready => _ready; // This field indicates we have the COM port open and we have received a HELLO/ALREADY_CONNECTED from the Arduino
        public int semaphore => _semaphore; // How many orders we can send before a RECEIVED confirmation
        public bool IsOpen => arduinoPort.IsOpen;

        public void WaitForConnection(int timeout=1000)
        {
            var awaitingArduinoWatch = new Stopwatch();
            awaitingArduinoWatch.Start();
            while (!arduinoPort.IsOpen)
            {
                try
                {
                    arduinoPort.Open();
                }
                catch (Exception ex) when (ex is System.IO.IOException)
                {
                    if (awaitingArduinoWatch.ElapsedMilliseconds >= timeout) throw;
                    System.Threading.Thread.Sleep(1000);
                }
            }

            logger.Info("Waiting for device...");
            arduinoPort.DataReceived += DataReceivedHandler;
            while (!_ready) // Keep on sending HELLO until we receive a confirmation that will be read by DataReceivedHandler
            {
                WriteOrder(Order.HELLO);
                System.Threading.Thread.Sleep(500);
            }
            logger.Info("Connected to device");
        }

        public void Close()
        {
            lock (arduinoPort)
            {
                _ready = false;
                arduinoPort.Close();
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
