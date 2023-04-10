using DataStructures;
using System.Collections.Generic;

namespace CodingChallenges.Trees
{
    /// <summary>
    /// Related   : Tree, Depth-First Search, Binary Search Tree, Binary Tree, Recursion
    /// Title     : 98. Validate Binary Search Tree
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/validate-binary-search-tree/
    /// Companies : Amazon 24, Bloomberg 16, Facebook 7, Microsoft 6, Google 4 (2022-04-01)
    /// Doc       : docs/98 Validate Binary Search Tree.docx
    /// </summary>
    public class ValidateBinarySearchTree
    {

        public bool IsValidBST(TreeNode root)
        {
            return CheckBranch(long.MinValue, root.val, root.left)
                    && CheckBranch(root.val, long.MaxValue, root.right);
        }

        public bool CheckBranch(long min, long max, TreeNode node)
        {
            if (node == null)
                return true;

            return min < node.val && node.val < max
                && (CheckBranch(min, node.val, node.left))
                && (CheckBranch(node.val, max, node.right));
        }

        // ========= Leetcode ============
        // Approach 1: Recursive Traversal with Valid Range
        public bool isValidBST_1(TreeNode root)
        {
            return validate_1(root, null, null);
        }
        public bool validate_1(TreeNode root, int? low, int? high)
        {
            // Empty trees are valid BSTs.
            if (root == null)
            {
                return true;
            }
            // The current node's value must be between low and high.
            if ((low != null && root.val <= low) || (high != null && root.val >= high))
            {
                return false;
            }
            // The left and right subtree must also be valid.
            return validate_1(root.right, root.val, high) && validate_1(root.left, low, root.val);
        }



        // We use Integer instead of int as it supports a null value.
        private int? prev;
        // Approach 3: Recursive Inorder Traversal
        public bool isValidBST_3(TreeNode root)
        {
            prev = null;
            return inorder(root);
        }

        private bool inorder(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            if (!inorder(root.left))
            {
                return false;
            }
            if (prev != null && root.val <= prev)
            {
                return false;
            }
            prev = root.val;
            return inorder(root.right);
        }

        // Approach 4: Iterative Inorder Traversal
        public bool isValidBST_4(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            int? prev = null;

            while (stack.Count > 0 || root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                // If next element in inorder traversal
                // is smaller than the previous one
                // that's not BST.
                if (prev != null && root.val <= prev)
                {
                    return false;
                }
                prev = root.val;
                root = root.right;
            }
            return true;
        }
    }
}
