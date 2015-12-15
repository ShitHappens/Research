using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading;
using System.IO;

namespace Dreams.Kademlia
{
    public class Client : Dreams.Dht.Client
    {
        private int alfa = 10;
        private int k = 20;
        private PeerInfo me = new PeerInfo();
        private List<PeerInfo> bootstrapPeers = new List<PeerInfo>();
        private BucketList buckets;
        private Transport transport;
        private Dictionary<string, Storage> publications = new Dictionary<string, Storage>();
        private Dictionary<string, Storage> storages = new Dictionary<string, Storage>();
        private List<FindNodeThread> threads = new List<FindNodeThread>();
        private bool running = false;
        private Thread thread;
        public event LookupHandler Lookup;

        public int K
        {
            get { return k; }
            set { k = value; }
        }

        public int Alfa
        {
            get { return alfa; }
            set { alfa = value; }
        }

        public PeerInfo Me
        {
            get { return me; }
            set { me = value; }
        }

        public List<PeerInfo> BootstrapPeers
        {
            get { return bootstrapPeers; }
        }

        public Transport Transport
        {
            get { return transport; }
        }

        public Client()
        {
//            PeerInfo peer1 = new PeerInfo();
//            peer1.Id = PeerId.CalculateId("bootnode");
//            peer1.EndPoint = new IPEndPoint(IPAddress.Parse("192.168.1.34"), 4401);

//            bootstrapPeers.Add(peer1);

            buckets = new BucketList(this);
            transport = CreateTransport();
        }

        public override void Start()
        {
            transport.Message += new Transport.MessageHandler(transport_Message);
            if (me.EndPoint.Port == 0)
            {
                me.EndPoint.Port = 4401;
            }
            if (me.EndPoint.Address == IPAddress.Any)
            {
                me.EndPoint.Address = IPAddress.Loopback;
                //me.EndPoint.Address = IPAddress.Parse("192.168.1.34");// Dns.GetHostEntry("").AddressList[0];
            }
            int i = 0;
            while (i < 200)
            {
                try
                {
                    transport.Listen(me.EndPoint.Port);
                    break;
                }
                catch (Exception)
                {
                    me.EndPoint.Port ++;
                    i++;
                }
            }
            if (i == 200)
            {
                throw new Exception("");
            }

            //Serialize
            buckets.Load();

            UpdatePeer(Me);

            //Discover
            foreach (PeerInfo bootstrapPeer in bootstrapPeers)
            {
                Message ping = Message.CreatePingRequest(bootstrapPeer);
                Send(ping, bootstrapPeer);
            }

            running = true;
            thread = new Thread(Run);
            thread.Name = "ClientThread";
            thread.Start();
        }

        public override void Abort()
        {
            if (running)
            {
                running = false;
                thread.Join();
            }

            foreach (FindNodeThread thread in threads)
            {
                thread.Abort();
            }

            transport.Stop();

            //Serialize
            buckets.Store();
        }

        public override void Join()
        {
            //Serialize
        }

        public override void BeginStore(string key, string val)
        {
            lock (threads)
            {
                Storage storage = new Storage();
                storage.Key = key;
                storage.Val = val;
                storage.Expiration = DateTime.Now + new TimeSpan(0, 20, 0);
                publications[key] = storage;
                StoreThread thread = new StoreThread(this, key, val);
                thread.Finish += new FindNodeThread.FinishHandler(thread_Finish);
                threads.Add(thread);
                thread.Start();
            }
        }

        void thread_Finish(FindNodeThread thread)
        {
            lock (threads)
            {
                threads.Remove(thread);
            }
        }

        public override void BeginLookup(string key)
        {
            lock (threads)
            {
                FindValueThread thread = new FindValueThread(this, key);
                thread.Finish += new FindNodeThread.FinishHandler(thread_Finish);
                threads.Add(thread);
                thread.Start();
            }
        }

        public void FireLookupResult(string key, string val)
        {
            LookupHandler handler = Lookup;

            if (handler != null)
            {
                handler(key, val);
            }
        }

        public void Send(Message message, PeerInfo peer)
        {
            Debug.WriteLine("SendMessage " + message.Type + "("+peer.EndPoint.ToString()+")");

            lock (buckets)
            {
                PeerInfo bucketPeer = buckets.GetPeer(peer.Id);
                if (bucketPeer != null)
                {
                    bucketPeer.LastSend = DateTime.Now;
                }
            }

            message.Peer = Me;
            transport.Send(message, peer);
//            transport.Send(message, peer);
//            transport.Send(message, peer);
        }

        protected virtual Transport CreateTransport()
        {
            return new Transport();
        }

        void transport_Message(Transport transport, Message message)
        {
            Debug.WriteLine("ReceivedMessage " + message.Type + "(" + message.Peer.EndPoint.ToString() + ")");

            UpdatePeer(message.Peer);

            switch (message.Type)
            {
                case Message.MessageType.PingRequest:
                    ProcessPingRequest(message);
                    break;
                case Message.MessageType.FindNodeRequest:
                    ProcessFindNodeRequest(message);
                    break;
                case Message.MessageType.FindNodeResponse:
                    ProcessFindNodeResponse(message);
                    break;
                case Message.MessageType.FindValueRequest:
                    ProcessFindValueRequest(message);
                    break;
                case Message.MessageType.StoreRequest:
                    ProcessStoreRequest(message);
                    break;
            }

            lock (threads)
            {
                foreach(FindNodeThread thread in threads)
                {
                    thread.ProcessMessage(message);
                }
            }

        }

