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

namespace Composability_Tool_20160301
{
    /// <summary>
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Page
    {
        public List<String> sourceUMPVars;
        public string composedUMPName { get; set; }

        public Results()
        {
            InitializeComponent();
            this.DataContext = this;
            composedUMPName = "Please compose two UMPs first to see the results.";
            UMPResult_TextBlock.Foreground = new SolidColorBrush(Colors.Red);
            barChart.Visibility = Visibility.Hidden;
            //we need to pass: 1. Composed name of two UMPs 2. Parameters of each UMP entered by the user
            /*string parameter = string.Empty;
            if (NavigationContext.QueryString.TryGetValue("parameter", out parameter))
            {
                this.label.Text = parameter;
            }*/
        }
        public Results(string _composedUMPName, ObservableCollection<eqVariable> sourceVarList, ObservableCollection<eqVariable> targetVarList, ObservableCollection<eqVariable> linkVarList)
        {
            InitializeComponent();
            DynamicUMPResults();
            loadBarChart();
            this.DataContext = this;
            composedUMPName = _composedUMPName;
            //we need to pass: 1. Composed name of two UMPs 2. Parameters of each UMP entered by the user
            /*string parameter = string.Empty;
            if (NavigationContext.QueryString.TryGetValue("parameter", out parameter))
            {
                this.label.Text = parameter;
            }*/
        }

        public void loadBarChart()
        {
            List<KeyValuePair<string, double>> monthlySalesList = new List<KeyValuePair<string, double>>();
            monthlySalesList.Add(new KeyValuePair<string, double>("Energy Consumption", 200));
            monthlySalesList.Add(new KeyValuePair<string, double>("GHG Emissions", 2204));
            monthlySalesList.Add(new KeyValuePair<string, double>("Water Consumption", 804));
            barChart.DataContext = monthlySalesList;
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
            
            UMPResults_ItemControl.ItemsSource = items;
        }
    }
}
