using NUnit.Framework;

namespace Code.Tests.DynamicProgrammingTests
{
    [TestFixture]
    class LongestIncreasingSubsequenceLengthTests
    {
        private DynamicProgramming _dynamicProgramming;

        [SetUp]
        public void SetUp()
        {
            _dynamicProgramming = new DynamicProgramming();
        }

        [Test]
        public void LongestIncreasingSubsequenceLength_EmptyArray_ShouldReturnZero()
        {
            int[] nums = new int[] { };
            int expected = 0;

            int result = _dynamicProgramming.LongestIncreasingSubsequenceLength(nums);

            Assert.AreEqual(expected, result);
        }

        /* The longest increasing subsequence is [2,3,7,101], therefore the length is 4. 
         */
        [Test]
        public void LongestIncreasingSubsequenceLength_ShouldReturnLongestLength()
        {
            int[] nums = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
            int expected = 4;

            int result = _dynamicProgramming.LongestIncreasingSubsequenceLength(nums);

            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 10, 9, 2, 5, 3, 4 }, 3)]
        [TestCase(new int[] { 1, 3, 6, 7, 9, 4, 10, 5, 6 }, 6)]
        public void LongestIncreasingSubsequenceLength_Should_ReturnLongestLength(int[] nums, int expected)
        {
            int result = _dynamicProgramming.LongestIncreasingSubsequenceLength(nums);

            Assert.AreEqual(expected, result);
        }
    }
}
