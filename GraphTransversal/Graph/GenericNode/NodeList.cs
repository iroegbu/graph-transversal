using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GraphTransversal.Graph.GenericNode
{
    public class NodeList<T> : Collection<Node<T>> where T:IComparable
    {
        public NodeList() : base() { }

        public NodeList(int Count)
        {
            for (int i = 0; i < Count; i++)
                Items.Add(default(Node<T>));
        }

        public Node<T> FindByValue(T Value)
        {
            foreach (var item in Items)
            {
                if (item.Name.Equals(Value))
                {
                    return item;
                }
            }
            throw new KeyNotFoundException("No node for given value was found.");
        }
    }
}