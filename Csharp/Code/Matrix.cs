﻿using System;
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

        /* Given an m x n matrix, return all elements of the matrix in spiral order.
         */
        public IList<int> SpiralOrder(int[][] matrix)
        {
            IList<int> spiralList = new List<int>();
            int top = 0;
            int bottom = matrix.Length - 1;
            int left = 0;
            int right = matrix[0].Length - 1;

            while (top < bottom && left < right)
            {
                int l = left;
                int r = right;

                // left to right
                while (l <= r)
                {
                    spiralList.Add(matrix[top][l]);
                    l++;
                }

                // top to bottom
                int t = top + 1;
                int b = bottom;
                while (t <= b)
                {
                    spiralList.Add(matrix[t][right]);
                    t++;
                }

                // right to left
                l = left;
                r = right - 1;

                while (l <= r)
                {
                    spiralList.Add(matrix[bottom][r]);
                    r--;
                }

                // bottom to top
                t = top + 1;
                b = bottom - 1;
                while (t <= b)
                {
                    spiralList.Add(matrix[b][left]);
                    b--;
                }

                top++;
                bottom--;
                left++;
                right--;
            }

            if (left <= right && top == bottom)
            {
                while (left < right)
                {
                    spiralList.Add(matrix[top][left]);
                    left++;
                }
            }

            if (left == right && top <= bottom)
            {
                while (top < bottom)
                {
                    spiralList.Add(matrix[top][left]);
                    top++;
                }
            }

            if (left == right && top == bottom)
            {
                spiralList.Add(matrix[top][left]);
            }

            return spiralList;
        }
    }
}