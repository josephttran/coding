using Code.Models;
using NUnit.Framework;
using System.Collections;

namespace Code.Tests.TreeTests
{
    [TestFixture]
    class InvertTreeTests
    {
        private Tree _tree;

        [SetUp]
        public void Setup()
        {
            _tree = new Tree();
        }

        [Test]
        public void InvertTree_ShouldNotBeOriginalTree()
        {
            TreeNode tree = new TreeNode(4, new TreeNode(2), new TreeNode(7));
            TreeNode sameTree = new TreeNode(4, new TreeNode(2), new TreeNode(7));

            TreeNode result = _tree.InvertTree(tree);

            Assert.IsFalse(IsSameTree(sameTree, result));
        }

        [Test]
        public void InvertTree_True_Test()
        {
            TreeNode tree = new TreeNode(4, 
                new TreeNode(2,
                    new TreeNode(1),
                    new TreeNode(3)), 
                new TreeNode(7,
                    new TreeNode(6),
                    new TreeNode(9))
                );

            TreeNode expected = new TreeNode(4,
                new TreeNode(7,
                    new TreeNode(9),
                    new TreeNode(6)),
                new TreeNode(2,
                    new TreeNode(3),
                    new TreeNode(1))
                ); 

            TreeNode result = _tree.InvertTree(tree);

            Assert.IsTrue(IsSameTree(expected, result));
        }

        bool IsSameTree(TreeNode p, TreeNode q)
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
