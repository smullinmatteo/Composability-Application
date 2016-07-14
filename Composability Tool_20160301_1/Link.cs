using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composability_Tool_20160301
{
    public class Link
    {
        public string targetUMP { get; set; }
        public string targetInput { get; set; }
        public string sourceUMP { get; set; }
        public string sourceOutput { get; set; }
        public string description { get; set; }
        public List<LinkEquation> equations;

        public Link(string _targetUMP, string _targetInput, string _sourceUMP, string _sourceOutput, string _descr)
        {
            targetUMP = _targetUMP;
            targetInput = _targetInput;
            sourceUMP = _sourceUMP;
            sourceOutput = _sourceOutput;
            description = _descr;
            equations = new List<LinkEquation>();
        }

        public void AddEquation(LinkEquation eq)
        {
            equations.Add(eq);
        }

        public List<LinkEquation> getEqueation()
        {
            return equations;
        }

        public bool compareSourceTarget(string _sourceUMP, string _targetUMP)
        {
            if (this.sourceUMP.Equals(_sourceUMP) && this.targetUMP.Equals(_targetUMP))
                return true;
            return false;
        }
    }
}
