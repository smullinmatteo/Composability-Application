using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;

namespace Composability_Tool_20160301
{
    public class UMP
    {
        public static string errorMsg { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public List<String> inputList { get; set; }
        public List<String> outputList { get; set; }
        public List<String> feedbackList { get; set; }
        public List<String> productProcessInfoList { get; set; }
        public List<String> resourceInfoList { get; set; }
        public Dictionary<String, Double> internalVars { get; set; }
        public List<UMPEquation> equations;
        public Dictionary<String, String> nameVarDic { get; set; }

        /*public UMP(string _name, string _type, string _description, List<String> _inputList, List<String> _outputList, List<String> _feedbackList, List<String> _productProcessInfoList, List<String> _resourceInfoList, List<UMPEquation> _eq)
        {
            inputList = _inputList;
            outputList = _outputList;
            feedbackList = _feedbackList;
            productProcessInfoList = _productProcessInfoList;
            resourceInfoList = _resourceInfoList;
            equations = _eq;
            name = _name;
            type = _type;
            description = _description;

        }*/

        public void setNameVarDic(Dictionary<String, String> _nameVarDic)
        {
            nameVarDic = _nameVarDic;
        }

        public UMP()
        {

        }

        public UMP(string _name, string _type, string _description)
        {
            inputList = new List<string>();
            outputList = new List<string>();
            feedbackList = new List<string>();
            productProcessInfoList = new List<string>();
            resourceInfoList = new List<string>();
            equations = new List<UMPEquation>();
            name = _name;
            type = _type;
            internalVars = new Dictionary<string, double>();
            description = _description;
        }

        internal static string writeXMLNewXML(string newUMPName)
        {
            throw new NotImplementedException();
        }

        public void AddInput(string inputName)
        {
            inputList.Add(inputName);
        }

        public void AddOutput(string outputName)
        {
            outputList.Add(outputName);
        }

        public void AddFeedback(string feedbackName)
        {
            feedbackList.Add(feedbackName);
        }

        public void AddProductProcessInfo(string productProcessInfoname)
        {
            productProcessInfoList.Add(productProcessInfoname);
        }

        public void AddResourceInfo(string resourceInfoName)
        {
            resourceInfoList.Add(resourceInfoName);
        }

        public void AddEquation(UMPEquation eq)
        {
            equations.Add(eq);
        }

        public static string writeXMLComposedSystemResult(string composedUMPName, Dictionary<string, double> sustainabilityMetricValues)
        {
            StringBuilder fileContent = new StringBuilder("<ComposedSystem name=\"" +composedUMPName + "\">\n");
            fileContent.Append("<FinalSustainabilityMetrics>\n");
            foreach (string metric in sustainabilityMetricValues.Keys)
            {
                fileContent.Append("<Metric name=\"" + metric + "\" value=\"" + sustainabilityMetricValues[metric] + "\" />\n");
            }
            fileContent.Append("</FinalSustainabilityMetrics>\n");
            fileContent.Append("</ComposedSystem>");
            return fileContent.ToString();
        }

        private static Dictionary<string, double> sumupSustainabilityMetrics(Dictionary<string, double> umpSustainabilityMetrics1, Dictionary<string, double> umpSustainabilityMetrics2)
        {
            Dictionary<string, double> sustMetrics = new Dictionary<string, double>();
            foreach (string metric in umpSustainabilityMetrics1.Keys)
            {
                sustMetrics.Add(metric, umpSustainabilityMetrics1[metric]+ umpSustainabilityMetrics2[metric]);
            }
            return sustMetrics;
        }

        public static string writeXMLComposedSystemContent(UMP SourceUMP, UMP TargetUMP, Transformation linkingAction, ObservableCollection<eqVariable> sourceVarList, ObservableCollection<eqVariable> targetVarList, ObservableCollection<eqVariable> linkVarList, Dictionary<string, double> sourceSustainabilityMetrics, Dictionary<string, double> targetSustainabilityMetrics, Dictionary<string, double> allParams, Dictionary<string, double> allInternalVars)
        {
            StringBuilder fileContent = new StringBuilder("<ComposedSystem>\n<UMPs>\n");
            //UMP tmpUMP = (UMP)SourceUMP.SelectedValue;
            List<ObservableCollection<eqVariable>> varList = new List<ObservableCollection<eqVariable>>() { sourceVarList, targetVarList };
            List<Dictionary<string, double>> sustainabilityList = new List<Dictionary<string, double>>() { sourceSustainabilityMetrics, targetSustainabilityMetrics};
            int ind = 0;
            foreach (UMP tmpUMP in new List<UMP>() { SourceUMP, TargetUMP })
            {
                if (ind == 0 && (allParams != null || allInternalVars != null))
                {
                    fileContent.Append("<UMP name=\"" + tmpUMP.description + "\" type=\"" + tmpUMP.type + "\" description=\"" + tmpUMP.description + "\">\n");
                    foreach (string param in allParams.Keys)
                    {
                        fileContent.Append("<Parameter name=\"" + param + "\" value=\"" + allParams[param] + "\"/>\n");
                    }
                    fileContent.Append("<Transformation>\n");
                    foreach (string var in allInternalVars.Keys)
                    {
                        //TODO: compute the equation results and write them to the file
                        fileContent.Append("<Equation>" + var + "=" + allInternalVars[var] + "</Equation>\n");
                    }
                }
                else {
                    fileContent.Append("<UMP name=\"" + tmpUMP.name + "\" type=\"" + tmpUMP.type + "\" description=\"" + tmpUMP.description + "\">\n");
                    foreach (eqVariable param in varList[ind])
                    {
                        fileContent.Append("<Parameter name=\"" + param.name + "\" value=\"" + param.value + "\"/>\n");
                    }
                    fileContent.Append("<Transformation>\n");
                    foreach (UMPEquation eq in tmpUMP.equations)
                    {
                        //TODO: compute the equation results and write them to the file
                        fileContent.Append("<Equation category=\"" + eq.category + "\" description=\"" + eq.description + "\">" + eq.internalVar.Key + "=" + eq.internalVar.Value + "</Equation>\n");
                    }
                }
                fileContent.Append("</Transformation>\n");
                fileContent.Append("<SustainabilityMetrics>\n");
                foreach (string metric in sustainabilityList[ind].Keys)
                {
                    fileContent.Append("<Metric name=\"" + metric + "\" value=\"" + sustainabilityList[ind][metric] + "\" />\n");
                }
                fileContent.Append("</SustainabilityMetrics>\n");
                fileContent.Append("</UMP>\n");
                ind++;
            }
            fileContent.Append("</UMPs>\n");
            fileContent.Append("<Linking>\n");
            fileContent.Append("<LinkingAction targetUMP = \"" + TargetUMP.name + "\" sourceUMP = \"" + SourceUMP.name + "\" allocationVariable = \"1\">\n");
            fileContent.Append("<Transformation targetInput=\"" + linkingAction.targetInput + "\"  sourceOutput=\"" + linkingAction.sourceOutput + "\">\n");
            foreach (eqVariable var in linkVarList)
            {
                fileContent.Append("<Equation name=\"" + var.name + "\">" + var.value + "</Equation>\n");
            }
            fileContent.Append("</Transformation>\n");
            fileContent.Append("</LinkingAction>\n");
            fileContent.Append("</Linking>\n");
            Dictionary<string, double> sumedMetrics = sumupSustainabilityMetrics(sustainabilityList[0], sustainabilityList[1]);
            fileContent.Append("<FinalSustainabilityMetrics>\n");
            foreach (string metric in sumedMetrics.Keys)
            {
                fileContent.Append("<Metric name=\"" + metric + "\" value=\"" + sumedMetrics[metric] + "\" />\n");
            }
            fileContent.Append("</FinalSustainabilityMetrics>\n");
            fileContent.Append("</ComposedSystem>");
            return fileContent.ToString();
        }

        public static Dictionary<string, double> readXMLComposedSystemContent(string filename)
        {
            Dictionary<string, Dictionary<string, double>> sustainabilityList = new Dictionary<string, Dictionary<string, double>>();
            Console.WriteLine("file: " + filename);
            XDocument testXML = XDocument.Load(filename);
            Dictionary<string, double> sustainabilityMetrics = new Dictionary<string, double>();
            /*var umpsVar = from ump in testXML.Descendants("UMP")
                          select new
                          {
                              sustainabilityMetrics = ump.Descendants("SustainabilityMetrics").Descendants("Metric"),
                              name = Convert.ToString(ump.Attribute("name").Value)
                          };

            foreach (var umpVar in umpsVar)
            {
                Dictionary<string, double> sustainabilityMetrics = new Dictionary<string, double>();
                var metricVar = from metric in umpVar.sustainabilityMetrics
                              select new
                              {
                                  name = Convert.ToString(metric.Attribute("name").Value),
                                  value = Convert.ToDouble(metric.Attribute("value").Value)
                              };
                foreach(var met in metricVar)                
                    sustainabilityMetrics.Add(met.name, met.value);
                sustainabilityList.Add(umpVar.name, sustainabilityMetrics);            
            }*/

            var metricVar = from metric in testXML.Descendants("FinalSustainabilityMetrics").Descendants("Metric")
                            select new
                          {
                              name = Convert.ToString(metric.Attribute("name").Value),
                              value = Convert.ToDouble(metric.Attribute("value").Value)
                          };
            foreach (var met in metricVar)
                sustainabilityMetrics.Add(met.name, met.value);
            return sustainabilityMetrics;
        }

        public static List<object> readXMLComposedSystemAllContent(string filename)
        {
            List<object> resList = new List<object>();
            Console.WriteLine("file: " + filename);
            XDocument testXML = XDocument.Load(filename);

            var umpsVar = from ump in testXML.Descendants("UMP")
                          select new
                          {
                              parameter = ump.Descendants("Parameter"),
                              name = Convert.ToString(ump.Attribute("name").Value)
                          };

            foreach (var umpVar in umpsVar)
            {
                Dictionary<string, double> parameters = new Dictionary<string, double>();
                var paramVar = from param in umpVar.parameter
                                select new
                              {
                                  name = Convert.ToString(param.Attribute("name").Value),
                                  value = Convert.ToDouble(param.Attribute("value").Value)
                              };
                foreach(var par in paramVar)                
                    parameters.Add(par.name, par.value);
                resList.Add(umpVar.name);
                resList.Add(parameters);    // The first UMP is Source, Second one is Target        
            }

            var linkVar = from link in testXML.Descendants("LinkingAction").Descendants("Transformation")
                          select new
                          {
                              equations = link.Descendants("Equation"),
                              sourceOutput = Convert.ToString(link.Attribute("sourceOutput").Value),
                              targetInput = Convert.ToString(link.Attribute("targetInput").Value)
                          };
            foreach (var link in linkVar) {
                var eqVar = from eq in link.equations
                            select new
                            {
                                value = Convert.ToDouble(eq.Value),
                                name = Convert.ToString(eq.Attribute("name").Value)
                            };
                resList.Add(link.targetInput);
                resList.Add(link.sourceOutput);
                Dictionary<string, double> linkParameters = new Dictionary<string, double>();
                foreach (var l in eqVar) {
                    linkParameters.Add(l.name, l.value);
                }
                resList.Add(linkParameters);
            }
            
            // 1. SourceName, 2. SourceParameters, 3.TargetName, 4.TargetParameters, 5. LinkTargetInput, 6. LinkSourceOutput, 7. LinkingParameters
            return resList; 
        }

        public static List<Dictionary<string, double>> composeUMPs(UMP source, UMP target, ObservableCollection<eqVariable> sourceVarList, ObservableCollection<eqVariable> targetVarList, ObservableCollection<eqVariable> linkVarList, Transformation transformation, Dictionary<string, List<string>> sustainabilityKeywordListPairs)
        {
            MathEquation mathEq = new MathEquation();
            
            Dictionary<string, double> sourceUMPInternalVarValues = UMPEvaluator(source, sourceVarList, null, mathEq);
            Dictionary<string, double> linkInternalVarValues = linkUMPs(transformation, sourceVarList, targetVarList, linkVarList, mathEq);
            if(linkInternalVarValues == null)
            {
                Dictionary<string, double> errorDic = new Dictionary<string, double>();
                errorDic.Add(errorMsg, -1);
                return new List<Dictionary<string, double>>() { errorDic };
            }
            Dictionary<string, double> targetUMPInternalVarValues = UMPEvaluator(target, targetVarList, linkInternalVarValues, mathEq);
            Dictionary<string, double> sourceUMPSustainabilityValues = mathEq.computeSustainabilityMetrics(source.name, sustainabilityKeywordListPairs, sourceUMPInternalVarValues);
            Dictionary<string, double> targetUMPSustainabilityValues = mathEq.computeSustainabilityMetrics(target.name, sustainabilityKeywordListPairs, targetUMPInternalVarValues);
            List<Dictionary<string, double>> allParamVarList = makeAllParamVarLists(null, null,source.name, target.name, sourceVarList, targetVarList, sourceUMPInternalVarValues, targetUMPInternalVarValues);
            // OUTPUT FORMAT:
            // {SOURCE_INTERNAL_VARS, LINK_INTERNAL_VARS, TARGET_INTERNAL_VARS, SOURCE_SUSTAINABILITY_METRICS, TARGET_SUSTAINABILITY_METRICS, ALL_COMPOSED_PARAMETERS, ALL_COMPOSED_INTERNAL_VARS}
            return new List<Dictionary<string, double>>() { sourceUMPInternalVarValues, linkInternalVarValues, targetUMPInternalVarValues, sourceUMPSustainabilityValues, targetUMPSustainabilityValues, allParamVarList[0], allParamVarList[1]};
        }

        public static List<Dictionary<string, double>> makeAllParamVarLists(Dictionary<string, double> prevAllParameters, Dictionary<string, double> prevAllInternalVarValues, string sourceName, string targetName, ObservableCollection<eqVariable> sourceVarList, ObservableCollection<eqVariable> targetVarList, Dictionary<string, double> sourceUMPInternalVarValues, Dictionary<string, double> targetUMPInternalVarValues)
        {
            Dictionary<string, double> allParameters, allInternalVarValues;
            if (prevAllInternalVarValues != null && prevAllParameters != null)
            {
                allParameters = new Dictionary<string, double>(prevAllParameters);
                allInternalVarValues = new Dictionary<string, double>(prevAllInternalVarValues);
            }
            else
            {
                allParameters = new Dictionary<string, double>();
                allInternalVarValues = new Dictionary<string, double>();
            }

            if (sourceVarList != null)
            {
                foreach (eqVariable param in sourceVarList)
                    allParameters.Add(param.name + "_" + sourceName, param.value);
            }
            foreach (eqVariable param in targetVarList)
                allParameters.Add(param.name + "_" + targetName, param.value);
            if (sourceUMPInternalVarValues != null)
            {
                foreach (string internalvar in sourceUMPInternalVarValues.Keys)
                    allInternalVarValues.Add(internalvar + "_" + sourceName, sourceUMPInternalVarValues[internalvar]);
            }
            foreach (string internalvar in targetUMPInternalVarValues.Keys)
                allInternalVarValues.Add(internalvar + "_" + targetName, targetUMPInternalVarValues[internalvar]);
            return new List<Dictionary<string, double>>() { allParameters, allInternalVarValues };
        }

        public static List<Dictionary<string, double>> composeUMPs(string linkedTargetName, List<Dictionary<string, double>> linkedSourceResults, UMP target, ObservableCollection<eqVariable> sourceVarList, ObservableCollection<eqVariable> targetVarList, ObservableCollection<eqVariable> linkVarList, Transformation transformation, Dictionary<string, List<string>> sustainabilityKeywordListPairs)
        {
            MathEquation mathEq = new MathEquation();

            //Add all previous linked UMP's source, target, and link internal var/values to sourceVarList.
            //We will only add last composed UMP's internal vars to the current sourceUMPInternalVarValues
            Dictionary<string, double> sourceUMPInternalVarValues = new Dictionary<string, double>();
            int index = 2;
            foreach (string prevItem in linkedSourceResults[index].Keys)
            {
                //sourceVarList.Add(new eqVariable(prevItem, linkedSourceResults[i][prevItem]));
                if (sourceUMPInternalVarValues.Keys.Contains(prevItem))
                    sourceUMPInternalVarValues[prevItem] = linkedSourceResults[index][prevItem];
                else
                    sourceUMPInternalVarValues.Add(prevItem, linkedSourceResults[index][prevItem]);
            }
            //Sum up the source and target sustainability metrics of the linkedUMP
            Dictionary<string, double> sourceUMPSustainabilityValues = new Dictionary<string, double>();
            foreach (string sustainabilityMetricsKey in linkedSourceResults[3].Keys)
            {
                sourceUMPSustainabilityValues.Add(sustainabilityMetricsKey, linkedSourceResults[3][sustainabilityMetricsKey] + linkedSourceResults[4][sustainabilityMetricsKey]);
            }
            //Dictionary<string, double> sourceUMPInternalVarValues = UMPEvaluator(source, sourceVarList, null, mathEq);
            Dictionary<string, double> linkInternalVarValues = linkUMPs(transformation, sourceVarList, targetVarList, linkVarList, mathEq);
            Dictionary<string, double> targetUMPInternalVarValues = UMPEvaluator(target, targetVarList, linkInternalVarValues, mathEq);
            //Dictionary<string, double> sourceUMPSustainabilityValues = mathEq.computeSustainabilityMetrics(sustainabilityKeywordListPairs, sourceUMPInternalVarValues);
            Dictionary<string, double> targetUMPSustainabilityValues = mathEq.computeSustainabilityMetrics(target.name, sustainabilityKeywordListPairs, targetUMPInternalVarValues);
            List<Dictionary<string, double>> allParamVarList = makeAllParamVarLists(linkedSourceResults[5], linkedSourceResults[6], linkedTargetName, target.name, null, targetVarList, null, targetUMPInternalVarValues);
            return new List<Dictionary<string, double>>() { sourceUMPInternalVarValues, linkInternalVarValues, targetUMPInternalVarValues, sourceUMPSustainabilityValues, targetUMPSustainabilityValues, allParamVarList[0], allParamVarList[1]};
        }

        private static Dictionary<String, Double> linkUMPs(Transformation transformation, ObservableCollection<eqVariable> sourceVarList, ObservableCollection<eqVariable> targetVarList, ObservableCollection<eqVariable> linkVarList, MathEquation mathEq)
        {
            if (transformation == null)
                return null;
            //Transformation transformation = (Transformation)Transformation.SelectedValue;
            //link source to target using linkequation equations

            //ASSUMING EQUATIONS ARE SORTED, we begin by computing each equation value from the frist one to the last one
            foreach (LinkEquation linkEquation in transformation.equations)
            {
                string eqStr = linkEquation.eq;
                string[] delimiterStrs = { " ", "+", "-", "=", "\t", "tan(", "sin(", "cos(", "ln(", "log(", "/", "exp", "sqrt", "(", ")", "[", "]", "*", "^" };
                string[] potentialVars = eqStr.Split(delimiterStrs, StringSplitOptions.RemoveEmptyEntries);
                foreach (eqVariable eqVar in linkVarList)
                {
                    if (potentialVars.Contains(eqVar.name))
                        eqStr = eqStr.Replace(eqVar.name, eqVar.value.ToString());
                }
                foreach (eqVariable eqVar in sourceVarList)
                {
                    if (potentialVars.Contains(eqVar.name))
                        eqStr = eqStr.Replace(eqVar.name, eqVar.value.ToString());
                }
                foreach (eqVariable eqVar in targetVarList)
                {
                    if (potentialVars.Contains(eqVar.name))
                        eqStr = eqStr.Replace(eqVar.name, eqVar.value.ToString());
                }
                foreach(string key in transformation.internalVars.Keys)
                {
                    if(potentialVars.Contains(key))
                        eqStr = eqStr.Replace(key, transformation.internalVars[key].ToString());
                }
                if (eqStr.Contains("∞"))
                {
                    errorMsg = "Incorrect parameter values!";
                    return null;
                }

                double value = mathEq.evaluateEquation(eqStr);
                //CHECK if value is equal to Double.MinValue
                linkEquation.internalVar = new KeyValuePair<string, double>(linkEquation.internalVar.Key, value);
                transformation.internalVars[linkEquation.internalVar.Key] = value;
                foreach(eqVariable var in linkVarList)
                {
                    if (var.name.Equals(linkEquation.internalVar.Key))
                        var.value = value;
                }
                //linkVarList.Add(new eqVariable(linkEquation.internalVar.Key, value));
            }
            return transformation.internalVars;
        }

        private static Dictionary<String, Double> UMPEvaluator(UMP ump, ObservableCollection<eqVariable> varList, Dictionary<string, double> linkInternalVarValues, MathEquation mathEq)
        {
            bool isTargetUMP = false;
            double value = -1;
            if (linkInternalVarValues != null)
            {
                isTargetUMP = true;
            }
            bool valueSet = false;
            //ASSUMING EQUATIONS ARE SORTED, we begin by computing each equation value from the frist one to the last one
            foreach (UMPEquation umpEquation in ump.equations)
            {
                if (isTargetUMP)
                {
                    //TODO: What if it is processTime?
                    if (linkInternalVarValues.Keys.Contains(umpEquation.internalVar.Key))
                    {
                        value = linkInternalVarValues[umpEquation.internalVar.Key];
                        valueSet = true;
                    }
                }
                if (!valueSet) { 
                    string eqStr = umpEquation.eq;
                    //var interpreter = new Interpreter();
                    //var result = interpreter.Eval("8 / 2 + 2");
                    string[] delimiterStrs = { " ", "+", "-", "=", "\t", "tan(", "sin(", "cos(", "ln(", "log(", "/", "exp", "sqrt", "(", ")", "[", "]", "*", "^" };
                    string[] potentialVars = eqStr.Split(delimiterStrs, StringSplitOptions.RemoveEmptyEntries);
                    foreach (eqVariable eqVar in varList)
                    {
                        if (potentialVars.Contains(eqVar.name))
                            eqStr = eqStr.Replace(eqVar.name, eqVar.value.ToString());
                    }
                    foreach (string key in ump.internalVars.Keys)//TODO: should we double check this?!
                    {
                        if (potentialVars.Contains(key))
                            eqStr = eqStr.Replace(key, ump.internalVars[key].ToString());
                    }
                    if (isTargetUMP)
                    {
                        foreach (string linkInternalVar in linkInternalVarValues.Keys)
                        {
                            if (potentialVars.Contains(linkInternalVar))
                                eqStr = eqStr.Replace(linkInternalVar, linkInternalVarValues[linkInternalVar].ToString());
                        }
                    }
                    value = mathEq.evaluateEquation(eqStr);
                }
                
                //CHECK if value is equal to Double.MinValue
                umpEquation.internalVar = new KeyValuePair<string, double>(umpEquation.internalVar.Key, value);
                ump.internalVars[umpEquation.internalVar.Key] = value;
                foreach (eqVariable var in varList)
                {
                    if (var.name.Equals(umpEquation.internalVar.Key))
                        var.value = value;
                }
                //varList.Add(new eqVariable(umpEquation.internalVar.Key, value));
            }
            return ump.internalVars;
        }
    }
}
