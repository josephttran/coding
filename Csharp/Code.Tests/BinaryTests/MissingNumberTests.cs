using NUnit.Framework;

namespace Code.Tests.BinaryTests
{
    [TestFixture]
    class MissingNumberTests
    {
        private Binary _Binary;

        [SetUp]
        public void Setup()
        {
            _Binary = new Binary();
        }

        [Test]
        public void MissingNumber_InputArrayNumber_ReturnMissingNumber()
        {
            // Arrange
            int[] nums = new int[] { 3, 0, 1 };
            int expected = 2;

            // Act
            int actual = _Binary.MissingNumber(nums);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MissingNumber_InputNumbers_ReturnMissingNumber()
        {
            int[] nums = new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
            int expected = 8;

            int actual = _Binary.MissingNumber(nums);

            Assert.AreEqual(expected, actual);
        }
    }
}
