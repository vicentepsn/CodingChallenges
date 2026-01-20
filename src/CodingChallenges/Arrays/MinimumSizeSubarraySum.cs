namespace CodingChallenges.Arrays;

/// <summary>
/// Groups: Arrays, Sliding Window
/// Title: 209. Minimum Size Subarray Sum
/// Difficult: Medium
/// Link: https://leetcode.com/problems/minimum-size-subarray-sum
/// Approach: Sliding Window
/// </summary>
public class MinimumSizeSubarraySum
{
    // Leetcode: beats 100%
    public int MinSubArrayLen(int target, int[] nums)
    {
        int left = 0;
        int right = 0;

        int ninSubArrayLen = int.MaxValue;
        int currSubArraySum = nums[0];

        while (right < nums.Length)
        {
            int currSubArrayLen = right - left + 1;
            if (currSubArrayLen == 1 && currSubArraySum >= target)
            {
                return 1;
            }
            if (currSubArraySum < target)
            {
                right++;
                if (right < nums.Length)
                    currSubArraySum += nums[right];
            }
            else
            {
                ninSubArrayLen = Math.Min(ninSubArrayLen, currSubArrayLen);
                currSubArraySum -= nums[left];
                left++;
            }
        }

        return ninSubArrayLen == int.MaxValue ? 0 : ninSubArrayLen;
    }
}
