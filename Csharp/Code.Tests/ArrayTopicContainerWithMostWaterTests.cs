using NUnit.Framework;

namespace Code.Tests
{
    [TestFixture]
    class ArrayTopicContainerWithMostWaterTests
    {
        private ArrayTopic _ArrayTopic;

        [SetUp]
        public void Setup()
        {
            _ArrayTopic = new ArrayTopic();
        }

        [Test]
        public void ContainerWithMostWater_OneElement_ReturnZero()
        {
            // Arrange
            int[] nums = { 4 };
            int expected = 0;

            // Act
            int result = _ArrayTopic.ContainerWithMostWater(nums);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ContainerWithMostWater_ArrayOfPositiveInteger_ReturnMaxArea()
        {
            // Arrange
            int[] nums = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            int expected = 49;

            // Act
            int result = _ArrayTopic.ContainerWithMostWater(nums);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ContainerWithMostWater_ArrayOfPositiveInteger2_ReturnMaxArea()
        {
            // Arrange
            int[] nums = { 1, 8, 26, 9, 5, 4, 25, 3, 9 };
            int expected = 100;

            // Act
            int result = _ArrayTopic.ContainerWithMostWater(nums);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
