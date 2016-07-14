using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using WpfCharts;

namespace WpfCharts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly Random random = new Random(1234);

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            DataContext = this;

            Axes = new[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7" };

            Lines = new ObservableCollection<ChartLine> {
                                                            new ChartLine {
                                                                              LineColor = Colors.Red,
                                                                              FillColor = Color.FromArgb(128, 255, 0, 0),
                                                                              LineThickness = 2,
                                                                              PointDataSource = GenerateRandomDataSet(Axes.Length),
                                                                              Name = "Chart 1"
                                                                          },
                                                            new ChartLine {
                                                                              LineColor = Colors.Blue,
                                                                              FillColor = Color.FromArgb(128, 0, 0, 255),
                                                                              LineThickness = 2,
                                                                              PointDataSource = GenerateRandomDataSet(Axes.Length),
                                                                              Name = "Chart 2"
                                                                          }
                                                        };
        }

        public List<double> GenerateRandomDataSet(int nmbrOfPoints)
        {
            var pts = new List<double>(nmbrOfPoints);
            for (var i = 0; i < nmbrOfPoints; i++)
            {
                pts.Add(random.NextDouble());
            }
            return pts;
        }

        public string[] Axes { get; set; }
        public ObservableCollection<ChartLine> Lines { get; set; }

        private void AddLineClick(object sender, RoutedEventArgs e)
        {
            var line = new ChartLine
            {
                LineColor = Colors.Yellow,
                FillColor = Color.FromArgb(128, 255, 255, 0),
                LineThickness = 2,
                PointDataSource = GenerateRandomDataSet(Axes.Length),
                Name = "Chart " + (Lines.Count + 1)
            };
            Lines.Add(line);
        }
    }
}
