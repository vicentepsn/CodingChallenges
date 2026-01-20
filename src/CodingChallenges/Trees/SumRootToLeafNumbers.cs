using DataStructures;

namespace CodingChallenges.Trees;

/// <summary>
/// Groups    : Binary Tree, Depth-First Search
/// Title     : 129. Sum Root to Leaf Numbers
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/sum-root-to-leaf-numbers
/// Approach  : -
/// </summary>
public class SumRootToLeafNumbers
{
    int sumRootToLeafNumbers;
    // Leetcode: Beats 100.00% / 56.86%
    // O(n) / O(h) => h is the max hight of the tree
    public int SumNumbers(TreeNode root)
    {
        sumRootToLeafNumbers = 0;

        SumNumbers(root, 0);
        return sumRootToLeafNumbers;
    }
    public void SumNumbers(TreeNode node, int currNumberInPath)
    {
        int currValue = currNumberInPath * 10 + node.val;

        if (node.left == null && node.right == null)
        {
            sumRootToLeafNumbers += currValue;
            return;
        }

        if (node.left != null)
            SumNumbers(node.left, currValue);
        if (node.right != null)
            SumNumbers(node.right, currValue);
    }
}
