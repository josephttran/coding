using NUnit.Framework;

namespace Code.Tests.GraphTests
{
    [TestFixture]
    class CanFinishCoursesTests
    {
        private Graph _graph;

        [SetUp]
        public void SetUp()
        {
            _graph = new Graph();
        }

        [Test]
        public void CanFinishCourses_ShouldBeFalse()
        {
            int numCourses = 2;
            int[][] prerequisites = new int[][]
            {
                new int[] { 1, 0 },
                new int[] { 0, 1 }
            };

            bool result = _graph.CanFinishCourses(numCourses, prerequisites);

            Assert.IsFalse(result);
        }

        [Test]
        public void CanFinishCourses_ShouldBeFalse_Test()
        {
            int numCourses = 3;
            int[][] prerequisites = new int[][]
            {
                new int[] { 1, 0 },
                new int[] { 0, 2 },
                new int[] { 2, 1 }
            };

            bool result = _graph.CanFinishCourses(numCourses, prerequisites);

            Assert.IsFalse(result);
        }

        [Test]
        public void CanFinishCourses_ShouldBeFalse_Tests()
        {
            int numCourses = 3;
            int[][] prerequisites = new int[][]
            {
                new int[] { 1, 0 },
                new int[] { 1, 2 },
                new int[] { 0, 1 }
            };

            bool result = _graph.CanFinishCourses(numCourses, prerequisites);

            Assert.IsFalse(result);
        }

        [Test]
        public void CanFinishCourses_ShouldBeTrue()
        {
            int numCourses = 3;
            int[][] prerequisites = new int[][]
            {
                new int[] { 1, 0 },
                new int[] { 2, 1 }
            };

            bool result = _graph.CanFinishCourses(numCourses, prerequisites);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanFinishCourses_ShouldBeTrue_WhenNoPrerequisite()
        {
            int numCourses = 2;
            int[][] prerequisites = new int[][] { };

            bool result = _graph.CanFinishCourses(numCourses, prerequisites);

            Assert.IsTrue(result);
        }
    }
}
