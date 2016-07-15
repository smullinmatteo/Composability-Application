using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Xml;
using System.Xml.XPath;

namespace Composability_Tool_20160301
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Compose_AddProcess : Page
    {
        private XMLReader xmlreader;
        string folderPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Directory.GetCurrentDirectory())));
        public List<Transformation> myLinks { get; set; }
        public ObservableCollection<eqVariable> linkVarList { get; private set; }
        public List<UMP> myUMPs { get; set;}
        public string mixedName;
        public HashSet<String> allUserVariables;
        public ObservableCollection<UMP> linkedUMPName { get; set; }
        public ObservableCollection<eqVariable> targetVarList { get; private set; }
        public ObservableCollection<eqVariable> sourceVarList { get; private set; }
        public List<Dictionary<string, double>> composedUMPResults { get; set; }
        public List<Dictionary<string, double>> composeResults { get; set; }

        private ObservableCollection<eqVariable> umpATargetVarValues { get; set; }

        public Compose_AddProcess(string umpAName, ObservableCollection<eqVariable> umpASourceVars, ObservableCollection<eqVariable> umpATargetVars, ObservableCollection<eqVariable> umpALinkVars, string _mixedName, List<Dictionary<string, double>> _composedUMPResults)
        {
            InitializeComponent();
            mixedName = _mixedName;
            linkedUMPName = new ObservableCollection<UMP>();
            linkedUMPName.Add(new UMP(umpAName, "", mixedName));
            //sourceVarList = umpAVars;
            composedUMPResults = _composedUMPResults;
            DynamicLinkedUMPValues(umpASourceVars, umpATargetVars);
            umpATargetVarValues = umpATargetVars;
            LinkedUMP.DataContext = this;
            xmlreader = new XMLReader();
            xmlreader.readComposedSystem();
            allUserVariables = new HashSet<string>();
            
            loadUMPs();
            ButtonChain_1.Visibility = System.Windows.Visibility.Visible;
            ButtonChain_1.Content = (umpAName).ToString();
            
            
        }

        private void DynamicLinkedUMPValues(ObservableCollection<eqVariable> umpASourceVarList, ObservableCollection<eqVariable> umpATargetVarList)
        {
            SourceUMPParameters_ItemsControl.DataContext = null;
            /*Dictionary<string, eqVariable> vars = new Dictionary<string, eqVariable>();
            sourceVarList = new ObservableCollection<eqVariable>();
            for (int i = 0; i < 3; i++)
            {
                if (i == 2) continue; //don't add link variables here
                foreach (string prevItem in composedUMPResults[i].Keys)
                {
                    if (!vars.Keys.Contains(prevItem))
                    {
                        eqVariable eqv = new eqVariable(prevItem, prevItem, composedUMPResults[i][prevItem]);
                        vars.Add(prevItem, eqv);
                        sourceVarList.Add(eqv);
                    }
                    else
                    {
                        //TODO: Remove overlaps?
                        sourceVarList.Remove(vars[prevItem]);
                    }
                }
            }*/
            SourceUMPParameters_ItemsControl.DataContext = this;
        }

        private void loadUMPs()
        {
            myUMPs = xmlreader.umpList;
            TargetUMP.DataContext = this;
        }

        public void DynamicTargetUMPValues()
        {
            TargetUMPParameters_ItemsControl.DataContext = null;
            HashSet<String> items = new HashSet<String>();
            UMP ump = (UMP)TargetUMP.SelectedValue;
            targetVarList = new ObservableCollection<eqVariable>();
            if (ump != null)
            {
                foreach (UMPEquation eq in ump.equations)
                {
                    foreach (string variable in eq.getEqVar())
                    {
                        eqVariable ev;
                        if (items.Contains(variable))
                            continue;
                        items.Add(variable);
                        allUserVariables.Add(variable);
                        if (ump.nameVarDic.ContainsKey(variable))
                            ev = new eqVariable(variable, ump.nameVarDic[variable], "");
                        else
                            ev = new eqVariable(variable, variable, "");
                        targetVarList.Add(ev);
                    }
                }
                ButtonChain_4.Visibility = System.Windows.Visibility.Visible;
                ButtonChain_4.Content = ((UMP)TargetUMP.SelectedValue).name.ToString();

            }
            TargetUMPParameters_ItemsControl.DataContext = this;
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
            SaveButton.Visibility = System.Windows.Visibility.Visible;
            if (LinkedUMP.SelectedValue == null || TargetUMP.SelectedValue == null || Transformation == null || Transformation.SelectedValue == null)
            {
                ShowError("Error\nTo continue to results be sure to select both Target and Source UMP and a linking variable");
                return;
            }
            if (composeResults == null)
            {
                composeUMPSAsynch("Finish");
            }
            else {
                string composedUMPName = "";
                if (LinkedUMP.SelectedValue != null && Transformation.SelectedValue != null && TargetUMP.SelectedValue != null)
                {
                    composedUMPName = ((UMP)LinkedUMP.SelectedValue).name + "_" + ((Transformation)Transformation.SelectedValue).sourceOutput + "_" + ((Transformation)Transformation.SelectedValue).targetInput + "_" + ((UMP)TargetUMP.SelectedValue).name;
                    SourceUMPParameters_ItemsControl.IsTextSearchEnabled = true;
                    TargetUMPParameters_ItemsControl.IsTextSearchEnabled = true;
                    this.NavigationService.Navigate(new Results(composedUMPName, sourceVarList, targetVarList, linkVarList, composeResults));
                }
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            LinkedUMP.UnselectAll();
            TargetUMP.UnselectAll();
            Transformation.UnselectAll();
            SourceUMPParameters_ItemsControl.DataContext = null;
            TargetUMPParameters_ItemsControl.DataContext = null;
            allUserVariables = new HashSet<string>();
            LinkingValues_ItemsControl.DataContext = null;
            ButtonChain_1.Visibility = System.Windows.Visibility.Hidden;
            ButtonChain_1.Content = "";
            ButtonChain_2.Visibility = System.Windows.Visibility.Hidden;
            ButtonChain_2.Content = "";
            ButtonChain_3.Visibility = System.Windows.Visibility.Hidden;
            ButtonChain_3.Content = "";
            ButtonChain_4.Visibility = System.Windows.Visibility.Hidden;
            ButtonChain_4.Content = "";
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (LinkedUMP.SelectedValue == null || TargetUMP.SelectedValue == null || Transformation == null || Transformation.SelectedValue == null)
            {
                ShowError("Error\nTo continue saving be sure to select both Target and Source UMP and a linking variable");
                return;
            }
            if (composeResults == null)
            {
                composeUMPSAsynch("Save");
            }
            else {
                File.WriteAllText(folderPath + "\\composedSystemsFiles\\" + mixedName + "_" + ((UMP)TargetUMP.SelectedValue).name + ".xml", UMP.writeXMLComposedSystemContent((UMP)LinkedUMP.SelectedValue, (UMP)TargetUMP.SelectedValue, sourceVarList, targetVarList, composeResults[3], composeResults[4], composedUMPResults[5], composedUMPResults[6]));
            }
        }

        private void targetSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DynamicTargetUMPValues();
            loadLinks();
        }

        private void linkedUMPSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DynamicLinkedUMPValues(null, null);
            loadLinks();
        }

        private void loadLinks()
        {
            Transformation.ItemsSource = null;
            myLinks = new List<Transformation>();
            if (TargetUMP.SelectedValue != null && LinkedUMP.SelectedValue != null)
            {
                foreach (Link link in xmlreader.linkingList)
                {
                    if (link.compareSourceTarget(((UMP)LinkedUMP.SelectedValue).name, ((UMP)TargetUMP.SelectedValue).name))
                    {
                        myLinks.AddRange(link.transformations);
                    }
                }
            }
            Transformation.DataContext = this;
            Transformation.ItemsSource = myLinks;
        }

        public void DynamicLinkingValues()
        {
            LinkingValues_ItemsControl.DataContext = null;
            HashSet<String> items = new HashSet<String>();
            linkVarList = new ObservableCollection<eqVariable>();
            if (Transformation != null)
            {
                Transformation selectedTransformation = (Transformation)Transformation.SelectedValue;
                if (selectedTransformation != null)
                {
                    selectedTransformation.eqVars.RemoveWhere(v => allUserVariables.Contains(v));
                    foreach (string variable in selectedTransformation.getEqVar())
                    {
                        eqVariable ev;
                        if (items.Contains(variable))
                            continue;
                        items.Add(variable);
                        allUserVariables.Add(variable);
                        if (selectedTransformation.nameVarDic.ContainsKey(variable))
                            ev = new eqVariable(variable, selectedTransformation.nameVarDic[variable], "");
                        else
                            ev = new eqVariable(variable, variable, "");
                        linkVarList.Add(ev);
                    }
                    ButtonChain_2.Visibility = System.Windows.Visibility.Visible;
                    ButtonChain_3.Visibility = System.Windows.Visibility.Visible;
                    ButtonChain_2.Content = ((Transformation)Transformation.SelectedValue).sourceOutput.ToString().Substring(0, 4);
                    ButtonChain_3.Content = ((Transformation)Transformation.SelectedValue).targetInput.ToString().Substring(0, 4);
                }
            }
            allUserVariables = new HashSet<string>();
            LinkingValues_ItemsControl.DataContext = this;
        }

        private void linkingSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DynamicLinkingValues();
        }

        private void LinkButton_Click(object sender, RoutedEventArgs e)
        {
            if ((UMP)LinkedUMP.SelectedValue != null && TargetUMP.SelectedValue != null && Transformation != null && Transformation.SelectedValue != null)
            { //if all are true, reload the page with the targetUMP now set as the sourceUMP. This allows for repeating the linking process
              //otherwise, produce a popup window
                if (composeResults == null)
                {
                    composeUMPSAsynch("Link");
                }
                else {
                    string mixedName2 = mixedName + "_" + ((UMP)TargetUMP.SelectedValue).name;
                    this.NavigationService.Navigate(new Compose_AddProcess(((UMP)TargetUMP.SelectedValue).name, sourceVarList, targetVarList, linkVarList, mixedName2, composeResults));
                }
            }
            else
            {
                //Window errorPopupWindow = new Window();
                //errorPopupWindow.ShowDialog();
                ShowError("Error\nTo continue linking be sure to select both Target and Source UMP and a linking variable");
            }

        }

        private void ShowError(string errorMsg)
        {
            System.Windows.Forms.MessageBox.Show(errorMsg);
        }

        private async void composeUMPSAsynch(string methodCallName)
        {
            try
            {
                pbCalculationProgress.Visibility = Visibility.Visible;
                var cancellationTokenSource = new CancellationTokenSource();

                var limit = 10;

                var progressReport = new Progress<int>();//(i) =>
                //    pbCalculationProgress.Value = Convert.ToInt32((100 * i / (limit - 1))));

                var token = cancellationTokenSource.Token;
                List<object> arguments = new List<object>();
                arguments.Add(((UMP)LinkedUMP.SelectedValue).name);
                arguments.Add(composedUMPResults);
                arguments.Add((UMP)TargetUMP.SelectedValue);
                arguments.Add(umpATargetVarValues);
                arguments.Add(targetVarList);
                arguments.Add(linkVarList);
                arguments.Add((Transformation)Transformation.SelectedValue);
                arguments.Add(xmlreader.sustainabilityKeywordListPairs);
                await Task.Run(() =>
                    DoWork(limit, token, progressReport, arguments),
                    token);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            pbCalculationProgress.Visibility = Visibility.Hidden;
            
            switch (methodCallName)
            {
                case "Save":
                    File.WriteAllText(folderPath + "\\composedSystemsFiles\\" + mixedName + "_" + ((UMP)TargetUMP.SelectedValue).name + ".xml", UMP.writeXMLComposedSystemContent((UMP)LinkedUMP.SelectedValue, (UMP)TargetUMP.SelectedValue, sourceVarList, targetVarList, composeResults[3], composeResults[4], composedUMPResults[5], composedUMPResults[6]));
                    break;
                case "Finish":
                    string composedUMPName = "";
                    if (LinkedUMP.SelectedValue != null && Transformation.SelectedValue != null && TargetUMP.SelectedValue != null)
                    {
                        composedUMPName = ((UMP)LinkedUMP.SelectedValue).name + "_" + ((Transformation)Transformation.SelectedValue).sourceOutput + "_" + ((Transformation)Transformation.SelectedValue).targetInput + "_" + ((UMP)TargetUMP.SelectedValue).name;
                        SourceUMPParameters_ItemsControl.IsTextSearchEnabled = true;
                        TargetUMPParameters_ItemsControl.IsTextSearchEnabled = true;
                        this.NavigationService.Navigate(new Results(composedUMPName, sourceVarList, targetVarList, linkVarList, composeResults));
                    }
                    break;
                case "Link":
                    string mixedName2 = mixedName + "_" + ((UMP)TargetUMP.SelectedValue).name;
                    this.NavigationService.Navigate(new Compose_AddProcess(((UMP)TargetUMP.SelectedValue).name, sourceVarList, targetVarList, linkVarList, mixedName2, composeResults));
                    break;
                default:
                    break;
            }
        }
        private int DoWork(
            int limit,
            CancellationToken token,
            IProgress<int> progressReport,
            List<object> arguments)
        {
            string name = (string)arguments[0];
            List<Dictionary<string, double>> composedResultsA = (List<Dictionary<string, double>>)arguments[1];
            UMP b = (UMP)arguments[2];
            ObservableCollection<eqVariable> sourceVarList1 = (ObservableCollection<eqVariable>)arguments[3];
            ObservableCollection<eqVariable> targetVarList1 = (ObservableCollection<eqVariable>)arguments[4];
            ObservableCollection<eqVariable> linkVarList1 = (ObservableCollection<eqVariable>)arguments[5];
            Transformation trans = (Transformation)arguments[6];
            Dictionary<string, List<string>> keywords = (Dictionary<string, List<string>>)arguments[7];
            limit = 100;
            int progressPercentage = Convert.ToInt32(20);
            System.Threading.Thread.Sleep(100);
            progressReport.Report(progressPercentage);
            composeResults = UMP.composeUMPs(name, composedResultsA, b, sourceVarList1, targetVarList1, linkVarList1, trans, keywords);
            progressPercentage = Convert.ToInt32(80);
            System.Threading.Thread.Sleep(100);
            progressReport.Report(progressPercentage);
            if (composeResults.Count == 1)//Error situation
            {
                string errorMsg = composeResults[0].Keys.First();
                composeResults = null;
                ShowError(errorMsg);
            }
            System.Threading.Thread.Sleep(100);
            progressPercentage = Convert.ToInt32(100);
            progressReport.Report(progressPercentage);
            token.ThrowIfCancellationRequested();
            return limit;
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbCalculationProgress.Visibility = Visibility.Visible;
            //pbCalculationProgress.Value = e.ProgressPercentage;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Done");
        }

        /*public void DynamicUMPValues()
{
   List<UMPVar> items = new List<UMPVar>();
   //items.Add(new UMPVar() { name = "Strength", value = "" });

   LinkingValues_ItemsControl.ItemsSource = items;
   TargetUMPParameters_ItemsControl.ItemsSource = items;
   SourceUMPParameters_ItemsControl.ItemsSource = items;
}*/
    }
}
