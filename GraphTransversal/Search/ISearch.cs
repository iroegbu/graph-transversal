using GraphTransversal.Graph.GenericNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Search
{
    public interface ISearch<T> where T : IComparable
    {
        string Name { get; }
        (Node<T>, List<Node<T>>) Search(Node<T> Root, Node<T> Goal, int Depth = 0);
    }
}
