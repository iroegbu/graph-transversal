using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Graph.GenericNode
{
    public class Node<T> where T : IComparable
    {
        public T Name { get; set; }
        public NodeList<T> Children { get; set; }

        public Node() { }
        public Node(T _data) : this(_data, null) { }
        public Node(T _data, NodeList<T> _children)
        {
            Name = _data;
            Children = _children;
        }

        public void AddChild(Node<T> child)
        {
            Children.Add(child);
        }

        public bool IsEqual(T Value)
        {
            return Value.CompareTo(Name) >= 0;
        }
    }
}
