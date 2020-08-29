using NUnit.Framework;

namespace Code.Tests.BinaryTests
{
    [TestFixture]
    class HammingWeightTests
    {
        private Binary _Binary;

        [SetUp]
        public void Setup()
        {
            _Binary = new Binary();
        }

        [Test]
        public void HammingWeight_InputUnsignedNumber_ReturnOne()
        {
            // Arrange
            uint unsignedNum = 0b_00000000000000000000000010000000;
            int expected = 1;

            // Act
            int actual = _Binary.HammingWeight(unsignedNum);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HammingWeight_InputUnsignedNumberWithThreeOnes_ReturnThree()
        {
            uint unsignedNum = 0b_00000000000000000000000000001011;
            int expected = 3;

            int actual = _Binary.HammingWeight(unsignedNum);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HammingWeight_InputUnsignedNumber_ReturnNumberOfOnes()
        {
            uint unsignedNum = 0b_11111111111111111111111111111101;
            int expected = 31;

            int actual = _Binary.HammingWeight(unsignedNum);

            Assert.AreEqual(expected, actual);
        }
    }
}
