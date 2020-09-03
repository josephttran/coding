using NUnit.Framework;

namespace Code.Tests.DynamicProgrammingTests
{
    class CoinChangeTests
    {
        private DynamicProgramming _dynamicProgramming;

        [SetUp]
        public void SetUp()
        {
            _dynamicProgramming = new DynamicProgramming();
        }

        [TestCase(new int[] { 2 }, 3)]
        public void CoinChange_WhenAmountCannotBeMade_ReturnNegativeOne(int[] coins, int amount)
        {
            int expected = -1;

            int result = _dynamicProgramming.CoinChange(coins, amount);

            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 1, 2, 5 }, 11, 3)]
        [TestCase(new int[] { 2, 5, 10 }, 21, 5)]
        [TestCase(new int[] { 1, 2, 5, 10, 25 }, 21, 3)]
        [TestCase(new int[] { 1, 2, 5, 10, 25 }, 27, 2)]
        public void CoinChange_WhenAmountCanBeMade_ReturnFewestCoin(int[] coins, int amount, int expected)
        {
            int result = _dynamicProgramming.CoinChange(coins, amount);

            Assert.AreEqual(expected, result);
        }
    }
}
