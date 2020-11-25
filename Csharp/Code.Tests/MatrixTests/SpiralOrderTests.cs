using NUnit.Framework;
using System.Collections.Generic;

namespace Code.Tests.MatrixTests
{
    [TestFixture]
    public class SpiralOrderTests
    {
        Matrix _matrix;

        [SetUp]
        public void SetUp()
        {
            _matrix = new Matrix();
        }

        [Test]
        public void SpiralOrder_Test_WhenSingleRow()
        {
            int[][] matrix = { new int[] { 1, 2, 3 } };

            IList<int> expected = new List<int>() { 1, 2, 3 };

            IList<int> result = _matrix.SpiralOrder(matrix);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SpiralOrder_Test_WhenSingleColumn()
        {
            int[][] matrix = {
                new int[] { 3 },
                new int[] { 6 },
                new int[] { 9 }};
            IList<int> expected = new List<int>() { 3, 6, 9 };

            IList<int> result = _matrix.SpiralOrder(matrix);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SpiralOrder_WhenMSameLengthN_Even()
        {
            int[][] matrix = {
                new int[] { 1, 2 },
                new int[] { 3, 4 }};

            IList<int> expected = new List<int>() { 1, 2, 4, 3 };

            IList<int> result = _matrix.SpiralOrder(matrix);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SpiralOrder_WhenMSameLengthN_Odd()
        {
            int[][] matrix = {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }};

            IList<int> expected = new List<int>() { 1, 2, 3, 6, 9, 8, 7, 4, 5 };

            IList<int> result = _matrix.SpiralOrder(matrix);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SpiralOrder_WhenNGreaterThanM_AndNOdd()
        {
            int[][] matrix = {
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 6, 7, 8, 9, 10 },
                new int[] { 11, 12, 13, 14, 15}};

            IList<int> expected = new List<int>() { 1, 2, 3, 4, 5, 10, 15, 14, 13, 12, 11, 6, 7, 8,  9, };

            IList<int> result = _matrix.SpiralOrder(matrix);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SpiralOrder_WhenNGreaterThanM_AndNEven()
        {
            int[][] matrix = {
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 6, 7, 8 },
                new int[] { 9, 10, 11, 12}};

            IList<int> expected = new List<int>() { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 };

            IList<int> result = _matrix.SpiralOrder(matrix);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SpiralOrder_WhenMGreaterThanN_AndMLengthEven()
        {
            int[][] matrix = {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
                new int[] { 10, 11, 12}};

            IList<int> expected = new List<int>() { 1, 2, 3, 6, 9, 12, 11, 10, 7, 4, 5, 8 };

            IList<int> result = _matrix.SpiralOrder(matrix);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SpiralOrder_WhenMGreaterThanN_AndMLengthOdd()
        {
            int[][] matrix = {
                new int[] { 2, 3, 4  },
                new int[] { 5, 6, 7 },
                new int[] { 8, 9, 10  },
                new int[] { 11, 12, 13 },
                new int[] { 14, 15, 16 } };

            IList<int> expected = new List<int>() { 2, 3, 4, 7, 10, 13, 16, 15, 14, 11, 8, 5, 6, 9, 12 };

            IList<int> result = _matrix.SpiralOrder(matrix);

            Assert.AreEqual(expected, result);
        }
    }
}
