using NUnit.Framework;

namespace Code.Tests.DynamicProgrammingTests
{
    [TestFixture]
    class CombinationSumIVTests
    {
        private DynamicProgramming _dynamicProgramming;

        [SetUp]
        public void SetUp()
        {
            _dynamicProgramming = new DynamicProgramming();
        }

        [Test]
        public void CombinationSumIV_ReturnPossibleCombination()
        {
            int[] nums = new int[] { 1, 2, 3 };
            int target = 4;
            int expected = 7;

            int result = _dynamicProgramming.CombinationSumIV(nums, target);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CombinationSumIV_ArrayNotInSequence_ReturnPossibleCombination()
        {
            int[] nums = new int[] { 1, 5, 3 };
            int target = 6;
            int expected = 8;

            int result = _dynamicProgramming.CombinationSumIV(nums, target);

            Assert.AreEqual(expected, result);
        }
    }
}
