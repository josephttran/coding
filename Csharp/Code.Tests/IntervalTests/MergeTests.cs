using NUnit.Framework;

namespace Code.Tests.IntervalTests
{
    [TestFixture]
    class MergeTests
    {
        Interval _interval;

        [SetUp]
        public void Setup()
        {
            _interval = new Interval();
        }

        [Test]
        public void Merge_ShouldMergeIntervalWhenOverLap()
        {
            int[][] intervals = {
                new int[] { 1, 3 },
                new int[] { 8, 10 },
                new int[] { 2, 6 },
                new int[] { 15, 18 } };

            int[][] expected = { 
                new int[] { 1, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }};

            int[][] result = _interval.Merge(intervals);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Merge_ShouldMergeIntervalWhenOverLap_Test2()
        {
            int[][] intervals = {
                new int[] { 1, 4 },
                new int[] { 4, 5 }};
 
            int[][] expected = { new int[] { 1, 5 } };

            int[][] result = _interval.Merge(intervals);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Merge_ShouldMergeIntervalWhenOverLap_Test3()
        {
            int[][] intervals = {
                new int[] { 1, 4 },
                new int[] { 5, 6 }};

            int[][] expected = { 
                new int[] { 1, 4 },
                new int[] { 5, 6 }};

            int[][] result = _interval.Merge(intervals);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Merge_ShouldMergeIntervalWhenOverLap_Test4()
        {
            int[][] intervals = {
                new int[] { 1, 4 },
                new int[] { 2, 3 }};

            int[][] expected = {
                new int[] { 1, 4 }};

            int[][] result = _interval.Merge(intervals);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Merge_ShouldMergeIntervalWhenOverLap_Test5()
        {
            int[][] intervals = {
                new int[] { 1, 4 },
                new int[] { 0, 2 },
                new int[] { 3, 5 }};

            int[][] expected = {
                new int[] { 0, 5 }};

            int[][] result = _interval.Merge(intervals);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Merge_ShouldMergeIntervalWhenOverLap_Test6()
        {
            int[][] intervals = {
                new int[] { 2, 3 },
                new int[] { 2, 2 },
                new int[] { 3, 3 },
                new int[] { 1, 3 },
                new int[] { 5, 7 },
                new int[] { 2, 2 },
                new int[] { 4, 6 }};

            int[][] expected = {
                new int[] { 1, 3 },
                new int[] { 4, 7 }};

            int[][] result = _interval.Merge(intervals);

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
