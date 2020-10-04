using NUnit.Framework;

namespace Code.Tests.DynamicProgrammingTests
{
    [TestFixture]
    class CanJumpTests
    {
        private DynamicProgramming _dynamicProgramming;

        [SetUp]
        public void SetUp()
        {
            _dynamicProgramming = new DynamicProgramming();
        }

        [Test]
        public void CanJump_WhenCannotReachEnd_ReturnFalse()
        {
            int[] nums = new int[] { 3, 2, 1, 0, 4 };

            bool result = _dynamicProgramming.CanJump(nums);

            Assert.IsFalse(result);
        }

        [Test]
        public void CanJump_WhenCanReachEnd_ReturnTrue()
        {
            int[] nums = new int[] { 2, 3, 1, 1, 4 };

            bool result = _dynamicProgramming.CanJump(nums);

            Assert.IsTrue(result);
        }
    }
}
