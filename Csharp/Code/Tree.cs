﻿using Code.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Code
{
    public class Tree
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            TreeNode temp = InvertTree(root.left);
            root.left = InvertTree(root.right);
            root.right = temp;

            return root;
        }

        /* Given two binary trees, write a function to check if they are the same or not.
         * Two binary trees are considered the same 
         * if they are structurally identical and the nodes have the same value.
         */
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }

            if (p.val != q.val)
            {
                return false;
            }

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        /* Given the root of a binary tree, return its maximum depth.
         * A binary tree's maximum depth is the number of nodes along the longest path 
         * from the root node down to the farthest leaf node.
         */
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int maxLeft = MaxDepth(root.left);
            int maxRight = MaxDepth(root.right);

            return 1 + Math.Max(maxLeft, maxRight);
        }

        /* Given a non-empty binary tree, find the maximum path sum.
         * For this problem, a path is defined as any node sequence 
         * from some starting node to any node in the tree along the parent-child connections. 
         * The path must contain at least one node and does not need to go through the root.
         */
        public int MaxPathSum(TreeNode root)
        {
            int max = int.MinValue;

            MaxSum(root);

            return max;

            int MaxSum(TreeNode node)
            {
                if(node == null)
                {
                    return 0;
                }

                int left = Math.Max(0, MaxSum(node.left));
                int right = Math.Max(0, MaxSum(node.right));

                max = Math.Max(max, node.val + left + right);

                return node.val + Math.Max(left, right);
            }
        }
    }
}

