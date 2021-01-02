using NUnit.Framework;
using System.Collections;

namespace Code.Tests.IntervalTests
{
    [TestFixture]
    class InsertTests
    {
        Interval _interval;

        [SetUp]
        public void Setup()
        {
            _interval = new Interval();
        }

        [Test]
        public void Insert_ShouldContainOnlyNewInterval_WhenIntervalsIsEmpty()
        {
            int[][] intervals = { };
            int[] newInterval = { 1, 2 };
            int[][] expected = 
            { 
                new int[] { 1, 2 } 
            };

            int[][] result = _interval.Insert(intervals, newInterval);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestCaseSource(typeof(DataSource), nameof(DataSource.TestCases))]
        public void Insert_ShouldInsertNewIntervalOrMerge(int[][] intervals, int[] newInterval, int[][] expected)
        {
            int[][] result = _interval.Insert(intervals, newInterval);

            CollectionAssert.AreEqual(expected, result);
        }

        class DataSource
        {
            public static IEnumerable TestCases
            {
                get
                {
                    // First Test Data
                    int[][] firstIntervals = { 
                        new int[] { 1, 3 }, 
                        new int[] { 6, 9 } };
                    int[] firstNewInterval = { 2, 5 };
                    int[][] firstOutput = { 
                        new int[] { 1, 5 },
                        new int[] { 6, 9 } };

                    // Second Test Data
                    int[][] secondIntervals = { new int[] { 1, 5 } };
                    int[] secondNewInterval = { 2, 3 };
                    int[][] secondOutput = { new int[] { 1, 5 } };

                    // Third Test Data
                    int[][] thirdIntervals = { new int[] { 1, 5 } };
                    int[] thirdNewInterval = { 2, 7 };
                    int[][] thirdOutput = { new int[] { 1, 7 } };
                    
                    // Fourth Test Data
                    int[][] fourthIntervals = {
                        new int[] { 1, 2 },
                        new int[] { 3, 5 },
                        new int[] { 6, 7 },
                        new int[] { 8, 10 },
                        new int[] { 12, 16 }};
                    int[] fourthNewInterval = { 4, 8 };
                    int[][] fourthOutput = {
                        new int[] { 1, 2 },
                        new int[] { 3, 10 },
                        new int[] { 12, 16 }};

                    // Fifth Test Data
                    int[][] fifthIntervals = {
                        new int[] { 2, 5 },
                        new int[] { 6, 7 },
                        new int[] { 8, 9 }};
                    int[] fifthNewInterval = { 0, 1 };
                    int[][] fifthOutput = {
                        new int[] { 0, 1 },
                        new int[] { 2, 5 },
                        new int[] { 6, 7 },
                        new int[] { 8, 9 }};

                    yield return new TestCaseData(firstIntervals, firstNewInterval, firstOutput);
                    yield return new TestCaseData(secondIntervals, secondNewInterval, secondOutput);
                    yield return new TestCaseData(thirdIntervals, thirdNewInterval, thirdOutput);
                    yield return new TestCaseData(fourthIntervals, fourthNewInterval, fourthOutput);
                    yield return new TestCaseData(fifthIntervals, fifthNewInterval, fifthOutput);
                }
            }
        }
    }
}
