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
        string folderPath = @"F:\Matteo's Computer Went to Shit\Documents\Visual Studio 2015\Composability Tool_20160301\Composability Tool_20160301\XMLFiles\";
        public List<ComposedSystem> composedSystems;
        public List<UMP> umpList;
        public List<Link> linkingList;
 

        public XMLReader()
        {
            composedSystems = new List<ComposedSystem>();
            umpList = new List<UMP>();
            linkingList = new List<Link>();
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
                                  equationVariables = UMP.Element("Transformation").Descendants("EquationVariables")
                              };

                
                //List<UMP> umps = new List<UMP>();
                foreach (var umpVar in umpsVar)
                {
                    //foreach (var equation in umpVar.transformation)
                    UMP tmpUMP = new UMP(umpVar.name, umpVar.type, umpVar.description);
                    var inputsVar = from input in umpVar.inputs select new {
                        name = Convert.ToString(input.Attribute("name").Value),
                        correspondingVar = Convert.ToString(input.Value)};
                    var outputsVar = from output in umpVar.outputs select new {
                        name = Convert.ToString(output.Attribute("name").Value),
                        correspondingVar = Convert.ToString(output.Value)
                    };
                    var feedbackVar = from feedback in umpVar.feedbacks select new {
                        name = Convert.ToString(feedback.Attribute("name").Value),
                        correspondingVar = Convert.ToString(feedback.Value)
                    };
                    var productprocessinfoVar = from productprocessinfo in umpVar.productprocessinfo select new {
                        name = Convert.ToString(productprocessinfo.Attribute("name").Value),
                        correspondingVar = Convert.ToString(productprocessinfo.Value)
                    };
                    var resourceinfoVar = from resourceinfo in umpVar.resourceinfo select new {
                        name = Convert.ToString(resourceinfo.Attribute("name").Value),
                        correspondingVar = Convert.ToString(resourceinfo.Value)
                    };
                    var umpEqsVar = from eq in umpVar.equations
                                                      select new
                                                      {
                                                          category = Convert.ToString(eq.Attribute("category").Value),
                                                          descr = Convert.ToString(eq.Attribute("description").Value),
                                                          equation = Convert.ToString(eq.Value)
                                                      };
                    Dictionary<String, String> nameVarDic = new Dictionary<string, string>();
                    foreach (var inputVal in inputsVar)
                    {
                        tmpUMP.AddInput(inputVal.name);
                        if (!inputVal.correspondingVar.Equals(""))
                            nameVarDic.Add(inputVal.correspondingVar, inputVal.name);
                    }
                    foreach (var outputVal in outputsVar) { 
                        tmpUMP.AddOutput(outputVal.name);
                        if (!outputVal.correspondingVar.Equals(""))
                            nameVarDic.Add(outputVal.correspondingVar, outputVal.name);
                    }
                    foreach (var feedbackVal in feedbackVar) { 
                        tmpUMP.AddFeedback(feedbackVal.name);
                        if (!feedbackVal.correspondingVar.Equals(""))
                            nameVarDic.Add(feedbackVal.correspondingVar, feedbackVal.name);
                    }
                    foreach (var productProcessVal in productprocessinfoVar)
                    {
                        tmpUMP.AddProductProcessInfo(productProcessVal.name);
                        if (!productProcessVal.correspondingVar.Equals(""))
                            nameVarDic.Add(productProcessVal.correspondingVar, productProcessVal.name);
                    }

                    foreach (var resourceinfoVal in resourceinfoVar)
                    {
                        tmpUMP.AddResourceInfo(resourceinfoVal.name);
                        if (!resourceinfoVal.correspondingVar.Equals(""))
                            nameVarDic.Add(resourceinfoVal.correspondingVar, resourceinfoVal.name);
                    }

                    //Read the Equation Variables that is the full set of variables of all equations
                    //List<String> eqVariables = new List<string>();
                    //foreach (var umpEqVariable in umpVar.equationVariables)
                    //    eqVariables.Add(umpEqVariable.Value);
                    //Read each equation and set the variables
                    foreach (var umpEq in umpEqsVar)
                        tmpUMP.AddEquation(new UMPEquation(umpEq.category, umpEq.descr, umpEq.equation));
                    tmpUMP.setNameVarDic(nameVarDic);
                    umpList.Add(tmpUMP);
                }
                Console.WriteLine("After reading "+ umpList.Count + " UMPs");
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
                                  targetInput = Convert.ToString(linkingAction.Attribute("targetInput").Value),
                                  sourceUMP = Convert.ToString(linkingAction.Attribute("sourceUMP").Value),
                                  sourceOutput = Convert.ToString(linkingAction.Attribute("sourceOutput").Value),
                                  descr = Convert.ToString(linkingAction.Attribute("description").Value),
                                  equations = linkingAction.Descendants("Transformation").Descendants("Equation"),
                                  equationVariables = linkingAction.Descendants("Transformation").Descendants("EquationVariables")
                                  
            
                              };


                //List<LinkingAction> Linking = new List<LinkingAction>();
                foreach (var linkingAction in linkingVar)
                {
                    Link link = new Link(linkingAction.targetUMP, linkingAction.targetInput, linkingAction.sourceUMP, linkingAction.sourceOutput, linkingAction.descr);
                    //foreach (var equation in LinkingAction.transformation)
                    var linkingeqVar = from eq in linkingAction.equations
                                    select new
                                    {
                                        targetUMP = Convert.ToString(eq.Attribute("targetUMP").Value),
                                        targetInput = Convert.ToString(eq.Attribute("targetInput").Value),
                                        sourceUMP = Convert.ToString(eq.Attribute("sourceUMP").Value),
                                        sourceOutput = Convert.ToString(eq.Attribute("sourceOutput").Value),
                                        descr = Convert.ToString(eq.Attribute("description").Value),
                                        equation = Convert.ToString(eq.Value)
                                    };

                    //Read the Equation Variables that is the full set of variables of all equations
                    List<String> eqVariables = new List<string>();
                    foreach (var linkVarName in linkingAction.equationVariables)
                        eqVariables.Add(linkVarName.Value);
                    //Read each equation and set the variables
                    foreach (var linkingeq in linkingeqVar)
                        link.AddEquation(new LinkEquation(linkingeq.targetUMP, linkingeq.targetInput, linkingeq.sourceUMP, linkingeq.sourceOutput, linkingeq.descr, linkingeq.equation));
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

    }
}
