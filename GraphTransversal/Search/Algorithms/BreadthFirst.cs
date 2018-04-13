using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Search
{
    class BreadthFirst : ISearch
    {
        public string Name { get; }

        public BreadthFirst()
        {
            Name = "Breadth-First Search";
        }
    }
}
