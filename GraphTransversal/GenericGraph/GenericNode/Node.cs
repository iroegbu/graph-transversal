using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.GenericGraph.GenericNode
{
    public class Node<T>
    {
        public T Value { get; set; }
        public NodeList<T> Children { get; set; }

        public Node() { }
        public Node(T _data) : this(_data, null) { }
        public Node(T _data, NodeList<T> _children)
        {
            Value = _data;
            Children = _children;
        }

        public void AddChild(Node<T> child)
        {
            Children.Add(child);
        }
    }
}
