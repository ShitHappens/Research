using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Dreams.Dht
{
    public abstract class Client
    {
        public delegate void LookupHandler(string key, string val);
        public event LookupHandler Lookup;

        public abstract void Start();
        public abstract void Abort();
        public abstract void Join();
        public abstract void BeginStore(string key, string val);
        public abstract void BeginLookup(string key);
    }
}
