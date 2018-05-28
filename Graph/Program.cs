using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodes = findBuildOrder();
            foreach(var node in nodes) {
                Console.WriteLine(node.GetName());
            } 
            Console.WriteLine("Build path for DFS solution:");
            var stack = findBuildOrderDFS();
            while(!stack.IsEmpty()) {
                Console.WriteLine(stack.Pop().GetName());
            }           
        }

        private static List<GraphNode> findBuildOrder() {
            var graph = buildGraph();
            return orderGraphNodes(graph.GetNodes());
        }

        private static Stack findBuildOrderDFS() {
            var graph = buildGraph();
            var stack = new Stack();
            foreach(var node in graph.GetNodes()) {
                if (!node.DoDFS(stack)) {
                    return null;
                }
            }
            return stack;
        }

        private static Graph buildGraph() {
            string[] nodeNames = new string[]{ "a", "b", "c", "d", "e", "f" };
            string[,] dependencies = { { "a", "d" }, { "f", "b" }, { "b", "d" }, { "f", "a" }, { "d", "c" } };
            var graph = new Graph();
            foreach(var name in nodeNames) {
                graph.GetOrCreateNode(name);
            }

            for(var i = 0; i < dependencies.GetLength(0); i++) {
                string first = dependencies[i, 0];
                string second = dependencies[i, 1];
                graph.AddEdge(first, second);
            }
            return graph;
        }

        private static List<GraphNode> orderGraphNodes(List<GraphNode> nodes){
            GraphNode[] order = new GraphNode[nodes.Count];

            int endOfList = addNonDependent(order, nodes, 0);
            int toBeProcessed = 0;

            while (toBeProcessed < nodes.Count) {
                var current = order[toBeProcessed];
                /* if current is null, that means we have a circle dependency, 
                 * since there is no node with zero dependencies. */
                if (current == null) {
                    return null;
                }

                var children = current.GetChildren();
                foreach(var child in children) {
                    child.DecrementDependencies();
                }

                endOfList = addNonDependent(order, children, endOfList);
                toBeProcessed++;
            }

            return order.ToList();
        }

        private static int addNonDependent(GraphNode[] order, List<GraphNode> nodes, int offset) {
            foreach(var node in nodes) {
                if (node.GetDependencies() == 0) {
                    order[offset] = node;
                    offset++;
                }
            }
            return offset;
        }
    }
}
