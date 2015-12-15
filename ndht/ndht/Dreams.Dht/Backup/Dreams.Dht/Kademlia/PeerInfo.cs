using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Dreams.Kademlia
{
    [Serializable]
    public class PeerInfo
    {
        private PeerId id = new PeerId();
        private string name = string.Empty;
        private IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);
        private int rtt = -1;
        private DateTime lastSeen = DateTime.MinValue;
        private DateTime lastSend = DateTime.MinValue;

        public PeerId Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public IPEndPoint EndPoint
        {
            get { return endpoint; }
            set { endpoint = value; }
        }

        public DateTime LastSeen
        {
            get { return lastSeen; }
            set { lastSeen = value; }
        }

        public DateTime LastSend
        {
            get { return lastSend; }
            set { lastSend = value; }
        }

        public void Update(PeerInfo peer)
        {
            endpoint = peer.endpoint;
            rtt = peer.rtt;
            lastSeen = DateTime.Now;
        }

    }
}
