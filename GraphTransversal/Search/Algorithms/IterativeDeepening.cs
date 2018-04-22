using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphTransversal.Graph.GenericNode;

namespace GraphTransversal.Search
{
    class IterativeDeepening<T> : ISearch<T> where T : IComparable
    {
        public string Name { get; }

        public IterativeDeepening()
        {
            Name = "Iterative-Deepening Search";
        }

        public (Node<T>, List<Node<T>>) Search(Node<T> Root, Node<T> Goal)
        {
            throw new NotImplementedException();
        }
    }
}
