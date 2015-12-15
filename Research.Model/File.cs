using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Model
{
    public class File
    {
        public string Name { get; set; }
        public byte[] Bytes { get; set; }
        public int? HashCode { get; set; }

        public File(string name, byte[] bytes)
        {
            this.Name = name;
            this.Bytes = bytes;
            this.HashCode = GetHashedName(name);
        }

        private static int? GetHashedName(string name)
        {
            int? ret = null;

            ret = name.GetHashCode();

            return ret;
        }
    }
}
