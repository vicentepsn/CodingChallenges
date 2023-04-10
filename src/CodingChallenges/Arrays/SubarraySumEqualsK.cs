using System.Collections.Generic;

namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Related   : String, Hash Table, Sliding Window
    /// Title     : 560. Subarray Sum Equals K
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/subarray-sum-equals-k/
    /// Companies : Facebook 159, Amazon 20, Google 10, Microsoft 7, Oracle 7, tiktok 5, Bloomberg 4, Apple 4, ... (2022-03-31)
    /// </summary>
    public class SubarraySumEqualsK
    {
        // Approach 4: Using Hashmap
        // Time complexity : O(n). The entire numsnums array is traversed only once.
        // Space complexity : O(n). Hashmap mapmap can contain up to nn distinct entries in the worst case.
        public int SubarraySum_Optimal(int[] nums, int k)
        {
            int count = 0, sum = 0;
            var map = new Dictionary<int, int>();
            map[0] = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (map.ContainsKey(sum - k))
                    count += map[sum - k];
                map[sum] = map.GetValueOrDefault(sum, 0) + 1;
            }
            return count;
        }

        // Approach 3: Without Space
        // Time complexity : O(n^2). We need to consider every subarray possible.
        // Space complexity : O(1). Constant space is used.
        public int SubarraySum_WithoutSpace(int[] nums, int k)
        {
            int count = 0;
            for (int start = 0; start < nums.Length; start++)
            {
                int sum = 0;
                for (int end = start; end < nums.Length; end++)
                {
                    sum += nums[end];
                    if (sum == k)
                        count++;
                }
            }
            return count;
        }

        // Approach 2: Using Cumulative Sum
        // Time complexity : O(n^2). Considering every possible subarray takes O(n^2) time. Finding out the sum of any 
        //                   subarray takes O(1) time after the initial processing of O(n) for creating the cumulative sum array.
        // Space complexity : O(n). Cumulative sum array sumsum of size n+1n+1 is used.
        public int SubarraySum_Cumulative(int[] nums, int k)
        {
            int count = 0;
            int[] sum = new int[nums.Length + 1];
            sum[0] = 0;
            for (int i = 1; i <= nums.Length; i++)
                sum[i] = sum[i - 1] + nums[i - 1];
            for (int start = 0; start < nums.Length; start++)
            {
                for (int end = start + 1; end <= nums.Length; end++)
                {
                    if (sum[end] - sum[start] == k)
                        count++;
                }
            }
            return count;
        }

        // Approach 1: Brute Force
        // Time complexity : O(n^3). Considering every possible subarray takes O(n^2) time. For each of the subarray
        //                   we calculate the sum taking O(n) time in the worst case, taking a total of O(n^3) time.
        // Space complexity : O(1). Constant space is used.
        public int SubarraySum_BruteForce(int[] nums, int k)
        {
            int count = 0;
            for (int start = 0; start < nums.Length; start++)
            {
                for (int end = start + 1; end <= nums.Length; end++)
                {
                    int sum = 0;
                    for (int i = start; i < end; i++)
                        sum += nums[i];
                    if (sum == k)
                        count++;
                }
            }
            return count;
        }
    }
}
