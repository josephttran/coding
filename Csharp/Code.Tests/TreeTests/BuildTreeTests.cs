using Code.Models;
using NUnit.Framework;


namespace Code.Tests.TreeTests
{
    [TestFixture]
    class BuildTreeTests
    {
        private Tree _tree;

        [SetUp]
        public void Setup()
        {
            _tree = new Tree();
        }

        [Test]
        public void BuildTree_ShouldBuildTree()
        {
            int[] preorder = { 3, 9, 20, 15, 7 };
            int[] inorder = { 9, 3, 15, 20, 7 };
            TreeNode expectedTree = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));

            TreeNode result = _tree.BuildTree(preorder, inorder);

            Assert.IsTrue(IsSameTree(expectedTree, result));
        }

        [Test]
        public void BuildTree_ShouldBuildTree_True()
        {
            int[] preorder = { 3, 9, 15, 8, 7, 20 };
            int[] inorder = { 15, 9, 7, 8, 3, 20};
            TreeNode expectedTree = new TreeNode(3, new TreeNode(9, new TreeNode(15), new TreeNode(8, new TreeNode(7), null)), new TreeNode(20));

            TreeNode result = _tree.BuildTree(preorder, inorder);

            Assert.IsTrue(IsSameTree(expectedTree, result));
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
