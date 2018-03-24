using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GraphTransversal.GenericGraph.GenericNode
{
    public class NodeList<T> : Collection<Node<T>>
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
                if (item.Value.Equals(Value))
                {
                    return item;
                }
            }
            throw new KeyNotFoundException("No node for given value was found.");
        }
    }
}