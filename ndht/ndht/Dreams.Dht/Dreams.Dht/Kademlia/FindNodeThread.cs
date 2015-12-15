using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Dreams.Kademlia
{
    public class FindNodeThread
    {
        public delegate void FinishHandler(FindNodeThread thread);
        public event FinishHandler Finish;
 
        private Client client;
        private PeerId keyId;
        private Thread thread;

        public Client Client
        {
            get { return client; }
        }

        public PeerId KeyId
        {
            get { return keyId; }
        }

        public FindNodeThread(Client client, PeerId keyId)
        {
            this.client = client;
            this.keyId = keyId;
        }

        public void Start()
        {
            thread = new Thread(Run);
            thread.Name = "FindNodeThread";
            thread.Start();
        }

        public void Abort()
        {
            thread.Abort();
        }

        public void Join()
        {
            thread.Join();
        }

        public virtual void ProcessMessage(Message message)
        {
            if (message.Type == Message.MessageType.FindNodeResponse)
            {
                int i = 0;
                while (i*3 < message.Parameters.Count)
                {
                    if (message.Parameters[i * 3] == KeyId.ToString())
                    {
                    }
                    i++;
                }
            }
        }

        protected virtual Message CreateFindRequest()
        {
            Message message = Message.CreateFindNodeRequest(KeyId);
            message.Peer.Id = Client.Me.Id;
            return message;
        }

        protected virtual void Run()
        {
            Message message = CreateFindRequest();

            DateTime lastSend = DateTime.Now;

            List<PeerInfo> peers = client.GetCloserPeers(KeyId, client.Alfa);
            lock (client)
            {
                foreach (PeerInfo peer in peers)
                {
                    lastSend = DateTime.Now;
                    Client.Send(message, peer);
                }
            }

            //WaitForNeearPeers
            while ((DateTime.Now - lastSend).TotalMilliseconds < 2*1000)
            {
                Thread.Sleep(10);
                List<PeerInfo> newPeers = client.GetCloserPeers(KeyId, client.Alfa);
                foreach (PeerInfo newPeer in newPeers)
                {
                    bool nearer = true;
                    foreach (PeerInfo oldPeer in peers)
                    {
                        if (PeerId.CalculateDistance(oldPeer.Id, KeyId) <= PeerId.CalculateDistance(newPeer.Id, KeyId))
                        {
                            nearer = false;
                        }
                    }
                    if (nearer)
                    {
                        lastSend = DateTime.Now;
                        peers.Add(newPeer);
                        Client.Send(message, newPeer);
                    }
                }
            }

            if (Finish != null)
            {
                Finish(this);
            }
        }
    }
}
