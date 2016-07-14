using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Composability_Tool_20160301
{
    public class UMPEquation
    {
        public string category { get; set; }
        public string description { get; set; }
        public string eq { get; set; }
        public HashSet<String> eqVars { get; set; }

        public KeyValuePair<String, Double> internalVar { get; set; }

        public void AddEqVars(string eqVar)
        {
            eqVars.Add(eqVar);
        }

        public HashSet<String> getEqVar()
        {
            return eqVars;
        }

        public UMPEquation(string _category, string _descr, string _eq)
        {
            category = _category;
            description = _descr;
            eq = Regex.Replace(_eq, "[ \n\r\t]", "");
            eq = findSetEqVars();
        }

        public string findSetEqVars()
        {
            //we have the equation string in eq and we want to extract equation variables from eq and set to eqVars
            string eqTmp = eq;
            string[] tmpEqSplits = eq.Split('=');
            if (tmpEqSplits.Length > 1)
            {
                internalVar = new KeyValuePair<string, double>(tmpEqSplits[0], 0.0);
                eqTmp = tmpEqSplits[1];
            }

            string[] delimiterStrs = { " ", "+", "-", "=", "\t", "tan(", "sin(", "cos(", "ln(", "log(", "/", "exp", "sqrt", "(", ")", "[", "]", "*", "^" };
            string[] potentialVars = eqTmp.Split(delimiterStrs, StringSplitOptions.RemoveEmptyEntries);
            double tmp;
            eqVars = new HashSet<string>();
            foreach(string pvar in potentialVars)
            {
                if (!Double.TryParse(pvar, out tmp))
                    eqVars.Add(pvar);
            }
            eq = eqTmp;
            return eq;
        }

    }
}
