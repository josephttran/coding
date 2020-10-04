using System;
using System.Collections.Generic;
using System.Text;

namespace Code
{
    public class StringTopic
    {
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
