using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composability_Tool_20160301
{
    public class eqVariable
    {
        public eqVariable(string _name, double _value)
        {
            name = _name;
            value = _value;
        }
        public eqVariable(string _name, string _unit)
        {
            name = _name;
            unit = _unit;
        }

        public eqVariable(string _name, string _presentionName, string _unit)
        {
            name = _name;
            presentionName = _presentionName;
            unit = _unit;
        }

        public eqVariable(string _name, string _presentionName, double _value)
        {
            name = _name;
            presentionName = _presentionName;
            value = _value;
        }
        public string name { get; set; }
        public double value { get; set; }
        public string unit { get; set; }
        public string presentionName { get; set; }
    }
}
