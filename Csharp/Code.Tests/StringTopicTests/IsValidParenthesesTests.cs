using NUnit.Framework;

namespace Code.Tests.StringTopicTests
{
    [TestFixture]
    class IsValidParenthesesTests
    {
        private StringTopic _stringTopic;

        [SetUp]
        public void Setup()
        {
            _stringTopic = new StringTopic();
        }
        
        [TestCase("]", false)]
        [TestCase("(])", false)]
        [TestCase("()", true)]
        [TestCase("()[]{}", true)]
        [TestCase("(]", false)]
        [TestCase("([)]", false)]
        [TestCase("{[]}", true)]
        public void IsValidParentheses_Tests(string s, bool expected)
        {
            bool result = _stringTopic.IsValidParentheses(s);

            Assert.AreEqual(expected, result);
        }
    }
}
