using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;

using NLog;


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

        public PositionMessage(UInt32 result, float elevator, float aileron, float rudder=0, float collective=0)
        {
            this.result = result;
            this.elevator = elevator;
            this.aileron = aileron;
            this.rudder = rudder;
            this.collective = collective;
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

                sock.Client.ReceiveTimeout = 50;
                sock.Client.SendTimeout = 50;
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

        static void ByteArrayToPositionMessage(byte[] bytearray, ref PositionMessage obj)
        {
            int len = Marshal.SizeOf(obj);
            IntPtr i = Marshal.AllocHGlobal(len);
            Marshal.Copy(bytearray, 0, i, len);
            obj = (PositionMessage)Marshal.PtrToStructure(i, obj.GetType());
            Marshal.FreeHGlobal(i);
        }

        public void Connect()
        {
            logger.Info($"Trying to connect to CLS2Sim in {ipAddress}:{port}");
            try
            {
                sock.Connect(ipAddress, port);
                SendForcesReadPosition(new ForceMessage(0, 0));
            }
            catch (Exception ex)
            {
                logger.Error($"Couldn't connect to Brunner CLS2Sim: {ex.Message}");
                throw;
            }
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
            ByteArrayToPositionMessage(bytes, ref position);

            return position;
        }
    }
}
