using System;
using System.Collections.Generic;

namespace Code
{
    public class ArrayTopic
    {
		/* Given an array of integers, return indices of the two numbers such that they add up to a specific target.
		 * You may assume that each input would have exactly one solution, and you may not use the same element twice.
		 */
		public int[] TwoSum(int[] nums, int target)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();

			for (int i = 0; i < nums.Length; i++)
			{
				int complement = target - nums[i];

				if (dictionary.TryGetValue(complement, out int value))
                {
					return new int[] { value, i };
                }

				if (dictionary.TryGetValue(nums[i], out _))
                {
					continue;
                }

				dictionary.Add(nums[i], i);
			}

			throw new ArgumentException("No two sum solution");
		}

		/* Say you have an array for which the ith element is the price of a given stock on day i.
		 * If you were only permitted to complete at most one transaction 
		 * (i.e., buy one and sell one share of the stock), design an algorithm to find the maximum profit.
		 * Note that you cannot sell a stock before you buy one.
		 */
		public int MaxProfit(int[] prices)
		{
			if (prices.Length == 0)
            {
				return 0;
            }

			int minPrice = prices[0];
			int sellPrice = prices[0];
			int maxProfit = 0;
			
			for (int i = 0; i < prices.Length; ++i)
            {
				if (minPrice > prices[i] && i + 1 != prices.Length)
                {
					minPrice = prices[i];
					sellPrice = prices[i];
                }

				if (sellPrice < prices[i])
				{
					sellPrice = prices[i];
					maxProfit = Math.Max(maxProfit, sellPrice - minPrice);
				}
			}

			if (maxProfit > 0)
			{
				return maxProfit;
			}

			return 0;
		}

		/* Given an array of integers, find if the array contains any duplicates.
		 * Your function should return true if any value appears at least twice in the array, 
		 * and it should return false if every element is distinct.
		 */
		public bool ContainsDuplicate(int[] nums)
		{
			HashSet<int> set = new HashSet<int>(nums);

			return set.Count != nums.Length;
		}
	}
}
