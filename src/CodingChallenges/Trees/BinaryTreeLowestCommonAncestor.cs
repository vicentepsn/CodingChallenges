using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.Trees
{
    /// <summary>
    /// Related   : Tree, Depth-First Search (DFS), Binary Tree
    /// Title     : 236. Lowest Common Ancestor of a Binary Tree
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
    /// Companies : Facebook 180, Amazon 24, LinkedIn 12, Microsoft 10, Google 9 (2022-05-02)
    /// </summary>
    public static class BinaryTreeLowestCommonAncestor
    {
        /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
        // O(n) / O(n)
        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode result = null;
            FindNodes(root, p, q, ref result);
            return result;
        }

        private static bool FindNodes(TreeNode node, TreeNode p, TreeNode q, ref TreeNode result)
        {
            if (node == null)
                return false;

            int foundByLeft = FindNodes(node.left, p, q, ref result) ? 1 : 0;
            int foundByRight = FindNodes(node.right, p, q, ref result) ? 1 : 0;
            int foundAtNode = (node == p || node == q) ? 1 : 0;

            if (foundByLeft + foundByRight + foundAtNode == 2)
                result = node;

            return (foundByLeft + foundByRight + foundAtNode > 0);
        }
    }

    // Leetcode - Recursive solution
    class Solution1
    {

        private TreeNode ans;

        public Solution1()
        {
            // Variable to store LCA node.
            this.ans = null;
        }

        private bool recurseTree(TreeNode currentNode, TreeNode p, TreeNode q)
        {

            // If reached the end of a branch, return false.
            if (currentNode == null)
            {
                return false;
            }

            // Left Recursion. If left recursion returns true, set left = 1 else 0
            int left = this.recurseTree(currentNode.left, p, q) ? 1 : 0;

            // Right Recursion
            int right = this.recurseTree(currentNode.right, p, q) ? 1 : 0;

            // If the current node is one of p or q
            int mid = (currentNode == p || currentNode == q) ? 1 : 0;


            // If any two of the flags left, right or mid become True
            if (mid + left + right >= 2)
            {
                this.ans = currentNode;
            }

            // Return true if any one of the three bool values is True.
            return (mid + left + right > 0);
        }

        public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            // Traverse the tree
            this.recurseTree(root, p, q);
            return this.ans;
        }
    }

    // Leetcode - Approach 3: Iterative without parent pointers
    class Solution2
    {

        // Three static flags to keep track of post-order traversal.

        // Both left and right traversal pending for a node.
        // Indicates the nodes children are yet to be traversed.
        private static int BOTH_PENDING = 2;

        // Left traversal done.
        private static int LEFT_DONE = 1;

        // Both left and right traversal done for a node.
        // Indicates the node can be popped off the stack.
        private static int BOTH_DONE = 0;

        public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {

            var stack = new Stack<KeyValuePair<TreeNode, int>>();

            // Initialize the stack with the root node.
            stack.Push(new KeyValuePair<TreeNode, int>(root, Solution2.BOTH_PENDING));

            // This flag is set when either one of p or q is found.
            bool one_node_found = false;

            // This is used to keep track of the LCA.
            TreeNode LCA = null;

            // Child node
            TreeNode child_node = null;

            // We do a post order traversal of the binary tree using stack
            while (stack.Count > 0)
            {

                KeyValuePair<TreeNode, int> top = stack.Peek();
                TreeNode parent_node = top.Key;
                int parent_state = top.Value;

                // If the parent_state is not equal to BOTH_DONE,
                // this means the parent_node can't be popped off yet.
                if (parent_state != Solution2.BOTH_DONE)
                {

                    // If both child traversals are pending
                    if (parent_state == Solution2.BOTH_PENDING)
                    {

                        // Check if the current parent_node is either p or q.
                        if (parent_node == p || parent_node == q)
                        {

                            // If one_node_found was set already, this means we have found
                            // both the nodes.
                            if (one_node_found)
                            {
                                return LCA;
                            }
                            else
                            {
                                // Otherwise, set one_node_found to True,
                                // to mark one of p and q is found.
                                one_node_found = true;

                                // Save the current top element of stack as the LCA.
                                LCA = stack.Peek().Key;
                            }
                        }

                        // If both pending, traverse the left child first
                        child_node = parent_node.left;
                    }
                    else
                    {
                        // traverse right child
                        child_node = parent_node.right;
                    }

                    // Update the node state at the top of the stack
                    // Since we have visited one more child.
                    stack.Pop();
                    stack.Push(new KeyValuePair<TreeNode, int>(parent_node, parent_state - 1));

                    // Add the child node to the stack for traversal.
                    if (child_node != null)
                    {
                        stack.Push(new KeyValuePair<TreeNode, int>(child_node, Solution2.BOTH_PENDING));
                    }
                }
                else
                {

                    // If the parent_state of the node is both done,
                    // the top node could be popped off the stack.
                    // Update the LCA node to be the next top node.
                    if (LCA == stack.Pop().Key && one_node_found)
                    {
                        LCA = stack.Peek().Key;
                    }

                }
            }

            return null;
        }
    }
}
