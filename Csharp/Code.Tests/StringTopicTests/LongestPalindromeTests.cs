using NUnit.Framework;

namespace Code.Tests.StringTopicTests
{
    class LongestPalindromeTests
    {
        private StringTopic _stringTopic;

        [SetUp]
        public void Setup()
        {
            _stringTopic = new StringTopic();
        }

        [TestCase("a", "a")]
        [TestCase("ac", "a")]
        [TestCase("aa", "aa")]
        [TestCase("aaa", "aaa")]
        [TestCase("aaaa", "aaaa")]
        [TestCase("aba", "aba")]
        [TestCase("abb", "bb")]
        [TestCase("babad", "bab")]
        [TestCase("cbbd", "bb")]
        public void LongestPalindrome_Tests(string s, string expected)
        {
            string result = _stringTopic.LongestPalindrome(s);

            Assert.AreEqual(expected, result);
        }
    }
}
