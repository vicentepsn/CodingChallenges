namespace CodingChallenges.Arrays;

/// <summary>
/// Groups    : Binary Search, Array
/// Title     : 162. Find Peak Element
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/find-peak-element
/// Approachs : Binary Search
/// </summary>
public class FindPeakElementClass
{
    public int FindPeakElement(int[] nums)
    {
        int left = 0, right = nums.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] > nums[mid + 1])
            {
                // pico está à esquerda ou no próprio mid
                right = mid;
            }
            else
            {
                // pico está à direita
                left = mid + 1;
            }
        }

        return left; // ou right, pois left == right
    }
}
