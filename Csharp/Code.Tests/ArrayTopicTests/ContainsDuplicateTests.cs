using NUnit.Framework;

namespace Code.Tests.ArrayTopicTests
{
    [TestFixture]
    class ContainsDuplicateTests
    {
        private ArrayTopic _ArrayTopic;

        [SetUp]
        public void Setup()
        {
            _ArrayTopic = new ArrayTopic();
        }

        [TestCase(new int[] { 1, 2, 3, 1 })]
        [TestCase(new int[] { 1, 1, 2, 4, 8, 2 })]
        public void ContainsDuplicate_HasDuplicate_ReturnTrue(int[] values)
        {
            bool hasDuplicate = _ArrayTopic.ContainsDuplicate(values);

            Assert.IsTrue(hasDuplicate);
        }

        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 2, 6, 4, 8 })]
        public void ContainsDuplicate_NoDuplicate_ReturnFalse(int[] values)
        {
            bool hasDuplicate = _ArrayTopic.ContainsDuplicate(values);

            Assert.IsFalse(hasDuplicate);
        }
    }
}
