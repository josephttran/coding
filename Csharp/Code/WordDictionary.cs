using System.Collections.Generic;

namespace Code
{
    /* Design a data structure that supports adding new words and finding if a string matches any previously added string.
     */
    public class WordDictionary
    {
        Dictionary<int, HashSet<string>> lengthWords;

        public WordDictionary()
        {
            lengthWords = new Dictionary<int, HashSet<string>>();
        }

        public void AddWord(string word)
        {
            int wordLength = word.Length;

            if (lengthWords.TryGetValue(wordLength, out _))
            {
                lengthWords[wordLength].Add(word);
            }
            else
            {
                HashSet<string> set = new HashSet<string>();
                set.Add(word);
                lengthWords.Add(wordLength, set);
            }
        }

        public bool Search(string word)
        {
            int wordLength = word.Length;

            if (lengthWords.TryGetValue(wordLength, out _))
            {
                foreach (string str in lengthWords[wordLength])
                {
                    bool same = true;

                    for (int i = 0; i < wordLength; i++)
                    {
                        if (word[i] == '.' || word[i] == str[i])
                        {
                            continue;
                        }

                        same = false;
                        break;
                    }

                    if (same)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
