using NUnit.Framework;

namespace Code.Tests.MatrixTests
{
    public class SetMatrixZeroesTests
    {
        Matrix _matrix;

        [SetUp]
        public void SetUp()
        {
            _matrix = new Matrix();
        }

        [Test]
        public void SetMatrixZeroes_SingleColumnTest()
        {
            int[][] matrix = {
                new int[] { 1 }, 
                new int[] { 0 },
                new int[] { 1 }};

            int[][] expectedMatrix = {
                new int[] { 0 },
                new int[] { 0 },
                new int[] { 0 }};

            _matrix.SetMatrixZeroes(matrix);

            CollectionAssert.AreEqual(expectedMatrix, matrix);
        }

        [Test]
        public void SetMatrixZeroes_SingleRowTest()
        {
            int[][] matrix = { new int[] { 1, 0, 1 } };

            int[][] expectedMatrix = { new int[] { 0, 0, 0 } };

            _matrix.SetMatrixZeroes(matrix);

            CollectionAssert.AreEqual(expectedMatrix, matrix);
        }

        [Test]
        public void SetMatrixZeroes_ShouldSetRowAndColumnToZero_WhenElementIsZero()
        {
            int[][] matrix = { 
                new int[] { 1, 1, 1 },
                new int[] { 1, 0, 1 },
                new int[] { 1, 1, 1 } };

            int[][] expectedMatrix = {
                new int[] { 1, 0, 1 },
                new int[] { 0, 0, 0 },
                new int[] { 1, 0, 1 } };

            _matrix.SetMatrixZeroes(matrix);

            CollectionAssert.AreEqual(expectedMatrix, matrix);
        }

        [Test]
        public void SetMatrixZeroes_WhenElementIsZero_SetRowAndColumnToZero()
        {
            int[][] matrix = {
                new int[] { 0, 1, 2, 0 },
                new int[] { 3, 4, 5, 2 },
                new int[] { 1, 3, 1, 5 } };

            int[][] expectedMatrix = {
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 4, 5, 0 },
                new int[] { 0, 3, 1, 0 } };

            _matrix.SetMatrixZeroes(matrix);

            CollectionAssert.AreEqual(expectedMatrix, matrix);
        }

        [Test]
        public void SetMatrixZeroes_WhenElementIsZero_SetRowAndColumnToZero_Test()
        {
            int[][] matrix = {
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 0, 7, 8 },
                new int[] { 0, 10, 11, 12 },
                new int[] { 13, 14, 15, 0 } };

            int[][] expectedMatrix = {
                new int[] { 0, 0, 3, 0 },
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0 } };

            _matrix.SetMatrixZeroes(matrix);

            CollectionAssert.AreEqual(expectedMatrix, matrix);
        }
    }
}
