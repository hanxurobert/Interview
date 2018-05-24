using System.Collections.Generic;
using System;

namespace Tree {
    public class BinarySearchTree {
        public Node Root { get; set; }
        public void AddNode(int nodeValue) {
            if (Root == null) {
                Root = new Node(nodeValue);
            } else {
                var currentNode = Root;
                setNodeValue(currentNode, nodeValue);
            }
        }

        public void TreeTraversal() {
            visitNode(Root);
        }

        private void setNodeValue(Node node, int nodeValue) {
            if (node.Data <= nodeValue) {
                if (node.RightNode == null) {
                    node.RightNode = new Node(nodeValue);
                } else {
                    setNodeValue(node.RightNode, nodeValue);
                }
            } else {
                if (node.LeftNode == null) {
                    node.LeftNode = new Node(nodeValue);
                } else {
                    setNodeValue(node.LeftNode, nodeValue);
                }
            }
        }

        private void visitNode(Node node) {
            if (node.LeftNode != null) {
                visitNode(node.LeftNode);
            }
            Console.WriteLine(node.Data);
            if (node.RightNode != null) {
                visitNode(node.RightNode);
            }
        }
    }

    public class Node {
        public Node(int value) { Data = value; }

        public int Data { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
    }
}