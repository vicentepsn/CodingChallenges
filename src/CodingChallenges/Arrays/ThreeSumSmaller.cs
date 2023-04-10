using System;

namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Groups    : Array
    /// Title     : 259. 3Sum Smaller
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/3sum-smaller/
    /// Approach  : Two Pointer, binary search
    /// </summary>
    public class ThreeSumSmaller
    {
        // Complexity: T: O(n² + n.log n) => O(n²)    /   S: O(1)
        public int threeSumSmaller(int[] nums, int target)
        {
            Array.Sort(nums); // O(n.log n)
            int sum = 0;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                sum += twoSumSmaller(nums, i + 1, target - nums[i]);
                //sum += twoSumSmaller_BinarySearch(nums, i + 1, target - nums[i]);
            }
            return sum;
        }

        private int twoSumSmaller(int[] nums, int startIndex, int target)
        {
            int sum = 0;
            int left = startIndex;
            int right = nums.Length - 1;
            while (left < right)
            {
                if (nums[left] + nums[right] < target)
                {
                    sum += right - left;
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return sum;
        }

        // Complexity: T:O(N².log N) / S: O(1)
        private int twoSumSmaller_BinarySearch(int[] nums, int startIndex, int target)
        {
            int sum = 0;
            for (int i = startIndex; i < nums.Length - 1; i++)
            {
                int j = binarySearch(nums, i, target - nums[i]);
                sum += j - i;
            }
            return sum;
        }

        private int binarySearch(int[] nums, int startIndex, int target)
        {
            int left = startIndex;
            int right = nums.Length - 1;
            while (left < right)
            {
                int mid = (left + right + 1) / 2;
                if (nums[mid] < target)
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return left;
        }
    }
}
