using NUnit.Framework;

namespace Code.Tests.MatrixTests
{
    class WordSearchTests
    {
        Matrix _matrix;

        [SetUp]
        public void SetUp()
        {
            _matrix = new Matrix();
        }

        [TestCase]
        public void RotateImage_False_TestCase()
        {
            char[][] matrix = { 
                new char[] { 'A', 'B', 'C', 'E' },
                new char[] { 'S', 'F', 'C', 'S' },
                new char[] { 'A', 'D', 'E', 'E' } };

            string word = "ABCB";
            bool expected = false;

            bool result = _matrix.WordSearch(matrix, word);

            Assert.AreEqual(expected, result);
        }

        [TestCase("ABCCED")]
        [TestCase("SEE")]
        public void RotateImage_True_TestCase(string word)
        {
            char[][] matrix = {
                new char[] { 'A', 'B', 'C', 'E' },
                new char[] { 'S', 'F', 'C', 'S' },
                new char[] { 'A', 'D', 'E', 'E' } };

            bool expected = true;

            bool result = _matrix.WordSearch(matrix, word);

            Assert.AreEqual(expected, result);
        }
    }
}
