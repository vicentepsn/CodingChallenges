﻿using System;

namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Related   : Array, Hash Table
    /// Title     : 41. First Missing Positive
    /// Difficult : Hard
    /// Link      : https://leetcode.com/problems/first-missing-positive/
    /// Approachs : -
    /// </summary>
    public class FirstMissingPositive
    {
        // Time complexity : O(N) since all we do here is four walks along the array of length N.
        // Space complexity : O(1) since this is a constant space solution.
        public int firstMissingPositive_myAnswer(int[] nums)
        {
            var L = nums.Length;

            var containsOne = false;
            foreach (var num in nums)
                if (num == 1)
                {
                    containsOne = true;
                    break;
                }

            if (!containsOne)
                return 1;

            for (int i = 0; i < L; i++)
                if (nums[i] <= 0 || nums[i] > L)
                    nums[i] = 1;

            for (int i = 0; i < L; i++)
            {
                var numIdx = Math.Abs(nums[i]) - 1;

                nums[numIdx] = -Math.Abs(nums[numIdx]);
            }

            for (int i = 1; i < L; i++)
                if (nums[i] > 0)
                    return i + 1;

            return L + 1;
        }

        public int firstMissingPositive(int[] nums)
        {
            int n = nums.Length;

            // Base case.
            int contains = 0;
            for (int i = 0; i < n; i++)
                if (nums[i] == 1)
                {
                    contains++;
                    break;
                }

            if (contains == 0)
                return 1;

            // Replace negative numbers, zeros,
            // and numbers larger than n by 1s.
            // After this convertion nums will contain 
            // only positive numbers.
            for (int i = 0; i < n; i++)
                if ((nums[i] <= 0) || (nums[i] > n))
                    nums[i] = 1;

            // Use index as a hash key and number sign as a presence detector.
            // For example, if nums[1] is negative that means that number `1`
            // is present in the array. 
            // If nums[2] is positive - number 2 is missing.
            for (int i = 0; i < n; i++)
            {
                int a = Math.Abs(nums[i]);
                // If you meet number a in the array - change the sign of a-th element.
                // Be careful with duplicates : do it only once.
                if (a == n)
                    nums[0] = -Math.Abs(nums[0]);
                else
                    nums[a] = -Math.Abs(nums[a]);
            }

            // Now the index of the first positive number 
            // is equal to first missing positive.
            for (int i = 1; i < n; i++)
            {
                if (nums[i] > 0)
                    return i;
            }

            if (nums[0] > 0)
                return n;

            return n + 1;
        }

    }
}
