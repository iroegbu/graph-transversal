using GraphTransversal.Graph.GenericNode;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Search.Algorithms
{
    class UniformCost<T> : ISearch<T> where T : IComparable
    {
        public string Name { get; } = "Uniform-Cost";
        public PriorityQueue<T> Open;

        public UniformCost()
        {
            Open = new PriorityQueue<T>();
        }

        private void InitSearch(Node<T> Root)
        {
            Open.Add(Root);
        }

        public (Node<T>, List<Node<T>>) Search(Node<T> Root, Node<T> Goal, int Depth = 0)
        {
            List<Node<T>> Closed = new List<Node<T>>();
            while (Open.Count != 0)
            {
                var Current = Open.Pop();
                if (Current.IsEqual(Goal.Name))
                {
                    return (Goal, Closed);
                }

                foreach (var _Child in Current.Children)
                {
                    Open.Add(_Child);
                }
            }
            return (Goal, Closed);
        }
    }

    class PriorityQueue<T> : Collection<Node<T>> where T : IComparable
    {
        public Node<T> Pop()
        {
            var node = Items.OrderBy(n => n.TotalCost).First();
            Remove(node);
            return node;
        }
    }
}
