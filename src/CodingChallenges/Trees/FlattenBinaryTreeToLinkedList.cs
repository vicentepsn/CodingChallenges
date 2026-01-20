using DataStructures;

namespace CodingChallenges.Trees;

/// <summary>
/// Groups    : Binary Tree, Linked List, Depth-First Search, Stack?
/// Title     : 114. Flatten Binary Tree to Linked List
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/flatten-binary-tree-to-linked-list
/// Approach  : -
/// </summary>
public class FlattenBinaryTreeToLinkedList
{
    private TreeNode lastFlattenLeft; // último nó folha do lado esquerdo / last leaf node of the left side

    // Leetcode: Beats 100.00% / 8.53%
    // O(n) / O(1) "in-place"
    public void Flatten(TreeNode root)
    {
        if (root == null) return;
        if (root.right == null && root.left == null)
        {
            lastFlattenLeft = root;
            return;
        }

        if (root.left != null)
        {
            Flatten(root.left);
            if (root.right != null)
            {
                lastFlattenLeft.right = root.right;
                Flatten(root.right);
            }
            root.right = root.left;
            root.left = null;
        }
        else
            Flatten(root.right);
    }
}
