using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Dreams.Dht.Util;

namespace Dreams.Kademlia
{
    [Serializable]
    public class PeerId
    {
        private byte[] buffer = new byte[20];

        public byte[] Buffer
        {
            get { return buffer; }
            set { buffer = value; }
        }

        public PeerId()
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
			rng.GetBytes(buffer);
        }

        public int GetBucketIndex()
        {
            int i;
            for (i = 159; i >= 0; i--)
            {
                if (IsBit(i))
                {
                    return i;
                }
            }
            return 0;
        }

        public bool IsBit(int index)
        {
            int byteIndex = index / 8;
            int bitIndex = index % 8;
            byte mask = (byte)(0x01 << bitIndex);

            return (buffer[19-byteIndex] & mask) != 0;
        }

        public void SetByte(int index, byte val)
        {
            buffer[19 - index] = val;
        }

        public static bool operator ==(PeerId id1, PeerId id2)
        {
            return id1.ToString() == id2.ToString();
        }

        public static bool operator !=(PeerId id1, PeerId id2)
        {
            return id1.buffer != id2.buffer;
        }

        public static bool operator >(PeerId id1, PeerId id2)
        {
            int i;
            for (i = 0; i < 160; i++)
            {
                if (id1.IsBit(160 - 1 - i) && !id2.IsBit(160 - 1 - i))
                {
                    return true;
                }
                if (!id1.IsBit(160 - 1 - i) && id2.IsBit(160 - 1 - i))
                {
                    return false;
                }
            }
            return false;
        }

        public static bool operator <(PeerId id1, PeerId id2)
        {
            int i;
            for (i = 0; i < 160; i++)
            {
                if (id2.IsBit(160 - 1 - i) && !id1.IsBit(160 - 1 - i))
                {
                    return true;
                }
                if (!id2.IsBit(160 - 1 - i) && id1.IsBit(160 - 1 - i))
                {
                    return false;
                }
            }
            return false;
        }

        public static bool operator >=(PeerId id1, PeerId id2)
        {
            return id1 == id2 || id1 > id2;
        }

        public static bool operator <=(PeerId id1, PeerId id2)
        {
            return id1 == id2 || id1 < id2;
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }

        public override int  GetHashCode()
        {
 	         return buffer.GetHashCode();
        }

        public override string ToString()
        {
            return HexEncoding.ToString(buffer);
        }

        public static PeerId CalculateDistance(PeerId id1, PeerId id2)
        {
            PeerId id = new PeerId();
            int i;
            for (i = 0; i < 20; i++)
            {
                id.buffer[i] = (byte)(id1.buffer[i] ^ id2.buffer[i]);
            }
            return id;
        }

        public static PeerId CalculateId(string key)
        {
            PeerId id = new PeerId();
            SHA1 sha1 = SHA1.Create();
            byte[] input = System.Text.Encoding.ASCII.GetBytes(key);
            id.Buffer = sha1.ComputeHash(input);            
            return id;
        }

        public static PeerId LoadFromString(string key)
        {
            PeerId id = new PeerId();
            int discarded;
            id.buffer = HexEncoding.GetBytes(key, out discarded);
            return id;
        }
    }
}
