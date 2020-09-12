using NUnit.Framework;
using System.Collections.Generic;

namespace Code.Tests.DynamicProgrammingTests
{
    [TestFixture]
    class WordBreakTests
    {
        private DynamicProgramming _dynamicProgramming;

        [SetUp]
        public void SetUp()
        {
            _dynamicProgramming = new DynamicProgramming();
        }

        [Test, Timeout(2000)]
        public void WordBreak_TimeNotExceeded()
        {
            string s = "a";
            IList<string> wordDict = new List<string> { "a" };

            bool result = _dynamicProgramming.WordBreak(s, wordDict);

            Assert.IsTrue(result);
        }

        [Test, Timeout(2000)]
        public void WordBreak_TimeNotExceeded_AndReturnFalse()
        {
            string s = "a";
            IList<string> wordDict = new List<string> { "b" };

            bool result = _dynamicProgramming.WordBreak(s, wordDict);

            Assert.IsFalse(result);
        }

        [TestCase()]
        public void WordBreak_CanBeSegmented()
        {
            string s = "leetcode";
            IList<string> wordDict = new List<string> { "leet", "code" };

            bool result = _dynamicProgramming.WordBreak(s, wordDict);

            Assert.IsTrue(result);
        }

        [TestCase()]
        public void WordBreak_CanBeSegmented_True()
        {
            string s = "applepenapple";
            IList<string> wordDict = new List<string> { "apple", "pen" };

            bool result = _dynamicProgramming.WordBreak(s, wordDict);

            Assert.IsTrue(result);
        }

        [Test]
        public void WordBreak_CanBeSegmented_BeTrue()
        {
            string s = "catsanddog";
            IList<string> wordDict = new List<string> { "cats", "dog", "sand", "and", "cat" };

            bool result = _dynamicProgramming.WordBreak(s, wordDict);

            Assert.IsTrue(result);
        }

        [Test]
        public void WordBreak_CanBeSegmented_ReturnTrue()
        {
            string s = "leetacode";
            IList<string> wordDict = new List<string> { "leet", "code", "a" };

            bool result = _dynamicProgramming.WordBreak(s, wordDict);

            Assert.IsTrue(result);
        }

        [Test]
        public void WordBreak_CanBeSegmented_ShouldReturnTrue()
        {
            string s = "ddadddbdddadd";
            IList<string> wordDict = new List<string> { "dd", "ad", "da", "b" };

            bool result = _dynamicProgramming.WordBreak(s, wordDict);

            Assert.IsTrue(result);
        }

        [Test]
        public void WordBreak_CannotBeSegmented()
        {
            string s = "catsandog";
            IList<string> wordDict = new List<string> { "cats", "dog", "sand", "and", "cat" };

            bool result = _dynamicProgramming.WordBreak(s, wordDict);

            Assert.IsFalse(result);
        }

        [Test]
        public void WordBreak_CannotBeSegmented_BeFalse()
        {
            string s = "ccbb";
            IList<string> wordDict = new List<string> { "bc", "cb" };

            bool result = _dynamicProgramming.WordBreak(s, wordDict);

            Assert.IsFalse(result);
        }
    }
}
