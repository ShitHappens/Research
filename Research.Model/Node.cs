using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Model
{
    public class Node
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public string ID { get; set; }

        public List<File> Files { get; set; }
    }
}
