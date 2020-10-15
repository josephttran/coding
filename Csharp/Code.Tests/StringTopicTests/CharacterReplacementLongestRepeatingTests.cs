using NUnit.Framework;

namespace Code.Tests.StringTopicTests
{
    class CharacterReplacementLongestRepeatingTests
    {
        private StringTopic _stringTopic;

        [SetUp]
        public void Setup()
        {
            _stringTopic = new StringTopic();
        }

        [Test]
        public void CharacterReplacementLongestRepeating_WhenEmpty_ReturnZero()
        {
            string s = "";
            int expected = 0;

            int result = _stringTopic.CharacterReplacementLongestRepeating(s, 0);

            Assert.AreEqual(expected, result);
        }

        [TestCase("ABAB", 2, 4)]
        [TestCase("AABABBA", 1, 4)]
        public void CharacterReplacementLongestRepeating_WhenReplaceCharacters_ReturnLongestRepeatSubstring(string s, int numReplacement, int expected)
        {
            int result = _stringTopic.CharacterReplacementLongestRepeating(s, numReplacement);

            Assert.AreEqual(expected, result);
        }
    }
}
