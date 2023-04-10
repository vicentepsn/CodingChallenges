using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges.MyArrays
{
    /// <summary>
    /// Groups    : Array, Sort, Hash Table
    /// Title     : 15. 3Sum
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/3sum/
    /// Approachs : Two Pointers
    /// </summary>
    public class ThreeSum
    {
        // Time Complexity: O(n^2). twoSumII is O(n), and we call it n times.
        public static IList<IList<int>> threeSum(int[] nums)
        {
            const int target = 0;
            var result = new List<IList<int>>();

            if (nums.Length < 3)
                return result;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2 && nums[i] <= target; i++)
            {
                if (i == 0 || nums[i] != nums[i - 1])
                    twoSumII(nums, i, result, target);
                    //twoSum(nums, i, result);
            }

            return result;
        }

        public static IList<IList<int>> threeSum_NoSort(int[] nums)
        {
            var res = new HashSet<IList<int>>();
            var dups = new HashSet<int>();
            var seen = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; ++i)
                if (dups.Add(nums[i]))
                {
                    for (int j = i + 1; j < nums.Length; ++j)
                    {
                        int complement = -nums[i] - nums[j];
                        if (seen.ContainsKey(complement) && seen[complement] == i)
                        {
                            var triplet = new List<int>() { nums[i], nums[j], complement };
                            triplet.Sort();
                            res.Add(triplet);
                        }
                        seen[nums[j]] = i;
                    }
                }
            return res.ToList();
        }

        // using Two Pointers approach
        private static void twoSumII(int[] nums, int i, List<IList<int>> result, int target)
        {
            int low = i + 1, high = nums.Length - 1;

            while (low < high)
            {
                var sum = nums[i] + nums[low] + nums[high];

                if (sum < target)
                    low++;
                else if (sum > target)
                    high--;
                else
                {
                    var newResultItem = new List<int>() { nums[i], nums[low++], nums[high--] };
                    result.Add(newResultItem);
                    while (low < high && nums[low] == nums[low - 1])
                        ++low;
                }

            }
        }

        // using HashSet approach
        private static void twoSum(int[] nums, int i, List<IList<int>> result)
        {
            var seen = new HashSet<int>();
            for (int j = i + 1; j < nums.Length; ++j)
            {
                int complement = -nums[i] - nums[j];
                if (seen.Contains(complement))
                {
                    result.Add(new List<int>() { nums[i], nums[j], complement });
                    while (j + 1 < nums.Length && nums[j] == nums[j + 1])
                        ++j;
                }
                seen.Add(nums[j]);
            }
        }


    }
}
