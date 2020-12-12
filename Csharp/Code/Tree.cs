using Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /* Given two non-empty binary trees s and t, 
         * check whether tree t has exactly the same structure and node values with a subtree of s. 
         * A subtree of s is a tree consists of a node in s and all of this node's descendants. 
         * The tree s could also be considered as a subtree of itself.
         */
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            string sString = serializePreorder(s);
            string tString = serializePreorder(t);
            Console.WriteLine(sString);
            Console.WriteLine(tString);
            return sString.Contains(tString);

            string serializePreorder(TreeNode root)
            {
                if (root == null)
                {
                    return "null";
                }

                return "#" + root.val +  serializePreorder(root.left) + serializePreorder(root.right);
            }
        }

        /* Given a binary tree, return the level order traversal of its nodes' values. 
         * (ie, from left to right, level by level).
         */
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> levelOrderList = new List<IList<int>>();
            IList<int> list = new List<int>();
            int height = GetTreeHeight(root);

            for (int i = 0; i < height; ++i)
            {
                GivenTreeLevel(root, i);
                levelOrderList.Add(list);
                list = new List<int>();
            }

            return levelOrderList;

            int GetTreeHeight(TreeNode node)
            {
                if (node == null)
                {
                    return 0;
                }

                return 1 + Math.Max(GetTreeHeight(node.left), GetTreeHeight(node.right));
            }

            void GivenTreeLevel(TreeNode node, int level)
            {
                if (node == null)
                {
                    return;
                }
                else if (level == 0)
                {
                    list.Add(node.val);
                }
                else
                {
                    GivenTreeLevel(node.left, level - 1);
                    GivenTreeLevel(node.right, level - 1);
                }
            }
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

        #region Codec
        /* Design an algorithm to serialize and deserialize a binary tree. 
         * There is no restriction on how your serialization/deserialization algorithm should work. 
         * You just need to ensure that a binary tree can be serialized to a string 
         * and this string can be deserialized to the original tree structure.
         */
        // Encodes a tree to a single string.
        public string Serialize(TreeNode root)
        {
            if (root == null)
            {
                return "null#";
            }

            string serializeTree = "";
            string separator = "#";
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();

                if (node == null)
                {
                    serializeTree = serializeTree + "null" + separator;
                }
                else
                {
                    serializeTree = serializeTree + node.val + separator;
                    stack.Push(node.right);
                    stack.Push(node.left);
                }
            }

            return serializeTree;
        }

        // Decodes your encoded data to tree.
        public TreeNode Deserialize(string data)
        {
            if (data == "null#")
            {
                return null;
            }

            char separator = '#';
            string[] nums = data.Remove(data.Length - 1).Split(separator);
            Queue<string> dataQueue = new Queue<string>(nums);

            string val = dataQueue.Dequeue();
            TreeNode root = new TreeNode(int.Parse(val));
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            bool left = true;
            TreeNode node;

            while (dataQueue.Count > 0)
            {
                val = dataQueue.Dequeue();

                if (val == "null")
                {
                    node = null;
                }
                else
                {
                    node = new TreeNode(int.Parse(val));
                }

                if (left)
                {
                    stack.Peek().left = node;
                    if (node == null)
                    {
                        left = false;
                    }
                }
                else
                {
                    stack.Pop().right = node;
                    if(node != null)
                    {
                        left = true;
                    }
                }

                if (node != null)
                {
                    stack.Push(node);
                }
            }

            return root;
        }
        #endregion
    }
}

