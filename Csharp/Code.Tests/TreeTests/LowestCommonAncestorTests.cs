using Code.Models;
using NUnit.Framework;
using System.Collections;

namespace Code.Tests.TreeTests
{
    [TestFixture]
    class LowestCommonAncestorTests
    {
        private Tree _tree;

        [SetUp]
        public void Setup()
        {
            _tree = new Tree();
        }

        [TestCaseSource(typeof(DataSource), nameof(DataSource.TestCases))]
        public void LowestCommonAncestor_ShouldReturnLowestCommonAncestor_WhenGivenPAndQ(TreeNode root, TreeNode p, TreeNode q, int expected)
        {
            TreeNode result = _tree.LowestCommonAncestor(root, p, q);

            Assert.AreEqual(expected, result.val);
        }

        private class DataSource
        {
            public static IEnumerable TestCases
            {
                get
                {

                    TreeNode firstP = new TreeNode(2, new TreeNode(0), new TreeNode(4, new TreeNode(3), new TreeNode(5)));
                    TreeNode firstQ = new TreeNode(8, new TreeNode(7), new TreeNode(9));
                    TreeNode firstRoot = new TreeNode(6, firstP, firstQ);
                    int firstExpected = 6;

                    TreeNode secondQ = new TreeNode(4, new TreeNode(3), new TreeNode(5));
                    TreeNode secondP = new TreeNode(2, new TreeNode(0), secondQ);
                    TreeNode secondRoot = new TreeNode(6, secondP, new TreeNode(8, new TreeNode(7), new TreeNode(9)));
                    int secondExpected = 2;

                    TreeNode thirdP = new TreeNode(2);
                    TreeNode thirdQ = new TreeNode(1);
                    TreeNode thirdRoot = thirdP;
                    thirdRoot.left = thirdQ;
                    int thirdExpected = 2;

                    yield return new TestCaseData(firstRoot, firstP, firstQ, firstExpected);
                    yield return new TestCaseData(secondRoot, secondP, secondQ, secondExpected);
                    yield return new TestCaseData(thirdRoot, thirdP, thirdQ, thirdExpected);
                }
            }
        }
    }
}
