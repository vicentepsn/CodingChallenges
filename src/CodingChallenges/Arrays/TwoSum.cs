using System.Collections.Generic;

namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Groups    : Array, Hash Table
    /// Title     : 1. Two Sum
    /// Difficult : Easy
    /// Link      : https://leetcode.com/problems/two-sum/
    /// Approach  : -
    /// </summary>
    public static class TwoSum
    {
        public static int[] GetTwoSum(int[] nums, int target)
        {
            // key = complement of nums[i] to target, value = i
            var dict = new Dictionary<int, int>(nums.Length);

            dict[nums[0]] = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                int compliment = target - nums[i];
                if (dict.ContainsKey(compliment))
                {
                    return new int[] { dict[compliment], i };
                }
                dict[nums[i]] = i;

            }

            return null;
        }

        public static int[] GetTwoSum_2(int[] nums, int target)
        {
            Dictionary<int, int> dict = [];

            dict[nums[0]] = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (dict.ContainsKey(diff))
                {
                    return new[] { dict[diff], i };
                }
                dict[nums[i]] = i;
            }

            return null;
        }
    }
}
