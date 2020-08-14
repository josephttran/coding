using NUnit.Framework;

namespace Code.Tests
{
    [TestFixture]
    class ArrayTopicMaxSubArray
    {
        private ArrayTopic _ArrayTopic;

        [SetUp]
        public void Setup()
        {
            _ArrayTopic = new ArrayTopic();
        }

        [Test]
        public void MaxSubArray_InputIntegerArray_ReturnMaxSum()
        {
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int expected = 6;

            int actual = _ArrayTopic.MaxSubArray(nums);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MaxSubArrayDAC_InputIntegerArray_ReturnMaxSum()
        {
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int expected = 6;

            int actual = _ArrayTopic.MaxSubArrayDAC(nums);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 4 }, 4)]
        [TestCase(new int[] { -2, 1, -3, 4, 10 }, 14)]
        [TestCase(new int[] { 4, 1, -3, 4, -5, 10, -2 }, 11)]
        public void MaxSubArrayDAC_InputIntegers_ReturnMaxSum(int[] nums, int expected)
        {
            int actual = _ArrayTopic.MaxSubArrayDAC(nums);

            Assert.AreEqual(expected, actual);
        }
    }
}