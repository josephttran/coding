using NUnit.Framework;

namespace Code.Tests
{
    [TestFixture]
    class ArrayTopicTests
    {
        private ArrayTopic _ArrayTopic;

        [SetUp]
        public void Setup()
        {
            _ArrayTopic = new ArrayTopic();
        }

        [Test]
        public void TwoSum_ArrayOfIntegerAndTargetValueInput_ReturnTwoIndicesWhereValueSumEqualTargetValue()
        {
            // Arrange
            int[] nums = { 0, 4, 5, 2, 13, 22 };
            int target = 15;
            int[] expected = { 3, 4 };
            
            // Act
            int[] result = _ArrayTopic.TwoSum(nums, target);

            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}
