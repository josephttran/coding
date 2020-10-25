using NUnit.Framework;

namespace Code.Tests.StringTopicTests
{
    class IsPalindromeTests
    {
        private StringTopic _stringTopic;

        [SetUp]
        public void Setup()
        {
            _stringTopic = new StringTopic();
        }
        
        [TestCase("0P", false)]
        [TestCase("A man, a plan, a canal: Panama", true)]
        [TestCase("race a car", false)]
        public void IsPalindrome_Tests(string s, bool expected)
        {
            bool result = _stringTopic.IsPalindrome(s);

            Assert.AreEqual(expected, result);
        }
    }
}
