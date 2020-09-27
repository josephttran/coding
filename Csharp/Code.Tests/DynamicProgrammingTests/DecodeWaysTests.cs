using NUnit.Framework;

namespace Code.Tests.DynamicProgrammingTests
{
    class DecodeWaysTests
    {
        private DynamicProgramming _dynamicProgramming;

        [SetUp]
        public void SetUp()
        {
            _dynamicProgramming = new DynamicProgramming();
        }

        [Test]
        public void DecodeWays_WhenStringZero_ReturnZero()
        {
            string str = "0";
            int expected = 0;

            int result = _dynamicProgramming.DecodeWays(str);

            Assert.AreEqual(expected, result);
        }

        [TestCase("0001")]
        [TestCase("100")]
        [TestCase("1001")]
        [TestCase("30")]
        public void DecodeWays_ShouldReturnZero(string str)
        {
            int expected = 0;

            int result = _dynamicProgramming.DecodeWays(str);

            Assert.AreEqual(expected, result);
        }

        [TestCase("2206", 1)]
        [TestCase("27", 1)]
        [TestCase("9", 1)]
        [TestCase("12", 2)]
        [TestCase("226", 3)]
        [TestCase("2216", 5)]
        [TestCase("22123", 8)]
        public void DecodeWays_ShouldReturnTotalWayToDecode(string str, int expected)
        {
            int result = _dynamicProgramming.DecodeWays(str);

            Assert.AreEqual(expected, result);
        }
    }
}
