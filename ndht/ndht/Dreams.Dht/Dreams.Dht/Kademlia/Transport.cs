using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dreams.Kademlia
{
    public class Transport
    {
        public delegate void MessageHandler(Transport transport, Message message);
        public event MessageHandler Message;

        private UdpClient udp;
        private Thread th;

        public void Listen(int port)
        {
            udp = new UdpClient(port);
            th = new Thread(Run);
            th.Name = "TransportThread";
            th.Start();
        }

        public void Stop()
        {
            if (udp != null)
            {
                udp.Close();
                th.Abort();
                th.Join();
            }
        }

        public void Send(Message message, PeerInfo peer)
        {
            MemoryStream stream = new MemoryStream();
            using(stream)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, message);
                stream.Flush();
                udp.Send(stream.GetBuffer(), (int)stream.Position, peer.EndPoint);
            }
        }

        private void Run()
        {
            try
            {
                while (true)
                {
                    IPEndPoint remoteEP = null;
                    byte[] buffer = udp.Receive(ref remoteEP);

                    MemoryStream stream = new MemoryStream(buffer);
                    using (stream)
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        Message message = (Message)formatter.Deserialize(stream);
                        message.Peer.EndPoint = remoteEP;

                        if (Message != null)
                        {
                            Message(this, message);
                        }
                    }
                }
            }
            catch (SocketException)
            {
            }
            catch (ThreadAbortException)
            {
            }
        }
    }
}
