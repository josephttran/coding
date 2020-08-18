using NUnit.Framework;
using System.Collections.Generic;

namespace Code.Tests
{
    [TestFixture]
    class ArrayTopicThreeSumTests
    {
        private ArrayTopic _ArrayTopic;

        [SetUp]
        public void Setup()
        {
            _ArrayTopic = new ArrayTopic();
        }

        [Test]
        public void ThreeSum_ArrayOfZero_ReturnAllUniqueTripletsSumZero()
        {
            // Arrange
            int[] nums = { 0, 0, 0 };
            IList<IList<int>> expected = new List<IList<int>>()
            {
                new List<int>() { 0, 0, 0 }
            };

            // Act
            IList<IList<int>> allUniqueTriplets = _ArrayTopic.ThreeSum(nums);

            // Assert
            CollectionAssert.AreEquivalent(expected, allUniqueTriplets);
        }

        [Test]
        public void ThreeSum_ArrayOfInteger_ReturnEmpty()
        {
            int[] nums = { 1, 2, -2, -1 };
            IList<IList<int>> expected = new List<IList<int>>() { };

            IList<IList<int>> allUniqueTriplets = _ArrayTopic.ThreeSum(nums);

            CollectionAssert.AreEquivalent(expected, allUniqueTriplets);
        }

        [Test]
        public void ThreeSum_ArrayOfThreeInteger_ReturnAllUniqueTripletsSumZero()
        {
            int[] nums = { 1, 1, -2 };
            IList<IList<int>> expected = new List<IList<int>>()
            {
                new List<int>() { -2, 1, 1 }
            };

            IList<IList<int>> allUniqueTriplets = _ArrayTopic.ThreeSum(nums);

            CollectionAssert.AreEquivalent(expected, allUniqueTriplets);
        }

        [Test]
        public void ThreeSum_ArrayOfFourInteger_ReturnAllUniqueTripletsSumZero()
        {
            int[] nums = { -1, 0, 1, 0 };
            IList<IList<int>> expected = new List<IList<int>>()
            {
                new List<int>() { -1, 0 ,1 }
            };

            IList<IList<int>> allUniqueTriplets = _ArrayTopic.ThreeSum(nums);

            CollectionAssert.AreEquivalent(expected, allUniqueTriplets);
        }

        [Test]
        public void ThreeSum_ArrayOfFiveInteger_ReturnAllUniqueTripletsSumZero()
        {
            int[] nums = { -2, 0, 1, 1, 2 };
            IList<IList<int>> expected = new List<IList<int>>()
            {
                new List<int>() { -2, 0, 2 },
                new List<int>() { -2, 1, 1 }
            };

            IList<IList<int>> allUniqueTriplets = _ArrayTopic.ThreeSum(nums);

            CollectionAssert.AreEquivalent(expected, allUniqueTriplets);
        }

        [Test]
        public void ThreeSum_ArrayOfInteger_ReturnAllUniqueTripletsSumZero()
        {
            int[] nums = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> expected = new List<IList<int>>()
            {
                new List<int>() { -1, 0, 1 },
                new List<int>() { -1, -1, 2 }
            };

            IList<IList<int>> allUniqueTriplets = _ArrayTopic.ThreeSum(nums);

            CollectionAssert.AreEquivalent(expected, allUniqueTriplets);
        }

        [Test]
        public void ThreeSum_ArrayOfIntegerTest_ReturnAllUniqueTripletsSumZero()
        {
            int[] nums = { -4, -2, -2, -2, 0, 1, 2, 2, 2, 3, 3, 4, 4, 6, 6 };
            IList<IList<int>> expected = new List<IList<int>>()
            {
                new List<int>() { -4, -2, 6 },
                new List<int>() { -4, 0, 4 },
                new List<int>() { -4, 1, 3 },
                new List<int>() { -4, 2, 2 },
                new List<int>() { -2, -2, 4 },
                new List<int>() { -2, 0, 2 }
            };

            IList<IList<int>> allUniqueTriplets = _ArrayTopic.ThreeSum(nums);

            CollectionAssert.AreEquivalent(expected, allUniqueTriplets);
        }

        [Test]
        public void ThreeSum_LongArrayOfInteger_ReturnAllUniqueTripletsSumZero()
        {
            // Arrange
            int[] nums = { 
                11, 2, -10, 12, -10, 11, 9, 4, 2, -9, -12, -4, 0, 8, -6, -5, 8, 5, -15, -14, -1, 14, -6, -12,
                3, -5, 7, -3, 9, -8, -3, -3, 2, -6, -14, 7, 12, 11, -4, -9, -13, -1, 3, 2, -8, 12, 4, 7, -6, -4, 1, 8,
                -5, 10, 12, 13, 12, 4, -13, -2, 4, -9, 10, -9, -8, 4, 5, -11, 0, -13, -12, -6, -7, 6, 11, -7, -5, -8,
                -15, 4, 3, 1, -11, 13, -12, 8, 3, 8, -10, 5, -9, 9, 11, 9, 7, 10, -2, -3, 14, 13 
            };

            // Act
            IList<IList<int>> allUniqueTriplets = _ArrayTopic.ThreeSum(nums);

            // Assert
            CollectionAssert.IsNotEmpty(allUniqueTriplets);
            CollectionAssert.AllItemsAreUnique(allUniqueTriplets);
        }
    }
}
