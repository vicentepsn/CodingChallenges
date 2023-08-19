using System;

namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Related   : Array, Math
    /// Title     : 453. Minimum Moves to Equal Array Elements
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/minimum-moves-to-equal-array-elements/
    /// Companies : Microsoft 7, Amazon 2, Twitter 16 (2023-05)
    /// </summary>
    public static class MinimumMovesToEqualArrayElements
    {
        // Approach Using Maths (The optimal one)
        // T = O(n), S = O(1)
        public static int MinMoves(int[] nums)
        {
            int min = int.MaxValue;
            int moves = 0;

            foreach (int num in nums)
                min = Math.Min(min, num);

            foreach (int num in nums)
                moves += num - min;

            return moves;
        }

        // From Author
        // Approach: using maths (can overflow the int values)
        // T = O(n), S = O(1)
        public static int MinMoves_a1(int[] nums)
        {
            int moves = 0, min = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                moves += nums[i];
                min = Math.Min(min, nums[i]);
            }
            return moves - min * nums.Length;
        }

        // From Author
        // Approach: DP
        // T = O(n.log(n)), S = O(1)
        public static int MinMoves_a2(int[] nums)
        {
            Array.Sort(nums);
            int moves = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                int diff = (moves + nums[i]) - nums[i - 1];
                nums[i] += moves;
                moves += diff;
            }
            return moves;
        }

        // From Author
        // Approach: sorting
        // T = O(n.log(n)), S = O(1)
        public static int MinMoves_a3(int[] nums)
        {
            Array.Sort(nums);
            int count = 0;
            for (int i = nums.Length - 1; i > 0; i--)
            {
                count += nums[i] - nums[0];
            }
            return count;
        }

        // From Author
        // Approach: brute force
        // T = O(n²), S = O(1)
        public static int MinMoves_a4(int[] nums)
        {
            int min = 0, max = nums.Length - 1, count = 0;
            while (true)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[max] < nums[i])
                    {
                        max = i;
                    }
                    if (nums[min] > nums[i])
                    {
                        min = i;
                    }
                }
                int diff = nums[max] - nums[min];
                if (diff == 0)
                {
                    break;
                }
                count += diff;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i != max)
                    {
                        nums[i] = nums[i] + diff;
                    }
                }
            }
            return count;
        }
    }
}
