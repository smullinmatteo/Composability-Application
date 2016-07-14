using System;
using System.Collections.Generic;
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
    /// Interaction logic for Comparison.xaml
    /// </summary>
    public partial class Comparison_old : Page
    {
        public string path;
        public IEnumerable<string> composedUMPName { get; set; }
        public Comparison_old()
        {
            InitializeComponent();
            LoadComposedSystems();
        }

        public Comparison_old( string _composedUMPName)
        {
            InitializeComponent();
            path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\composedSystemsFiles\\";
            this.DataContext = this;
            //composedUMPName = _composedUMPName;
        }

        private void LoadComposedSystems()
        {
            comparisoncomboBox_1.DataContext = null;
            comparisoncomboBox_2.DataContext = null;
            comparisoncomboBox_3.DataContext = null;
            composedUMPName = Directory.GetFiles(path, "*.xml").Select(System.IO.Path.GetFileName);
            comparisoncomboBox_1.DataContext = this;
            comparisoncomboBox_2.DataContext = this;
            comparisoncomboBox_3.DataContext = this;
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

        //this section adds a sin graph for the canvas's in row 1
        private void RunComparisonButton_Click(object sender, RoutedEventArgs e)
        {
            //Dictionary<string, Dictionary<string, double>> umpSustainabilityMetrics1 = UMP.readXMLComposedSystemContent(path + comparisoncomboBox_1.SelectedValue);
            //Dictionary<string, Dictionary<string, double>> umpSustainabilityMetrics2 = UMP.readXMLComposedSystemContent(path + comparisoncomboBox_2.SelectedValue);
            //Dictionary<string, Dictionary<string, double>> umpSustainabilityMetrics3 = UMP.readXMLComposedSystemContent(path + comparisoncomboBox_3.SelectedValue);
            AddChart();
        }


        private double xmin = 0;

        private double xmax = 6.5;
        private double ymin = -1.1;
        private double ymax = 1.1;
        private Polyline polyline;
        

        private void AddChart()
        {
            // Draw sine chart:
            polyline = new Polyline { Stroke = Brushes.Black };

            for (int i = 0; i < 70; i++)
            {
                var x = i / 5.0;
                var y = Math.Sin(x);
                polyline.Points.Add(CorrespondingPoint(new Point(x, y)));
            }
            canvas_1.Children.Add(polyline);
            // Draw cosine chart:
            polyline = new Polyline
            {
                Stroke = Brushes.Black,
                StrokeDashArray = new DoubleCollection(new double[] { 4, 3 })
            };
            for (int i = 0; i < 70; i++)
            {
                var x = i / 5.0;
                var y = Math.Cos(x);
                polyline.Points.Add(CorrespondingPoint(new Point(x, y)));
            }
            canvas_1.Children.Add(polyline);
        }
        private Point CorrespondingPoint(Point pt)
        {
            var result = new Point
            {
                X = (pt.X - xmin) * canvas_1.Width / (xmax - xmin),
                Y = canvas_1.Height - (pt.Y - ymin) * canvas_1.Height
                    / (ymax - ymin)
            };
            return result;
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            comparisoncomboBox_1.SelectedIndex = -1;
            comparisoncomboBox_2.SelectedIndex = -1;
            comparisoncomboBox_1.SelectedIndex = -1;
            canvas_1.Children.Clear();
            canvas_2.Children.Clear();
            canvas_3.Children.Clear();
        }
    }
}
