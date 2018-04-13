using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var Algorithms = SearchAlgorithms.GetAlgorithms();

            foreach (var algo in Algorithms)
            {
                AlgorithmCmbBx.Items.Add(algo.Name);
            }
        }

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
                        var Root = ParseGraph(JSONString);
                        RefreshGraph(Root);
                    }
                }
            }
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

        private Node<string> ParseGraph(string JSONString)
        {
            var Generator = new FromJSON(JSONString);
            var Root = Generator.Generate();
            return Root;
        }
    }
}
