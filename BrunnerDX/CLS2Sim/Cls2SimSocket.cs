using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;

using NLog;
using System.Threading;
using System.IO;

namespace BrunnerDX
{
    public struct ForceMessage
    {
        UInt32 message;
        public Int32 elevator;
        public Int32 aileron;
        public Int32 rudder;
        public Int32 collective;

        public ForceMessage(int elevator, int aileron, int rudder=0, int collective=0)
        {
            this.message = 0xAF;
            this.elevator = elevator;
            this.aileron = aileron;
            this.rudder = rudder;
            this.collective = collective;
        }
    }

    public struct PositionMessage
    {
        public UInt32 result;
        public float elevator;
        public float aileron;
        public float rudder;
        public float collective;

        public PositionMessage(UInt32 result, float elevator, float aileron, float rudder = 0, float collective = 0)
        {
            this.result = result;
            this.elevator = elevator;
            this.aileron = aileron;
            this.rudder = rudder;
            this.collective = collective;
        }
    }

    public struct ProfileSetMessage
    {
        Int32 command;
        Int32 profileCommand;
        byte profileNameLength;
        public char[] profileName;

        public ProfileSetMessage(char[] profileName)
        {
            this.command = 0xCF;
            this.profileCommand = 0x01;
            this.profileNameLength = (byte)profileName.Length;
            this.profileName = profileName;
        }
    }
    public struct ReadRequestMessage
    {
        UInt32 command;
        UInt32 axis;
        UInt32 dataId;

        public ReadRequestMessage(UInt32 axis, UInt32 dataId)
        {
            this.command = 0xD0;
            this.axis = axis;
            this.dataId = dataId;
        }
    }

    public struct ButtonReplyMessage
    {
        public UInt16 length;
        public byte status;
        public UInt16 deviceId;
        public UInt16 dataId;
        public bool[] buttons;

        public ButtonReplyMessage(UInt16 length, byte status, UInt16 deviceId, UInt16 dataId, bool[] buttons)
        {
            this.length = length;
            this.status = status;
            this.deviceId = deviceId;
            this.dataId = dataId;
            this.buttons = buttons;
        }

        public static ButtonReplyMessage FromArray(byte[] bytes)
        {
            var reader = new BinaryReader(new MemoryStream(bytes));
            var s = default(ButtonReplyMessage);

            s.length = reader.ReadUInt16(); // length of the rest of the message
            s.status = reader.ReadByte();
            s.deviceId = reader.ReadUInt16();
            s.dataId = reader.ReadUInt16();

            int numBytesButtons = s.length - 5; // we have used 5 bytes for reading status, deviceId, dataId
            s.buttons = new bool[numBytesButtons * 8];
            for (int b = 0; b < numBytesButtons; b++ )
            {
                byte buttonGroup = reader.ReadByte();
                for (int i = 0; i < 8; i++)
                {
                    s.buttons[b*8 + i] = (buttonGroup & (1 << i)) == 0 ? false : true;
                }
            }

            return s;
        }
    }

    public class Cls2SimSocket : IDisposable
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        IPAddress ipAddress;
        int port;

        IPEndPoint remoteEP;
        UdpClient sock;

        public Cls2SimSocket(string host, int port)
        {
            try
            {
                this.ipAddress = IPAddress.Parse(host);
                this.port = port;


                remoteEP = new IPEndPoint(ipAddress, port);
                sock = new UdpClient();
                sock.Connect(ipAddress, port);

                sock.Client.ReceiveTimeout = 500;
                sock.Client.SendTimeout = 500;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            sock.Close();
            sock.Dispose();
        }

        static byte[] StructureToByteArray(object obj)
        {
            int len = Marshal.SizeOf(obj);
            byte[] arr = new byte[len];
            IntPtr ptr = Marshal.AllocHGlobal(len);
            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, arr, 0, len);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        static void ByteArrayToMessage<T>(byte[] bytearray, ref T obj) {
            int len = Marshal.SizeOf(obj);
            IntPtr i = Marshal.AllocHGlobal(len);
            Marshal.Copy(bytearray, 0, i, len);
            obj = (T)Marshal.PtrToStructure(i, obj.GetType());
            Marshal.FreeHGlobal(i);
        }

        public bool WaitForResponse(int timeout=5)
        {
            while (timeout > 0)
            {
                try
                {
                    SendForcesReadPosition(new ForceMessage(0, 0));
                    return true;
                }
                catch (Exception ex)
                {
                    --timeout;
                }
                Thread.Sleep(1000);
            }
            return false;
        }

        public PositionMessage SendForcesReadPosition(ForceMessage forces)
        {
            SendForces(forces);
            return ReadPosition();
        }

        public int SendForces(ForceMessage forces)
        {
            byte[] msg = StructureToByteArray(forces);
            int bytesSent = sock.Send(msg, msg.Length);
            return bytesSent;
        }

        public PositionMessage ReadPosition()
        {
            PositionMessage position = new PositionMessage();
            int len = Marshal.SizeOf(position);
            byte[] bytes = sock.Receive(ref remoteEP);
            ByteArrayToMessage<PositionMessage>(bytes, ref position);
            return position;
        }

        public ButtonReplyMessage GetButtonsPressed()
        {
            ReadRequestMessage request = new ReadRequestMessage(0x01, 0x31);

            byte[] msg = StructureToByteArray(request);
            int bytesSent = sock.Send(msg, msg.Length);

            byte[] bytes = sock.Receive(ref remoteEP);
            return ButtonReplyMessage.FromArray(bytes);
        }
    }
}
