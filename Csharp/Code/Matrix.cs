using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code
{
    public class Matrix
    {

        /* Given an m x n matrix. If an element is 0, set its entire row and column to 0.
         */
        public void SetMatrixZeroes(int[][] matrix)
        {
            bool zeroRow = Array.IndexOf(matrix[0], 0) != -1;
            bool zeroColumn = matrix.Any(row => row[0] == 0);

            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix[i].Length; ++j)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }
                }
            }

            for (int i = 1; i < matrix.Length; ++i)
            {
                if (matrix[i][0] == 0)
                {
                    for (int j = 1; j < matrix[i].Length; ++j)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            for (int j = 1; j < matrix[0].Length; ++j)
            {
                if (matrix[0][j] == 0)
                {
                    for (int i = 1; i < matrix.Length; ++i)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            if (zeroRow)
            {
                for (int j = 0; j < matrix[0].Length; ++j)
                {
                    matrix[0][j] = 0;
                }
            }

            if(zeroColumn)
            {
                for (int i = 0; i < matrix.Length; ++i)
                {
                    matrix[i][0] = 0;
                }
            }
        }
    }
}
