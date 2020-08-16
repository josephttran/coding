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

		/*Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
		 * (i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).
		 * You are given a target value to search. If found in the array return its index, otherwise return -1.
		 * You may assume no duplicate exists in the array.
		 * Your algorithm's runtime complexity must be in the order of O(log n).	
		 */
		public int SearchRotatedSortedArray(int[] nums, int target)
		{
			if (nums.Length == 1)
			{
				return nums[0] == target ? 0 : -1;
			}

			if (nums[0] < nums[nums.Length - 1])
			{
				return BinarySearch(nums, target);
			}
			else
			{
				int low = 0;
				int high = nums.Length - 1;

				while (low + 1 != high)
				{
					int mid = (high + low) / 2;

					if (nums[low] < nums[mid])
					{
						low = mid;
					}

					if (nums[mid] < nums[high])
					{
						high = mid;
					}
				}

				if (target < nums[0] && target > nums[nums.Length - 1])
                {
					return -1;
                }

				if (target >= nums[0] && target <= nums[low])
                {
					return BinarySearch(nums.Take(high).ToArray(), target);
				}
				else
                {
					int targetIndex = BinarySearch(nums.Skip(high).Take(nums.Length - low).ToArray(), target);

					return targetIndex == -1 ? -1 : low + 1 + targetIndex;
				}
			}
		}

		int BinarySearch(int[] nums, int target)
		{
			int low = 0;
			int high = nums.Length - 1;

			while (low <= high)
			{
				int mid = (high + low) / 2;

				if (target == nums[mid])
				{
					return mid;
				}
				else
				{
					if (target < nums[mid])
					{
						high = mid - 1;
					}
					else
					{
						low = mid + 1;
					}
				}
			}

			return -1;
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

		public int MaxSubArrayDAC(int[] nums)
		{
			if (nums.Length == 0)
			{
				return 0;
			}
			else
			{
				int MaxSumSubarray(int[] arr, int low, int high)
                {
					if (low == high)
                    {
						return arr[high];
                    }

					int middle = (high + low) / 2;

					int leftSumSubarray = MaxSumSubarray(nums, low, middle);
					int rightSumSubarray = MaxSumSubarray(nums, middle + 1, high);
					int crossingSumSubarray = MaxSumSubarrayCrossing(nums, low, middle, high);

					return Math.Max(Math.Max(leftSumSubarray, rightSumSubarray), crossingSumSubarray);
				}

				int MaxSumSubarrayCrossing(int[] arr, int low, int mid, int high)
                {
					int leftSum = Int32.MinValue;
					int sum = 0;

					for (int i = mid; i >= low; --i)
                    {
						sum += arr[i];
						if (leftSum < sum)
                        {
							leftSum = sum;
                        }
                    }

					int rightSum = Int32.MinValue;
					sum = 0;

					for (int i = mid + 1; i <= high; ++i)
					{
						sum += arr[i];
						if (rightSum < sum)
						{
							rightSum = sum;
						}
					}

					return (leftSum + rightSum);
                }

				int maxSum = MaxSumSubarray(nums, 0, nums.Length - 1);

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

		/* Given an integer array nums, find the contiguous subarray within an array (containing at least one number) which has the largest product.
		 */
		public int MaxProductSubarray(int[] nums)
		{
			if (nums.Length == 1)
            {
				return nums[0];
            }
	
			// Create subarray
			List<List<int>> listOfSubarray = new List<List<int>>();
			List<int> subarray = new List<int>();

			for (int i = 0; i < nums.Length; ++i)
            {
				if (nums[i] != 0)
                {
					subarray.Add(nums[i]);
                }
				else
                {
					if (subarray.Count > 0)
                    {
						listOfSubarray.Add(subarray);
						subarray = new List<int>();
                    }
                }
            }

			if (subarray.Count > 0)
			{
				listOfSubarray.Add(subarray);
			}

			if (listOfSubarray.Count == 0)
            {
				return 0;
            }

			// Find max product of subarray
			if (listOfSubarray.Any(arr => arr.Any(num => num > 0)))
			{
				int maxProductSub = listOfSubarray.Select(subarr =>
				{		
					int arrNegativeCount = subarr.Count(a => a < 0);

					if (arrNegativeCount % 2 == 0)
					{
						return subarr.Aggregate((acc, num) => acc * num);
					}
					else
					{
						if (subarr.Count < 3)
						{
							return subarr.Max();
						}

						if (arrNegativeCount == 1)
						{
							int indexOfNegative = subarr.FindIndex((arr) => arr < 0);

							if (indexOfNegative == 0)
                            {
								return subarr.Skip(1).Aggregate((acc, num) => acc * num);
							}
							
							if (indexOfNegative == subarr.Count - 1)
                            {
								return subarr.Take(subarr.Count - 1).Aggregate((acc, num) => acc * num);
							}

							return Math.Max(
								subarr.Take(indexOfNegative).Aggregate((acc, num) => acc * num),
								subarr.Skip(indexOfNegative + 1).Aggregate((acc, num) => acc * num)
							);
						}

						int negativeCount = arrNegativeCount;
						// max left
						int maxProduct = 1;
						int currentProduct = 1;

						foreach (int num in subarr)
						{
							if (num < 0)
							{
								if (negativeCount > 1)
								{
									negativeCount--;
								}
								else
								{
									if (maxProduct < currentProduct)
									{
										maxProduct = Math.Max(maxProduct, currentProduct);
										currentProduct = 1;
										continue;
									}
								}
							}

							currentProduct *= num;
						}

						// max right
						subarr.Reverse();
						negativeCount = arrNegativeCount;
						arrNegativeCount = 
						currentProduct = 1;
						foreach (int num in subarr)
						{
							if (num < 0)
							{
								if (negativeCount > 1)
								{
									negativeCount--;
								}
								else
								{
									if (maxProduct < currentProduct)
									{
										maxProduct = Math.Max(maxProduct, currentProduct);
										currentProduct = 1;
										continue;
									}
								}
							}

							currentProduct *= num;
						}

						return maxProduct;
					}
				}).Max();

				return maxProductSub;
			}
			else
			{
				// Subarray contains no postive number
				int maxProductSub = listOfSubarray.Select(subarr =>
				{
					int arrNegativeCount = subarr.Count(a => a < 0);

					if (subarr.Contains(0))
                    {
						int indexOfNegative = subarr.FindIndex((arr) => arr == 0);
						int leftProduct = subarr.Take(indexOfNegative).Aggregate((acc, num) => acc * num);
						int rightProduct = subarr.Skip(indexOfNegative + 1).Aggregate((acc, num) => acc * num);

						return Math.Max(0, Math.Max(leftProduct, rightProduct));
                    }
					else
                    {
						if (arrNegativeCount % 2 == 0)
						{
							return subarr.Aggregate((acc, num) => acc * num);
						}
						else
						{
							// Section
							// Subarray contains more than 2 negative
							int[] negativeNumbersIndices = subarr.Select((arr, index) => arr < 0 ? index : -1).Where(i => i != -1).ToArray();
							int max = 0;

							for (int i = 0; i < negativeNumbersIndices.Length; ++i)
                            {
								int indexOfNegative = negativeNumbersIndices[i];
								int leftProduct = subarr.Take(indexOfNegative + 1).Aggregate((acc, num) => acc * num);
								int rightProduct = subarr.Skip(indexOfNegative).Aggregate((acc, num) => acc * num);

								max = Math.Max(max, Math.Max(leftProduct, rightProduct));
                            }

							return max;
						}
                    }
				}).Max();

				return maxProductSub;
			}
		}

		/* Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
		 * (i.e.,  [0,1,2,4,5,6,7] might become  [4,5,6,7,0,1,2]).
		 * Find the minimum element.
		 * You may assume no duplicate exists in the array.
		 */
		public int FindMinRotatedSortedArray(int[] nums)
		{
			if (nums.Length == 1)
            {
				return nums[0];
            }

			if (nums[0] < nums[nums.Length - 1])
            {
				return nums[0];
            }

			int low = 0;
			int high = nums.Length - 1;

			while (low + 1 != high)
            {
				int mid = (high + low) / 2;

				if (nums[low] < nums[mid])
                {
					low = mid;
                }

				if (nums[mid] < nums[high])
				{
					high = mid;
                }
            }

			return nums[high];
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
