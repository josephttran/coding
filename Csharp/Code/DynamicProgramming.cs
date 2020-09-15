﻿using System;
using System.Runtime;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Code
{
    public class DynamicProgramming
    {
        /* You are climbing a stair case. It takes n steps to reach to the top.
         * Each time you can either climb 1 or 2 steps. 
         * In how many distinct ways can you climb to the top?
         * 1 <= n <= 45
         */
        public int ClimbStairs(int n)
        {
            if ( n < 3)
            {
                return n;
            }

            int prevPrev = 1; 
            int prev = 2;
            int number = prev + prevPrev;
            int nBegin = 3;

            while (nBegin != n)
            {
                prevPrev = prev;
                prev = number;
                number = prev + prevPrev;
                nBegin++;
            }

            return number;
        }

        /* You are given coins of different denominations and a total amount of money amount. 
         * Write a function to compute the fewest number of coins that you need to make up that amount. 
         * If that amount of money cannot be made up by any combination of the coins, return -1.
         */
        public int CoinChange(int[] coins, int amount)
        {
            int[] fewestCoins = Enumerable.Repeat(amount + 1, amount + 1).ToArray();
            fewestCoins[0] = 0;

            for (int i = 0; i <= amount; ++i)
            {
                foreach (int coin in coins)
                {
                    if (i - coin > -1)
                    {
                        fewestCoins[i] = Math.Min(fewestCoins[i], fewestCoins[i - coin] + 1);
                    }
                }
            }

            if (fewestCoins[amount] < amount + 1)
            {
                return fewestCoins[amount];
            }

            return -1;
        }

        /* Given an integer array with all positive numbers and no duplicates, 
         * find the number of possible combinations that add up to a positive integer target.
         */
        public int CombinationSumIV(int[] nums, int target)
        {
            Array.Sort(nums);
            int[] dp = new int[target + 1];

            for (int i = 1; i < dp.Length; ++i)
            {
                for (int j = 0; j < nums.Length; ++j)
                {
                    if (i < nums[j])
                    {
                        break;
                    }

                    if (i == nums[j])
                    {
                        dp[i] += 1;
                    }
                    else
                    {
                        dp[i] += dp[i - nums[j]];
                    }
                }
            }

            return dp[target];
        }

        /* You are a professional robber planning to rob houses along a street. 
         * Each house has a certain amount of money stashed, 
         * the only constraint stopping you from robbing each of them is that adjacent houses have security system connected 
         * and it will automatically contact the police if two adjacent houses were broken into on the same night.
         * 
         * Given a list of non-negative integers representing the amount of money of each house, 
         * determine the maximum amount of money you can rob tonight without alerting the police.
         */
        public int HouseRobber(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            if (nums.Length == 2)
            {
                return Math.Max(nums[0], nums[1]);
            }

            int[] dp = new int[nums.Length];

            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);

            for (int i = 2; i < dp.Length; ++i)
            {
                dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);
            }

            return dp[dp.Length - 1];
        }

        /* Given two strings text1 and text2, return the length of their longest common subsequence.
         * A subsequence of a string is a new string generated from the original string with 
         * some characters(can be none) deleted without changing the relative order of the remaining characters. 
         * (eg, "ace" is a subsequence of "abcde" while "aec" is not). 
         * A common subsequence of two strings is a subsequence that is common to both strings. 
         * 
         * If there is no common subsequence, return 0.
         * The input strings consist of lowercase English characters only.
         */
        public int LongestCommonSubsequence(string text1, string text2)
        {
            if (text1.Length == 0 || text2.Length == 0)
            {
                return 0;
            }

            string row = text1;
            string col = text2;
            int[,] commons = new int[row.Length, col.Length];

            for (int j = 0; j < col.Length; ++j)
            {
                if (row[0] == col[j])
                {
                    while (j < col.Length)
                    {
                        commons[0, j] = 1;
                        j += 1;
                    }
                }
                else
                {
                    commons[0, j] = 0;
                }
            }

            for (int i = 1; i < row.Length; ++i)
            {
                if (row[i] == col[0])
                {
                    while (i < row.Length)
                    {
                        commons[i, 0] = 1;
                        i += 1;
                    }
                }
                else
                {
                    commons[i, 0] = commons[i - 1, 0];
                }
            }

            for (int i = 1; i < row.Length; ++i)
            {
                for (int j = 1; j < col.Length; ++j)
                {
                    if (row[i] == col[j])
                    {
                        commons[i, j] = 1 + commons[i - 1, j - 1];
                    }
                    else
                    {
                        commons[i, j] = Math.Max(commons[i, j - 1], commons[i - 1, j]);
                    }
                }
            }

            return commons[row.Length - 1, col.Length - 1];
        }

        /* Given an unsorted array of integers, find the length of longest increasing subsequence.
         */
        public int LongestIncreasingSubsequenceLength(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            List<int> longest = new List<int>();
            longest.Add(nums[0]);

            for (int i = 1; i < nums.Length; ++i)
            {
                int index = longest.BinarySearch(nums[i]);

                if (index < 0)
                {
                    index = (index + 1) * -1;
                }

                if (longest[longest.Count - 1] < nums[i])
                {
                    longest.Add(nums[i]);
                }
                else
                {
                    longest[index] = nums[i];
                }
            }

            return longest.Count;
        }

        /* Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, 
         * determine if s can be segmented into a space-separated sequence of one or more dictionary words.
         * 
         * The same word in the dictionary may be reused multiple times in the segmentation.
         * You may assume the dictionary does not contain duplicate words.
         */
        public bool WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> set = new HashSet<string>(wordDict);
            // Index 0 empty string is true
            bool[] canBreak = Enumerable.Repeat(false, s.Length + 1).ToArray();
            canBreak[0] = true;

            for (int subLength = 1; subLength < canBreak.Length; ++subLength)
            {
                for (int start = subLength; start > 0; --start)
                {
                    if (canBreak[start - 1] && set.Contains(s.Substring(start - 1, subLength - start + 1)))
                    {
                        canBreak[subLength] = true;
                        break;
                    }
                }
            }

            return canBreak[canBreak.Length - 1];
        }
    }
}
