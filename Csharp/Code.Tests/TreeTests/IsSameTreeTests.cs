using Code.Models;
using NUnit.Framework;
using System.Collections;

namespace Code.Tests.TreeTests
{
    [TestFixture]
    class IsSameTreeTests
    {
        private Tree _tree;

        [SetUp]
        public void Setup()
        {
            _tree = new Tree();
        }

        [TestCaseSource(typeof(DataSource), nameof(DataSource.TestCases))]
        public void IsSameTree_Tests(TreeNode tree1, TreeNode tree2, bool expected)
        {
            bool result = _tree.IsSameTree(tree1, tree2);

            Assert.AreEqual(expected, result);
        }

        private class DataSource
        {
            public static IEnumerable TestCases
            {
                get
                {
                    TreeNode firstP = new TreeNode(1, new TreeNode(2), new TreeNode(3));
                    TreeNode firstQ = new TreeNode(1, new TreeNode(2), new TreeNode(3));
                    bool firstExpected = true;


                    TreeNode secondP = new TreeNode(1, new TreeNode(2), null);
                    TreeNode secondQ = new TreeNode(1, null, new TreeNode(2));
                    bool secondExpected = false;

                    TreeNode thirdP = new TreeNode(1, new TreeNode(2), new TreeNode(1));
                    TreeNode thirdQ = new TreeNode(1, new TreeNode(1), new TreeNode(2));
                    bool thirdExpected = false;

                    yield return new TestCaseData(firstP, firstQ, firstExpected);
                    yield return new TestCaseData(secondP, secondQ, secondExpected);
                    yield return new TestCaseData(thirdP, thirdQ, thirdExpected);
                }
            }
        }
    }
}
