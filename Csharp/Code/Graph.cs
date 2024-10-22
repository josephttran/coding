﻿using Code.Ds;
using Code.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Code
{
    public class Graph
    {
        /* There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1.
         * Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
         * Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?
         * 
         * The input prerequisites is a graph represented by a list of edges, not adjacency matrices.
         */
        public bool CanFinishCourses(int numCourses, int[][] prerequisites)
        {
            int[] indegree = new int[numCourses];

            for (int i = 0; i < prerequisites.Length; i++)
            {
                indegree[prerequisites[i][0]]++;
            }

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            int numNonePrerequisite = queue.Count;

            while(queue.Count > 0)
            {
                int num = queue.Dequeue();

                for (int i = 0; i < prerequisites.Length; i++)
                {
                    if (prerequisites[i][1] == num)
                    {
                        indegree[prerequisites[i][0]]--;

                        if(indegree[prerequisites[i][0]] == 0)
                        {
                            numNonePrerequisite++;
                            queue.Enqueue(prerequisites[i][0]);
                        }
                    }
                }
            }

            return numNonePrerequisite == numCourses;
        }

        /* Given a reference of a node in a connected undirected graph.
         * Return a deep copy (clone) of the graph.
         * Each node in the graph contains a val (int) and a list (List[Node]) of its neighbors.
         * 
         * There is no repeated edges and no self-loops in the graph.
         */
        public Node CloneGraph(Node node)
        {
            if (node == null)
            {
                return null;
            }

            HashSet<Node> visited = new HashSet<Node>();
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);

            List<Node> cloneNode = new List<Node>();

            while (q.Count > 0)
            {
                Node currNode = q.Dequeue();

                if (!visited.Contains(currNode))
                {
                    visited.Add(currNode);
                    cloneNode.Add(new Node(currNode.val));
                }

                foreach (Node neighbor in currNode.neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        q.Enqueue(neighbor);
                    }
                }
            }

            cloneNode.Sort((a, b) => a.val.CompareTo(b.val));

            foreach (Node currNode in visited)
            {
                cloneNode[currNode.val - 1].neighbors = new List<Node>();

                foreach (Node neighbor in currNode.neighbors)
                {
                    cloneNode[currNode.val - 1].neighbors.Add(cloneNode[neighbor.val - 1]);
                }
            }

            return cloneNode[0];
        }

        /* Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
         */
        public int LongestConsecutiveSequence(int[] nums)
        {
            if(nums.Length == 0)
            {
                return 0;
            }

            Dictionary<int, int> map = new Dictionary<int, int>();
            Dictionary<int, int> mapSize = new Dictionary<int, int>();
            int count = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.TryGetValue(nums[i], out _))
                {
                    map[nums[i]] = nums[i];
                    mapSize[nums[i]] = 1;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                Union(nums[i], nums[i] - 1);
                Union(nums[i], nums[i] + 1);
            }

            return count;

            int Find(int x)
            {
                if (!map.TryGetValue(x, out _))
                {
                    return Int32.MinValue;
                }

                while (map[x] != x)
                {
                    map[x] = map[map[x]];
                    x = map[x];
                }

                return x;
            }

            void Union(int x, int y)
            {
                int xRoot = Find(x);
                int yRoot = Find(y);

                if (xRoot == Int32.MinValue || yRoot == Int32.MinValue)
                {
                    return;
                }

                if (xRoot == yRoot)
                {
                    return;
                }

                if (mapSize[xRoot] > mapSize[yRoot])
                {
                    map[yRoot] = xRoot;
                    mapSize[xRoot] = mapSize[xRoot] + mapSize[yRoot];
                    if(mapSize[xRoot] > count)
                    {
                        count = mapSize[xRoot];
                    }
                }
                else
                {
                    map[xRoot] = yRoot;
                    mapSize[yRoot] = mapSize[xRoot] + mapSize[yRoot];

                    if (mapSize[yRoot] > count)
                    {
                        count = mapSize[yRoot];
                    }
                }
            }
        }

        /* Given an m x n 2d grid map of '1's (land) and '0's (water), return the number of islands.
         * An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
         * You may assume all four edges of the grid are all surrounded by water.
         */
        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int numIsland = 0;
            int row = grid.Length;
            int col = grid[0].Length;

            DisjointSet ds = new DisjointSet(row * col);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        numIsland++;
                    }
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        int x = i * col + j;

                        if (i < row - 1 && grid[i + 1][j] == '1')
                        {
                            int y = (i + 1) * col + j;

                            if (!ds.IsConnected(x, y))
                            {
                                numIsland--;
                            };

                            ds.Union(x, y);
                        }

                        if (j < col - 1 && grid[i][j + 1] == '1')
                        {
                            int y = i * col + (j + 1);

                            if (!ds.IsConnected(x, y))
                            {
                                numIsland--;
                            };

                            ds.Union(x, y);
                        }
                    }
                }
            }

            return numIsland;
        }

        /* Given an m x n matrix of non-negative integers representing the height of each unit cell in a continent, 
         * the "Pacific ocean" touches the left and top edges of the matrix and the "Atlantic ocean" touches the right and bottom edges.
         * Water can only flow in four directions (up, down, left, or right) from a cell to another one with height equal or lower.
         * 
         * Find the list of grid coordinates where water can flow to both the Pacific and Atlantic ocean.
         */
        public IList<IList<int>> PacificAtlantic(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return  new List<IList<int>>();
            }

            IList<IList<int>> list = new List<IList<int>>();
            int m = matrix.Length;
            int n = matrix[0].Length;

            bool[,] pacific = new bool[m, n];
            bool[,] atlantic = new bool[m, n];

            for (int row = 0; row < m; row++)
            {
                dfs(matrix, row, 0, matrix[row][0], pacific);
                dfs(matrix, row, n - 1, matrix[row][n - 1], atlantic);
            }

            for (int col = 0; col < n; col++)
            {
                dfs(matrix, 0, col, matrix[0][col], pacific);
                dfs(matrix, m - 1, col, matrix[m - 1][col], atlantic);
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (pacific[i,j] && atlantic[i,j])
                    {
                        list.Add(new List<int> { i, j });
                    }
                }
            }

            return list;

            void dfs(int[][] mat, int i, int j, int previousHeight, bool[,] visited)
            {
                if (i < 0 || j < 0 || i > mat.Length - 1 || j > mat[0].Length - 1 || mat[i][j] < previousHeight || visited[i,j])
                {
                    return;
                }

                visited[i,j] = true;

                dfs(mat, i + 1, j, mat[i][j], visited);                
                dfs(mat, i - 1, j, mat[i][j], visited);
                dfs(mat, i, j + 1, mat[i][j], visited);
                dfs(mat, i, j - 1, mat[i][j], visited);
            }
        }
    }
}
