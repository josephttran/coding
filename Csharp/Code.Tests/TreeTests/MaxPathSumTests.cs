using Code.Models;
using NUnit.Framework;

namespace Code.Tests.TreeTests
{
    [TestFixture]
    class MaxPathSumTests
    {
        private Tree _tree;

        [SetUp]
        public void Setup()
        {
            _tree = new Tree();
        }

        [Test]
        public void MaxPathSum_ShouldBeARootValue()
        {
            TreeNode tree = new TreeNode(10, new TreeNode(-1), null);
            int expected = 10;

            int result = _tree.MaxPathSum(tree);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MaxPathSum_ShouldBeARootValue_WhenNoChildren()
        {
            TreeNode tree = new TreeNode(1, null, null);
            int expected = 1;

            int result = _tree.MaxPathSum(tree);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MaxPathSum_ShouldBeLeftSubTree_Test()
        {
            TreeNode tree = new TreeNode(-10,
                new TreeNode(10, new TreeNode(15), new TreeNode(20)),
                new TreeNode(20, null, null));
            int expected = 45;

            int result = _tree.MaxPathSum(tree);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MaxPathSum_ShouldBeRightSubTree_Test()
        {
            TreeNode tree = new TreeNode(-10,
                new TreeNode(9, null, null),
                new TreeNode(20, new TreeNode(15), new TreeNode(7)));

            int expected = 42;

            int result = _tree.MaxPathSum(tree);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MaxPathSum_ShouldBeRootAndLeftAndRight_Test()
        {
            TreeNode tree = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            int expected = 6;

            int result = _tree.MaxPathSum(tree);

            Assert.AreEqual(expected, result);
        }
    }
}
