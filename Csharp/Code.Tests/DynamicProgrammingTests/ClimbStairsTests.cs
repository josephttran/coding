using NUnit.Framework;

namespace Code.Tests.DynamicProgrammingTests
{
    [TestFixture]
    class ClimbStairsTests
    {
        private DynamicProgramming _dynamicProgramming;

        [SetUp]
        public void SetUp()
        {
            _dynamicProgramming = new DynamicProgramming();
        }

        [Test]
        public void ClimbStairs_WhenInputOne_ReturnOne()
        {
            // Arrange
            int num = 1;
            int expected = 1;

            // Act
            int result = _dynamicProgramming.ClimbStairs(num);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 5)]
        [TestCase(5, 8)]
        [TestCase(6, 13)]
        public void ClimbStairs_WhenNumGreaterThanZeroAndLessThanFortySix_ReturnNumberOfWay(int num, int expected)
        {
            int result = _dynamicProgramming.ClimbStairs(num);

            Assert.AreEqual(expected, result);
        }

        [Test, Timeout(5000)]
        public void ClimbStairs_WhenInputLargeNumber_ReturnNotTakeLong()
        {
            // Arrange
            int num = 44;
            int expected = 1134903170;

            // Act
            int result = _dynamicProgramming.ClimbStairs(num);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
