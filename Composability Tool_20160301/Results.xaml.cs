using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCharts;

namespace Composability_Tool_20160301
{
    /// <summary>
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Page
    {
        public List<String> sourceUMPVars;
        private static string folderPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Directory.GetCurrentDirectory())));
        public string composedUMPName { get; set; }

        public Dictionary<string, double> umpSustainabilityMetrics { get; set; }
        private List<Dictionary<string, double>> composeResults { get; set; }

        public Results()
        {
            InitializeComponent();
            this.DataContext = this;
            composedUMPName = "Please compose two UMPs first to see the results.";
            UMPResult_TextBlock.Foreground = new SolidColorBrush(Colors.Red);
            
            //barChart.Visibility = Visibility.Hidden;
            //we need to pass: 1. Composed name of two UMPs 2. Parameters of each UMP entered by the user
            /*string parameter = string.Empty;
            if (NavigationContext.QueryString.TryGetValue("parameter", out parameter))
            {
                this.label.Text = parameter;
            }*/
        }

        public Results(string _composedUMPName, ObservableCollection<eqVariable> sourceVarList, ObservableCollection<eqVariable> targetVarList, ObservableCollection<eqVariable> linkVarList, List<Dictionary<string, double>> _composeResults)
        {
            InitializeComponent();
            DynamicUMPResults();
            this.DataContext = this;
            composedUMPName = _composedUMPName;
            composeResults = _composeResults;
            umpSustainabilityMetrics = new Dictionary<string, double>();
            loadTableData();
            //we need to pass: 1. Composed name of two UMPs 2. Parameters of each UMP entered by the user
            /*string parameter = string.Empty;
            if (NavigationContext.QueryString.TryGetValue("parameter", out parameter))
            {
                this.label.Text = parameter;
            }*/
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = folderPath + "\\composedSystemsFiles\\" + composedUMPName + "_Results.xml";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML file (*.xml)|*.xml";
            saveFileDialog.InitialDirectory = folderPath + "\\composedSystemsFiles\\";
            if (saveFileDialog.ShowDialog() == true)
                fileName = saveFileDialog.FileName;
            File.WriteAllText(fileName, UMP.writeXMLComposedSystemResult(composedUMPName, umpSustainabilityMetrics));
            MessageBox.Show("Done");
        }

        public void loadTableData()
        {
            if(composeResults != null && composeResults.Count > 1)
                umpSustainabilityMetrics = sumupSustainabilityMetrics(composeResults[3], composeResults[4]);
            
            /*barChart.DataContext = null;
            DataPointSeries series0 = (DataPointSeries)barChart.Series[0];
            //DataPointSeries series1 = (DataPointSeries)barChart.Series[1];
            //DataPointSeries series2 = (DataPointSeries)barChart.Series[2];
            series0.DataContext = umpSustainabilityMetrics1;
            //series1.DataContext = umpSustainabilityMetrics2;
            //series2.DataContext = umpSustainabilityMetrics3;
            barChart.DataContext = this;*/
        }

        private Dictionary<string, double> sumupSustainabilityMetrics(Dictionary<string, double> sourceUMPSustainabilityMetrics, Dictionary<string, double> targetUMPSustainabilityMetrics)
        {
            Dictionary<string, double> sustMetrics = new Dictionary<string, double>();
            foreach (string metric in sourceUMPSustainabilityMetrics.Keys)
            {
                sustMetrics.Add(metric, sourceUMPSustainabilityMetrics[metric] + targetUMPSustainabilityMetrics[metric]);
            }
            return sustMetrics;
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
            //this.NavigationService.Navigate(new Comparison(composedUMPName));

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
        public void DynamicUMPResults()
        {
            List<eqVariable> items = new List<eqVariable>();
            //items.Add(new UMPVar() { name = "Strength", inputName = "" });
            
            //UMPResults_ItemControl.ItemsSource = items;
        }
    }
}
