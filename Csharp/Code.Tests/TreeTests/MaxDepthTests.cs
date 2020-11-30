using Code.Models;
using NUnit.Framework;
using System.Collections;

namespace Code.Tests.TreeTests
{
    [TestFixture]
    class MaxDepthTests
    {
        private Tree _tree;

        [SetUp]
        public void Setup()
        {
            _tree = new Tree();
        }

        [Test]
        public void MaxDepth_ShouldBeZero_WhenNoNodes()
        {
            TreeNode tree = new TreeNode();
            tree = null;
            int expected = 0;

            int result = _tree.MaxDepth(tree);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MaxDepth_ShouldBeOne_WhenSingleNode()
        {
            TreeNode tree = new TreeNode(0);
            int expected = 1;

            int result = _tree.MaxDepth(tree);

            Assert.AreEqual(expected, result);
        }

        [TestCaseSource(typeof(DataSource), nameof(DataSource.TestCases))]
        public void MaxDepth_ShoudReturnMaxDepth_Tests(TreeNode tree, int expected)
        {
            int result = _tree.MaxDepth(tree);

            Assert.AreEqual(expected, result);
        }

        private class DataSource
        {
            public static IEnumerable TestCases
            {
                get
                {
                    TreeNode first = new TreeNode(1, null, new TreeNode(2));
                    int expectedFirst = 2;

                    TreeNode second = new TreeNode(1, new TreeNode(9), new TreeNode(20));
                    second.right.left = new TreeNode(15);
                    second.right.right = new TreeNode(7);
                    int expectedSecond = 3;

                    yield return new TestCaseData(first, expectedFirst);
                    yield return new TestCaseData(second, expectedSecond);
                }
            }
        }
    }
}
