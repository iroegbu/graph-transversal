using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Search
{
    class DepthLimited : ISearch
    {
        public string Name { get; }

        public DepthLimited()
        {
            Name = "Depth-Limited Search";
        }
    }
}
