using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Search
{
    public static class SearchAlgorithms
    {
        public static List<ISearch> GetAlgorithms()
        {
            var types = new List<ISearch>
            {
                new BreadthFirst(),
                new DepthFirst(),
                new DepthLimited(),
                new IterativeDeepening()
            };

            return types;
        }
    }
}
