using NUnit.Framework;

namespace Code.Tests.DynamicProgrammingTests
{
    [TestFixture]
    class LongestCommonSubsequenceTests
    {
        private DynamicProgramming _dynamicProgramming;

        [SetUp]
        public void SetUp()
        {
            _dynamicProgramming = new DynamicProgramming();
        }

        [Test]
        public void LongestCommonSubsequence_WhenBothTextEmpty_ReturnZero()
        {
            string text1 = "";
            string text2 = "";
            int expected = 0;

            int result = _dynamicProgramming.LongestCommonSubsequence(text1, text2);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void LongestCommonSubsequence_WhenSameText_ReturnTextLength()
        {
            string text1 = "abc";
            string text2 = "abc";
            int expected = 3;

            int result = _dynamicProgramming.LongestCommonSubsequence(text1, text2);

            Assert.AreEqual(expected, result);
        }

        [TestCase("abc", "def", 0)]
        [TestCase("abcde", "ace", 3)]
        [TestCase("bl", "yby", 1)]
        [TestCase("bsbininm", "jmjkbkjkv", 1)]
        [TestCase("abcba","abcbcba", 5)]
        public void LongestCommonSubsequence_ShouldReturnLongestCommonSubsequenceLength(string text1, string text2, int expected)
        {
            int result = _dynamicProgramming.LongestCommonSubsequence(text1, text2);

            Assert.AreEqual(expected, result);
        }
    }
}
