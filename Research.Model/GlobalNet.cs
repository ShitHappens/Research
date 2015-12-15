using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Model
{
    class GlobalNet : Net
    {
        List<LocalNet> LocalNets { get; set; }
    }
}
