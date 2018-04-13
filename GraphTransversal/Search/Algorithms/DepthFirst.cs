using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Search
{
    class DepthFirst : ISearch
    {
        public string Name { get; }

        public DepthFirst()
        {
            Name = "Depth-First Search";
        }
    }
}
