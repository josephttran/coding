using NUnit.Framework;

namespace Code.Tests.DynamicProgrammingTests
{
    class HouseRobberIITests
    {
        private DynamicProgramming _dynamicProgramming;

        [SetUp]
        public void SetUp()
        {
            _dynamicProgramming = new DynamicProgramming();
        }

        [Test]
        public void HouseRobberII_WhenSingleElement_ShouldReturnElement()
        {
            int[] nums = new int[] { 4 };
            int expected = 4;

            int result = _dynamicProgramming.HouseRobberII(nums);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void HouseRobberII_ShouldBeMaxAmount_WhenSumNonAdjacent()
        {
            int[] nums = new int[] { 2, 3, 2 };
            int expected = 3;

            int result = _dynamicProgramming.HouseRobberII(nums);

            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 1, 2, 3, 1 }, 4)]
        [TestCase(new int[] { 1, 2, 3, 1, 4, 5 }, 8)]
        [TestCase(new int[] { 7, 1, 3, 8, 8, 5 }, 18)]
        [TestCase(new int[] { 7, 1, 3, 8, 8, 5, 2 }, 20)]
        [TestCase(new int[] { 7, 12, 3, 8, 8, 5, 9 }, 29)]
        public void HouseRobberII_WhenSumNonAdjacent_ReturnMaxAmount(int[] nums, int expected)
        {
            int result = _dynamicProgramming.HouseRobberII(nums);

            Assert.AreEqual(expected, result);
        }
    }
}
