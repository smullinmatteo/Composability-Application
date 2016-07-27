using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Threading;

namespace Composability_Tool_20160301
{
    /// <summary>
    /// Interaction logic for Compose.xaml
    /// </summary>
    public partial class Compose : Page
    {
        XMLReader xmlreader;
        MathEquation mathEq;
        string folderPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Directory.GetCurrentDirectory())));
        public string SourceValue { get; set; }
        public bool targetUMPSelectionFlag = false;
        public Visibility pbarVis { get; set; }
        public bool sourceUMPSelectionFlag = false;
        public HashSet<String> allUserVariables;
        public ObservableCollection<eqVariable> sourceVarList { get; private set; }
        public ObservableCollection<eqVariable> targetVarList { get; private set; }
        public ObservableCollection<eqVariable> linkVarList { get; private set; }
        public List<UMP> myUMPs { get; set; }
        public List<Transformation> myLinks { get; set; }

        private List<Dictionary<string, double>> composeResults { get; set; }
        public Compose()
        {
            InitializeComponent();
            xmlreader = new XMLReader();
            xmlreader.readComposedSystem();
            loadUMPs();
            mathEq = new MathEquation();
            allUserVariables = new HashSet<string>();
            composeResults = null;
            pbarVis = Visibility.Hidden;
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
            Transformation.ItemsSource = null;
            myLinks = new List<Transformation>();
            if (SourceUMP.SelectedValue != null && TargetUMP.SelectedValue != null)
            {
                foreach (Link link in xmlreader.linkingList)
                {
                    if (link.compareSourceTarget(((UMP)SourceUMP.SelectedValue).name, ((UMP)TargetUMP.SelectedValue).name))
                    {
                        myLinks.AddRange(link.transformations);
                    }
                }
            }
            Transformation.DataContext = this;
            Transformation.ItemsSource = myLinks;
        }
        public void DynamicSourceUMPValues(Dictionary<string, double> presetValues)
        {
            //SourceUMPParameters_ItemsControl.ItemsSource = null;
            HashSet<string> items = new HashSet<string>();
            UMP ump = (UMP)SourceUMP.SelectedValue;
            sourceVarList = new ObservableCollection<eqVariable>();
            if (ump != null)
            {
                foreach (UMPEquation eq in ump.equations)
                {
                    //Prepare the list of equation variables that we will show to user, replace them with their specified name if available
                    foreach (string variable in eq.getEqVar())
                    {
                        eqVariable ev;
                        if (items.Contains(variable))
                            continue;
                        items.Add(variable);
                        allUserVariables.Add(variable);
                        if (ump.nameVarDic.ContainsKey(variable))
                            ev = new eqVariable(variable, ump.nameVarDic[variable], (presetValues != null)? presetValues[variable] : 0);
                        else
                            ev = new eqVariable(variable, "*"+variable, (presetValues != null) ? presetValues[variable] : 0);
                        sourceVarList.Add(ev);
                    }
                }

                /*
                items.AddRange(ump.inputList);
                items.AddRange(ump.productProcessInfoList);
                items.AddRange(ump.resourceInfoList);
                //SourceUMPParameters_ItemsControl.ItemsSource = items;
                */
                ButtonChain_1.Visibility = System.Windows.Visibility.Visible;
                ButtonChain_1.Content = ((UMP)SourceUMP.SelectedValue).presentationName.ToString();

            }
            //foreach (string p in items)
            //    sourceVarList.Add(new eqVariable());
            SourceUMPParameters_ItemsControl.DataContext = null;
            SourceUMPParameters_ItemsControl.DataContext = this;
        }

        public void DynamicTargetUMPValues(Dictionary<string, double> presetValues)
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
                            ev = new eqVariable(variable, ump.nameVarDic[variable], (presetValues != null) ? presetValues[variable] : 0);
                        else
                            ev = new eqVariable(variable, "*" + variable, (presetValues != null) ? presetValues[variable] : 0);
                        targetVarList.Add(ev);
                    }
                }
                /*
                items.AddRange(ump.inputList);
                items.AddRange(ump.productProcessInfoList);
                items.AddRange(ump.resourceInfoList);
                //TargetUMPParameters_ItemsControl.ItemsSource = items;
                */
                ButtonChain_4.Visibility = System.Windows.Visibility.Visible;
                ButtonChain_4.Content = ((UMP)TargetUMP.SelectedValue).presentationName.ToString();

            }
            TargetUMPParameters_ItemsControl.DataContext = this;
        }
        public void DynamicLinkingValues(Dictionary<string, double> presetValues)
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
                            ev = new eqVariable(variable, selectedTransformation.nameVarDic[variable], (presetValues != null) ? presetValues[variable] : 0);
                        else
                            ev = new eqVariable(variable, "*"+variable, (presetValues != null) ? presetValues[variable] : 0);
                        linkVarList.Add(ev);
                    }
                    //items.AddRange(selectedTransformation.eqVars);
                    //LinkingValues_ItemsControl.ItemsSource = items;
                    ButtonChain_2.Visibility = System.Windows.Visibility.Visible;
                    ButtonChain_3.Visibility = System.Windows.Visibility.Visible;
                    ButtonChain_2.Content = ((Transformation)Transformation.SelectedValue).sourceOutput.ToString().Substring(0,3);
                    ButtonChain_3.Content = ((Transformation)Transformation.SelectedValue).targetInput.ToString().Substring(0,3);

                }
            }
            allUserVariables = new HashSet<string>();
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
            //pbar.Visibility = Visibility.Visible;
            //AllowUIToUpdate();

            //SaveAsButton.Visibility = System.Windows.Visibility.Visible;
            //SaveButton.Visibility = System.Windows.Visibility.Visible;
            //RunButton.Visibility = System.Windows.Visibility.Visible;
            if (SourceUMP.SelectedValue == null || TargetUMP.SelectedValue == null || Transformation == null || Transformation.SelectedValue == null)
            {
                ShowError("Error\nTo continue to results be sure to select both Target and Source UMP and a linking variable");
                return;
            }
            if (composeResults == null)
            {
                composeUMPSAsynch("Finish", "");
                //ProgressBarInderminate popup = new ProgressBarInderminate();
                //popup.ShowDialog();
                /*composeResults = UMP.composeUMPs((UMP)SourceUMP.SelectedValue, (UMP)TargetUMP.SelectedValue, sourceVarList, targetVarList, linkVarList, (Transformation)Transformation.SelectedValue, xmlreader.sustainabilityKeywordListPairs);
                if(composeResults.Count == 1)//Error situation
                {
                    string errorMsg = composeResults[0].Keys.First();
                    composeResults = null;
                    ShowError(errorMsg);
                    return;
                }*/
                //popup.Close();
            }
            else {
                string composedUMPName = "";
                if (SourceUMP.SelectedValue != null && Transformation.SelectedValue != null && TargetUMP.SelectedValue != null)
                {
                    composedUMPName = ((UMP)SourceUMP.SelectedValue).name + ">" + ((Transformation)Transformation.SelectedValue).sourceOutput + ">" + ((Transformation)Transformation.SelectedValue).targetInput + ">" + ((UMP)TargetUMP.SelectedValue).name;
                    SourceUMPParameters_ItemsControl.IsTextSearchEnabled = true;
                    TargetUMPParameters_ItemsControl.IsTextSearchEnabled = true;
                    this.NavigationService.Navigate(new Results(composedUMPName, sourceVarList, targetVarList, linkVarList, composeResults));
                }
            }
            //pbar.Visibility = Visibility.Hidden;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //pbar.Visibility = Visibility.Visible;
            //AllowUIToUpdate();
            //File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "composedSystemsFiles\\" + ((UMP)SourceUMP.SelectedValue).name + "_" + ((UMP)TargetUMP.SelectedValue).name + ".xml", writeXMLComposedSystemContent());
            if (SourceUMP.SelectedValue == null || TargetUMP.SelectedValue == null || Transformation == null || Transformation.SelectedValue == null)
            {
                ShowError("Error\nTo continue saving be sure to select both Target and Source UMP and a linking variable");
                return;
            }
            string fileName = ((UMP)SourceUMP.SelectedValue).name + "_" + ((UMP)TargetUMP.SelectedValue).name;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML file (*.xml)|*.xml";
            saveFileDialog.InitialDirectory = folderPath + "\\composedSystemsFiles\\";
            if (saveFileDialog.ShowDialog() == true)
                fileName = saveFileDialog.FileName;
            if (composeResults == null)
            {
                composeUMPSAsynch("Save", fileName);
                /*composeResults = UMP.composeUMPs((UMP)SourceUMP.SelectedValue, (UMP)TargetUMP.SelectedValue, sourceVarList, targetVarList, linkVarList, (Transformation)Transformation.SelectedValue, xmlreader.sustainabilityKeywordListPairs);
                if (composeResults.Count == 1)//Error situation
                {
                    string errorMsg = composeResults[0].Keys.First();
                    composeResults = null;
                    ShowError(errorMsg);
                    return;
                }*/
            }
            else
            {
                File.WriteAllText(folderPath + "\\composedSystemsFiles\\" + ((UMP)SourceUMP.SelectedValue).name + "_" + ((UMP)TargetUMP.SelectedValue).name + ".xml", UMP.writeXMLComposedSystemContent((UMP)SourceUMP.SelectedValue, (UMP)TargetUMP.SelectedValue, ((Transformation)Transformation.SelectedValue), sourceVarList, targetVarList, linkVarList, composeResults[3], composeResults[4], null, null));
            }
            //pbar.Visibility = Visibility.Hidden;
        }

        void AllowUIToUpdate()
        {

            DispatcherFrame frame = new DispatcherFrame();

            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Render, new DispatcherOperationCallback(delegate (object parameter)

            {

                frame.Continue = false;

                return null;

            }), null);

            Dispatcher.PushFrame(frame);

        }

        private void LinkUMPButton_Click(object sender, RoutedEventArgs e)
        {
            AllowUIToUpdate();
            if (SourceUMP.SelectedValue == null || TargetUMP.SelectedValue == null || Transformation == null || Transformation.SelectedValue == null)
            {
                ShowError("Error\nTo continue linking be sure to select both Target and Source UMP and a linking variable");
                return;
            }
            if (composeResults == null)
            {
                composeUMPSAsynch("Link", "");
            }
            else
            {
                string mixedName = ((UMP)SourceUMP.SelectedValue).presentationName + "_" + ((UMP)TargetUMP.SelectedValue).name;
                this.NavigationService.Navigate(new Compose_AddProcess(((UMP)TargetUMP.SelectedValue).name, sourceVarList, targetVarList, linkVarList, mixedName, composeResults));
            }
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            myUMPs = xmlreader.umpList;
            SourceUMP.UnselectAll();
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
            SourceUMP.DataContext = null;
            SourceUMP.DataContext = this;
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
            composeResults = null;
            DynamicSourceUMPValues(null);
            sourceUMPSelectionFlag = true;
            if (targetUMPSelectionFlag)
                loadLinks();
        }

        private void targetSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            composeResults = null;
            DynamicTargetUMPValues(null);
            targetUMPSelectionFlag = true;
            if (sourceUMPSelectionFlag)
                loadLinks();
        }

        private void linkingSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            composeResults = null;
            DynamicLinkingValues(null);
        }

        private void ShowError(string errorMsg)
        {
            //pbar.Visibility = Visibility.Hidden;
            System.Windows.Forms.MessageBox.Show(errorMsg);
        }
        
        /*public void composeUMPSAsynch()
        {

            pbCalculationProgress.Value = 0;
            doneEvent = new AutoResetEvent(false);
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            //worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            List<Object> arguments = new List<object>();
            arguments.Add((UMP)SourceUMP.SelectedValue);
            arguments.Add((UMP)TargetUMP.SelectedValue);
            arguments.Add(sourceVarList);
            arguments.Add(targetVarList);
            arguments.Add(linkVarList);
            arguments.Add((Transformation)Transformation.SelectedValue);
            arguments.Add(xmlreader.sustainabilityKeywordListPairs);
            worker.RunWorkerAsync(arguments);
            doneEvent.WaitOne(1000);
        }*/

        private async void composeUMPSAsynch(string methodCallName, string fileName)
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
                arguments.Add((UMP)SourceUMP.SelectedValue);
                arguments.Add((UMP)TargetUMP.SelectedValue);
                arguments.Add(sourceVarList);
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
            switch (methodCallName) {
                case "Save":
                    File.WriteAllText(fileName, UMP.writeXMLComposedSystemContent((UMP)SourceUMP.SelectedValue, (UMP)TargetUMP.SelectedValue, (Transformation)Transformation.SelectedValue, sourceVarList, targetVarList, linkVarList, composeResults[3], composeResults[4], null, null));
                    break;
                case "Finish":
                    string composedUMPName = "";
                    if (SourceUMP.SelectedValue != null && Transformation.SelectedValue != null && TargetUMP.SelectedValue != null)
                    {
                        composedUMPName = ((UMP)SourceUMP.SelectedValue).presentationName + "_" + /*((Transformation)Transformation.SelectedValue).sourceOutput + ">" + ((Transformation)Transformation.SelectedValue).targetInput + ">" + */((UMP)TargetUMP.SelectedValue).name;
                        SourceUMPParameters_ItemsControl.IsTextSearchEnabled = true;
                        TargetUMPParameters_ItemsControl.IsTextSearchEnabled = true;
                        this.NavigationService.Navigate(new Results(composedUMPName, sourceVarList, targetVarList, linkVarList, composeResults));
                    }
                    break;
                case "Link":
                    string mixedName = ((UMP)SourceUMP.SelectedValue).presentationName + "_" + ((UMP)TargetUMP.SelectedValue).name;
                    this.NavigationService.Navigate(new Compose_AddProcess(((UMP)TargetUMP.SelectedValue).name, sourceVarList, targetVarList, linkVarList, mixedName, composeResults));
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
            UMP a = (UMP)arguments[0];
            UMP b = (UMP)arguments[1];
            ObservableCollection<eqVariable> sourceVarList1 = (ObservableCollection<eqVariable>)arguments[2];
            ObservableCollection<eqVariable> targetVarList1 = (ObservableCollection<eqVariable>)arguments[3];
            ObservableCollection<eqVariable> linkVarList1 = (ObservableCollection<eqVariable>)arguments[4];
            Transformation trans = (Transformation)arguments[5];
            Dictionary<string, List<string>> keywords = (Dictionary<string, List<string>>)arguments[6];
            limit = 100;
            int progressPercentage = Convert.ToInt32(20);
            System.Threading.Thread.Sleep(100);
            progressReport.Report(progressPercentage);
            composeResults = UMP.composeUMPs(a, b, sourceVarList1, targetVarList1, linkVarList1, trans, keywords);
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

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            sourceUMPSelectionFlag = false;
            // Create OpenFileDialog 
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = folderPath + "\\composedSystemsFiles\\";
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "XML file (*.xml)|*.xml";
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                // 1. SourceName, 2. SourceParameters, 3.TargetName, 4.TargetParameters, 5. LinkTargetInput, 6. LinkSourceOutput, 7. LinkingParameters
                List<object> loadedComposedSystem = UMP.readXMLComposedSystemAllContent(filename);
                if(loadedComposedSystem.Count != 7)
                {
                    ShowError("Corrupt or incorrectly formatted file, please choose another file to load.");
                    return;
                }
                
                foreach (UMP currUMP in myUMPs)
                {
                    bool found = false;
                    if (currUMP.name.Equals((string)loadedComposedSystem[0]))
                    {
                        SourceUMP.SelectedValue = currUMP;
                        found = true;
                    }
                    if (!found)//did not match with any UMP, it should be a composedUMP 
                    {
                        SourceUMP.DataContext = null;
                        string[] splits = ((string)loadedComposedSystem[0]).Split('_');
                        UMP composedSourceUMP = new UMP(splits[splits.Length-1], (string)loadedComposedSystem[0], "", "");
                        myUMPs = new List<UMP>();
                        myUMPs.Add(composedSourceUMP);
                        SourceUMP.SelectedValue = composedSourceUMP;
                        SourceUMP.DataContext = this;
                    }
                    if (currUMP.name.Equals((string)loadedComposedSystem[2]))
                        TargetUMP.SelectedValue = currUMP;
                }
                if (Transformation.SelectedValue == null)
                {
                    loadLinks();
                }
                foreach (Link link in xmlreader.linkingList)
                {
                    foreach (Transformation tmpTrans in link.transformations)
                    {
                        if (tmpTrans.targetInput.Equals((string)loadedComposedSystem[4]) && tmpTrans.sourceOutput.Equals((string)loadedComposedSystem[5]))
                            Transformation.SelectedValue = tmpTrans;
                    }
                }
                DynamicSourceUMPValues(((Dictionary<string, double>)loadedComposedSystem[1]));
                DynamicTargetUMPValues(((Dictionary<string, double>)loadedComposedSystem[3]));
                DynamicLinkingValues(((Dictionary<string, double>)loadedComposedSystem[6]));
            }            
        }
    }

}