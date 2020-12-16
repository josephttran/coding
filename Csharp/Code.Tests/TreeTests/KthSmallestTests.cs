using Code.Models;
using NUnit.Framework;
using System.Collections;

namespace Code.Tests.TreeTests
{
    [TestFixture]
    class KthSmallestTests
    {
        private Tree _tree;

        [SetUp]
        public void Setup()
        {
            _tree = new Tree();
        }

        [TestCaseSource(typeof(DataSource), nameof(DataSource.TestCases))]
        public void KthSmallest_ShouldReturnKSmallestNumberInTree(TreeNode root, int k, int expected)
        {
            int result = _tree.KthSmallest(root, k);

            Assert.AreEqual(expected, result);
        }

        private class DataSource
        { 
            public static IEnumerable TestCases
            {
                get
                {
                    TreeNode firstRoot = new TreeNode(5, new TreeNode(3, new TreeNode(2, new TreeNode(1), null), new TreeNode(4)), new TreeNode(6));
                    int firstK = 3;
                    int firstExpected = 3;

                    TreeNode secondRoot = new TreeNode(3, new TreeNode(1, null, new TreeNode(2)), new TreeNode(4));
                    int secondK = 1;
                    int secondExpected = 1;

                    TreeNode thirdRoot = new TreeNode(3, new TreeNode(1, null, new TreeNode(2)), new TreeNode(4));
                    int thirdK = 4;
                    int thirdExpected = 4;

                    yield return new TestCaseData(firstRoot, firstK, firstExpected);
                    yield return new TestCaseData(secondRoot, secondK, secondExpected);
                    yield return new TestCaseData(thirdRoot, thirdK, thirdExpected);
                }
            }
        }
    }
}
