using NUnit.Framework;

namespace Code.Tests.StringTopicTests
{
    [TestFixture]
    class IsAnagramTests
    {
        private StringTopic _stringTopic;

        [SetUp]
        public void Setup()
        {
            _stringTopic = new StringTopic();
        }

        [Test]
        public void IsAnagram_WhenLengthNotSame_ReturnFalse()
        {
            string s = "a";
            string t = "asdf";
            bool expected = false;

            bool result = _stringTopic.IsAnagram(s, t);

            Assert.AreEqual(expected, result);
        }

        [TestCase("anagram", "nagaram", true)]
        [TestCase("rat", "car", false)]
        public void IsAnagram_ReturnWhetherIsAnagram(string s, string t, bool expected)
        {
            bool result = _stringTopic.IsAnagram(s, t);

            Assert.AreEqual(expected, result);
        }
    }
}
