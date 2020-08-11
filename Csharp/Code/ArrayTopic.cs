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
	}
}
