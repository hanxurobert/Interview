using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class Graph {
        private Dictionary<string, GraphNode> nodes = new Dictionary<string, GraphNode>();

        public GraphNode GetOrCreateNode(string name) {
            if (!nodes.ContainsKey(name)) {
                var node = new GraphNode(name);
                nodes.Add(name, node);
            }
            return nodes[name];
        }

        public void AddEdge(string startName, string endName) {
            var start = GetOrCreateNode(startName);
            var end = GetOrCreateNode(endName);
            start.AddNeighbor(end);
        }

        public List<GraphNode> GetNodes() { return nodes.Values.ToList(); }
    }
}