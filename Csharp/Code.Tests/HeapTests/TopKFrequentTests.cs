using NUnit.Framework;

namespace Code.Tests.HeapTests
{
    [TestFixture]
    class TopKFrequentTests
    {
        private Heap _heap;

        [SetUp]
        public void Setup()
        {
            _heap = new Heap();
        }

        [Test]
        public void TopKFrequent_SingleElement_Tests()
        {
            int[] nums = { 1 };
            int k = 1;
            int[] expected = { 1 };

            int[] result = _heap.TopKFrequent(nums, k);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void TopKFrequent_Tests()
        {
            int[] nums = { 1, 1, 1, 2, 2, 3 };
            int k = 2;
            int[] expected = { 1, 2 };

            int[] result = _heap.TopKFrequent(nums, k);

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
