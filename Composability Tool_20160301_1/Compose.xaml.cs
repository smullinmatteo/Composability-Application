using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Composability_Tool_20160301
{
    /// <summary>
    /// Interaction logic for Compose.xaml
    /// </summary>
    public partial class Compose : Page
    {
        XMLReader xmlreader;
        public string SourceValue { get; set; }
        public bool targetUMPSelectionFlag = false;
        public bool sourceUMPSelectionFlag = false;
        public ObservableCollection<eqVariable> sourceVarList { get; private set; }
        public ObservableCollection<eqVariable> targetVarList { get; private set; }
        public ObservableCollection<eqVariable> linkVarList { get; private set; }
        public List<UMP> myUMPs { get; set; }
        public List<LinkEquation> myLinks { get; set; }
        public Compose()
        {
            InitializeComponent();
            xmlreader = new XMLReader();
            xmlreader.readComposedSystem();
            loadUMPs();
            //loadLinks();
        }

        private void loadUMPs()
        {
            myUMPs = xmlreader.umpList;
            //myUMPs = new ObservableCollection<UMP>();
            //myUMPs.Add(new UMP("name", "type", "desc"));
            //SourceUMP.Items.Add(new UMP() { name = "name1" , type = "type1"});
            SourceUMP.DataContext = this;
            TargetUMP.DataContext = this;
        }
        private void loadLinks()
        {
            LinkingAction.ItemsSource = null;
            myLinks = new List<LinkEquation>();
            if (SourceUMP.SelectedValue != null && TargetUMP.SelectedValue != null)
            {
                foreach (Link link in xmlreader.linkingList)
                {
                    if (link.compareSourceTarget(((UMP)SourceUMP.SelectedValue).name, ((UMP)TargetUMP.SelectedValue).name))
                    {
                        myLinks.AddRange(link.equations);
                    }
                }
            }
            LinkingAction.DataContext = this;
            LinkingAction.ItemsSource = myLinks;
        }
        public void DynamicSourceUMPValues()
        {
            //SourceUMPParameters_ItemsControl.ItemsSource = null;
            HashSet<String> items = new HashSet<String>();
            UMP ump = (UMP)SourceUMP.SelectedValue;

            if (ump != null)
            {
                foreach (UMPEquation eq in ump.equations)
                {
                    foreach (string variable in eq.getEqVar())
                    {
                        if (ump.nameVarDic.ContainsKey(variable))
                            items.Add(ump.nameVarDic[variable]);
                        else
                            items.Add(variable);
                    }
                }

                /*
                items.AddRange(ump.inputList);
                items.AddRange(ump.productProcessInfoList);
                items.AddRange(ump.resourceInfoList);
                //SourceUMPParameters_ItemsControl.ItemsSource = items;
                */
                ButtonChain_1.Visibility = System.Windows.Visibility.Visible;
                ButtonChain_1.Content = ((UMP)SourceUMP.SelectedValue).name.ToString();

            }
            sourceVarList = new ObservableCollection<eqVariable>();
            foreach (string p in items)
                sourceVarList.Add(new eqVariable(p));
            SourceUMPParameters_ItemsControl.DataContext = null;
            SourceUMPParameters_ItemsControl.DataContext = this;
        }

        public void DynamicTargetUMPValues()
        {
            TargetUMPParameters_ItemsControl.DataContext = null;
            HashSet<String> items = new HashSet<String>();
            UMP ump = (UMP)TargetUMP.SelectedValue;
            if (ump != null)
            {
                foreach (UMPEquation eq in ump.equations)
                {
                    foreach (string variable in eq.getEqVar())
                    {
                        if (ump.nameVarDic.ContainsKey(variable))
                            items.Add(ump.nameVarDic[variable]);
                        else
                            items.Add(variable);
                    }
                }
                /*
                items.AddRange(ump.inputList);
                items.AddRange(ump.productProcessInfoList);
                items.AddRange(ump.resourceInfoList);
                //TargetUMPParameters_ItemsControl.ItemsSource = items;
                */
                ButtonChain_4.Visibility = System.Windows.Visibility.Visible;
                ButtonChain_4.Content = ((UMP)TargetUMP.SelectedValue).name.ToString();

            }
            targetVarList = new ObservableCollection<eqVariable>();
            foreach (string p in items)
                targetVarList.Add(new eqVariable(p));
            TargetUMPParameters_ItemsControl.DataContext = this;
        }
        public void DynamicLinkingValues()
        {
            LinkingValues_ItemsControl.DataContext = null;
            List<String> items = new List<String>();
            if (LinkingAction != null)
            {
                LinkEquation linkequation = (LinkEquation)LinkingAction.SelectedValue;
                if (linkequation != null)
                {
                    items.AddRange(linkequation.eqVars);
                    //LinkingValues_ItemsControl.ItemsSource = items;
                    ButtonChain_2.Visibility = System.Windows.Visibility.Visible;
                    ButtonChain_3.Visibility = System.Windows.Visibility.Visible;
                    ButtonChain_2.Content = ((LinkEquation)LinkingAction.SelectedValue).sourceOutput.ToString();
                    ButtonChain_3.Content = ((LinkEquation)LinkingAction.SelectedValue).targetInput.ToString();

                }
            }
            linkVarList = new ObservableCollection<eqVariable>();
            foreach (string p in items)
                linkVarList.Add(new eqVariable(p));
            LinkingValues_ItemsControl.DataContext = this;
        }

        /* public void loadLinkValues()
         {
             List<linkVar> items = new List<linkVar>();
             items.Add(new linkVar() { name = "Strength", inputName = "" });
             items.Add(new linkVar() { name = "Pressure", inputName = "" });
             items.Add(new linkVar() { name = "Length", inputName = "" });

             LinkingValues_ItemsControl.ItemsSource = items;
             TargetUMPParameters_ItemsControl.ItemsSource = items;
             SourceUMPParameters_ItemsControl.ItemsSource = items;
         }*/

        private void linkUMPs()
        {
            UMP source = (UMP)SourceUMP.SelectedValue;
            UMP target = (UMP)TargetUMP.SelectedValue;
            LinkEquation linkEquation = (LinkEquation)LinkingAction.SelectedValue;
            //link source to target using linkequation equations
            string eqStr = linkEquation.eq;
            //var interpreter = new Interpreter();
            //var result = interpreter.Eval("8 / 2 + 2");
            foreach (eqVariable eqVar in linkVarList)
            {
                if (eqStr.Contains(eqVar.name))
                    eqStr = eqStr.Replace(eqVar.name, eqVar.value.ToString());
            }
            NCalc.Expression expression = new NCalc.Expression(eqStr);
            expression.Parameters["pi"] = 3.14;
            var value = expression.Evaluate();
        }

        private void ComposeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Compose.xaml", UriKind.Relative));

        }

        private void RepositoryButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Repository.xaml", UriKind.Relative));

        }

        private void ResultsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Results.xaml", UriKind.Relative));

        }

        private void ComparisonButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Comparison.xaml", UriKind.Relative));

        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Start.xaml", UriKind.Relative));
        }
        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Help.xaml", UriKind.Relative));

        }
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("About.xaml", UriKind.Relative));
        }
        private void FeedbackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Feedback.xaml", UriKind.Relative));
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            //SaveAsButton.Visibility = System.Windows.Visibility.Visible;
            //SaveButton.Visibility = System.Windows.Visibility.Visible;
            //RunButton.Visibility = System.Windows.Visibility.Visible;
            linkUMPs();
            string composedUMPName = "";
            if (SourceUMP.SelectedValue != null && LinkingAction.SelectedValue != null && TargetUMP.SelectedValue != null)
            {
                composedUMPName = ((UMP)SourceUMP.SelectedValue).name + "_" + ((LinkEquation)LinkingAction.SelectedValue).sourceOutput + "_" + ((LinkEquation)LinkingAction.SelectedValue).targetInput + "_" + ((UMP)TargetUMP.SelectedValue).name;
                SourceUMPParameters_ItemsControl.IsTextSearchEnabled = true;
                TargetUMPParameters_ItemsControl.IsTextSearchEnabled = true;
                this.NavigationService.Navigate(new Results(composedUMPName, sourceVarList, targetVarList, linkVarList));
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "XML file (*.xml)|*.xml";
            //saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory+"composedSystemsFiles";
            //if (saveFileDialog.ShowDialog() == true)
            //File.WriteAllText(saveFileDialog.FileName, getXMLComposedSystemContent());
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "composedSystemsFiles\\" + ((UMP)SourceUMP.SelectedValue).name + "_" + ((UMP)TargetUMP.SelectedValue).name + ".xml", getXMLComposedSystemContent());
        }

        private string getXMLComposedSystemContent()
        {
            StringBuilder fileContent = new StringBuilder("<ComposedSystem>\n<UMPs>\n");
            //UMP tmpUMP = (UMP)SourceUMP.SelectedValue;
            foreach (UMP tmpUMP in new List<UMP>() { (UMP)SourceUMP.SelectedValue, (UMP)TargetUMP.SelectedValue })
            {
                fileContent.Append("<UMP name=\"" + tmpUMP.name + "\" type=\"" + tmpUMP.type + "\" description=\"" + tmpUMP.description + "\">\n");
                foreach (eqVariable param in sourceVarList)
                {
                    fileContent.Append("<Parameter name=\"" + param.name + "\" value=\"" + param.value + "\"/>\n");
                }
                fileContent.Append("<Transformation>\n");
                foreach (UMPEquation eq in tmpUMP.equations)
                {
                    //TODO: compute the equation results and write them to the file
                    //< Equation category =\"Energy\" description=\"describes the total natural gas burned \" set=\"Natural Gas\">mCH4 = ΔCHCH4 *ΔHreq*MMCH4*PUNCOMB</Equation>
                }
                fileContent.Append("</Transformation>\n");
                fileContent.Append("</UMP>\n");
            }
            fileContent.Append("</UMPs>\n</ComposedSystem>");
            return fileContent.ToString();
        }

        private void LinkUMPButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Compose_AddProcess(((UMP)TargetUMP.SelectedValue).name, targetVarList));
            //NavigationService.Navigate(new Uri("Compose_AddProcess.xaml", UriKind.Relative));
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SourceUMP.UnselectAll();
            TargetUMP.UnselectAll();
            LinkingAction.UnselectAll();
            SourceUMPParameters_ItemsControl.ItemsSource = null;
            TargetUMPParameters_ItemsControl.ItemsSource = null;
            LinkingValues_ItemsControl.ItemsSource = null;
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {

        }
        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Results.xaml", UriKind.Relative));
            /*Clicking run will navigate the user to the results page and run the results for the user. This involves skipping the run button on the results page.*/
        }
        /*protected override void (NavigationEventArgs e)
        {
            // NavigationEventArgs returns destination page
            Page destinationPage = e.Content as Page;
            if (destinationPage != null)
            {
                // Change property of destination page
                destinationPage.sourceUMPVars = "String or object..";
            }
        }*/

        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DynamicSourceUMPValues();
            sourceUMPSelectionFlag = true;
            if (targetUMPSelectionFlag)
                loadLinks();
        }

        private void targetSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DynamicTargetUMPValues();
            targetUMPSelectionFlag = true;
            if (sourceUMPSelectionFlag)
                loadLinks();
        }

        private void linkingSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DynamicLinkingValues();
        }
    }
    
}