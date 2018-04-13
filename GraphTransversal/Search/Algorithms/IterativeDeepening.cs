using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Search
{
    class IterativeDeepening : ISearch
    {
        public string Name { get; }

        public IterativeDeepening()
        {
            Name = "Iterative-Deepening Search";
        }
    }
}
