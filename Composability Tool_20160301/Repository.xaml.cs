using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Composability_Tool_20160301
{
    /// <summary>
    /// Interaction logic for Repository.xaml
    /// </summary>
    public partial class Repository : Page
    {
        public List<UMP> myUMPs { get; set; }
        public string NewUMPName { get; private set; }

        private XMLReader xmlreader;
        public Repository()
        {
            InitializeComponent();
            xmlreader = new XMLReader();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            xmlreader.readComposedSystem();
            loadUMPs();
        }

        private void loadUMPs()
        {
            myUMPs = xmlreader.umpList;
            UMPRepository_ListView.DataContext = this;
        }
        public void Add_Click(object sender, RoutedEventArgs e)
        {
            /*XDocument xDoc = new XDocument();
            string folderPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Directory.GetCurrentDirectory()))) + "\\XMLFiles\\";
            string fileName = folderPath + "\\XMLFiles\\" + NewUMPName + "_NEW.xml";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML file (*.xml)|*.xml";
            saveFileDialog.InitialDirectory = folderPath + "\\composedSystemsFiles\\";
            //if (saveFileDialog.ShowDialog() == true)
                fileName = saveFileDialog.FileName;
            File.WriteAllText(fileName, UMP.writeXMLNewXML(NewUMPName));
            System.Windows.Forms.MessageBox.Show("Done");

                        //string fileName = ("its_alive");
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "XML file (*.xml)|*.xml";
            //saveFileDialog.InitialDirectory = folderPath;
            //string folderPath = @"C:\XMLFiles\xdoc5_is_alive.xml";
            //xDoc.Save(folderPath);
            //xDoc.Save(filename, folderPath + "myxml.xml");*/
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Process.Start("http://research.engr.oregonstate.edu/isl/");
        }
        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Process.Start("http://research.engr.oregonstate.edu/isl/");
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
    }
}
