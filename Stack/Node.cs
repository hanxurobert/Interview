namespace Stack{
    public class Node {
        public Node(string value) {
            Data = value;
        }

        public string Data {get; set; }

        public Node Next { get; set; }
    }
}