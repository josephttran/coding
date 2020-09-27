using NUnit.Framework;

namespace Code.Tests.DynamicProgrammingTests
{
    class UniquePathsTests
    {
        private DynamicProgramming _dynamicProgramming;

        [SetUp]
        public void SetUp()
        {
            _dynamicProgramming = new DynamicProgramming();
        }

        [TestCase(3, 7, 28)]
        [TestCase(3, 2, 3)]
        [TestCase(7, 3, 28)]
        [TestCase(3, 3, 6)]
        public void UniquePaths_WhenMatrix_ShouldReturnNumberOfUniquePath(int m, int n, int expected)
        {
            int result = _dynamicProgramming.UniquePaths(m, n);

            Assert.AreEqual(expected, result);
        }
    }
}
