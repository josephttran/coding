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

        /* Given a string S and a string T 
         * Find the minimum window in S which will contain all the characters in T in complexity O(n).
         */
        public string MinWindowSubstring(string s, string t)
        {
            if (s.Length == 0 || t.Length == 0)
            {
                return "";
            }

            Dictionary<char, int> map = new Dictionary<char, int>();
            int requiredLength = t.Length;
            int substringBegin = 0;
            int substringLength = int.MaxValue;
            int begin = 0;
            int end = 0;

            foreach (char c in t)
            {
                if (map.ContainsKey(c))
                {
                    map[c] += 1;
                }
                else
                {
                    map.Add(c, 1);
                }
            }

            while (end < s.Length)
            {
                if (map.ContainsKey(s[end]))
                {
                    map[s[end]]--;

                    if (map[s[end]] >= 0)
                    {
                        requiredLength--;
                    }
                }

                while (requiredLength == 0)
                {
                    if (end - begin < substringLength)
                    {
                        substringBegin = begin;
                        substringLength = end - begin + 1;
                    }

                    if (map.ContainsKey(s[begin]))
                    {
                        map[s[begin]]++;

                        if (map[s[begin]] > 0)
                        {
                            requiredLength++;
                        }
                    }

                    begin++;
                }

                end++;
            }

            if (substringLength != int.MaxValue)
            {
                return s.Substring(substringBegin, substringLength);
            }

            return ""; 
        }
    }
}
