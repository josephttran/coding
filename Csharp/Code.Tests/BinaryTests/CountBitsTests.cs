using NUnit.Framework;

namespace Code.Tests.BinaryTests
{
    [TestFixture]
    class CountBitsTests
    {
        private Binary _Binary;

        [SetUp]
        public void Setup()
        {
            _Binary = new Binary();
        }

        [Test]
        public void CountBits_InputNumber_ReturnArrayWithLengthOfNumberPlusOne()
        {
            // Arrange
            int num = 8;
            int expectedLength = 9;

            // Act
            int[] countArr = _Binary.CountBits(num);
            int length = countArr.Length;

            // Assert
            Assert.AreEqual(expectedLength, length);
        }

        [Test]
        public void CountBits_InputNumberTwo_ReturnArrayZeroOneOne()
        {
            // Arrange
            int num = 2;
            int[] expected = new int[] { 0, 1, 1 };

            // Act
            int[] actual = _Binary.CountBits(num);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, new int[] { 0, 1, 1, 2, 1, 2 })]
        [TestCase(16, new int[] { 0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4, 1 })]
        public void CountBits_InputNumber_ReturnArrayCountOnesBits(int num, int[] expected)
        {
            int[] actual = _Binary.CountBits(num);

            Assert.AreEqual(expected, actual);
        }
    }
}
