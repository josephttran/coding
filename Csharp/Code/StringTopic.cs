using System;
using System.Collections.Generic;
using System.Text;

namespace Code
{
    public class StringTopic
    {
        /* Given a string s that consists of only uppercase English letters, you can perform at most k operations on that string.
         * In one operation, you can choose any character of the string and change it to any other uppercase English character.
         * Find the length of the longest sub-string containing all repeating letters you can get after performing the above operations.
         */
        public int CharacterReplacementLongestRepeating(string s, int k)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            int longest = 0;
            int left = 0;

            for (int right = 0; right < s.Length; ++right)
            {
                if (!dictionary.ContainsKey(s[right]))
                {
                    dictionary[s[right]] = 1;
                }
                else
                {
                    dictionary[s[right]] += 1;
                }

                longest = Math.Max(longest, dictionary[s[right]]);

                if (right - left + 1 > k + longest)
                {
                    dictionary[s[left]] -= 1;
                    left++;
                }
            }

            return s.Length - left;
        }

        /* Given a string s, find the length of the longest substring without repeating characters.
         */
        public int LengthOfLongestSubstring(string s)
        {
            Queue<char> queue = new Queue<char>();
            int longest = 0;

            for (int i = 0; i < s.Length; ++i)
            {
                if (queue.Contains(s[i]))
                {
                    while (queue.Contains(s[i]))
                    {
                        queue.Dequeue();
                    }
                    
                }

                queue.Enqueue(s[i]);
                longest = Math.Max(longest, queue.Count);
            }

            return longest;
        }
    }
}
