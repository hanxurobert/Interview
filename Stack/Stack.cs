
namespace Stack {
    public class Stack {
        public Node _top;

        public Node Pop() {
            var temp = _top;
            _top = _top.Next;
            temp.Next = null;
            return temp;
        }

        public string Peek() {
            return _top.Data;
        }

        public Node Add(string value) {
            var node = new Node(value);
            node.Next = _top;
            _top = node;

            return _top;
        }

        public bool IsEmpty() {
            return _top == null;
        }
    }
}

