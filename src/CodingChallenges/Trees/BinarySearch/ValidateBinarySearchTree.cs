using DataStructures;

namespace CodingChallenges.Trees.BinarySearch;

/// <summary>
/// Related   : Binary Search Tree, Depth-First Search
/// Title     : 98. Validate Binary Search Tree
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/validate-binary-search-tree
/// Companies : 
/// </summary>
public class ValidateBinarySearchTree
{
    private TreeNode prev = null;
    private bool result = true;

    // Leetcode: Beats 100.00% / 52.29%
    public bool IsValidBST(TreeNode root)
    {
        InOrder(root);
        return result;
    }

    private void InOrder(TreeNode node)
    {
        if (node == null || result == false) return;

        InOrder(node.left);

        if (prev != null)
        {
            if (prev.val >= node.val)
            {
                result = false;
                return;
            }
        }
        prev = node;

        InOrder(node.right);
    }
}

/*
    5
   / \
  1   4
     / \
    3   6
Input: root = [5,1,4,null,null,3,6]
Output: false
Explanation: The root node's value is 5 but its right smallest child's value is 3.

*/
