using Code.Models;

namespace Code
{
    /*  Implement a trie with insert, search, and startsWith methods.
     *  All inputs consist of lowercase letters a-z.
     *  All inputs to be non-empty strings
     */
    public class Trie
    {
        TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode currentNode = _root;

            for (int i = 0; i < word.Length; i++)
            {
                int index = word[i] - 'a';

                if (currentNode.Children[index] == null)
                {
                    currentNode.Children[index] = new TrieNode();
                }

                currentNode = currentNode.Children[index];
            }

            currentNode.IsEnd = true;
        }

        public bool Search(string word)
        {
            TrieNode currentNode = _root;

            for (int i = 0; i < word.Length; i++)
            {
                int index = word[i] - 'a';
                if (currentNode.Children[index] == null)
                {
                    return false;
                }

                currentNode = currentNode.Children[index];
            }

            if (currentNode.IsEnd)
            {
                return true;
            }

            return false;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode currentNode = _root;

            for (int i = 0; i < prefix.Length; i++)
            {
                int index = prefix[i] - 'a';
                if (currentNode.Children[index] == null)
                {
                    return false;
                }

                currentNode = currentNode.Children[index];
            }

            return true;
        }
    }
}
