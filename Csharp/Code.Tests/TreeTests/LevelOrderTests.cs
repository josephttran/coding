using Code.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Code.Tests.TreeTests
{
    [TestFixture]
    class LevelOrderTests
    {
        private Tree _tree;

        [SetUp]
        public void Setup()
        {
            _tree = new Tree();
        }

        [Test]
        public void LevelOrder_ShouldBeEmpty()
        {
            TreeNode tree = null;
            IList<IList<int>> expected = new List<IList<int>>();

            IList<IList<int>> result = _tree.LevelOrder(tree);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void LevelOrder_Test()
        {
            TreeNode tree = new TreeNode(3, 
                new TreeNode(9), 
                new TreeNode(20, new TreeNode(15), new TreeNode(7))
            );

            IList<IList<int>> expected = new List<IList<int>>
            {
                new List<int> { 3 },
                new List<int> { 9, 20 },
                new List<int> { 15, 7 }
            };

            IList<IList<int>> result = _tree.LevelOrder(tree);

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
