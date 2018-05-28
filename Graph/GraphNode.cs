using System.Collections.Generic;
using System.Linq;

namespace Graph {
    public class GraphNode {
        private Dictionary<string, GraphNode> children = new Dictionary<string, GraphNode>();
        private string name = null;
        private int dependency = 0;
        private State NodeState { get; set; }

        public enum State
        {
            COMPLETE,
            PARTIAL,
            BLANK
        }
        public GraphNode Next { get; set; }

        public GraphNode(string name) {
            this.name = name;
            this.NodeState = State.BLANK;
        }

        public void AddNeighbor(GraphNode node) {
            if (!children.ContainsKey(node.GetName())) {
                children.Add(node.GetName(), node);
                node.IncrementDependencies();
            }
        }
        public void IncrementDependencies() { dependency++; }
        public void DecrementDependencies() { dependency--; }
        public int GetDependencies() { return dependency; }

        public string GetName() { return name; }
        public List<GraphNode> GetChildren() { return children.Values.ToList(); }
        public bool DoDFS(Stack stack) {
            // Circle
            if (NodeState == State.PARTIAL) {
                return false;
            }

            if (NodeState == State.BLANK) {
                NodeState = State.PARTIAL;

                var children = GetChildren();
                foreach(var child in children) {
                    if (!child.DoDFS(stack)) {
                        return false;
                    }
                }
                NodeState = State.COMPLETE;
                stack.Add(this);
            }
            return true;
        }
    }
}