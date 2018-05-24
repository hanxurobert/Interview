using System.Collections.Generic;

namespace Tree {
    public class HeapTree {
        private int count = 0;
        private List<int> nodesArray;

        private int getParentNodeIndex(int nodeIndex){ return (nodeIndex - 1) / 2; }
        private int getLeftChildNodeIndex(int nodeIndex) { return nodeIndex * 2 + 1; }
        private int getRightChildNodeIndex(int nodeIndex) { return nodeIndex * 2 + 2; }

        private bool hasParentNode(int nodeIndex) { return getParentNodeIndex(nodeIndex) >= 0; }
        private bool hasLeftChildNode(int nodeIndex) { return getLeftChildNodeIndex(nodeIndex) < count; }
        private bool hasRightChildNode(int nodeIndex) { return getRightChildNodeIndex(nodeIndex) < count; }


        private int leftNode(int nodeIndex) { return nodesArray[getLeftChildNodeIndex(nodeIndex)]; }
        private int rightNode(int nodeIndex) { return nodesArray[getRightChildNodeIndex(nodeIndex)]; }
        private int parentNode(int nodeIndex) { return nodesArray[getParentNodeIndex(nodeIndex)]; }


        private void swap(int indexOne, int indexTwo) {
            int temp = nodesArray[indexOne];
            nodesArray[indexOne] = nodesArray[indexTwo];
            nodesArray[indexTwo] = temp;
        }

        public void AddNode(int nodeValue) {
            if (count == 0) { 
                nodesArray = new List<int> { nodeValue };
            } else {
                nodesArray.Add(nodeValue);
            }
            count++;
            int nodeIndex = count - 1;
            while(hasParentNode(nodeIndex) && parentNode(nodeIndex) > nodesArray[nodeIndex]) {
                int parentNodeIndex = getParentNodeIndex(nodeIndex);
                swap(nodeIndex, parentNodeIndex);
                nodeIndex = parentNodeIndex;
            }
        }

        public int PopNode(){
            if (count == 0) { throw new System.Exception("Heap tree is empty!!"); }
            int nodeIndex = 0;
            int nodeValue = nodesArray[0];
            nodesArray[0] = nodesArray[count - 1];
            nodesArray.RemoveAt(count -1);
            count--;
            while(hasLeftChildNode(nodeIndex)) {
                int smallerChildNodeIndex = getLeftChildNodeIndex(nodeIndex);
                if (hasRightChildNode(nodeIndex) && nodesArray[getRightChildNodeIndex(nodeIndex)] < nodesArray[smallerChildNodeIndex]) {
                    smallerChildNodeIndex = getRightChildNodeIndex(nodeIndex);
                }

                if (nodesArray[nodeIndex] > nodesArray[smallerChildNodeIndex]) {
                    swap(nodeIndex, smallerChildNodeIndex);
                    nodeIndex = smallerChildNodeIndex;
                } else {
                    break;
                }
            }

            return nodeValue;
        }

        public List<int> Items { get { return nodesArray; } }
    }
}