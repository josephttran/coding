using NUnit.Framework;

namespace Code.Tests.BinaryTests
{
    [TestFixture]
    class ReverseBitsTests
    {
        private Binary _Binary;

        [SetUp]
        public void Setup()
        {
            _Binary = new Binary();
        }

        [Test]
        public void ReverseBits_InputUnsignedint_ReturnReverseBits()
        {
            // Arrange
            uint binary = 0b_00000010100101000001111010011100;
            uint expected = 0b_00111001011110000010100101000000;

            // Act
            uint actual = _Binary.ReverseBits(binary);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseBits_InputUint_ReturnReverseBits()
        {
            // Arrange
            uint binary = 0b_11111111111111111111111111111101;
            uint expected = 0b_10111111111111111111111111111111;

            // Act
            uint actual = _Binary.ReverseBits(binary);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
