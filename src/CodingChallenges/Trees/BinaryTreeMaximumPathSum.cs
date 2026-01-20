using DataStructures;

namespace CodingChallenges.Trees;

/// <summary>
/// Groups    : Binary Tree, Depth-First Search, Dynamic Programming
/// Title     : 124. Binary Tree Maximum Path Sum
/// Difficult : Hard
/// Link      : https://leetcode.com/problems/binary-tree-maximum-path-sum
/// Approach  : -
/// </summary>
public class BinaryTreeMaximumPathSum
{
    int maxPathSum;
    // Leetcode: Beats 100.00% / 62.47%
    // O(n) / O(h) => h is the max hight of the tree
    public int MaxPathSum(TreeNode root)
    {
        maxPathSum = int.MinValue;

        MaxSubPathSum(root);

        return maxPathSum;
    }

    public int MaxSubPathSum(TreeNode node)
    {
        int leftMaxPath = node.left != null ? MaxSubPathSum(node.left) : 0;
        int rightMaxPath = node.right != null ? MaxSubPathSum(node.right) : 0;
        if (leftMaxPath < 0) leftMaxPath = 0;
        if (rightMaxPath < 0) rightMaxPath = 0;

        int nodeMaxPathSum = node.val + leftMaxPath + rightMaxPath;

        maxPathSum = Math.Max(maxPathSum, nodeMaxPathSum);

        int result = node.val + Math.Max(leftMaxPath, rightMaxPath);
        if (result < 0) result = 0;

        return result;
    }
}
