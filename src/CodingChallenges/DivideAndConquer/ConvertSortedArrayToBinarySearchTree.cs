using DataStructures;

namespace CodingChallenges.DivideAndConquer;

/// <summary>
/// Related   : Divide and Conquer, Binary Search Tree, Array
/// Title     : 108. Convert Sorted Array to Binary Search Tree
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/word-search
/// Approachs : Divide and Conquer
/// </summary>
public class ConvertSortedArrayToBinarySearchTree
{
    public static TreeNode SortedArrayToBST(int[] nums)
    {
        return SortedArrayToBST(nums, 0, nums.Length - 1)!;
    }

    private static TreeNode? SortedArrayToBST(int[] nums, int left, int right)
    {
        if (left > right)
            return null;

        if (left == right)
            return new TreeNode(nums[left]);

        int idx = (right + left + 1) / 2;
        return new TreeNode(nums[idx], SortedArrayToBST(nums, left, idx - 1), SortedArrayToBST(nums, idx + 1, right));
    }
}
