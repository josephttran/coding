using NUnit.Framework;
using System.Collections.Generic;

namespace Code.Tests.MatrixTests
{
    [TestFixture]
    class WordSearchIITests
    {
        Matrix _matrix;

        [SetUp]
        public void Setup()
        {
            _matrix = new Matrix();
        }

        [Test]
        public void WordSearchII_ShouldBeEmpty_WhenWordCannotBeContructed()
        {
            char[][] board = { new char[] { 'a', 'b' }, new char[]{ 'c', 'd' } };
            string[] words = { "abcb" };
            IList<string> expected = new List<string>();

            IList<string> result = _matrix.WordSearchII(board, words);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void WordSearchII_ShouldReturnAllWordsOnBoard()
        {
            char[][] board = { 
                new char[] { 'o', 'a', 'a', 'n' }, 
                new char[] { 'e', 't', 'a', 'e' }, 
                new char[] { 'i', 'h', 'k', 'r' }, 
                new char[] { 'i', 'f', 'l', 'v' },
            };
            string[] words = { "oath", "pea", "eat", "rain" };
            IList<string> expected = new List<string>(new string[]{ "eat", "oath" });

            IList<string> result = _matrix.WordSearchII(board, words);

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}