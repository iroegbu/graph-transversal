using GraphTransversal.Graph.GenericNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Search
{
    class BreadthFirst<T> : ISearch<T> where T : IComparable
    {
        public string Name { get; }
        public Queue<Node<T>> Open;

        public BreadthFirst()
        {
            Name = "Breadth-First Search";
            Open = new Queue<Node<T>>();
        }

        private void InitSearch(Node<T> Root)
        {
            Open.Enqueue(Root);
        }

        public (Node<T>, List<Node<T>>) Search(Node<T> Root, Node<T> Goal = null)
        {
            List<Node<T>> Closed = new List<Node<T>>();
            if (Open.Count == 0)
            {
                InitSearch(Root);
            }
            while (Open.Count != 0)
            {
                var Current = Open.Dequeue();
                Closed.Add(Current);
                if (Current.IsEqual(Goal.Name))
                {
                    return (Goal, Closed);
                }

                foreach (var _Child in Current.Children)
                {
                    Open.Enqueue(_Child);
                }
            }
            return (Goal, Closed);
        }
    }
}
