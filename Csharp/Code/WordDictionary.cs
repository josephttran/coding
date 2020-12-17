using System;
using System.Collections.Generic;
using System.Text;

namespace Code
{
    /* Design a data structure that supports adding new words and finding if a string matches any previously added string.
     */
    public class WordDictionary
    {
        Dictionary<int, List<string>> lengthWords;

        public WordDictionary()
        {
            lengthWords = new Dictionary<int, List<string>>();
        }

        public void AddWord(string word)
        {
            int wordLength = word.Length;

            if (lengthWords.TryGetValue(wordLength, out List<string> wordList))
            {
                if (!wordList.Contains(word))
                {
                    lengthWords[wordLength].Add(word);
                }
            }
            else
            {
                List<string> list = new List<string>();
                list.Add(word);
                lengthWords.Add(wordLength, list);
            }
        }

        public bool Search(string word)
        {
            int wordLength = word.Length;

            if (lengthWords.TryGetValue(wordLength, out List<string> wordList))
            {
                foreach (string str in wordList)
                {
                    bool same = true;

                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == '.' || word[i] == str[i])
                        {
                            continue;
                        }

                        same = false;
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
