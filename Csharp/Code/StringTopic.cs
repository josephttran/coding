﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        /* Given an array of strings strs, group the anagrams together. You can return the answer in any order.
         * An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
         * typically using all the original letters exactly once.
         */
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs.Length == 1)
            {
                return new List<IList<string>>() { new List<string> { strs[0] } };
            }

            IList<IList<string>> output = new List<IList<string>>();
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

            foreach (string str in strs)
            {
                char[] chars = str.ToCharArray();
                Array.Sort(chars);
                string sortedStr = string.Join("", chars);

                if (map.TryGetValue(sortedStr, out List<string> value))
                {
                    map[sortedStr].Add(str);
                }
                else
                {
                    map.Add(sortedStr, new List<string>() { str });
                }
            }

            foreach (var kv in map)
            {
                output.Add(kv.Value.Select(l => l).OrderBy(item => item).ToList());
            }

            return output;
        }

        /* Given two strings s and t , write a function to determine if t is an anagram of s.
         * The string contains only lowercase alphabets.
         */
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            Dictionary<char, int> charCounter = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (charCounter.TryGetValue(c, out int value))
                {
                    charCounter[c] = value + 1;
                }
                else
                {
                    charCounter.Add(c, 1);
                }
            }

            foreach (char c in t)
            {
                if (charCounter.TryGetValue(c, out int value))
                {
                    charCounter[c] = value - 1;
                }
                else
                {
                    charCounter.Add(c, 1);
                }
            }

            foreach (var kv in charCounter)
            {
                if (kv.Value != 0)
                {
                    return false;
                }
            }

            return true;
        }

        /* Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
         * Empty string is valid palindrome.
         */
        public bool IsPalindrome(string s)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    sb.Append(c);
                }

                if (char.IsLetter(c))
                {
                    sb.Append(char.ToLower(c));
                }
            }

            string text = sb.ToString();

            for (int i = 0; i < text.Length / 2; ++i)
            {
                if (text[i] != text[text.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        /* Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
         * An input string is valid if:
         * 1. Open brackets must be closed by the same type of brackets.
         * 2. Open brackets must be closed in the correct order.
         */
        public bool IsValidParentheses(string s)
        {
            if (s.Length == 1)
            {
                return false;
            }

            Stack stack = new Stack();

            foreach (char c in s)
            {
                if (c == '[' || c == '{' || c == '(')
                {
                    stack.Push(c);
                }
                else if (stack.Count == 0) 
                {
                    return false;
                }
                else if (c == ']')
                {
                    if ((char) stack.Peek() == '[')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (c == '}')
                {
                    if ((char) stack.Peek() == '{')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }

                }
                else if (c == ')')
                {
                    if ((char) stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return stack.Count == 0;
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

        /* Given a string s, return the longest palindromic substring in s.
         */
        public string LongestPalindrome(string s)
        {
            if (s.Length == 1)
            {
                return s;
            }

            int start = 0;
            int end = 0;

            for (int i = s.Length; i >= 0; --i)
            {
                int l = i;
                int r = i + 1;
                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    l--;
                    r++;
                }
               
                int l2 = i;
                int r2 = i;
                while (l2 >= 0 && r2 < s.Length && s[l2] == s[r2])
                {
                    l2--;
                    r2++;
                }

                int len = Math.Max(r2 - l2 - 1, r - l - 1);

                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }

            return s.Substring(start, end - start + 1);
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
