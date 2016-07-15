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
    /// Interaction logic for Comparison.xaml
    /// </summary>
    public partial class Comparison : Page
    {
        public string path;
        public List<KeyValuePair<string, int>> ValueList { get; private set; }
        public IEnumerable<string> composedUMPName { get; set; }
        public string defaultImageSource { get; set; }
        public Dictionary<string, ulong> columnData { get; set; }
        public ObservableCollection<ChartLine> Lines { get; set; }

        public ObservableCollection<double> DependentValueA { get; set; }
        public ObservableCollection<double> DependentValueB { get; set; }
        public ObservableCollection<double> DependentValueC { get; set; }
        public ObservableCollection<string> IndependentValue { get; set; }
        public string[] Axes { get; set; }
        public Comparison()
        {
            InitializeComponent();
            path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))) + "\\composedSystemsFiles\\";
            //var uri = new Uri(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Images\\ISL Logo.png");
            //var bitmap = new BitmapImage(uri);
            //logoImage1.Source = bitmap;
            //defaultImageSource = "@("+System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Images\\ISL Logo.png)";
            LoadComposedSystems();
        }

        public Comparison( string _composedUMPName)
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
            string[] files = Directory.GetFiles(path, "*.xml");
            if (files != null)
                composedUMPName = files.Select(System.IO.Path.GetFileName);
            else
                composedUMPName = null;
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
            Dictionary<string, double> umpSustainabilityMetrics1 = null, umpSustainabilityMetrics2 = null, umpSustainabilityMetrics3 = null;
            int count = 0;
            if (comparisoncomboBox_1.SelectedValue != null)
            {
                umpSustainabilityMetrics1 = (UMP.readXMLComposedSystemContent(path + comparisoncomboBox_1.SelectedValue));
                count++;
            }
            if (comparisoncomboBox_2.SelectedValue != null) { 
                umpSustainabilityMetrics2 = (UMP.readXMLComposedSystemContent(path + comparisoncomboBox_2.SelectedValue));
                count++;
            }
            if (comparisoncomboBox_3.SelectedValue != null) { 
                umpSustainabilityMetrics3 = (UMP.readXMLComposedSystemContent(path + comparisoncomboBox_3.SelectedValue));
                count++;
            }
            if (count < 2)
                MessageBox.Show("Please choose at least two Composed Systems for comparison.");
            else {
                loadStackedColumnData(umpSustainabilityMetrics1, umpSustainabilityMetrics2, umpSustainabilityMetrics3);
                loadSpiderChart(umpSustainabilityMetrics1, umpSustainabilityMetrics2, umpSustainabilityMetrics3);
            }
        }
        
        private Dictionary<string, double> sumupSustainabilityMetrics(Dictionary<string, Dictionary<string, double>> umpSustainabilityMetrics)
        {
            Dictionary<string, double> sustMetrics = new Dictionary<string, double>();
            foreach(string umpS in umpSustainabilityMetrics.Keys)
            {
                foreach (string metric in umpSustainabilityMetrics[umpS].Keys) {
                    if (sustMetrics.ContainsKey(metric))
                        sustMetrics[metric] += umpSustainabilityMetrics[umpS][metric];
                    else
                        sustMetrics.Add(metric, umpSustainabilityMetrics[umpS][metric]);
                }
            }
            return sustMetrics;
        }

        private void AddChart(Dictionary<string, double> umpSustainabilityMetrics1, Dictionary<string, double> umpSustainabilityMetrics2, Dictionary<string, double> umpSustainabilityMetrics3)
        {
            /*barChart.DataContext = null;
            DataPointSeries series0 = (DataPointSeries)barChart.Series[0];
            DataPointSeries series1 = (DataPointSeries)barChart.Series[1];
            DataPointSeries series2 = (DataPointSeries)barChart.Series[2];
            series0.DataContext = umpSustainabilityMetrics1;
            series1.DataContext = umpSustainabilityMetrics2;
            series2.DataContext = umpSustainabilityMetrics3;
            barChart.DataContext = this;*/
            //columnSeries1.IndependentValuePath = "Key";
            //columnSeries1.DependentValuePath = "Value";

            // Draw sine chart:
            /*polyline = new Polyline { Stroke = Brushes.Black };

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
            canvas_1.Children.Add(polyline);*/
        }
        /*private Point CorrespondingPoint(Point pt)
        {
            var result = new Point
            {
                X = (pt.X - xmin) * canvas_1.Width / (xmax - xmin),
                Y = canvas_1.Height - (pt.Y - ymin) * canvas_1.Height
                    / (ymax - ymin)
            };
            return result;
        }*/

        private void loadStackedColumnData(Dictionary<string, double> umpSustainabilityMetrics1, Dictionary<string, double> umpSustainabilityMetrics2, Dictionary<string, double> umpSustainabilityMetrics3)
        {
            IndependentValue = new ObservableCollection<string>() { "C1", "C2", "C3" };
            List<SimpleDataValue> FirstCollection = new List<SimpleDataValue>();
            List<SimpleDataValue> SecondCollection = new List<SimpleDataValue>();
            List<SimpleDataValue> ThirdCollection = new List<SimpleDataValue>();
            Dictionary<string, double> sustMetrics = umpSustainabilityMetrics1;
            int baselineInd = 1;
            if (umpSustainabilityMetrics1 == null)
            {
                if (umpSustainabilityMetrics2 != null)
                {
                    sustMetrics = umpSustainabilityMetrics2;
                    baselineInd = 2;
                }
                else if (umpSustainabilityMetrics3 != null)
                {
                    sustMetrics = umpSustainabilityMetrics3;
                    baselineInd = 3;
                }
            }

            foreach (string metric in sustMetrics.Keys) {
                if (umpSustainabilityMetrics1 != null)//baselineInd = 1;
                    FirstCollection.Add(new SimpleDataValue("C1", 1));
                if(umpSustainabilityMetrics2 != null)
                {
                    if (baselineInd == 1)
                        SecondCollection.Add(new SimpleDataValue("C2", umpSustainabilityMetrics2[metric] / ((umpSustainabilityMetrics1[metric] == 0) ? 1 : umpSustainabilityMetrics1[metric])));
                    else//baselineInd = 2
                        SecondCollection.Add(new SimpleDataValue("C2", 1));

                }
                if(umpSustainabilityMetrics3 != null)
                {
                    if (baselineInd == 1)
                        ThirdCollection.Add(new SimpleDataValue("C3", umpSustainabilityMetrics3[metric] / ((umpSustainabilityMetrics1[metric] == 0) ? 1 : umpSustainabilityMetrics1[metric])));
                    else if (baselineInd == 2)
                        SecondCollection.Add(new SimpleDataValue("C3", umpSustainabilityMetrics3[metric] / ((umpSustainabilityMetrics2[metric] == 0) ? 1 : umpSustainabilityMetrics2[metric])));
                    else
                        ThirdCollection.Add(new SimpleDataValue("C3", umpSustainabilityMetrics3[metric]));
                }
            }
            /*if (umpSustainabilityMetrics2 != null)
            {
                foreach (string metric in umpSustainabilityMetrics2.Keys)
                    SecondCollection.Add(new SimpleDataValue("C2", umpSustainabilityMetrics2[metric]));
            }
            if (umpSustainabilityMetrics3 != null)
            {
                foreach (string metric in umpSustainabilityMetrics3.Keys)
                    ThirdCollection.Add(new SimpleDataValue("C3", umpSustainabilityMetrics3[metric]));
            }*/
            stackedColumnSeries.DataContext = null;
            stackedColumnSeries.DataContext = new ChartModel(FirstCollection, SecondCollection, ThirdCollection);
            //StackedColumnSeries.DataContext = this;

            /*this.StackedColumnSeries.DataContext = new ChartModel
            {
                FirstCollection = 
                FirstCollection = Enumerable.Range(1, 10).Select(i => new SimpleDataValue { IndependentValue = "Czujnik " + i, DependentValue = 100 }).ToList(),
                SecondCollection = Enumerable.Range(1, 10).Select(i => new SimpleDataValue { IndependentValue = "" + i, DependentValue = 200 }).ToList(),
                ThirdCollection = Enumerable.Range(1, 10).Select(i => new SimpleDataValue { IndependentValue = "" + i, DependentValue = 200 }).ToList()
            };*/
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            comparisoncomboBox_1.SelectedIndex = -1;
            comparisoncomboBox_2.SelectedIndex = -1;
            comparisoncomboBox_3.SelectedIndex = -1;
            /*foreach (DataPointSeries series in barChart.Series)
            {
                series.DataContext = null;
            }
            barChart.DataContext = null;*/
        }

        public void loadSpiderChart(Dictionary<string, double> umpSustainabilityMetrics1, Dictionary<string, double> umpSustainabilityMetrics2, Dictionary<string, double> umpSustainabilityMetrics3)
        {
            
            Dictionary<string, double> sustMetrics = umpSustainabilityMetrics1;
            if (umpSustainabilityMetrics1 == null)
            {
                if (umpSustainabilityMetrics2 != null)
                {
                    sustMetrics = umpSustainabilityMetrics2;
                }
                else if (umpSustainabilityMetrics3 != null)
                    sustMetrics = umpSustainabilityMetrics3;
            }
            Axes = new string[sustMetrics.Count];
            int ind = 0;
            var ptsA = new List<double>(Axes.Length);
            var ptsB = new List<double>(Axes.Length);
            var ptsC = new List<double>(Axes.Length);
            foreach (string metric in sustMetrics.Keys)
            {
                Axes[ind] = metric.Replace("Average", "Avg"); ind++;
                double minValue = 0, maxValue = 0;
                minValue = Math.Min((umpSustainabilityMetrics1==null)? double.MaxValue : umpSustainabilityMetrics1[metric], (umpSustainabilityMetrics2 == null) ? double.MaxValue : umpSustainabilityMetrics2[metric]);
                minValue = Math.Min(minValue, (umpSustainabilityMetrics3 == null) ? double.MaxValue : umpSustainabilityMetrics3[metric]);
                maxValue = Math.Max((umpSustainabilityMetrics1 == null) ? double.MinValue : umpSustainabilityMetrics1[metric], (umpSustainabilityMetrics2 == null) ? double.MinValue : umpSustainabilityMetrics2[metric]);
                maxValue = Math.Max(maxValue, (umpSustainabilityMetrics3 == null) ? double.MinValue : umpSustainabilityMetrics3[metric]);
                
                if(umpSustainabilityMetrics1 != null)
                    ptsA.Add((umpSustainabilityMetrics1[metric] - minValue) / (maxValue - minValue + 1));
                if (umpSustainabilityMetrics2 != null)
                    ptsB.Add((umpSustainabilityMetrics2[metric] - minValue) / (maxValue - minValue + 1));
                if (umpSustainabilityMetrics3 != null)
                    ptsC.Add((umpSustainabilityMetrics3[metric] - minValue) / (maxValue - minValue + 1));
            }
            Lines = new ObservableCollection<ChartLine>();
            if (ptsA.Count > 0) {
                Lines.Add(new ChartLine
                {
                    LineColor = Colors.Blue,
                    FillColor = Color.FromArgb(128, 0, 0, 255),
                    LineThickness = 2,
                    PointDataSource = ptsA,
                    Name = "C1"
                });
            }
            if (ptsB.Count > 0) {
                Lines.Add(new ChartLine {
                    LineColor = Colors.Red,
                    FillColor = Color.FromArgb(128, 255, 0, 0),
                    LineThickness = 2,
                    PointDataSource = ptsB,
                    Name = "C2"
                });
            }
            if (ptsC.Count > 0)
            {
                Lines.Add(new ChartLine
                {
                    LineColor = Colors.Green,
                    FillColor = Color.FromArgb(128, 0, 255, 0),
                    LineThickness = 2,
                    PointDataSource = ptsC,
                    Name = "C3"
                });
            }
            spiderChart.DataContext = null;
            spiderChart.DataContext = this;
            Console.WriteLine("Loaded Spider Chart");

        }
        private void Export_Click(object sender, RoutedEventArgs e)
        {
            if (stackedColumnSeries.DataContext == null)
            {
                MessageBox.Show("there is nothing to export");
            }
            else
            {
                Rect bounds = VisualTreeHelper.GetDescendantBounds(stackedColumnSeries);
                RenderTargetBitmap renderBitmap = new RenderTargetBitmap((int)bounds.Width, (int)bounds.Height, 96, 96, PixelFormats.Pbgra32);

                DrawingVisual isolatedVisual = new DrawingVisual();
                using (DrawingContext drawing = isolatedVisual.RenderOpen())
                {
                    drawing.DrawRectangle(Brushes.White, null, new Rect(new Point(), bounds.Size)); // Optional Background
                    drawing.DrawRectangle(new VisualBrush(stackedColumnSeries), null, new Rect(new Point(), bounds.Size));
                }

                renderBitmap.Render(isolatedVisual);

                //SpiderChart
                Rect boundsSpider = VisualTreeHelper.GetDescendantBounds(spiderChart);
                RenderTargetBitmap renderBitmapSpider = new RenderTargetBitmap((int)bounds.Width, (int)bounds.Height, 96, 96, PixelFormats.Pbgra32);

                DrawingVisual isolatedVisualSpider = new DrawingVisual();
                using (DrawingContext drawing = isolatedVisualSpider.RenderOpen())
                {
                    drawing.DrawRectangle(Brushes.White, null, new Rect(new Point(), bounds.Size)); // Optional Background
                    drawing.DrawRectangle(new VisualBrush(spiderChart), null, new Rect(new Point(), bounds.Size));
                }

                renderBitmapSpider.Render(isolatedVisualSpider);

                Microsoft.Win32.SaveFileDialog uloz_obr = new Microsoft.Win32.SaveFileDialog();
                uloz_obr.FileName = "Pic";
                uloz_obr.DefaultExt = "png";

                Nullable<bool> result = uloz_obr.ShowDialog();
                if (result == true)
                {
                    string obr_cesta = uloz_obr.FileName.Split(new String[] { ".png" }, StringSplitOptions.RemoveEmptyEntries)[0] + "_StackedBar" + ".png";

                    using (FileStream outStream = new FileStream(obr_cesta, FileMode.Create))
                    {
                        PngBitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                        encoder.Save(outStream);
                    }

                    obr_cesta = uloz_obr.FileName.Split(new String[] { ".png" }, StringSplitOptions.RemoveEmptyEntries)[0] + "_SpiderChart" + ".png";

                    using (FileStream outStream = new FileStream(obr_cesta, FileMode.Create))
                    {
                        PngBitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(renderBitmapSpider));
                        encoder.Save(outStream);
                    }
                }
            }
        }
    }
    public class SimpleDataValue
    {
        public SimpleDataValue(string metric, double v)
        {
            this.IndependentValue = metric;
            this.DependentValue = v;
        }

        public string IndependentValue { get; set; }
        public double DependentValue { get; set; }
    }

    public class ChartModel
    {
        public List<SimpleDataValue> FirstCollection { get; set; }
        public List<SimpleDataValue> SecondCollection { get; set; }
        public List<SimpleDataValue> ThirdCollection { get; set; }

        public ChartModel(List<SimpleDataValue> _A, List<SimpleDataValue> _B, List<SimpleDataValue> _C)
        {
            FirstCollection = _A;
            SecondCollection = _B;
            ThirdCollection = _C;
        }
    }
}
