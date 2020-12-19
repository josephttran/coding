using Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code
{
    public class Matrix
    {
        /* You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise). 
         * You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. 
         * DO NOT allocate another 2D matrix and do the rotation.
         * matrix.length == n
         */
        public void RotateImage(int[][] matrix)
        {
            int left = 0;
            int right = matrix.Length - 1;
            int top = 0;
            int bottom = matrix.Length - 1;

            while (top < bottom)
            {
                int l = left;
                int r = right;
                int t = top;
                int b = bottom;

                int copyLen = r - l;
                int[] temp = new int[copyLen];
                Array.Copy(matrix[top], l, temp, 0, copyLen);

                while (l < right)
                {
                    matrix[top][l] = matrix[b][left];
                    matrix[b][left] = matrix[bottom][r];
                    matrix[bottom][r] = matrix[t][right];

                    l++;
                    r--;
                    b--;
                    t++;
                }

                for (int i = top, tempIndex = 0; i < bottom; ++i, ++tempIndex)
                {
                    matrix[i][right] = temp[tempIndex];
                }

                left++;
                right--;
                top++;
                bottom--;
            }        
        }

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

        /* Given an m x n board of characters and a list of strings words, return all words on the board.
         * Each word must be constructed from letters of sequentially adjacent cells, 
         * where adjacent cells are horizontally or vertically neighboring. 
         * The same letter cell may not be used more than once in a word.
         */
        public IList<string> WordSearchII(char[][] board, string[] words)
        {
            IList<string> result = new List<string>();
            TrieNodeWord trie = new TrieNodeWord();

            for (int i = 0; i < words.Length; i++)
            {
                InsertWord(trie, words[i]);
            }

            for (int i = 0; i < board.Length; i++)
            {
                TrieNodeWord root = trie;

                for (int j = 0; j < board[i].Length; j++)
                {
                    dfs(board, i, j, root, result);
                }
            }

            return result;

            void dfs(char[][] b, int i, int j, TrieNodeWord trieNode, IList<string> res)
            {
                // Base
                if (trieNode.Word != null)
                {
                    res.Add(trieNode.Word);
                    trieNode.Word = null;
                }

                // Out of Bound
                if (i < 0 || i > b.Length - 1 || j < 0 || j > b[i].Length - 1)
                {
                    return;
                }

                char c = b[i][j];

                // Already visited
                if (c == '#' || trieNode.Children[c - 'a'] == null)
                {
                    return;
                }

                trieNode = trieNode.Children[c - 'a'];
                b[i][j] = '#';

                dfs(b, i + 1, j, trieNode, res);
                dfs(b, i - 1, j, trieNode, res);
                dfs(b, i, j + 1, trieNode, res);
                dfs(b, i, j - 1, trieNode, res);

                b[i][j] = c;
            }

            void InsertWord(TrieNodeWord node, string word)
            {
                TrieNodeWord currentNode = node;

                for (int i = 0; i < word.Length; i++)
                {
                    int index = word[i] - 'a';

                    if (currentNode.Children[index] == null)
                    {
                        currentNode.Children[index] = new TrieNodeWord();
                    }

                    currentNode = currentNode.Children[index];
                }

                currentNode.Word = word;
            }
        }

        /* Given an m x n board and a word, find if the word exists in the grid.
         * The word can be constructed from letters of sequentially adjacent cells, 
         * where "adjacent" cells are horizontally or vertically neighboring. 
         * The same letter cell may not be used more than once.
         */
        public bool WordSearch(char[][] board, string word)
        {
            if (board == null || board[0].Length == 0)
            {
                return false;
            }

            int m = board.Length;
            int n = board[0].Length;

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    // If first letter match then find the rest in order
                    if (board[i][j] == word[0])
                    {
                        if (match(board, i, j, 0, word))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;

            bool match(char[][] b, int i, int j, int position, string w)
            {
                if (position == w.Length)
                {
                    return true;
                }

                // Out of bound or character not at right position in the word
                if (i < 0 || j < 0 || i > b.Length - 1 || j > b[0].Length - 1 || b[i][j] != word[position])
                {
                    return false;
                }

                // Mark cell as visited
                char temp = b[i][j];
                b[i][j] = '-';

                bool valid = match(b, i + 1, j, position + 1, w) ||
                    match(b, i - 1, j, position + 1, w) ||
                    match(b, i, j + 1, position + 1, w) ||
                    match(b, i, j - 1, position + 1, w);

                b[i][j] = temp;

                return valid;;
            }
        }
    }
}
