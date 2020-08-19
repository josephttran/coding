using NUnit.Framework;

namespace Code.Tests.ArrayTopicTests
{
    [TestFixture]
    class FindMinRotatedSortedArrayTests
    {
        private ArrayTopic _ArrayTopic;

        [SetUp]
        public void Setup()
        {
            _ArrayTopic = new ArrayTopic();
        }

        [Test]
        public void FindMinRotatedSortedArray_TestOne_ReturnMin()
        {
            int[] nums = { 1 };
            int expected = 1;

            int actual = _ArrayTopic.FindMinRotatedSortedArray(nums);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindMinRotatedSortedArray_Test_ReturnMin()
        {
            int[] nums = { 3, 4, 5, 1, 2 };
            int expected = 1;

            int actual = _ArrayTopic.FindMinRotatedSortedArray(nums);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindMinRotatedSortedArray_TestTwo_ReturnMin()
        {
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int expected = 0;

            int actual = _ArrayTopic.FindMinRotatedSortedArray(nums);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindMinRotatedSortedArray_TestThree_ReturnMin()
        {
            int[] nums = { 0, 1, 3, 4, 6, 8, 9 };
            int expected = 0;

            int actual = _ArrayTopic.FindMinRotatedSortedArray(nums);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindMinRotatedSortedArray_TestFour_ReturnMin()
        {
            int[] nums = { 3, 1, 2 };
            int expected = 1;

            int actual = _ArrayTopic.FindMinRotatedSortedArray(nums);

            Assert.AreEqual(expected, actual);
        }
    }
}