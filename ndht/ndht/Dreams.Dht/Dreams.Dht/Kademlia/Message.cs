using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Dreams.Kademlia
{
    [Serializable]
    public class Message
    {
        public enum MessageType
        {
            PingRequest,
            PingResponse,
            StoreRequest,
            StoreResponse,
            FindNodeRequest,
            FindNodeResponse,
            FindValueRequest,
            FindValueResponse
        }

        private PeerInfo peer = new PeerInfo();
        private MessageType type = MessageType.PingRequest;
        private int ttl = 10;
        private List<String> parameters = new List<String>();

        public MessageType Type 
        {
            get { return type; }
            set { type = value; }
        }

        public PeerInfo Peer
        {
            get { return peer; }
            set { peer = value; }
        }

        public List<String> Parameters
        {
            get { return parameters; }
        }

        public Message(MessageType type)
        {
            this.type = type;
        }

        public static Message CreatePingRequest(PeerInfo peer)
        {
            Message message = new Message(MessageType.PingRequest);
            return message;
        }
        public static Message CreatePingResponse(Message ping)
        {
            Message message = new Message(MessageType.PingResponse);
            return message;
        }

        public static Message CreateStoreRequest(string key, string val)
        {
            Message message = new Message(MessageType.StoreRequest);
            message.parameters.Add(key);
            message.parameters.Add(val);
            return message;
        }

        public static Message CreateFindValueRequest(string key)
        {
            Message message = new Message(MessageType.FindValueRequest);
            message.parameters.Add(key);
            return message;
        }

        public static Message CreateFindValueResponse(string key, string val)
        {
            Message message = new Message(MessageType.FindValueResponse);
            message.parameters.Add(key);
            message.parameters.Add(val);
            return message;
        }

        public static Message CreateFindNodeRequest(PeerId id)
        {
            Message message = new Message(MessageType.FindNodeRequest);
            message.parameters.Add(id.ToString());
            return message;
        }

        public static Message CreateFindNodeResponse(List<PeerInfo> peers)
        {
            Message message = new Message(MessageType.FindNodeResponse);
            foreach (PeerInfo peer in peers)
            {
                message.parameters.Add(peer.Id.ToString());
                message.parameters.Add(peer.EndPoint.Address.ToString());
                message.parameters.Add(peer.EndPoint.Port.ToString());
            }
            return message;
        }

        public void Serialize(Stream stream, bool read)
        {
            //[Version][Node-ID][Message-ID][Type][Ttl]
            byte[] buffer = new byte[4];
            if (read)
            {
                stream.Read(buffer, 0, 4);
                stream.Read(peer.Id.Buffer, 0, 20);
                stream.Read(buffer, 0, 4);
                stream.Read(buffer, 0, 4);
                stream.Read(buffer, 0, 4);
            }
            else
            {
                stream.Write(buffer, 0, 4);
                stream.Write(peer.Id.Buffer, 0, 20);
                stream.Write(buffer, 0, 4);
                stream.Write(buffer, 0, 4);
                stream.Write(buffer, 0, 4);
            }
        }
    }
}