        void ProcessFindNodeRequest(Message message)
        {
            List<PeerInfo> peers = GetCloserPeers(PeerId.LoadFromString(message.Parameters[0]), k);
            Message response = Message.CreateFindNodeResponse(peers);
            Send(response, message.Peer);
        }

        void ProcessFindNodeResponse(Message message)
        {
            int i = 0;
            while (i * 3 + 2 < message.Parameters.Count)
            {
                PeerInfo peer = new PeerInfo();
                peer.Id = PeerId.LoadFromString(message.Parameters[i * 3] + 0);
                peer.EndPoint.Address = IPAddress.Parse(message.Parameters[i * 3 + 1]);
                peer.EndPoint.Port = Int32.Parse(message.Parameters[i * 3 + 2]);

                UpdatePeer(peer);
                //Message message = Message.CreatePingRequest(peer);
                //Send(message, peer);
                i++;
            }
        }

        void ProcessFindValueRequest(Message message)
        {
            string key = message.Parameters[0];
            Storage storage = null;
            lock (storages)
            {
                storages.TryGetValue(key, out storage);
            }
            if (storage != null)
            {
                Message response = Message.CreateFindValueResponse(key, storage.Val);
                Send(response, message.Peer);
            }
            else
            {
                List<PeerInfo> peers = GetCloserPeers(PeerId.CalculateId(message.Parameters[0]), k);
                Message response = Message.CreateFindNodeResponse(peers);
                Send(response, message.Peer);
            }
        }

        void ProcessStoreRequest(Message message)
        {
            Storage storage = new Storage();
            storage.Key = message.Parameters[0];
            storage.Val = message.Parameters[1];
            storage.Expiration = DateTime.Now + new TimeSpan(0, 20, 0);
            storages[message.Parameters[0]] = storage;
        }

        void ProcessPingRequest(Message message)
        {
            Message response = Message.CreatePingResponse(message);
            Send(response, message.Peer);
        }

        public List<PeerInfo> GetCloserPeers(PeerId id, int count)
        {
            List<PeerInfo> closerPeers = new List<PeerInfo>();
            lock (buckets)
            {
                foreach (PeerInfo peer in buckets)
                {
                    bool inserted = false;
                    int i;
                    for (i=0; i<closerPeers.Count; i++)
                    {
                        PeerInfo closerPeer = closerPeers[i];
                        if (PeerId.CalculateDistance(closerPeer.Id, id) > PeerId.CalculateDistance(peer.Id, id))
                        {
                            closerPeers.Insert(i, peer);
                            inserted = true;
                            break;
                        }
                    }
                    if (!inserted)
                    {
                        closerPeers.Add(peer);
                    }
                }
            }
            if (count < closerPeers.Count)
            {
                closerPeers.RemoveRange(count, closerPeers.Count - count);
            }
            return closerPeers;
        }

        public PeerInfo GetPeer(PeerId peerId)
        {
            lock (buckets)
            {
                return buckets.GetPeer(peerId);
            }
        }

        public void UpdatePeer(PeerInfo newPeer)
        {
            lock (buckets)
            {
                buckets.UpdatePeer(newPeer);
            }

            //TODO:Check storage for replication
            foreach (string key in storages.Keys)
            {
                PeerId keyId = PeerId.CalculateId(key);
                if (PeerId.CalculateDistance(Me.Id, keyId) > PeerId.CalculateDistance(newPeer.Id, keyId))
                {
                    Message message = Message.CreateStoreRequest(key, storages[key].Val);
                    Send(message, newPeer);
                }
            }
        }

        private void Run()
        {
            while (running)
            {
                //Ping all
                lock (buckets)
                {
                    foreach (PeerInfo peer in buckets)
                    {
                        if ((DateTime.Now - peer.LastSeen).TotalMilliseconds > 10 * 60 * 1000)
                        {
                            buckets.Remove(peer.Id);
                            break;
                        }
                    }

                    foreach (PeerInfo peer in buckets)
                    {
                        if ((DateTime.Now - peer.LastSend).TotalMilliseconds > 5 * 60 * 1000 ||
                            ((DateTime.Now - peer.LastSeen).TotalMilliseconds > 5 * 60 * 1000 && (DateTime.Now - peer.LastSend).TotalMilliseconds > 1 * 60 * 1000))
                        {
                            Message ping = Message.CreatePingRequest(peer);
                            Send(ping, peer);
                        }
                    }
                }

                lock(storages)
                {
                    foreach (Storage storage in storages.Values)
                    {
                        if (storage.Expiration < DateTime.Now)
                        {
                            storages.Remove(storage.Key);
                            break;
                        }
                    }
                }

                lock(publications)
                {
                    foreach (Storage storage in publications.Values)
                    {
                        if ((storage.Expiration - DateTime.Now).TotalMilliseconds < 10*60*1000)
                        {
                            BeginStore(storage.Key, storage.Val);
                            break;
                        }
                    }
                }

                Thread.Sleep(100);
            }
        }

        public string Dump()
        {
            string dump = string.Empty;

            lock (buckets)
            {
                dump = buckets.Dump();
            }

            foreach (Storage storage in storages.Values)
            {
                dump += "Storage " + storage.Key +" = "+storage.Val + "\r\n";
            }
            return dump;
        }
    }
}
