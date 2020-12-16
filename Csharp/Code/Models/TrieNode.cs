namespace Code.Models
{
    public class TrieNode
    {
        private const int _alphabetSize = 26;

        public TrieNode[] Children { get; set; }
        public bool IsEnd { get; set; }

        public TrieNode()
        {
            Children = new TrieNode[_alphabetSize];
        }
    }
}
