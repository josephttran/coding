using NUnit.Framework;
using System.Collections;

namespace Code.Tests.MatrixTests
{
    [TestFixture]
    class RotateImageTests
    {
        Matrix _matrix;

        [SetUp]
        public void SetUp()
        {
            _matrix = new Matrix();
        }

        [Test]
        public void RotateImage_NLengthIsOne()
        {
            int[][] matrix = { new int[] { 1 } };
            int[][] expectedMatrix = { new int[] { 1 } };

            _matrix.RotateImage(matrix);

            CollectionAssert.AreEqual(expectedMatrix, matrix);
        }

        [Test]
        public void RotateImage_NLengthIsTwo()
        {
            int[][] matrix = { 
                new int[] { 1, 2 },
                new int[] { 3, 4 } };

            int[][] expectedMatrix = {
                new int[] { 3, 1 },
                new int[] { 4, 2 } };

            _matrix.RotateImage(matrix);

            CollectionAssert.AreEqual(expectedMatrix, matrix);
        }

        [TestCaseSource(typeof(MyDataClass), nameof(MyDataClass.TestCases))]
        public void RotateImage_Test(int[][] matrix, int[][] expectedMatrix)
        {
            _matrix.RotateImage(matrix);

            CollectionAssert.AreEqual(expectedMatrix, matrix);
        }
    }

    public class MyDataClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                int[][] matrix = {
                    new int[] { 1, 2, 3 },
                    new int[] { 4, 5, 6 },
                    new int[] { 7, 8, 9 }};

                int[][] expectedMatrix = {
                    new int[] { 7, 4, 1 },
                    new int[] { 8, 5, 2 },
                    new int[] { 9, 6, 3 }};

                int[][] matrix2 = {
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 5, 6, 7, 8 },
                    new int[] { 9, 10, 11, 12 },
                    new int[] { 13, 14, 15, 16 }};

                int[][] expectedMatrix2 = {
                    new int[] { 13, 9, 5, 1 },
                    new int[] { 14, 10, 6, 2 },
                    new int[] { 15, 11, 7, 3 },
                    new int[] { 16, 12, 8, 4 }};

                yield return new TestCaseData(matrix, expectedMatrix);
                yield return new TestCaseData(matrix2, expectedMatrix2);
            }
        }
    }
}
