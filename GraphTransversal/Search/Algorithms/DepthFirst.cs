using GraphTransversal.Graph.GenericNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Search
{
    class DepthFirst<T> : ISearch<T> where T : IComparable
    {
        public string Name { get; }
        public Stack<Node<T>> Open;

        public DepthFirst()
        {
            Name = "Depth-First Search";
            Open = new Stack<Node<T>>();
        }

        private void InitSearch(Node<T> Root)
        {
            Open.Push(Root);
        }

        public (Node<T>, List<Node<T>>) Search(Node<T> Root, Node<T> Goal = null, int Depth = 0)
        {
            List<Node<T>> Closed = new List<Node<T>>();
            if (Open.Count == 0)
            {
                InitSearch(Root);
            }
            while (Open.Count != 0)
            {
                var Current = Open.Pop();
                Closed.Add(Current);
                if (Current.IsEqual(Goal.Name))
                {
                    return (Goal, Closed);
                }
                var _Children = Current.Children.Reverse();
                foreach (var _Child in _Children)
                {
                    Open.Push(_Child);
                }
            }
            return (Goal, Closed);
        }
    }
}
