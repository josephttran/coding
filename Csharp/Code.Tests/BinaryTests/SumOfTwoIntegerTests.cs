using NUnit.Framework;

namespace Code.Tests.BinaryTests
{
    [TestFixture]
    class SumOfTwoIntegerTests
    {
        private Binary _Binary;

        [SetUp]
        public void Setup()
        {
            _Binary = new Binary();
        }

        [Test]
        public void SumOfTwoInteger_AddOneAndTwo_ReturnThree()
        {
            // Arrange
            int firstNum = 1;
            int secondNum = 2;
            int expected = 3;

            // Act
            int actual = _Binary.SumOfTwoInteger(firstNum, secondNum);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SumOfTwoInteger_AddNegativeTwoAndThree_ReturnOne()
        {
            int firstNum = -2;
            int secondNum = 3;
            int expected = 1;

            int actual = _Binary.SumOfTwoInteger(firstNum, secondNum);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 0, 0)]
        [TestCase(12, 0, 12)]
        [TestCase(8, 5, 13)]
        [TestCase(12, 5, 17)]
        [TestCase(12, 1225, 1237)]
        public void SumOfTwoInteger_AddTwoPositiveNumber_ReturnSum(int firstNum, int secondNum, int expected)
        {
            int actual = _Binary.SumOfTwoInteger(firstNum, secondNum);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-12, -1225, -1237)]
        public void SumOfTwoInteger_AddTwoNegativeNumber_ReturnSum(int firstNum, int secondNum, int expected)
        {
            int actual = _Binary.SumOfTwoInteger(firstNum, secondNum);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, -12, -12)]
        [TestCase(-12, 0, -12)]
        [TestCase(-12, 125, 113)]
        [TestCase(125, -12, 113)]
        public void SumOfTwoInteger_AddANegativeNumber_ReturnSum(int firstNum, int secondNum, int expected)
        {
            int actual = _Binary.SumOfTwoInteger(firstNum, secondNum);

            Assert.AreEqual(expected, actual);
        }
    }
}
