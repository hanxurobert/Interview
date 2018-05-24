namespace Stack {
    public class Queue {
        public Node _first;
        public Node _last;

        public Node Pick() {
            var temp = _first;
            _first = _first.Next;
            temp.Next = null;
            if (IsEmpty()) {
                _last = null;
            }
            return temp;
        }

        public string Peek() {
            return _first.Data;
        }

        public Node Add(string value) {
            var node = new Node(value);
            if (_last == null) {
                _last = node;
            } else {
                _last.Next = node;
                _last = _last.Next;
            }
            if (_first == null) {
                _first = node;
            }
            return _last;
        }

        public bool IsEmpty() {
            return _first == null;
        }
    }
}