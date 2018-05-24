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
        public Stack<Node<T>> Open;

        public IterativeDeepening()
        {
            Name = "Iterative-Deepening Search";
            Open = new Stack<Node<T>>();
        }

        private void InitSearch(Node<T> Root)
        {
            Open.Push(Root);
        }

        public (Node<T>, List<Node<T>>) Search(Node<T> Root, Node<T> Goal, int Depth = 0)
        {
            List<Node<T>> Closed = new List<Node<T>>();
            int TreeDepth = MaximumDepth(Root),
                CurrentDepth = 0;

            ValueTuple<Node<T>, List<Node<T>>> Result = new ValueTuple<Node<T>, List<Node<T>>>(Goal, Closed);

            while (CurrentDepth <= TreeDepth)
            {
                var TempResult = InternalSearch(Root, Goal, CurrentDepth);

                Result = (TempResult.Item1, TempResult.Item2);

                if (TempResult.Item3)
                    break;

                CurrentDepth++;
            }

            return Result;
        }

        private (Node<T>, List<Node<T>>, bool) InternalSearch(Node<T> Root, Node<T> Goal, int CurrentDepth)
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
                    return (Goal, Closed, true);
                }
                if (Current.Depth <= CurrentDepth)
                {
                    var _Children = Current.Children.Reverse();
                    foreach (var _Child in _Children)
                    {
                        Open.Push(_Child);
                    }
                }
            }
            return (Goal, Closed, false);
        }

        private int MaximumDepth(Node<T> Root)
        {
            int Deepest = 0;

            if (Root.Children.Count != 0)
            {
                foreach (var Child in Root.Children)
                {
                    Deepest = Math.Max(Deepest, MaximumDepth(Child));
                }
            }

            return Deepest + 1;
        }
    }
}
