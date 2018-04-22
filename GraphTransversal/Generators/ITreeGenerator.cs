using GraphTransversal.Graph.GenericNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Generators.Tree
{
    interface ITreeGenerator
    {
        Node<string> Generate();
    }
}
