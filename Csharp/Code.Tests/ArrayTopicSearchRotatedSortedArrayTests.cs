using NUnit.Framework;

namespace Code.Tests
{
    [TestFixture]
    class ArrayTopicSearchRotatedSortedArrayTests
    {
        private ArrayTopic _ArrayTopic;

        [SetUp]
        public void Setup()
        {
            _ArrayTopic = new ArrayTopic();
        }

        [Test]
        public void SearchRotatedSortedArray_TargetValueDoesNotExist_ReturnNegativeOne()
        {
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 3;
            int expected = -1;

            int actual = _ArrayTopic.SearchRotatedSortedArray(nums, target);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SearchRotatedSortedArray_Sorted_ReturnTargetValueIndex()
        {
            int[] nums = { 0, 1, 2, 4, 5, 6, 7};
            int target = 4;
            int expected = 3;

            int actual = _ArrayTopic.SearchRotatedSortedArray(nums, target);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 3 }, 2, -1)]
        [TestCase(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
        [TestCase(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 1, 5)]
        [TestCase(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 6, 2)]
        public void SearchRotatedSortedArray_Rotated_ReturnTargetValueIndex(int[] nums, int target, int expected)
        {
            int actual = _ArrayTopic.SearchRotatedSortedArray(nums, target);

            Assert.AreEqual(expected, actual);
        }
    }
}