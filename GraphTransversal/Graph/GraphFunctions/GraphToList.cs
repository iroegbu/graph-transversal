using GraphTransversal.Graph.GenericNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Graph.GraphFunctions
{
    public class GraphToList
    {
        public static List<Node<string>> ToList(Node<string> Root)
        {
            var ListOfNodes = new List<Node<string>>();
            var TempList = new Queue<Node<string>>();
            TempList.Enqueue(Root);
            while(TempList.Count != 0)
            {
                var temp = TempList.Dequeue();
                ListOfNodes.Add(temp);
                foreach(var Child in temp.Children)
                {
                    Child.Parent = temp;
                    TempList.Enqueue(Child);
                }
            }

            return ListOfNodes;
        }
    }
}
