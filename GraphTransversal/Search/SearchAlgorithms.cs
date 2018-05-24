using GraphTransversal.Graph.GenericNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransversal.Search
{
    public static class AlgorithmFactory<T> where T: IComparable
    {
        public static List<ISearch<T>> GetAlgorithms()
        {
            var Algorithms = new List<ISearch<T>>
            {
                new DepthFirst<T>(),
                new BreadthFirst<T>(),
                new DepthLimited<T>(),
                new IterativeDeepening<T>()
            };

            return Algorithms;
        }

        public static List<string> GetAvailableAlgorithms()
        {
            throw new NotImplementedException();
        }
    }
}
