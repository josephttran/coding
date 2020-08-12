using NUnit.Framework;

namespace Code.Tests
{
    [TestFixture]
    class ArrayTopicProductExceptSelfTests
    {
        private ArrayTopic _ArrayTopic;

        [SetUp]
        public void Setup()
        {
            _ArrayTopic = new ArrayTopic();
        }

        [Test]
        public void ProductExceptSelf_Test()
        {
            int[] nums = { 1, 2, 3, 4 };
            int[] expected = { 24, 12, 8, 6 };

            int[] result = _ArrayTopic.ProductExceptSelf(nums);

            Assert.AreEqual(expected, result);
        }
    }
}
