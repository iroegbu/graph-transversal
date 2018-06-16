using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphTransversal.Graph.GenericNode;

namespace GraphTransversal.Search.Algorithms
{
    class BiDirectional<T> : ISearch<T> where T : IComparable
    {
        public string Name { get; } = "Bi-Directional Search";
        public Queue<Node<T>> OpenStart;
        public Queue<Node<T>> OpenGoal;

        public BiDirectional()
        {
            OpenStart = new Queue<Node<T>>();
            OpenGoal = new Queue<Node<T>>();
        }

        private void InitSearch(Node<T> Root)
        {
            OpenStart.Enqueue(Root);
        }

        public (Node<T>, List<Node<T>>) Search(Node<T> Root, Node<T> Goal, int Depth = 0)
        {
            OpenGoal.Enqueue(Goal);
            List<Node<T>> ClosedStart = new List<Node<T>>();
            var ClosedGoal = new List<Node<T>>();

            if (OpenStart.Count == 0)
            {
                InitSearch(Root);
            }
            while (OpenStart.Count != 0 && OpenGoal.Count != 0)
            {
                if (OpenStart.Count != 0)
                {
                    var CurrentStart = OpenStart.Dequeue();
                    if (CurrentStart.IsEqual(Goal.Name) || ClosedGoal.Contains(CurrentStart))
                    {
                        ClosedGoal.Reverse();
                        return (Goal, ClosedStart.Concat(ClosedGoal).ToList());
                    }
                    ClosedStart.Add(CurrentStart);
                    foreach (var _Child in CurrentStart.Children)
                    {
                        OpenStart.Enqueue(_Child);
                    }
                }
                if (OpenGoal.Count != 0)
                {
                    var CurrentGoal = OpenGoal.Dequeue();
                    if (CurrentGoal.IsEqual(Root.Name) || ClosedStart.Contains(CurrentGoal))
                    {
                        ClosedGoal.Reverse();
                        return (Goal, ClosedStart.Concat(ClosedGoal).ToList());
                    }
                    ClosedGoal.Add(CurrentGoal);
                    OpenGoal.Enqueue(CurrentGoal.Parent);
                }
            }
            return (Goal, ClosedStart);
        }
    }
}
