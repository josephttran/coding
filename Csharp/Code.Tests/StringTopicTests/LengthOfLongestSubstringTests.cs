using NUnit.Framework;

namespace Code.Tests.StringTopicTests
{
    [TestFixture]
    class LengthOfLongestSubstringTests
    {
        private StringTopic _stringTopic;

        [SetUp]
        public void Setup()
        {
            _stringTopic = new StringTopic();
        }

        [Test]
        public void LengthOfLongestSubstring_WhenEmpty_ReturnZero()
        {
            string s = "";
            int expected = 0;

            int result = _stringTopic.LengthOfLongestSubstring(s);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void LengthOfLongestSubstring_WhenOnlySpace_ReturnOne()
        {
            string s = " ";
            int expected = 1;

            int result = _stringTopic.LengthOfLongestSubstring(s);

            Assert.AreEqual(expected, result);
        }

        [TestCase("abcabcbb", 3)]
        [TestCase("bbbbb", 1)]
        [TestCase("pwwkew", 3)]
        public void LengthOfLongestSubstring_ShouldReturnLongestSubstringWithoutRepeatCharacter(string s, int expected)
        {
            int result = _stringTopic.LengthOfLongestSubstring(s);

            Assert.AreEqual(expected, result);
        }
    }
}
