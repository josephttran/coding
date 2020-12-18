using NUnit.Framework;

namespace Code.Tests.HeapTests
{
    [TestFixture]
    class MedianFinderTests
    {
        Heap.MedianFinder _heapMedianFinder;

        [SetUp]
        public void Setup()
        {
            _heapMedianFinder = new Heap.MedianFinder();
        }

        [Test]
        public void MedianFinder_Test()
        {
            int addOne = 1;
            double expected = 1;

            _heapMedianFinder.AddNum(addOne);
            double result = _heapMedianFinder.FindMedian();
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MedianFinder_Tests()
        {
            int addOne = 1;
            int addTwo = 2;
            int addThree = 3;
            double expected1 = 1.5;
            double expected2 = 2;

            _heapMedianFinder.AddNum(addOne);
            _heapMedianFinder.AddNum(addTwo);
            double result1 = _heapMedianFinder.FindMedian();
            _heapMedianFinder.AddNum(addThree);
            double result2 = _heapMedianFinder.FindMedian();


            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected1, result1);
                Assert.AreEqual(expected2, result2);
            });
        }
    }
}
