using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GraphTransversal.Search;
using GraphTransversal.Generators.Tree;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TreeContainer;
using GraphLayout;
using System.IO;
using System.Windows.Forms;
using GraphTransversal.Graph.GenericNode;

namespace GraphTransveralUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Node<string> Root;
        private ObservableCollection<ResultDataObject> SearchResult;

        public MainWindow()
        {
            InitializeComponent();
            SearchResult = new ObservableCollection<ResultDataObject>();
            ResultDtgd.ItemsSource = SearchResult;
        }

        #region Graph setup
        private void LoadGraphJSON(object sender, RoutedEventArgs e)
        {
            var Dialog = new OpenFileDialog();
            if (Dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var PathToFile = Dialog.FileName;
                if (File.Exists(PathToFile))
                {
                    string JSONString = "";
                    using (StreamReader sr = new StreamReader(PathToFile))
                    {
                        JSONString = sr.ReadToEnd();
                        Root = ParseGraph(JSONString);
                        RefreshGraph(Root);
                    }
                }
            }
        }

        private Node<string> ParseGraph(string JSONString)
        {
            var Generator = new FromJSON(JSONString);
            var _Root = Generator.Generate();
            return _Root;
        }

        private void RefreshGraph(Node<string> Root)
        {
            Tree.Clear();
            RefreshGraph(Root, null);
        }

        private void RefreshGraph(Node<string> Root, TreeContainer.TreeNode Parent)
        {
            TreeContainer.TreeNode SubTree;

            if (Parent == null)
            {
                SubTree = Tree.AddRoot(Root.Name);
            } else
            {
                SubTree = Tree.AddNode(Root.Name, Parent);
            }

            foreach (var Child in Root.Children)
            {
                RefreshGraph(Child, SubTree);
            }
        }
        #endregion

        private void SearchGraphAction(object sender, RoutedEventArgs e)
        {
            var NeedleValue = NeedleTxt.Text;
            var DepthValue = DepthTxt.Text;
            var NeedleNode = new Node<string>(NeedleValue);
            int.TryParse(DepthValue, out int Depth);

            var Algorithms = AlgorithmFactory<string>.GetAlgorithms();

            SearchResult.Clear();

            foreach (var Algorithm in Algorithms)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var Result = Algorithm.Search(Root, NeedleNode, Depth);
                watch.Stop();
                var TimeSpan = watch.Elapsed;
                DisplayResult(Algorithm.Name, TimeSpan, Result.Item2);
            }
        }

        private void DisplayResult(string AlgorithmName, TimeSpan ElapsedTime, List<Node<string>> VisitedNodes)
        {
            var TimeString = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ElapsedTime.Hours, ElapsedTime.Minutes, ElapsedTime.Seconds,
                ElapsedTime.Milliseconds);
            var Visited = string.Join(" -> ", VisitedNodes.Select(node => node.Name));
            SearchResult.Add(new ResultDataObject() { AlgorithmName = AlgorithmName, ElapsedTime = TimeString, Visited = Visited });
        }
    }

    public class ResultDataObject
    {
        public string AlgorithmName { get; set; }
        public string ElapsedTime { get; set; }
        public string Visited { get; set; }
    }
}
