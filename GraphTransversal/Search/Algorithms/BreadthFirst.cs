using GraphTransversal.Graph.GenericNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Search
{
    class BreadthFirst<T> : ISearch where T : IComparable
    {
        public string Name { get; }
        public Node<T> Root;
        public Stack<Node<T>> Open;

        public BreadthFirst(Node<T> Node)
        {
            Name = "Breadth-First Search";
            Root = Node;
        }

        private void InitSearch()
        {
            Open.Push(Root);
        }

        public (Node<T>, List<Node<T>>) Search(Node<T> Goal = null)
        {
            List<Node<T>> Closed = new List<Node<T>>();
            if (Open.Count == 0)
            {
                InitSearch();
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
