using Code.Models;
using NUnit.Framework;

namespace Code.Tests.TreeTests
{
    [TestFixture]
    class SerializeDeserializeTests
    {
        private Tree _tree;

        [SetUp]
        public void Setup()
        {
            _tree = new Tree();
        }

        [Test]
        public void SerializeDeserialize_ShouldNull()
        {
            TreeNode tree = null;
            TreeNode expected = null;

            TreeNode result = _tree.Deserialize(_tree.Serialize(tree));

            Assert.IsTrue(IsSameTree(expected, result));
        }

        [Test]
        public void SerializeDeserialize_ShouldBeSameTreeStructure_Test()
        {
            TreeNode tree = new TreeNode(1);
            tree.left = null;
            tree.right = new TreeNode(3);

            TreeNode expected = new TreeNode(1);
            expected.left = null;
            expected.right = new TreeNode(3);

            TreeNode result = _tree.Deserialize(_tree.Serialize(tree));

            Assert.IsTrue(IsSameTree(expected, result));
        }

        [Test]
        public void SerializeDeserialize_ShouldBeSameTreeStructure_Test2()
        {
            TreeNode tree = new TreeNode(1);
            tree.left = new TreeNode(2);
            tree.left.left = new TreeNode(4); 
            tree.left.right = new TreeNode(5);
            tree.right = new TreeNode(3);
            tree.right.right = new TreeNode(6);

            TreeNode expected = new TreeNode(1);
            expected.left = new TreeNode(2);
            expected.left.left = new TreeNode(4);
            expected.left.right = new TreeNode(5);
            expected.right = new TreeNode(3);
            expected.right.right = new TreeNode(6);

            TreeNode result = _tree.Deserialize(_tree.Serialize(tree));

            Assert.IsTrue(IsSameTree(expected, result));
        }

        [Test]
        public void SerializeDeserialize_ShouldBeSameTreeStructure_Test3()
        {
            TreeNode tree = new TreeNode(1);
            tree.left = new TreeNode(2);
            tree.right = new TreeNode(3);
            tree.right.right = new TreeNode(7);

            TreeNode expected = new TreeNode(1);
            expected.left = new TreeNode(2);
            expected.right = new TreeNode(3);
            expected.right.right = new TreeNode(7);

            TreeNode result = _tree.Deserialize(_tree.Serialize(tree));

            Assert.IsTrue(IsSameTree(expected, result));
        }

        private bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }

            if (p.val != q.val)
            {
                return false;
            }

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
    }
}
