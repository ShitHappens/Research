using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Dreams.Kademlia
{
    public class StoreThread : FindNodeThread
    {
        private string val;
        private string key;

        public StoreThread(Client client, string key, string val) :
            base(client, PeerId.CalculateId(key))
        {
            this.key = key;
            this.val = val;
        }

        protected override void Run()
        {
            base.Run();

            List<PeerInfo> peers = Client.GetCloserPeers(KeyId, 2);

            foreach(PeerInfo peer in peers)
            {
                Message message = Message.CreateStoreRequest(key, val);
                Client.Send(message, peer);
            }
        }
    }
}
