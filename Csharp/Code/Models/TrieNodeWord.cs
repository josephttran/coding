namespace Code.Models
{
    class TrieNodeWord
    {
        private const int _alphabetSize = 26;
        
        public TrieNodeWord[] Children { get; set; }
        public string Word { get; set; }

        public TrieNodeWord()
        {
            Children = new TrieNodeWord[_alphabetSize];
        }
    }
}
