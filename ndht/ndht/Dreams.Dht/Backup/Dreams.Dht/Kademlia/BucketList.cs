using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Xml;

namespace Dreams.Kademlia
{
    public class BucketList : IEnumerable<PeerInfo>
    {
        Client client;

        private Bucket[] buckets = new Bucket[160];

        public BucketList(Client client)
        {
            this.client = client;
            int i;
            for (i = 0; i < 160; i++)
            {
                buckets[i] = new Bucket();
            }
        }

        public void Load()
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load("kad.xml");
                foreach (XmlElement element in document.DocumentElement.ChildNodes)
                {
                    PeerInfo peer = new PeerInfo();
                    peer.Id = PeerId.LoadFromString(element.GetAttribute("id"));
                    string strAddress = element.GetAttribute("address");
                    IPAddress address = IPAddress.Parse(strAddress);
                    string strPort = element.GetAttribute("port");
                    int port = 4401;
                    Int32.TryParse(strPort, out port);
                    peer.EndPoint = new IPEndPoint(address, port);
                    UpdatePeer(peer);
                }
            }
            catch(FileNotFoundException)
            {
            }
        }

        public void Store()
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml("<peers></peers>");
            foreach (PeerInfo peer in this)
            {
                XmlElement element = document.CreateElement("peer");
                element.SetAttribute("id", peer.Id.ToString());
                element.SetAttribute("address", peer.EndPoint.Address.ToString());
                element.SetAttribute("port", peer.EndPoint.Port.ToString());
                document.DocumentElement.AppendChild(element);
            }
            using (XmlWriter writer = new XmlTextWriter("kad.xml", Encoding.UTF8))
            {
                document.Save(writer);
            }
        }

        public PeerInfo GetPeer(PeerId peerId)
        {
            foreach (PeerInfo peer in this)
            {
                if (peer.Id == peerId)
                {
                    return peer;
                }
            }

            return null;
        }

        public void UpdatePeer(PeerInfo newPeer)
        {
            PeerId distance = PeerId.CalculateDistance(client.Me.Id, newPeer.Id);

            foreach (Bucket bucket in buckets)
            {
                foreach (PeerInfo peer in bucket)
                {
                    if (peer.Id == newPeer.Id)
                    {
                        Debug.WriteLine("Updating peer " + peer.Id);
                        peer.Update(newPeer);
                        bucket.Remove(peer);
                        bucket.Insert(0, peer);
                        return;
                    }
                }
            }

            Debug.WriteLine("Adding peer " + newPeer.Id);
            int index = distance.GetBucketIndex();
            newPeer.LastSeen = DateTime.Now;
            
            if (buckets[index].Count < client.K)
            {
                buckets[index].Add(newPeer);
            }
        }

        public void Remove(PeerId id)
        {
            foreach (Bucket bucket in buckets)
            {
                foreach (PeerInfo peer in bucket)
                {
                    if (peer.Id == id)
                    {
                        bucket.Remove(peer);
                        return;
                    }
                }
            }
        }

        #region IEnumerable<Bucket> Members

        public IEnumerator<PeerInfo> GetEnumerator()
        {
            foreach (Bucket bucket in buckets)
            {
                foreach (PeerInfo peer in bucket)
                {
                    yield return peer;
                }
            }
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        public string Dump()
        {
            string dump = string.Empty;
            int i = 0;
            foreach (Bucket bucket in buckets)
            {
                dump += "Bucket " + (i++) + "\r\n";
                foreach (PeerInfo peer in bucket)
                {
                    dump += "\tPeer " + peer.Id.ToString() + " (" + peer.LastSeen + ")" + "\r\n";
                }
            }
            return dump;
        }
    }
}
