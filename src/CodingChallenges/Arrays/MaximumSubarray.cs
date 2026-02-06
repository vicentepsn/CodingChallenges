namespace CodingChallenges.Arrays;

/// <summary>
/// Groups    : Array, DP, Divide and Conquer
/// Title     : 53. Maximum Subarray
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
/// Approachs : Kadane's Algorithm
/// </summary>
public class MaximumSubarray // CG
{
    // O(n) / O(1)
    // Leetcode: Beats 100.00% / 8.47%
    public int MaxSubArray(int[] nums)
    {
        int maxEndingHere = nums[0];
        int maxSoFar = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
            maxSoFar = Math.Max(maxSoFar, maxEndingHere);
        }

        return maxSoFar;
    }
}

// O(n log n) / O(log n)
public class SolutionDivideAndConquer // CG
{
    public int MaxSubArray(int[] nums)
    {
        return MaxSubArrayHelper(nums, 0, nums.Length - 1);
    }

    private int MaxSubArrayHelper(int[] nums, int left, int right)
    {
        if (left == right) return nums[left];

        int mid = left + (right - left) / 2;

        int leftSum = MaxSubArrayHelper(nums, left, mid);
        int rightSum = MaxSubArrayHelper(nums, mid + 1, right);
        int crossSum = MaxCrossingSum(nums, left, mid, right);

        return Math.Max(Math.Max(leftSum, rightSum), crossSum);
    }

    private int MaxCrossingSum(int[] nums, int left, int mid, int right)
    {
        int leftMax = int.MinValue;
        int sum = 0;
        for (int i = mid; i >= left; i--)
        {
            sum += nums[i];
            leftMax = Math.Max(leftMax, sum);
        }

        int rightMax = int.MinValue;
        sum = 0;
        for (int i = mid + 1; i <= right; i++)
        {
            sum += nums[i];
            rightMax = Math.Max(rightMax, sum);
        }

        return leftMax + rightMax;
    }
}
