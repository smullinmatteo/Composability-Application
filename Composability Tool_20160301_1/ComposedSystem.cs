using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composability_Tool_20160301
{
    class ComposedSystem
    {
        List<UMP> umps { get; set; }
        List<Link> linkingList { get; set; }

        public ComposedSystem(List<UMP> _umps, List<Link> _linkingList)
        {
            umps = _umps;
            linkingList = _linkingList;
        }
    }
}
