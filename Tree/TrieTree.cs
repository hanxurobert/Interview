namespace Tree {
    public class TrieTree {
        private int count = 0;
        private TrieNode root = new TrieNode();

        public void Add(string s) {
            root.Add(s, 0);
        }
        public int FindCount(string s) {
            int index = 0;
            char currentChar = s[index];
            var childNode = root.GetChildNode(currentChar);
            while(childNode != null && index < s.Length - 1) {
                index++;
                currentChar = s[index];
                childNode = childNode.GetChildNode(currentChar);
            }
            return childNode == null ? 0 : childNode.Count;
        }
    }

    public class TrieNode {
        private const int NUMBER_OF_CHARACTER = 26;
        private TrieNode[] children = new TrieNode[NUMBER_OF_CHARACTER];

        public int Count { get; set; }
         

        public void Add(string s, int index) { 
            if (index == s.Length) { return; }
            Count++;
            char current = s[index];
            var child = GetChildNode(current);
            if (child == null) {
                child = new TrieNode();
                child.Count = 1;
                setNode(current, child);
            }
            child.Add(s, index + 1);
        }
        public TrieNode GetChildNode(char c) {
            return children[getCharIndex(c)];
        }

        private void setNode(char c, TrieNode node) {
            children[getCharIndex(c)] = node;
        }
        private int getCharIndex(char c) {
            return c - 'a';
        }
    }
}