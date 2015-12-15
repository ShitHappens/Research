using System;
using System.Collections.Generic;
using System.Text;

namespace Dreams.Kademlia
{
    public class Storage
    {
        private string key;
        private string val;
        private DateTime expiration = DateTime.MinValue;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        public string Val
        {
            get { return val; }
            set { val = value; }
        }
        public DateTime Expiration
        {
            get { return expiration; }
            set { expiration = value; }
        }
    }
}
