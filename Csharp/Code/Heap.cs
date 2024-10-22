﻿using Code.Models;
using System.Collections.Generic;

namespace Code
{
    public class Heap
    {
        #region Median finder
        /* Design a data structure that supports the following two operations:
         * void addNum(int num) - Add an integer number from the data stream to the data structure.
         * double findMedian() - Return the median of all elements so far.
         */
        public class MedianFinder
        {
            IntMaxHeap maxHeapHalfLower;
            IntMinHeap minHeapHalfUpper;

            public MedianFinder()
            {
                maxHeapHalfLower = new IntMaxHeap();
                minHeapHalfUpper = new IntMinHeap();
            }

            public void AddNum(int num)
            {
                maxHeapHalfLower.Insert(num);
                minHeapHalfUpper.Insert(maxHeapHalfLower.PeekTop());
                maxHeapHalfLower.RemoveRoot();


                if (maxHeapHalfLower.GetSize() < minHeapHalfUpper.GetSize())
                {
                    maxHeapHalfLower.Insert(minHeapHalfUpper.PeekTop());
                    minHeapHalfUpper.RemoveRoot();
                }
            }

            public double FindMedian()
            {
                if(minHeapHalfUpper.GetSize() < maxHeapHalfLower.GetSize())
                {
                    return maxHeapHalfLower.PeekTop();
                }

                return (minHeapHalfUpper.PeekTop() + maxHeapHalfLower.PeekTop()) * 0.5;
            }
        }
        #endregion

        public ListNode MergeKLists(ListNode[] lists)
        {
            MinHeap heap = new MinHeap(lists.Length);
            ListNode result = null;
            ListNode curr = null;

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null)
                {
                    heap.Insert(new MinHeapNode(i, lists[i].val));
                }
            }

            while (heap.GetSize() > 0)
            {
                MinHeapNode min = heap.RemoveRoot();

                ListNode temp = lists[min.KIndex].next;
                ListNode minNode = lists[min.KIndex];
                minNode.next = null;
                lists[min.KIndex] = temp;

                if (lists[min.KIndex] != null)
                {
                    heap.Insert(new MinHeapNode(min.KIndex, lists[min.KIndex].val));
                }

                if (curr == null)
                {
                    curr = minNode;
                    result = curr;
                }
                else
                {
                    curr.next = minNode;
                    curr = curr.next;
                }
            }

            return result;
        }

        /* Given a non-empty array of integers, return the k most frequent elements.
         * k is always valid 
         * 1 ≤ k ≤ number of unique elements
         */
        public int[] TopKFrequent(int[] nums, int k)
        {
            if (k == nums.Length)
            {
                return nums;
            }

            Dictionary<int, int> frequencyDictionary = new Dictionary<int, int>();
            MinHeap heap = new MinHeap(k + 1);
            int[] most = new int[k];

            for (int i = 0; i < nums.Length; i++)
            {
                if (!frequencyDictionary.TryGetValue(nums[i], out _))
                {
                    frequencyDictionary.Add(nums[i], 0);
                }

                frequencyDictionary[nums[i]]++;
            }

            foreach (var keyValue in frequencyDictionary)
            {
                heap.Insert(new MinHeapNode(keyValue.Key, keyValue.Value));
                
                if (heap.GetSize() > k)
                {
                    heap.RemoveRoot();
                }
            }

            for (int i = 0; i < most.Length; i++)
            {
                MinHeapNode minHeapNode = heap.RemoveRoot();
                most[i] = minHeapNode.KIndex;
            }

            return most;
        }
    }
}
