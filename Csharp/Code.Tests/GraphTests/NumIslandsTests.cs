using NUnit.Framework;

namespace Code.Tests.GraphTests
{
    [TestFixture]
    class NumIslandsTests
    {
        private Graph _graph;

        [SetUp]
        public void SetUp()
        {
            _graph = new Graph();
        }

        [Test]
        public void NumIslands_TestWhenEmpty()
        {
            char[][] grid = null;
            int expected = 0;

            int result = _graph.NumIslands(grid);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void NumIslands_ShouldReturnOne()
        {
            char[][] grid = new char[][]
            {
                new char[] {'1', '1', '1', '1', '0'},
                new char[] {'1', '1', '0', '1', '0'},
                new char[] {'1', '1', '0', '0', '0'},
                new char[] {'0', '0', '0', '0', '0'},
            };

            int expected = 1;

            int result = _graph.NumIslands(grid);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void NumIslands_ShouldReturnThree()
        {
            char[][] grid = new char[][]
            {
                 new char[] {'1', '1', '0', '0', '0'},
                 new char[] {'1', '1', '0', '0', '0'},
                 new char[] {'0', '0', '1', '0', '0'},
                 new char[] {'0', '0', '0', '1', '1'}
            };

            int expected = 3;

            int result = _graph.NumIslands(grid);

            Assert.AreEqual(expected, result);
        }
    }
}
