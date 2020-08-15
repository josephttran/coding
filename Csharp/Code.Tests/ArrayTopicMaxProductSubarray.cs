using NUnit.Framework;

namespace Code.Tests
{
    [TestFixture]
    class ArrayTopicMaxProductSubarray
    {
        private ArrayTopic _ArrayTopic;

        [SetUp]
        public void Setup()
        {
            _ArrayTopic = new ArrayTopic();
        }

        [Test]
        public void MaxProductSubarray_ArrayOneNumber_ReturnNumber()
        {
            int[] nums = { 4 };
            int expected = 4;

            int actual = _ArrayTopic.MaxProductSubarray(nums);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { -1, -2, -1, 2, 2, 1, 1 }, 8)]
        [TestCase(new int[] { 2, -5, -2, -4, 3 }, 24)]
        [TestCase(new int[] { 6, 3, -10, 0, 2 }, 18)]
        [TestCase(new int[] { 2, 3 }, 6)]
        [TestCase(new int[] { -3, 0, 1, -2 }, 1)]
        [TestCase(new int[] { -5, 0, 2 }, 2)]
        [TestCase(new int[] { -3, 0, -1, -4, 0, -1 }, 4)]
        [TestCase(new int[] { -3, -1, -1 }, 3)]
        [TestCase(new int[] { 3, -1, 4 }, 4)]
        [TestCase(new int[] { 0, 0 }, 0)]
        [TestCase(new int[] { 0, 0, 1 }, 1)]
        [TestCase(new int[] { 0, 0, 2, 0, 0, 1 }, 2)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 0, 2 }, 2)]
        [TestCase(new int[] { 2, 3, 4 }, 24)]
        [TestCase(new int[] { 2, 3, -2, 4 }, 6)]
        [TestCase(new int[] { -2, 0, -1 }, 0)]
        [TestCase(new int[] { 4, 0, -3, 5, -2, 0, 4, 5}, 30)]
        [TestCase(new int[] { 0, -3, 5, -2, 0, 4, 5 }, 30)]
        public void MaxProductSubarray_ArrayIntegers_ReturnMaxProduct(int[] nums, int expected)
        {
            int actual = _ArrayTopic.MaxProductSubarray(nums);

            Assert.AreEqual(expected, actual);
        }
    }
}