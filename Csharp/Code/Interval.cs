using System;
using System.Collections.Generic;
using System.Linq;

namespace Code
{
    public class Interval
    {
        /* Given an array of intervals where intervals[i] = [starti, endi], 
         * merge all overlapping intervals, and 
         * return an array of the non-overlapping intervals that cover all the intervals in the input.
         */
        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length < 2)
            {
                return intervals;
            }

            Array.Sort(intervals, (a, b) =>
            {
                return a[0].CompareTo(b[0]);
            });

            List<int[]> list = new List<int[]>();

            list.Add(intervals[0]);

            int index = 0;

            for (int i = 1; i < intervals.Length; i++)
            {
                if (list[index][1] < intervals[i][0])
                {
                    index++;
                    list.Add(intervals[i]);
                }
                else
                {
                    list[index][1] = Math.Max(list[index][1], intervals[i][1]);
                }
            }

            return list.ToArray();
        }
    }
}
