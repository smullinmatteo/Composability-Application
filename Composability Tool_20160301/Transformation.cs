using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composability_Tool_20160301
{
    public class Transformation
    {
        public string sourceOutput { get; set; }
        public string targetInput { get; set; }
        public string descr { get; set; }
        public List<LinkEquation> equations;
        public Dictionary<string, string> nameVarDic { get; set; }
        public HashSet<String> eqVars;

        public Dictionary<String,Double> internalVars { get; set; }

        public void setNameVarDic(Dictionary<String, String> _nameVarDic)
        {
            nameVarDic = _nameVarDic;
        }

        public void setEqVars(string eqVar)
        {
            eqVars.Add(eqVar);
        }

        public HashSet<String> getEqVar()
        {
            return eqVars;
        }

        public Transformation(string _sourceOutput, string _targetInput, string _descr)
        {
            sourceOutput = _sourceOutput;
            targetInput = _targetInput;
            descr = _descr;
            eqVars = new HashSet<string>();
            equations = new List<LinkEquation>();
            internalVars = new Dictionary<string, double>();
        }

        public void AddEquation(LinkEquation linkEq)
        {
            linkEq.eq = findSetEqVars(linkEq);
            equations.Add(linkEq);
        }

        public List<LinkEquation> getEquation()
        {
            return equations;
        }

        public string findSetEqVars(LinkEquation linkEq)
        {
            string eq = linkEq.eq;
            //we have the equation string in eq and we want to extract equation variables from eq and set to eqVars
            string eqTmp = eq;
            string[] tmpEqSplits = eq.Split('=');
            if (tmpEqSplits.Length > 1)
            {
                internalVars.Add(tmpEqSplits[0],0.0);
                eqTmp = tmpEqSplits[1];
                linkEq.internalVar = new KeyValuePair<string, double>(tmpEqSplits[0], 0.0);
            }

            string[] delimiterStrs = { " ", "+", "-", "=", "\t", "tan(", "sin(", "cos(", "ln(", "log(", "/", "exp", "sqrt", "(", ")", "[", "]", "*", "^" };
            string[] potentialVars = eqTmp.Split(delimiterStrs, StringSplitOptions.RemoveEmptyEntries);
            double tmp;
            foreach (string pvar in potentialVars)
            {
                if (!Double.TryParse(pvar, out tmp))
                    eqVars.Add(pvar);
            }
            eq = eqTmp;
            foreach(string internalVar in internalVars.Keys)
                eqVars.Remove(internalVar);
            return eq;
        }
    }
}
