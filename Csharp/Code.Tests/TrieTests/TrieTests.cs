using NUnit.Framework;

namespace Code.Tests.TrieTests
{
    [TestFixture]
    class TrieTests
    {
        Trie _trie;

        [SetUp]
        public void Setup()
        {
            _trie = new Trie();
        }

        [Test]
        public void Trie_ShouldFindInsertedWord()
        {
            // Arrange
            string word = "hello";
            string searchWord = "hello";
            bool expected = true;

            // Act
            _trie.Insert(word);
            bool result = _trie.Search(searchWord);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Trie_ShouldNotContainWord()
        {
            string word = "hello";
            string searchWord = "hel";
            bool expected = false;

            _trie.Insert(word);
            bool result = _trie.Search(searchWord);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Trie_ShouldContainPrefix()
        {
            string prefix = "hel";
            string word = "hello";
            bool expected = true;

            _trie.Insert(word);
            bool result = _trie.StartsWith(prefix);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Trie_ShouldNotContainPrefix()
        {
            string prefix = "hey";
            string word = "hello";
            bool expected = false;

            _trie.Insert(word);
            bool result = _trie.StartsWith(prefix);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Trie_Tests()
        {
            string[] actions = { "search", "search", "search", "search", "search", "search", "search", "search", "search", "startsWith", 
                "startsWith", "startsWith", "startsWith", "startsWith", "startsWith", "startsWith","startsWith", "startsWith" };
            string[] wordLists = { "apps","app","ad", "applepie","rest","jan","rent","beer","jam","apps",
                "app","ad","applepie","rest","jan","rent","beer","jam" };
            bool[] expectedOrder = { false, true, false, false, false, false, false, true, true, false,
                true, true, false, false, false, true, true, true };
            
            _trie.Insert("app");
            _trie.Insert("apple");
            _trie.Insert("beer");
            _trie.Insert("add");
            _trie.Insert("jam");
            _trie.Insert("rental");

            Assert.Multiple(() =>
            {
                int i = 0;
                while(i < actions.Length)
                {
                    string action = actions[i];
                    switch (action)
                    {
                        case "search":
                            Assert.AreEqual(expectedOrder[i], _trie.Search(wordLists[i]));
                            break;
                        case "startsWith":
                            Assert.AreEqual(expectedOrder[i], _trie.StartsWith(wordLists[i]));
                            break;
                        default:
                            break;
                    }

                    i++;
                }
            });
        }
    }
}
