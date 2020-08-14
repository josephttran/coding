using System;
using System.Collections.Generic;
using System.Linq;

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

		/* Given an array nums of n integers where n > 1, return an array output such that 
		 * output[i] is equal to the product of all the elements of nums except nums[i].
		 * 
		 * Constraint: It's guaranteed that the product of the elements of any prefix or suffix of the array 
		 * (including the whole array) fits in a 32 bit integer.
		 * Solve without division and in O(n). 
		 * Constant space complexity. (The output array does not count as extra space for the purpose of space complexity analysis.)
		 */
		public int[] ProductExceptSelf(int[] nums)
		{
			int[] output = Enumerable.Repeat(1, nums.Length).ToArray();
			int leftProduct = 1;
			int rightProduct = 1;

			for (int i = 1; i < nums.Length; ++i)
			{
				leftProduct *= nums[i - 1];
				output[i] *= leftProduct;
			}

			for (int i = nums.Length - 2; i >= 0; --i)
            {
				rightProduct *= nums[i + 1];
				output[i] *= rightProduct;
            }

			return output;
		}

		/* Given an integer array nums, find the contiguous subarray (containing at least one number) 
		 * which has the largest sum and return its sum.
		 */
		public int MaxSubArray(int[] nums)
		{
			if (nums.Length == 0)
            {
				return 0;
            }
			else
            {
				int currentSum = 0;
				int maxSum = nums[0];

				foreach (int num in nums)
                {
					if (currentSum < 0)
					{
						currentSum = 0;
					}

					currentSum += num;
					maxSum = Math.Max(maxSum, currentSum);
                }

				return maxSum;
            }
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
