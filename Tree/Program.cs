using System;
using System.Linq;
using System.Collections.Generic;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var minHeapTree = new HeapTree();
            var bstTree = new BinarySearchTree();

            List<int> items = new List<int>{48, 22, 33, 45, 67, 231, 90, 0, 12, 77};

            items.ForEach(item => {
                minHeapTree.AddNode(item);
                bstTree.AddNode(item);
            });
            Console.WriteLine("Print Binary Search Tree (TraversalTree Begin):");
            var result = TraversalTree(bstTree.Root);

            foreach (var line in result) {
                Console.WriteLine(string.Join(",", line));
            }

            Console.WriteLine("Print Binary Search Tree (TraversalTree End).");

            Console.WriteLine(string.Join(",", minHeapTree.Items));

            minHeapTree.PopNode();

            Console.WriteLine(string.Join(",", minHeapTree.Items));

            minHeapTree.AddNode(2);

            Console.WriteLine(string.Join(",", minHeapTree.Items));

            Console.WriteLine("Print Binary Search Tree (In Order):");
            bstTree.InOrderTraversal(bstTree.Root);

            Console.WriteLine("Print Binary Search Tree (Pre Order):");
            bstTree.PreOrderTraversal(bstTree.Root);

            Console.WriteLine("Print Binary Search Tree (Post Order):");
            bstTree.PostOrderTraversal(bstTree.Root);

            string[] dictionary  = new string[] { "robert", "rober", "roberthan", "rob", "pig", "dock" };
            var trieTree = new TrieTree();
            foreach(var s in dictionary) {
                trieTree.Add(s);
            }
            Console.WriteLine("Print Trie Tree:");
            Console.WriteLine(trieTree.FindCount("robe"));
        }

        private static List<List<int>> TraversalTree(Node node) {
            var left = new List<List<int>>();
            if (node.LeftNode != null){
                left = TraversalTree(node.LeftNode);
            }
            var right = new List<List<int>>();
            if (node.RightNode != null) {
                right = TraversalTree(node.RightNode);
            }
            
            return waveLists(left, right, node.Data);
        }

        private static List<List<int>> waveLists(List<List<int>> first, List<List<int>> second, int root) {
            var results = new List<List<int>>();
            if (first.Any() && second.Any()) {
                foreach(var array1 in first) {
                    foreach(var array2 in second) {
                        var result1 = new List<int>();
                        result1.Add(root);
                        result1.AddRange(array1);
                        result1.AddRange(array2);
                        results.Add(result1);
                        var result2 = new List<int>();
                        result2.Add(root);
                        result2.AddRange(array2);
                        result2.AddRange(array1);
                        results.Add(result2);
                    }
                }
            } else if (!first.Any() && !second.Any()) {
                results.Add(new List<int> { root });
            } else if (first.Any() || second.Any()) {
                var arrays = first.Any() ? first : second;
                foreach (var array in arrays) {
                    var result1 = new List<int>();
                    result1.Add(root);
                    result1.AddRange(array);
                    results.Add(result1);
                }
                    
            }
            return results;
        }
    }
}
