namespace CodingChallenges.Arrays;

/// <summary>
/// Groups    : Binary Search, Array
/// Title     : 153. Find Minimum in Rotated Sorted Array
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/find-minimum-in-rotated-sorted-array
/// Approachs : Binary Search
/// </summary>
public class FindMinimumInRotatedSortedArray
{
    // O(log n) / O(1)
    // Leetcode: Beats 100.00% / 10.30%
    public static int FindMin(int[] nums)
    {
        int n = nums.Length;
        if (nums[0] < nums[n - 1]) return nums[0];

        int left = 0;
        int right = n - 1;

        while (right - left > 1)
        {
            int midle = (right + left) / 2;

            if (nums[left] > nums[midle])
                right = midle;
            else
                left = midle;
        }

        return nums[right];
    }

    public int FindMin_CGPT(int[] nums)
    {
        int left = 0, right = nums.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] > nums[right])
            {
                // mínimo está à direita
                left = mid + 1;
            }
            else
            {
                // mínimo está à esquerda ou no próprio mid
                right = mid;
            }
        }

        return nums[left];
    }
}
