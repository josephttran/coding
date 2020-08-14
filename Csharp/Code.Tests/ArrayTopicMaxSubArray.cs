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
        public void MaxSubArray_ReturnM()
        {
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int expected = 6;

            int actual = _ArrayTopic.MaxSubArray(nums);

            Assert.AreEqual(expected, actual);
        }
    }
}