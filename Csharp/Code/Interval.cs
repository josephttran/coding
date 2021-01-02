using System;
using System.Collections.Generic;
using System.Linq;

namespace Code
{
    public class Interval
    {
        /* Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).
         * You may assume that the intervals were initially sorted according to their start times.
         */
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> list = new List<int[]>();
            int newIntervalStart = newInterval[0];
            int newIntervalEnd = newInterval[1];

            for (int i = 0; i < intervals.Length; i++)
            {
                if (intervals[i][1] < newIntervalStart)
                {
                    list.Add(intervals[i]);
                }
                else if (intervals[i][0] > newIntervalEnd)
                {
                    list.Add(new int[] { newIntervalStart, newIntervalEnd });
                    newIntervalStart = int.MaxValue;
                    newIntervalEnd = int.MaxValue;
                    list.Add(intervals[i]);
                }
                else
                {
                    newIntervalStart = Math.Min(newIntervalStart, intervals[i][0]);
                    newIntervalEnd = Math.Max(newIntervalEnd, intervals[i][1]);
                }
            }

            if (newIntervalStart != int.MaxValue)
            {
                list.Add(new int[] { newIntervalStart, newIntervalEnd });
            }

            return list.ToArray();
        }

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
