using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphTransversal.Graph.GenericNode;
using Newtonsoft.Json;

namespace GraphTransversal.Generators.Tree
{
    public class FromJSON : ITreeGenerator
    {
        public string JSON { get; }
        public Node<string> RootNode;

        public FromJSON(string _JSON)
        {
            JSON = _JSON;
        }

        public Node<string> Generate()
        {
            if (RootNode == null) { Parse(); }

            return RootNode;
        }

        private void Parse()
        {
            JsonSerializer serializer = new JsonSerializer();

            RootNode = JsonConvert.DeserializeObject<Node<string>>(JSON);
        }
    }
}
