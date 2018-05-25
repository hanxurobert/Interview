using System;
using System.Collections.Generic;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var minHeapTree = new HeapTree();
            var bstTree = new BinarySearchTree();

            List<int> items = new List<int>{12, 22, 33, 45, 67, 231, 90, 0, 77};

            items.ForEach(item => {
                minHeapTree.AddNode(item);
                bstTree.AddNode(item);
            });

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
        }
    }
}
