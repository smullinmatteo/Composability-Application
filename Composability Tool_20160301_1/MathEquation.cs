using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composability_Tool_20160301
{
    class MathEquation
    {

        public string formatEquation(String eq)
        {
            eq = eq.Replace("tan(", "Tan(");
            eq = eq.Replace("sin(", "Sin(");
            eq = eq.Replace("cos(", "Cos(");
            //eq = eq.Replace("^");
            int ind = eq.IndexOf("exp(");
            int openCounter = 0, closeCounter = 0, index = -1;
            for (int i = ind + 1; i < eq.Length; i++)
            {
                if (eq[i].Equals("("))
                    openCounter++;
                if (eq[i].Equals(")"))
                    closeCounter++;
                if (closeCounter > openCounter) {
                    index = i;
                    break;
                }
            }
            //find the source between the first ( and the...//
            eq = eq.Replace("exp(", "Pow(2.71828,); 
            eq.Insert(index, ")");

            return eq;

            //replace ln with log(2.71828, ) //find the material between the first following ( and the ...//
        }


    }
}
