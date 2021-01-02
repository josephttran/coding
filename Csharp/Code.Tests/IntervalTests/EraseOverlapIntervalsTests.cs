using NUnit.Framework;
using System.Collections;

namespace Code.Tests.IntervalTests
{
    [TestFixture]
    class EraseOverlapIntervalsTests
    {
        Interval _interval;

        [SetUp]
        public void Setup()
        {
            _interval = new Interval();
        }

        [TestCaseSource(typeof(DataSource), nameof(DataSource.TestCases))]
        public void EraseOverlapIntervals_ShouldGetMinimumNumberOfIntervalToRemove(int[][] intervals,  int expected)
        {
            int result = _interval.EraseOverlapIntervals(intervals);

            Assert.AreEqual(expected, result);
        }

        class DataSource
        {
            public static IEnumerable TestCases
            {
                get
                {
                    // First Test Data
                    int[][] firstIntervals = {
                        new int[] { 1, 2 },
                        new int[] { 3, 4 }};
                    int firstOutput = 0;

                    // Second Test Data
                    int[][] secondIntervals = {
                        new int[] { 1, 2 },
                        new int[] { 1, 2 },
                        new int[] { 1, 2 } };
                    int secondOutput = 2;

                    // Third Test Data
                    int[][] thirdIntervals = {
                        new int[] { 1, 2 },
                        new int[] { 2, 3 },
                        new int[] { 3, 4 },
                        new int[] { 1, 3 } };
                    int thirdOutput = 1;

                    // Fourth Test Data
                    int[][] fourthIntervals = {
                        new int[] { 0, 3 },
                        new int[] { 0, 2 },
                        new int[] { 1, 3 },
                        new int[] { 2, 4 },
                        new int[] { 3, 5 },
                        new int[] { 4, 6 } };
                    int fourthOutput = 3;

                    yield return new TestCaseData(firstIntervals, firstOutput);
                    yield return new TestCaseData(secondIntervals, secondOutput);
                    yield return new TestCaseData(thirdIntervals, thirdOutput);
                    yield return new TestCaseData(fourthIntervals, fourthOutput);
                }
            }
        }
    }
}
