using GraphTransversal.Graph.GenericNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Graph.BinaryNode
{
    class BinaryNode<T> : Node<T>
    {
        public BinaryNode() : base() { }
        public BinaryNode(T data) : base(data, null) { }
        public BinaryNode(T data, BinaryNode<T> left, BinaryNode<T> right)
        {
            Name = data;
            NodeList<T> children = new NodeList<T>();
            AddChild(left);
            AddChild(right);
        }

        public BinaryNode<T> Left
        {
            get
            {
                if (Children == null)
                    return null;
                else
                    return (BinaryNode<T>)Children[0];
            }
            set
            {
                if (Children == null)
                    Children = new NodeList<T>(2);

                Children[0] = value;
            }
        }

        public BinaryNode<T> Right
        {
            get
            {
                if (Children == null)
                    return null;
                else
                    return (BinaryNode<T>)Children[1];
            }
            set
            {
                if (Children == null)
                    Children = new NodeList<T>(2);

                Children[1] = value;
            }
        }
    }
}
