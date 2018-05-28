namespace Graph
{
    public class Stack {
        private GraphNode top;

        public GraphNode Pop() {
            var temp = top;
            top = top.Next;
            temp.Next = null;
            return temp;
        }

        public string Peek() {
            return top.GetName();
        }

        public GraphNode Add(GraphNode node) {
            node.Next = top;
            top = node;
            return node;
        } 

        public bool IsEmpty() {
            return top == null;
        }
    }
}