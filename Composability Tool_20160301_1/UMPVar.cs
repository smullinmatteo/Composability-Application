using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composability_Tool_20160301
{
    public class eqVariable
    {
        public eqVariable(string _name, string _unit)
        {
            name = _name;
            unit = _unit;
        }

        public eqVariable(string _name)
        {
            name = _name;
            unit = "";
        }
        public string name { get; set; }
        public double value { get; set; }
        public string unit { get; set; }
    }
}
