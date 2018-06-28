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
        public int Depth { get; set; }
        public int Cost { get; set; }
        public int TotalCost
        {
            get
            {
                if (Parent != null)
                {
                    return Parent.Cost + Cost;
                }
                else
                {
                    return Cost;
                }
            }
        }
        public NodeList<T> Children { get; set; }
        public Node<T> Parent { get; set; }

        public Node() { }
        public Node(T _data) : this(_data, null, null) { }
        public Node(T _data, Node<T> _parent) : this(_data, null, _parent) { }
        public Node(T _data, NodeList<T> _children, Node<T> _parent)
        {
            Name = _data;
            Children = _children;
            Parent = _parent;
        }

        public void AddChild(Node<T> child)
        {
            Children.Add(child);
        }

        public bool IsEqual(T Value)
        {
            return Value.CompareTo(Name) == 0;
        }
    }
}
