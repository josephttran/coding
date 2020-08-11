using NUnit.Framework;

namespace Code.Tests
{
    [TestFixture]
    class ArrayTopicMaxProfitTests
    {
        private ArrayTopic _ArrayTopic;

        [SetUp]
        public void Setup()
        {
            _ArrayTopic = new ArrayTopic();
        }

        [Test]
        public void MaxProfit_EmptyPrices_ReturnZero()
        {
            int[] stockPrices = { };

            int profit = _ArrayTopic.MaxProfit(stockPrices);

            Assert.AreEqual(profit, 0);
        }

        [Test]
        public void MaxProfit_BuyPriceLargerThanSellPrices_ReturnZero()
        {
            int[] stockPrices = { 7, 6, 4, 3, 1 };

            int profit = _ArrayTopic.MaxProfit(stockPrices);

            Assert.AreEqual(profit, 0);
        }

        [TestCase(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
        [TestCase(new int[] { 2, 4, 1 }, 2)]
        [TestCase(new int[] { 3, 2, 6, 5, 0, 3 }, 4)]
        public void MaxProfit_HasHigherSellPrices_ReturnMaxProfit(int[] stockPrices, int expected)
        {
            int profit = _ArrayTopic.MaxProfit(stockPrices);

            Assert.AreEqual(profit, expected);
        }
    }
}
