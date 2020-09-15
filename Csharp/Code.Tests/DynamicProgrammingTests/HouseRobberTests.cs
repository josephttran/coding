using NUnit.Framework;

namespace Code.Tests.DynamicProgrammingTests
{
    [TestFixture]
    class HouseRobberTests
    {
        private DynamicProgramming _dynamicProgramming;

        [SetUp]
        public void SetUp()
        {
            _dynamicProgramming = new DynamicProgramming();
        }

        [Test]
        public void HouseRobber_WhenSingleElement_ShouldReturnElement()
        {
            int[] nums = new int[] { 4 };
            int expected = 4;

            int result = _dynamicProgramming.HouseRobber(nums);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void HouseRobber_ShouldBeMaxAmount_WhenSumNonAdjacent()
        {
            int[] nums = new int[] { 1, 2, 3, 1 };
            int expected = 4;

            int result = _dynamicProgramming.HouseRobber(nums);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void HouseRobber_WhenSumNonAdjacent_ReturnMaxAmount()
        {
            int[] nums = new int[] { 2, 7, 9, 3, 1 };
            int expected = 12;

            int result = _dynamicProgramming.HouseRobber(nums);

            Assert.AreEqual(expected, result);
        }
    }
}
