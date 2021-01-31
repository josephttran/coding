using NUnit.Framework;

namespace Code.Tests.GraphTests
{
    [TestFixture]
    class LongestConsecutiveSequenceTests
    {
        private Graph _graph;

        [SetUp]
        public void SetUp()
        {
            _graph = new Graph();
        }

        [Test]
        public void LongestConsecutiveSequence_TestWhenEmpty()
        {
            int[] nums = { };
            int expected = 0;

            int result = _graph.LongestConsecutiveSequence(nums);

            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 100, 4, 200, 1, 3, 2 }, 4)]
        [TestCase(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }, 9)]
        public void LongestConsecutiveSequence_Test(int[] nums, int expected)
        {
            int result = _graph.LongestConsecutiveSequence(nums);

            Assert.AreEqual(expected, result);
        }
    }
}
