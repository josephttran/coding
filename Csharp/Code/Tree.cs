using Code.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Code
{
    public class Tree
    {
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
    }
}

