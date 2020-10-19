using NUnit.Framework;
using System.Collections.Generic;

namespace Code.Tests.StringTopicTests
{
    [TestFixture]
    class GroupAnagramsTests
    {
        private StringTopic _stringTopic;

        [SetUp]
        public void Setup()
        {
            _stringTopic = new StringTopic();
        }

        private static IEnumerable<TestCaseData> AddSingleElementCases()
        {
            yield return new TestCaseData(new string[] { "" }, new List<IList<string>>() { new List<string> { "" } });
            yield return new TestCaseData(new string[] { "a" }, new List<IList<string>>() { new List<string> { "a" } });
        }

        [Test, TestCaseSource("AddSingleElementCases")]
        public void GroupAnagrams_WhenSingleElement(string[] input, IList<IList<string>> expected)
        {
            IList<IList<string>> result = _stringTopic.GroupAnagrams(input);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void GroupAnagrams_ReturnGroup()
        {
            string[] input = { "eat", "tea", "tan", "ate", "nat", "bat" };
            IList<IList<string>> expected = new List<IList<string>>();
            expected.Add(new List<string>() { "bat" });
            expected.Add(new List<string>() { "nat", "tan" });
            expected.Add(new List<string>() { "ate", "eat", "tea" });

            IList<IList<string>> result = _stringTopic.GroupAnagrams(input);

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
