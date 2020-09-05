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

        /* Given an unsorted array of integers, find the length of longest increasing subsequence.
         */
        public int LongestIncreasingSubsequenceLength(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int longest = -1;

            int[] longestWithoutSelf = Enumerable.Repeat(0, nums.Length).ToArray();

            for (int i = 0; i < nums.Length; ++i)
            {
                int prev = nums[i];
                int prevPrevHigh = i;

                for (int j = i + 1; j < nums.Length; ++j)
                {
                    if (prev == nums[j])
                    {
                        continue;
                    }

                    if (prev < nums[j])
                    {
                        longestWithoutSelf[i] += 1;
                        prevPrevHigh = prev;
                        prev = nums[j];
                    }

                    if (prev > nums[j])
                    {
                        if (prevPrevHigh < nums[j])
                        {
                            prev = nums[j];
                        }
                    }         
                }

                if (longest < longestWithoutSelf[i])
                {
                    longest = longestWithoutSelf[i];
                }
            }

            return longest + 1;
        }
    }
}
