using Code.Models;
using NUnit.Framework;

namespace Code.Tests.TreeTests
{
    [TestFixture]
    class IsSubtreeTests
    {
        private Tree _tree;

        [SetUp]
        public void Setup()
        {
            _tree = new Tree();
        }

        [Test]
        public void SerializeDeserializeIsSubtree_ShouldBeTrue()
        {
            TreeNode tree = new TreeNode(3);
            tree.left = new TreeNode(4, new TreeNode(1), new TreeNode(2));
            tree.right = new TreeNode(5);

            TreeNode treeTwo = new TreeNode(4);
            treeTwo.left = new TreeNode(1);
            treeTwo.right = new TreeNode(2);

            bool result = _tree.IsSubtree(tree, treeTwo);

            Assert.IsTrue( result);
        }

        [Test]
        public void SerializeDeserializeIsSubtree_ShouldBeFalse()
        {
            TreeNode tree = new TreeNode(3);
            tree.left = new TreeNode(4, new TreeNode(1), new TreeNode(2, null, new TreeNode(0)));
            tree.right = new TreeNode(5);

            TreeNode treeTwo = new TreeNode(4);
            treeTwo.left = new TreeNode(1);
            treeTwo.right = new TreeNode(2);

            bool result = _tree.IsSubtree(tree, treeTwo);

            Assert.IsFalse(result);
        }

        [Test]
        public void SerializeDeserializeIsSubtree_OnlyRoot_ShouldBeFalse()
        {
            TreeNode tree = new TreeNode(12);
            TreeNode treeTwo = new TreeNode(2);

            bool result = _tree.IsSubtree(tree, treeTwo);

            Assert.IsFalse(result);
        }
    }
}
