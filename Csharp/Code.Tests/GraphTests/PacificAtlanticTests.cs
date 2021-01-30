using NUnit.Framework;
using System.Collections.Generic;

namespace Code.Tests.GraphTests
{
    [TestFixture]
    class PacificAtlanticTests
    {
        private Graph _graph;

        [SetUp]
        public void SetUp()
        {
            _graph = new Graph();
        }

        [Test]
        public void PacificAtlantic_TestWhenEmpty()
        {
            /*  Pacific ~   ~   ~   ~   ~ 
                   ~  1   2   2   3  (5) *
                   ~  3   2   3  (4) (4) *
                   ~  2   4  (5)  3   1  *
                   ~ (6) (7)  1   4   5  *
                   ~ (5)  1   1   2   4  *
                      *   *   *   *   * Atlantic
             */
            int[][] matrix = null;

            IList<IList<int>> expected = new List<IList<int>>();

            IList<IList<int>> result = _graph.PacificAtlantic(matrix);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void PacificAtlantic_ColumnGreaterThanRow_ShouldContainList()
        {
            /*  Pacific ~   ~ ~
                   ~  1   1   1 *
                   ~  1   1   1 *
                      *   *   * * Atlantic
             */
            int[][] matrix = new int[][]
            {
                new int[] { 1, 1, 1 },
                new int[] { 1, 1, 1 }
            };

            IList<IList<int>> expected = new List<IList<int>>()
            {
                new List<int>() { 0, 0 },
                new List<int>() { 0, 1 },
                new List<int>() { 0, 2 },
                new List<int>() { 1, 0 },
                new List<int>() { 1, 1 },
                new List<int>() { 1, 2 }
            };

            IList<IList<int>> result = _graph.PacificAtlantic(matrix);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void PacificAtlantic_RowGreaterThanColumn_ShouldContainList()
        {
            /*  Pacific ~   ~
                   ~  1   1  *
                   ~  1   1  *
                   ~  1   1  *
                      *   *  * Atlantic
             */
            int[][] matrix = new int[][]
            {
                new int[] { 1, 1 },
                new int[] { 1, 1 },
                new int[] { 1, 1 }
            };

            IList<IList<int>> expected = new List<IList<int>>()
            {
                new List<int>() { 0, 0 },
                new List<int>() { 0, 1 },
                new List<int>() { 1, 0 },
                new List<int>() { 1, 1 },
                new List<int>() { 2, 0 },
                new List<int>() { 2, 1 }
            };

            IList<IList<int>> result = _graph.PacificAtlantic(matrix);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void PacificAtlantic_ShouldContainList()
        {
            /*  Pacific ~   ~   ~   ~   ~ 
                   ~  1   2   2   3  (5) *
                   ~  3   2   3  (4) (4) *
                   ~  2   4  (5)  3   1  *
                   ~ (6) (7)  1   4   5  *
                   ~ (5)  1   1   2   4  *
                      *   *   *   *   * Atlantic
             */
            int[][] matrix = new int[][]
            {
                new int[] { 1, 2, 2, 3, 5 },
                new int[] { 3, 2, 3, 4, 4 },
                new int[] { 2, 4, 5, 3, 1 },
                new int[] { 6, 7, 1, 4, 5 },
                new int[] { 5, 1, 1, 2, 4 }
            };

            IList<IList<int>> expected = new List<IList<int>>()
            {
                new List<int>() { 0, 4 },
                new List<int>() { 1, 3 },
                new List<int>() { 1, 4 },
                new List<int>() { 2, 2 },
                new List<int>() { 3, 0 },
                new List<int>() { 3, 1 },
                new List<int>() { 4, 0 }
            };

            IList<IList<int>> result = _graph.PacificAtlantic(matrix);

            CollectionAssert.AreEquivalent(expected, result);
        }


        [Test]
        public void PacificAtlantic_ShouldContainList_Tests()
        {
            /*  Pacific ~   ~   ~   
                   ~  1   2   3  *
                   ~  8   9   4  *
                   ~  7   6   5  *
                      *   *   *  *  * Atlantic
             */

            int[][] matrix = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 8, 9, 4 },
                new int[] { 7, 6, 5 }
            };

            IList<IList<int>> expected = new List<IList<int>>()
            {
                new List<int>() { 0, 2 },
                new List<int>() { 1, 0 },
                new List<int>() { 1, 1 },
                new List<int>() { 1, 2 },
                new List<int>() { 2, 0 },
                new List<int>() { 2, 1 },
                new List<int>() { 2, 2 }
            };

            IList<IList<int>> result = _graph.PacificAtlantic(matrix);

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
