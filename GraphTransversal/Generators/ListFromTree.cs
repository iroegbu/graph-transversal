using GraphTransversal.Graph.GenericNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Generators
{
    class ListFromTree<T> where T : IComparable
    {
        public static List<Node<T>> ToList(Node<T> Root)
        {
            var Nodes = new List<Node<T>>();
            Stack<Node<T>> UnProcessed = new Stack<Node<T>>();

            Nodes.Add(Root);
            var Parent = Root;
            while (UnProcessed.Count != 0)
            {
                foreach(var Child in Parent.Children)
                {
                    Child.Parent = Parent;
                    Nodes.Add(Child);
                    foreach(var _Child in Child.Children)
                    {
                        UnProcessed.Push(_Child);
                    }
                }
            }
            return Nodes;
        }
    }
}
