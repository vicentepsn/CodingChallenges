using System;

namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Groups    : Array
    /// Title     : 16. 3Sum Closest
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/3sum-closest/
    /// Approach  : Two Pointer
    /// </summary>
    public class ThreeSumClosest
    {
        public static int threeSumClosest(int[] nums, int target)
        {
            int diff = int.MaxValue;
            int size = nums.Length;
            Array.Sort(nums);
            for (int i = 0; i < size && diff != 0; ++i)
            {
                int low = i + 1;
                int high = size - 1;
                while (low < high)
                {
                    int sum = nums[i] + nums[low] + nums[high];
                    if (Math.Abs(target - sum) < Math.Abs(diff))
                    {
                        diff = target - sum;
                    }
                    if (sum < target)
                    {
                        ++low;
                    }
                    else
                    {
                        --high;
                    }
                }
            }
            return target - diff;
        }
    }
}
