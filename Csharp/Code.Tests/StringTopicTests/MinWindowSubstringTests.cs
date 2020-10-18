using NUnit.Framework;

namespace Code.Tests.StringTopicTests
{
    [TestFixture]
    class MinWindowSubstringTests
    {
        private StringTopic _stringTopic;

        [SetUp]
        public void Setup()
        {
            _stringTopic = new StringTopic();
        }

        [Test]
        public void CharacterReplacementLongestRepeating_AllSubstringFromSDoesNotContainsAllLettersInT_ReturnEmpty()
        {
            string s = "aevds";
            string t = "sdf";
            string expected = "";

            string result = _stringTopic.MinWindowSubstring(s, t);

            Assert.AreEqual(expected, result);
        }

        [TestCase("a", "a", "a")]
        [TestCase("ADOBECODEBANC", "ABC", "BANC")]
        public void CharacterReplacementLongestRepeating_WhenReplaceCharacters_ReturnLongestRepeatSubstring(string s, string t, string expected)
        {
            string result = _stringTopic.MinWindowSubstring(s, t);

            Assert.AreEqual(expected, result);
        }
    }
}
