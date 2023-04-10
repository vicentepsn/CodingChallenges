using System;

namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Groups    : Array
    /// Title     : 31. Next Permutation
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/next-permutation/
    /// Approachs : Two Pointers?, Binary Search First
    /// </summary>
    public class NextPermutation
    {
        public static void nextPermutation(int[] nums)
        {
            if (nums.Length == 1)
                return;

            int idx = nums.Length - 1;

            while (idx > 0 && nums[idx - 1] >= nums[idx])
                idx--;

            Array.Reverse(nums, idx, nums.Length - idx);

            if (idx > 0)
            {
                // Using sequential search (as in Leetcode)
                //int lessHigerIdx = nums.length - 1;
                //while (nums[lessHigerIdx] <= nums[idx])
                //{
                //    lessHigerIdx--;
                //}

                // using BinarySearchFirst
                int lessHigerIdx = BirarySearchFirst(nums, idx, nums.Length - 1, nums[idx - 1] + 1);
                if (lessHigerIdx < 0)
                    lessHigerIdx = ~lessHigerIdx;

                swap(nums, idx - 1, lessHigerIdx);
            }
        }

        private static int BirarySearchFirst(int[] arr, int left, int right, int value)
        {
            if (left > right)
                return ~left;

            int mid = (left + right) / 2;

            if (arr[mid] >= value)
            {
                var leftIdx = BirarySearchFirst(arr, left, mid - 1, value);
                if (leftIdx < 0 && arr[mid] == value)
                    return mid;
                else
                    return leftIdx;
            }

            return BirarySearchFirst(arr, mid + 1, right, value);
        }


        private static void swap(int[] nums, int idxA, int idxB)
        {
            int temp = nums[idxA];
            nums[idxA] = nums[idxB];
            nums[idxB] = temp;
        }
    }
}
