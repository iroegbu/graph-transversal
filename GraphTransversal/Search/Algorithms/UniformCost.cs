using GraphTransversal.Graph.GenericNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Search.Algorithms
{
    class UniformCost<T> : ISearch<T> where T : IComparable
    {
        public string Name { get; } = "Uniform-Cost";
        public Queue<Node<T>> OpenStart;

        public UniformCost()
        {
            OpenStart = new Queue<Node<T>>();
        }

        private void InitSearch(Node<T> Root)
        {
            OpenStart.Enqueue(Root);
        }

        public (Node<T>, List<Node<T>>) Search(Node<T> Root, Node<T> Goal, int Depth = 0)
        {
            throw new NotImplementedException();
        }
    }
}
