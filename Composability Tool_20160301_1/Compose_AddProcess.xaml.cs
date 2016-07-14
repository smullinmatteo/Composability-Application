using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public List<LinkEquation> myLinks { get; set; }

        public List<UMP> myUMPs { get; set;}

        public ObservableCollection<UMP> linkedUMPName { get; set; }
        public ObservableCollection<eqVariable> targetVarList { get; private set; }
        public ObservableCollection<eqVariable> sourceVarList { get; private set; }

        public Compose_AddProcess(string umpAName, ObservableCollection<eqVariable> umpAVars)
        {
            InitializeComponent();
            linkedUMPName = new ObservableCollection<UMP>();
            linkedUMPName.Add(new UMP(umpAName, "", ""));
            sourceVarList = umpAVars;
            SourceUMPParameters_ItemsControl.DataContext = this;
            LinkedUMP.DataContext = this;
            xmlreader = new XMLReader();
            xmlreader.readComposedSystem();
            loadUMPs();
            ButtonChain_1.Visibility = System.Windows.Visibility.Visible;
            ButtonChain_1.Content = (umpAName).ToString();
        }

        private void loadUMPs()
        {
            myUMPs = xmlreader.umpList;
            TargetUMP.DataContext = this;
        }

        public void DynamicTargetUMPValues()
        {
            TargetUMPParameters_ItemsControl.DataContext = null;
            List<String> items = new List<String>();
            UMP ump = (UMP)TargetUMP.SelectedValue;
            if (ump != null)
            {
                items.AddRange(ump.inputList);
                items.AddRange(ump.productProcessInfoList);
                items.AddRange(ump.resourceInfoList);
                //TargetUMPParameters_ItemsControl.ItemsSource = items;

                ButtonChain_4.Visibility = System.Windows.Visibility.Visible;
                ButtonChain_4.Content = ((UMP)TargetUMP.SelectedValue).name.ToString();

            }
            targetVarList = new ObservableCollection<eqVariable>();
            foreach (string p in items)
                targetVarList.Add(new eqVariable(p));
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
            SaveAsButton.Visibility = System.Windows.Visibility.Visible;
            SaveButton.Visibility = System.Windows.Visibility.Visible;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: should be fixed
            //SaveAsButton.Visibility = System.Windows.Visibility.Visible;
            //SaveButton.Visibility = System.Windows.Visibility.Visible;
            TargetUMP.UnselectAll();
            LinkingAction.UnselectAll();
            TargetUMPParameters_ItemsControl.ItemsSource = null;
            //TargetUMPParameters_ItemsControl.Items.Clear();
            LinkingValues_ItemsControl.ItemsSource = null;
        }

        private void targetSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DynamicTargetUMPValues();
            loadLinks();
        }

        private void loadLinks()
        {
            LinkingAction.ItemsSource = null;
            myLinks = new List<LinkEquation>();
            if (TargetUMP.SelectedValue != null)
            {
                foreach (Link link in xmlreader.linkingList)
                {
                    if (link.compareSourceTarget(linkedUMPName.First().name, ((UMP)TargetUMP.SelectedValue).name))
                    {
                        myLinks.AddRange(link.equations);
                    }
                }
            }
            LinkingAction.DataContext = this;
            LinkingAction.ItemsSource = myLinks;
        }

        private void LinkButton_Click(object sender, RoutedEventArgs e)
        {
            if (linkedUMPName.First().name != null && TargetUMP.SelectedValue != null && LinkedUMP.SelectedValue != null)
            { //if all are true, reload the page with the targetUMP now set as the sourceUMP. This allows for repeating the linking process
              //otherwise, produce a popup window
                NavigationService.Navigate(new Uri("Compose_AddProcess.xaml", UriKind.Relative));
               
            }
            else
            {
                //Window errorPopupWindow = new Window();
                //errorPopupWindow.ShowDialog();
                System.Windows.Forms.MessageBox.Show("Error\nTo continue linking be sure to select both Target and Source UMP and a linking variable");
            }

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
