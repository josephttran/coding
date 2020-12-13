using Code.Models;
using NUnit.Framework;

namespace Code.Tests.TreeTests
{
    [TestFixture]
    class IsValidBSTTests
    {
        private Tree _tree;

        [SetUp]
        public void Setup()
        {
            _tree = new Tree();
        }

        [Test]
        public void IsValidBST_ShouldBeFalse()
        {
            TreeNode tree = new TreeNode(5, new TreeNode(1), new TreeNode(4, new TreeNode(3), new TreeNode(6)));

            bool result = _tree.IsValidBST(tree);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidBST_ShouldBeTrue()
        {
            TreeNode tree = new TreeNode(2, new TreeNode(1), new TreeNode(3));

            bool result = _tree.IsValidBST(tree);

            Assert.IsTrue(result);
        }
    }
}
