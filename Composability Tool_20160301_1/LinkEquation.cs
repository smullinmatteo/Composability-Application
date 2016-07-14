using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composability_Tool_20160301
{
    public class LinkEquation
    {
        public string targetUMP { get; set; }
        public string targetInput { get; set; }
        public string sourceUMP { get; set; }
        public string sourceOutput { get; set; }
        public string description { get; set; }
        public string eq { get; set; }

        //HashSet is similar to List, however HashSet won't keep repetitive elements and won't hold the order you add elements
        public HashSet<String> eqVars;

        public string internalVar;

        public void setEqVars(string eqVar)
        {
            eqVars.Add(eqVar);
        }

        public HashSet<String> getEqVar()
        {
            return eqVars;
        }

        public LinkEquation(string _targetUMP, string _targetInput, string _sourceUMP, string _sourceOutput, string _descr, string _eq)
        {
            targetUMP = _targetUMP;
            targetInput = _targetInput;
            sourceUMP = _sourceUMP;
            sourceOutput = _sourceOutput;
            description = _descr;
            eq = _eq;
            findSetEqVars();
        }

        public void findSetEqVars()
        {
            //we have the equation string in eq and we want to extract equation variables from eq and set to eqVars
            string eqTmp = eq;
            string[] tmpEqSplits = eq.Split('=');
            if (tmpEqSplits.Length > 1)
            {
                internalVar = tmpEqSplits[0];
                eqTmp = tmpEqSplits[1];
            }

            string[] delimiterStrs = { " ", "+", "-", "=", "\t", "tan(", "sin(", "cos(", "ln(", "log(", "/", "exp", "(", ")", "[", "]", "*" , "^"};
            string[] potentialVars = eqTmp.Split(delimiterStrs, StringSplitOptions.RemoveEmptyEntries);
            double tmp;
            eqVars = new HashSet<string>();
            foreach (string pvar in potentialVars)
            {
                if (!Double.TryParse(pvar, out tmp))
                    eqVars.Add(pvar);
            }
        }

    }
}
