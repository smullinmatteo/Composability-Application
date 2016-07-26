using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace Composability_Tool_20160301
{


    class XMLReader
    {
        string folderPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))) + "\\XMLFiles\\";
        string sustainabilityPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))) + "\\sustainabilityKeywordPairs.txt";
        public List<ComposedSystem> composedSystems;
        public List<UMP> umpList;
        public List<Link> linkingList;
        public Dictionary<String, List<String>> sustainabilityKeywordListPairs;


        public XMLReader()
        {
            composedSystems = new List<ComposedSystem>();
            umpList = new List<UMP>();
            linkingList = new List<Link>();
            sustainabilityKeywordListPairs = new Dictionary<string, List<string>>();
            //open the XML document
            //docNav = new XPathDocument(@"F:\Matteo's Computer Went to Shit\Documents\Visual Studio 2015\Composability Tool_20160301\Composability Tool_20160301\ComposedSystem_Peen&Temper");

        }

        public IEnumerable<String> getXMLFiles(string folderPath)
        {
            /*List<String> xmlFiles = new List<string>();
            foreach(string file in Directory.EnumerateFiles(folderPath, "*.xml"))
                xmlFiles.Add(file);*/
            return Directory.EnumerateFiles(folderPath, "*.xml");
        }

        public void readComposedSystem()
        {
            readSustainabilityKeywordPairs();
            foreach (string filename in getXMLFiles(folderPath))//for each XML file
            {
                XDocument testXML = XDocument.Load(filename);
                var umpsVar = from UMP in testXML.Descendants("UMP")
                              select new
                              {
                                  name = Convert.ToString(UMP.Attribute("name").Value),
                                  type = Convert.ToString(UMP.Attribute("type").Value),
                                  description = Convert.ToString(UMP.Attribute("description").Value),
                                  inputs = (UMP.Descendants("Input")),
                                  outputs = UMP.Descendants("Output"),
                                  feedbacks = UMP.Descendants("Feedback"),
                                  productprocessinfo = UMP.Descendants("ProductProcessInformation"),
                                  resourceinfo = UMP.Descendants("ResourceInformation"),
                                  equations = UMP.Element("Transformation").Descendants("Equation"),
                                  //equationVariables = UMP.Element("Transformation").Descendants("EquationVariables")
                              };


                //List<UMP> umps = new List<UMP>();
                foreach (var umpVar in umpsVar)
                {
                    //foreach (var equation in umpVar.transformation)
                    UMP tmpUMP = new UMP(umpVar.name, umpVar.type, umpVar.description);
                    var inputsVar = from input in umpVar.inputs
                                    select new
                                    {
                                        name = Convert.ToString(input.Attribute("name").Value),
                                        correspondingVar = Convert.ToString(input.Value)
                                    };
                    var outputsVar = from output in umpVar.outputs
                                     select new
                                     {
                                         name = Convert.ToString(output.Attribute("name").Value),
                                         correspondingVar = Convert.ToString(output.Value)
                                     };
                    var feedbackVar = from feedback in umpVar.feedbacks
                                      select new
                                      {
                                          name = Convert.ToString(feedback.Attribute("name").Value),
                                          correspondingVar = Convert.ToString(feedback.Value)
                                      };
                    var productprocessinfoVar = from productprocessinfo in umpVar.productprocessinfo
                                                select new
                                                {
                                                    name = Convert.ToString(productprocessinfo.Attribute("name").Value),
                                                    correspondingVar = Convert.ToString(productprocessinfo.Value)
                                                };
                    var resourceinfoVar = from resourceinfo in umpVar.resourceinfo
                                          select new
                                          {
                                              name = Convert.ToString(resourceinfo.Attribute("name").Value),
                                              correspondingVar = Convert.ToString(resourceinfo.Value)
                                          };
                    var umpEqsVar = from eq in umpVar.equations
                                    select new
                                    {
                                        category = (eq.Attribute("category") == null) ? "" : Convert.ToString(eq.Attribute("category").Value),
                                        descr = (eq.Attribute("description") == null) ? "" : Convert.ToString(eq.Attribute("description").Value),
                                        equation = Convert.ToString(eq.Value)
                                    };
                    Dictionary<String, String> nameVarDic = new Dictionary<string, string>();
                    foreach (var inputVal in inputsVar)
                    {
                        if (nameVarDic.ContainsKey(inputVal.correspondingVar))
                        {
                            Console.WriteLine("ERROR: " + inputVal.correspondingVar + " has already been defined!");
                        }
                        else
                        {
                            tmpUMP.AddInput(inputVal.name);
                            if (!inputVal.correspondingVar.Equals(""))
                                nameVarDic.Add(inputVal.correspondingVar, inputVal.name);
                        }
                    }
                    foreach (var outputVal in outputsVar)
                    {
                        if (nameVarDic.ContainsKey(outputVal.correspondingVar))
                        {
                            Console.WriteLine("ERROR: " + outputVal.correspondingVar + " has already been defined!");
                        }
                        else
                        {
                            tmpUMP.AddOutput(outputVal.name);
                            if (!outputVal.correspondingVar.Equals(""))
                                nameVarDic.Add(outputVal.correspondingVar, outputVal.name);
                        }
                    }
                    foreach (var feedbackVal in feedbackVar)
                    {
                        if (nameVarDic.ContainsKey(feedbackVal.correspondingVar))
                        {
                            Console.WriteLine("ERROR: " + feedbackVal.correspondingVar + " has already been defined!");
                        }
                        else
                        {
                            tmpUMP.AddFeedback(feedbackVal.name);
                            if (!feedbackVal.correspondingVar.Equals(""))
                                nameVarDic.Add(feedbackVal.correspondingVar, feedbackVal.name);
                        }
                    }
                    foreach (var productProcessVal in productprocessinfoVar)
                    {
                        if (nameVarDic.ContainsKey(productProcessVal.correspondingVar))
                        {
                            Console.WriteLine("ERROR: " + productProcessVal.correspondingVar + " has already been defined!");
                        }
                        else
                        {
                            tmpUMP.AddProductProcessInfo(productProcessVal.name);
                            if (!productProcessVal.correspondingVar.Equals(""))
                                nameVarDic.Add(productProcessVal.correspondingVar, productProcessVal.name);
                        }
                    }

                    foreach (var resourceinfoVal in resourceinfoVar)
                    {
                        if (nameVarDic.ContainsKey(resourceinfoVal.correspondingVar))
                        {
                            Console.WriteLine("ERROR: " + resourceinfoVal.correspondingVar + " has already been defined!");
                        }
                        else
                        {
                            tmpUMP.AddResourceInfo(resourceinfoVal.name);
                            if (!resourceinfoVal.correspondingVar.Equals(""))
                                nameVarDic.Add(resourceinfoVal.correspondingVar, resourceinfoVal.name);
                        }
                    }

                    //Read the Equation Variables that is the full set of variables of all equations
                    //List<String> eqVariables = new List<string>();
                    //foreach (var umpEqVariable in umpVar.equationVariables)
                    //    eqVariables.Add(umpEqVariable.Value);
                    //Read each equation and set the variables
                    foreach (var umpEq in umpEqsVar)
                    {
                        UMPEquation umpEquation = new UMPEquation(umpEq.category, umpEq.descr, umpEq.equation);
                        //Remove any internal variable from the list of equation variables that we show to user
                        foreach (string ivar in tmpUMP.internalVars.Keys)
                            umpEquation.eqVars.Remove(ivar);
                        tmpUMP.AddEquation(umpEquation);
                        tmpUMP.internalVars.Add(umpEquation.internalVar.Key, 0.0);
                    }

                    tmpUMP.setNameVarDic(nameVarDic);
                    if(!IsRepetitive(tmpUMP))
                        umpList.Add(tmpUMP);
                }
                Console.WriteLine("After reading " + umpList.Count + " UMPs");
                //Let's see

                //read each UMP equation and convert to string then dynamically set that string equal to a defined variable of the same name.
                /*foreach (var UMPVar in umpsVar)
                {
                    List<String> eqVariable = new List<string>();
                    var vartable = new Dictionary<string, eqVariable>();
                    vartable[strLine] = new eqVariable(input);


                   //foreach (var eqVariable in eqVariable) ;
                        //new equationVar = eqVariable();

                    //Read each equa tion and set the variables
//                    foreach (var linkingeq in linkingeqVar)
  //                  linkingList.Add(link);
                }*/
                //read the linking element data and prepare it for binding to XAML GUI

                var linkingVar = from linkingAction in testXML.Descendants("Linking").Descendants("LinkingAction")
                                 select new
                                 {
                                     targetUMP = Convert.ToString(linkingAction.Attribute("targetUMP").Value),
                                     sourceUMP = Convert.ToString(linkingAction.Attribute("sourceUMP").Value),
                                     descr = (linkingAction.Attribute("description") == null) ? "" : Convert.ToString(linkingAction.Attribute("description").Value),
                                     transformation = linkingAction.Descendants("Transformation")
                                 };


                //List<LinkingAction> Linking = new List<LinkingAction>();
                foreach (var linkingAction in linkingVar)
                {
                    Link link = new Link(linkingAction.targetUMP, linkingAction.sourceUMP, linkingAction.descr);
                    //foreach (var equation in LinkingAction.transformation)
                    var transforamtionVar = from trans in linkingAction.transformation
                                            select new
                                            {
                                                //targetUMP = Convert.ToString(trans.Attribute("targetUMP").Value),
                                                targetInput = Convert.ToString(trans.Attribute("targetInput").Value),
                                                //sourceUMP = Convert.ToString(trans.Attribute("sourceUMP").Value),
                                                sourceOutput = Convert.ToString(trans.Attribute("sourceOutput").Value),
                                                descr = (trans.Attribute("description") == null) ? "" : Convert.ToString(trans.Attribute("description").Value),
                                                equations = trans.Descendants("Equation"),
                                                equationVariables = trans.Descendants("EquationVariables")
                                            };
                    foreach (var transElement in transforamtionVar)
                    {
                        Transformation transformation = new Transformation(transElement.sourceOutput, transElement.targetInput, transElement.descr);
                        var transformEquations = from eq in transElement.equations
                                                 select new
                                                 {
                                                     descr = (eq.Attribute("description") == null) ? "" : Convert.ToString(eq.Attribute("description").Value),
                                                     equation = eq.Value
                                                 };
                        //Read the Equation Variables that is the full set of variables of all equations
                        List<String> eqVariables = new List<string>();
                        Dictionary<String, String> nameVarDic = new Dictionary<string, string>();
                        foreach (var linkVarName in transElement.equationVariables)
                        {
                            if (nameVarDic.ContainsKey(linkVarName.Value))
                            {
                                Console.WriteLine("ERROR: " + linkVarName.Value + " has already been defined!");
                            }
                            else
                            {
                                eqVariables.Add(linkVarName.Value);
                                string descr = (linkVarName.Attribute("description") == null) ? "" : Convert.ToString(linkVarName.Attribute("description").Value);
                                if (!descr.Equals(""))
                                    nameVarDic.Add(linkVarName.Value, descr);
                            }
                        }
                        //Read each equation and set the variables
                        foreach (var linkingeq in transformEquations)
                            transformation.AddEquation(new LinkEquation(linkingeq.descr, linkingeq.equation));
                        transformation.setNameVarDic(nameVarDic);
                        link.AddTransformation(transformation);

                    }
                    linkingList.Add(link);
                }
                composedSystems.Add(new ComposedSystem(umpList, linkingList));
            }
        }

        /*public void readComposedSystem()
        {
            foreach (string filename in getXMLFiles(folderPath))//for each XML file
            {
                //ComposedSystem cSys = new ComposedSystem()
                docNav = new XPathDocument(filename);
                // Create a navigator to query with XPath.
                nav = docNav.CreateNavigator();
                Object ump = nav.Select("/ComposedSystem/UMPs/UMP");
                Object input = nav.Select("/ComposedSystem/UMPs/UMP/Input");
                
            }
        }*/
        private void readSustainabilityKeywordPairs()
        {
            string line;
            StreamReader file = new StreamReader(sustainabilityPath);
            while ((line = file.ReadLine()) != null)
            {
                string[] splits = line.Split(',');
                if (sustainabilityKeywordListPairs.ContainsKey(splits[1]))
                {
                    sustainabilityKeywordListPairs[splits[1]].Add(splits[0]);
                }
                else
                {
                    List<String> mappedVars = new List<string>();
                    mappedVars.Add(splits[0]);
                    sustainabilityKeywordListPairs.Add(splits[1], mappedVars);
                }
            }
        }

        private bool IsRepetitive(UMP tmpUMP)
        {
            foreach (UMP tmpU in umpList)
            {
                if (tmpU.name.Equals(tmpUMP.name))
                    return true;
            }
            return false;
        }
    }
}
