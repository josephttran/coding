using NUnit.Framework;

namespace Code.Tests.WordDictionaryTests
{
    [TestFixture]
    class WordDictionaryTests
    {
        WordDictionary _wordDictionary;

        [SetUp]
        public void Setup()
        {
            _wordDictionary = new WordDictionary();
        }

        [Test]
        public void WordDictionary_Tests()
        {
            _wordDictionary.AddWord("bad");
            _wordDictionary.AddWord("dad");
            _wordDictionary.AddWord("mad");

            Assert.Multiple(() =>
            {
                Assert.IsFalse(_wordDictionary.Search("pad"));
                Assert.IsTrue(_wordDictionary.Search("bad"));
                Assert.IsTrue(_wordDictionary.Search(".ad"));
                Assert.IsTrue(_wordDictionary.Search("b.."));
            });
        }
    }
}
