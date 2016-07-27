using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathWorks.MATLAB.NET.Arrays;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using ComposibilityMatlabTool;

namespace Composability_Tool_20160301
{
    class MathEquation
    {
        public int shiftedCount;
        public static string toolPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Directory.GetCurrentDirectory())));
        public string matlabPath = toolPath + "\\Matlab\\";
        string[] metrics = {"massConsumable", "costConsumable", "powerConsumed", "costPower", "processTime", "wage", "illness", "injury", "illnessDaysLost", "injuryDaysLost",
                            "waterRate", "energyCost", "waterCost", "RateCO2", "RateCH4", "GWPCH4", "RateN2O", "GWPN2O","Rland","Rinc","Rrec","Rhaz" };
        public Double evaluateEquation(String eq)
        {
            eq = eq.Replace("--", "+");
            double value = evaluteUsingMatlabDLL(eq);
            //double value = evaluteUsingMatlab(eq);            
            return value;
            //replace ln with log(2.71828, ) //find the material between the first following ( and the ...//
        }

        public double evaluteUsingNCalc(String eq)
        {
            eq = eq.Replace("tan(", "Tan(");
            eq = eq.Replace("sin(", "Sin(");
            eq = eq.Replace("cos(", "Cos(");
            //eq = eq.Replace("^");
            shiftedCount = 0;
            eq = eq.Replace("exp(", "Pow(2.71828,");
            eq = replaceCarrot(eq);
            //NCalc.Expression expression = new NCalc.Expression(eq);
            //expression.Parameters["pi"] = 3.14;
            //var value = expression.Evaluate();
            var value = -1;
            return (double)value;
        }

        public String replaceCarrot(String eq)
        {
            String eqNew = eq;
            List<int> stackOpen = new List<int>();
            List<int> stackClose = new List<int>();
            List<int> carrotIndices = new List<int>();
            for (int i = 0; i < eq.Length; i++)
            {
                switch (eq[i])
                {
                    case '^':
                        carrotIndices.Add(i);
                        break;
                    case '(':
                        stackOpen.Add(i);
                        break;
                    case ')':
                        stackClose.Add(i);
                        break;
                }
            }

            for(int i = 0; i < carrotIndices.Count; i++)
            {
                var regex = new Regex(Regex.Escape("^"));
                int cIndex = carrotIndices[i];
                if (!eqNew[cIndex+shiftedCount].Equals('^'))
                    continue;
                if (!stackClose.Contains(cIndex - 1) && !stackOpen.Contains(cIndex + 1)) // 12^3
                {
                    string[] delimiterStrs = { "+", "-", "=", "\t", "tan(", "sin(", "cos(", "ln(", "log(", "/", "exp", "(", ")", "[", "]", "*" };
                    string[] potentialVars = eqNew.Split(delimiterStrs, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < potentialVars.Length; j++)
                    {
                        if (potentialVars[j].Contains("^"))
                        {
                            int index = eqNew.IndexOf(potentialVars[j]);
                            eqNew = eqNew.Replace(potentialVars[j], "Pow(" + potentialVars[j] + ")");
                            shiftedCount+=5;
                            break;
                        }
                    }
                }
                else
                {
                    if (stackClose.Contains(cIndex - 1)) // ... 2)^(3 or ...2)^3
                    {
                        int index = findMatchingBraceIndex(eq.Substring(0, cIndex - 2));
                        eqNew = eqNew.Insert(index+shiftedCount, "Pow(");
                        shiftedCount+=4;
                    }
                    else //... 2^(3...
                    {
                        string[] delimiterStrs = { "+", "-", "=", "\t", "tan(", "sin(", "cos(", "ln(", "log(", "/", "exp", "(", ")", "[", "]", "*" };
                        string[] potentialVars = eqNew.Split(delimiterStrs, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < potentialVars.Length; j++)
                        {
                            if (potentialVars[j].Contains("^"))
                            {
                                int index = eqNew.IndexOf(potentialVars[j]);
                                eqNew = eqNew.Insert(index, "Pow(");
                                shiftedCount+=4;break;
                            }
                        }
                    }
                    if (stackOpen.Contains(cIndex + 1)) // 2^(3 ... or ... 2)^(3
                    {
                        int index = findMatchingBraceIndex(eq.Substring(cIndex + 2));
                        eqNew = eqNew.Insert(index + cIndex + 2 + shiftedCount, ")");
                        shiftedCount++;
                    }
                    else // 2)^3
                    {
                        string[] delimiterStrs = { "+", "-", "=", "\t", "tan(", "sin(", "cos(", "ln(", "log(", "/", "exp", "(", ")", "[", "]", "*" };
                        string[] potentialVars = eqNew.Split(delimiterStrs, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < potentialVars.Length; j++)
                        {
                            if (potentialVars[j].Contains("^"))
                            {
                                int index = eqNew.IndexOf(potentialVars[j]);
                                eqNew = eqNew.Insert(index + potentialVars[j].Length, ")");
                                shiftedCount++;
                                break;
                            }
                        }
                    }
                }
                eqNew = regex.Replace(eqNew, ",", 1);
            }
            eqNew = eqNew.Replace("^", ",");
            return eqNew;
        }

        public Double evaluteUsingMatlab(String eq)
        {
            eq = eq.ToLower();
            eq = eq.Replace("log(", "log10(");
            eq = eq.Replace("ln(", "log(");
            eq = eq.Replace("--", "+");
            //MLApp.MLApp matlab = new MLApp.MLApp();
            //String res = matlab.Execute(new Uri("evaluateComposibilityEquations", UriKind.Relative).AbsolutePath);
            //matlab.Execute(@"cd 'C:\Users\smull\Documents\Visual Studio 2015\Composability Tool_20160301\Composability Tool_20160301\Matlab'");
            //matlab.Execute(@"cd Matlab\");
            //matlab.Execute(@"cd " + matlabPath);
            //matlab.Execute(@"cd('"+matlabPath+"')");
            object result = null;

            // Call the MATLAB function myfunc
            //matlab.Feval("evaluateComposibilityEquations", 1, out result, eq);
            //matlab.Execute(@"cd ..");
            // Display result 
            object[] res = result as object[];
            if (res[0] == System.Reflection.Missing.Value)
            {
                Console.WriteLine("Wrong parameter values!");
                return Double.MinValue;
            }
            return (double)res[0];
        }

        public double evaluteUsingMatlabDLL(string eq)
        {
            eq = eq.ToLower();
            eq = eq.Replace("log(", "log10(");
            eq = eq.Replace("ln(", "log(");
            eq = eq.Replace("--", "+");
            MWArray[] result = null;
            //inputString[1] = new MWCharArray(eq);
            EvaluateComposibilityEquations evaluateComposibilityEquations = new EvaluateComposibilityEquations();
            try
            {
                result = evaluateComposibilityEquations.evaluateComposibilityEquations(2, new MWCharArray(eq));
                int errorCode = ((MWNumericArray)result[1]).ToScalarInteger();
                if (errorCode == 1)
                {
                    Console.WriteLine("Wrong parameter values!");
                    return Double.MinValue;
                }
                return ((MWNumericArray)result[0]).ToScalarDouble();
            }
            catch
            {
                //int errorCode = ((MWNumericArray)result[1]).ToScalarInteger();
                //if (errorCode == 1)
                {
                    Console.WriteLine("Wrong parameter values!");
                    return Double.MinValue;
                }
            }
        }

        public Dictionary<string, double> computeSustainabilityMetrics(string umpName, Dictionary<String, List<String>> keywordPairs, Dictionary<String, Double> internalVars)
        {
            Dictionary<string, double> keywordValues = new Dictionary<string, double>();
            foreach (string keyword in keywordPairs.Keys)
            {
                double keywordVal = 0;
                foreach (string mappedVar in keywordPairs[keyword])
                {
                    if (internalVars.Keys.Contains(mappedVar))
                        keywordVal += internalVars[mappedVar];
                }
                keywordValues.Add(keyword, keywordVal);
            }
            MWArray[] results = null;
            MWArray[] inputs = new MWArray[metrics.Length+1];
            int ind = 0;
            inputs[0] = new MWCharArray(toolPath + "\\ProcessModelDatabase\\ProcessModelDatabase_" + umpName + ".csv");
            ind++;
            // Call the MATLAB function myfunc
            foreach (string metric in metrics)
            {
                if (!keywordValues.ContainsKey(metric))
                    keywordValues.Add(metric, 0.0);
                inputs[ind] = new MWNumericArray(keywordValues[metric]);
                ind++;
            }
            //EvaluateSustainability evaluateSust = new EvaluateSustainability();
            //evaluateSust.Sustainability_Evaluation_Criteria(7, ref results, inputs);
            EvaluateSustainabilityMetrics evaluateSustainabilityMetrics = new EvaluateSustainabilityMetrics();
            evaluateSustainabilityMetrics.Sustainability_Evaluation_Criteria(7, ref results, inputs);
            string[] outputMetrics = { "Operating Cost($)", "Energy Use(kWh)", "Water Use(L)", "GHG Emissions(Kg)", "Total Waste(Kg)", "Average Wage($/hr)", "Lost Work Days" };
            Dictionary<string, double> sustainabilityOutputMetrics = new Dictionary<string, double>();
            int index = 0;
            foreach (string outputMetric in outputMetrics)
            {
                sustainabilityOutputMetrics.Add(outputMetric, ((MWNumericArray)results[index]).ToScalarDouble());
                index++;
            }
            return sustainabilityOutputMetrics;
        }

        public Dictionary<string, double> computeSustainabilityMetricsUsingMatlab(Dictionary<String, List<String>> keywordPairs, Dictionary<String, Double> internalVars)
        {
            Dictionary<string, double> keywordValues = new Dictionary<string, double>();
            foreach(string keyword in keywordPairs.Keys)
            {
                double keywordVal = 0;
                foreach(string mappedVar in keywordPairs[keyword])
                {
                    if (internalVars.Keys.Contains(mappedVar))
                        keywordVal += internalVars[mappedVar];
                }
                keywordValues.Add(keyword, keywordVal);
            }
            //MLApp.MLApp matlab = new MLApp.MLApp();
            //matlab.Execute(@"cd('" + matlabPath + "')");
            //String res = matlab.Execute(new Uri("evaluateComposibilityEquations", UriKind.Relative).AbsolutePath);
            //matlab.Execute(@"cd 'C:\Users\smull\Documents\Visual Studio 2015\Composability Tool_20160301\Composability Tool_20160301\Matlab'");
            //matlab.Execute(@"cd " + matlabPath);
            //matlab.Execute(@"cd Matlab\");
            object result = null;
            double[] inputs = new double[metrics.Length];
            int ind = 0;
            // Call the MATLAB function myfunc
            foreach (string metric in metrics)
            {
                if (!keywordValues.ContainsKey(metric))
                    keywordValues.Add(metric, 0.0);
                inputs[ind] = keywordValues[metric];
                ind++;
            }
            //matlab.Feval("Sustainability_Evaluation_Criteria", 7, out result, inputs);
            /*matlab.Feval("Sustainability_Evaluation_Criteria", 7, out result, test, keywordValues[metrics[0]], keywordValues[metrics[1]], keywordValues[metrics[2]], keywordValues[metrics[3]]
                , keywordValues[metrics[4]], keywordValues[metrics[5]], keywordValues[metrics[6]], keywordValues[metrics[7]], keywordValues[metrics[8]], keywordValues[metrics[9]],
                keywordValues[metrics[10]], keywordValues[metrics[11]], keywordValues[metrics[12]], keywordValues[metrics[13]] , keywordValues[metrics[14]], keywordValues[metrics[15]], 
                keywordValues[metrics[16]], keywordValues[metrics[17]], keywordValues[metrics[18]], keywordValues[metrics[19]], keywordValues[metrics[20]], keywordValues[metrics[21]]);
            *///matlab.Execute(@"cd ..");
            // Display result 
            
            object[] res = result as object[];
            if (res[0] == System.Reflection.Missing.Value)
            {
                Console.WriteLine("Wrong parameter values!");
                return null;
            }
            string[] outputMetrics = { "operatingCost", "energyUse", "waterUse", "GHGEmissions", "totalWaste", "averageWage", "lostWorkDays" };
            Dictionary<string, double> sustainabilityOutputMetrics = new Dictionary<string, double>();
            int index = 0;
            foreach (string outputMetric in outputMetrics)
            {
                sustainabilityOutputMetrics.Add(outputMetric, (double)res[index]);
                index++;
            }
            return sustainabilityOutputMetrics;
        }

        public int findMatchingBraceIndex(String s)
        {
            //String s = "((paid for) + (8 working hours) + (company rules))";
            var stack = new Stack<int>();
            bool breakLoop = false;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '(':
                        stack.Push(i);
                        break;
                    case ')':
                        if (stack.Any())
                            stack.Pop();
                        else
                        {
                            stack.Push(i);
                            breakLoop = true;
                        }
                        //int index = stack.Any() ? stack.Pop() : -1;
                        //isSurroundedByParens = (index == 0);
                        break;
                }
                if (breakLoop)
                    break;
            }
            return stack.Pop();

        }


    }
}
