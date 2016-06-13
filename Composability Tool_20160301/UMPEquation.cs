using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composability_Tool_20160301
{
    public class UMPEquation
    {
        string category { get; set; }
        string description { get; set; }
        string eq { get; set; }
        HashSet<String> eqVars { get; set; }

        string internalVar { get; set; }

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

            string[] delimiterStrs = { " ", "+", "-", "=", "\t", "tan(", "sin(", "cos(", "ln(", "log(", "/", "exp", "(", ")", "[", "]", "*", "^"};
            string[] potentialVars = eqTmp.Split(delimiterStrs, StringSplitOptions.RemoveEmptyEntries);
            double tmp;
            eqVars = new HashSet<string>();
            foreach(string pvar in potentialVars)
            {
                if (!Double.TryParse(pvar, out tmp))
                    eqVars.Add(pvar);
            }
        }

    }
}
