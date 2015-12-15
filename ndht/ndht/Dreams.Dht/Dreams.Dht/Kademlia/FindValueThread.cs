using System;
using System.Collections.Generic;
using System.Text;

namespace Dreams.Kademlia
{
    class FindValueThread : FindNodeThread
    {
        private string key;

        public FindValueThread(Client client, string key) : 
            base(client, PeerId.CalculateId(key))
        {
            this.key = key;
        }

        public override void ProcessMessage(Message message)
        {
            base.ProcessMessage(message);

            if (message.Type == Message.MessageType.FindValueResponse)
            {
                if (message.Parameters.Count >= 2)
                {
                    if (message.Parameters[0] == key)
                    {
                        Client.FireLookupResult(key, message.Parameters[1]);
                    }
                }
            }
        }

        protected override Message CreateFindRequest()
        {
            Message message = Message.CreateFindValueRequest(key);
            message.Peer.Id = Client.Me.Id;
            return message;
        }
    }
}
