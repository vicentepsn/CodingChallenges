using DataStructures;

namespace CodingChallenges.Trees.BinarySearch;

/// <summary>
/// Related   : Binary Search Tree, Depth-First Search
/// Title     : 230. Kth Smallest Element in a BST
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/kth-smallest-element-in-a-bst
/// Companies : 
/// </summary>
public class KthSmallestElementInBST
{
    private int count = 0;
    private int result = -1;

    // Leetcode: Beats 100.00% / 78.27%
    // CG
    public int KthSmallest(TreeNode root, int k)
    {
        InOrder(root, k);
        return result;
    }

    private void InOrder(TreeNode node, int k)
    {
        if (node == null) return;

        InOrder(node.left, k);

        count++;
        if (count == k)
        {
            result = node.val;
            return;
        }

        InOrder(node.right, k);
    }
}
