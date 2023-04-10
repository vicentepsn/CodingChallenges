using System;

namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Groups    : Array
    /// Title     : 167. Two Sum II - Input Array Is Sorted (INDEX 1->N)
    /// Difficult : Easy
    /// Link      : https://leetcode.com/problems/two-sum/
    /// Related T.: Two Pointers, Binary Search
    /// </summary>
    public class TwoSumII
    {
        public static int[] TwoSum(int[] numbers, int target)
        {
            int low = 0, high = numbers.Length - 1;

            while (low < high)
            {
                int sum = numbers[low] + numbers[high];
                if (sum == target)
                    return new int[] { low + 1, high + 1 };

                if (sum < target)
                    low++;
                else
                    high--;
            }
            return new int[] { -1, -1 };
        }

        // Using Binary Search (not tested)
        public static int[] TwoSum_BS(int[] numbers, int target)
        {
            int low = 0, high = numbers.Length - 1;

            while (low < high)
            {
                int sum = numbers[low] + numbers[high];
                if (sum == target)
                    return new int[] { low + 1, high + 1 };

                if (sum < target)
                {
                    var complement = target - numbers[high];
                    var idx = Array.BinarySearch(numbers, low + 1, high - 1 - low, complement);
                    if (idx < 0)
                    {
                        if (~idx == high)
                            break;
                        low = ~idx;
                    }
                    else
                        low = idx;
                }
                else
                {
                    var complement = target - numbers[low];
                    var idx = Array.BinarySearch(numbers, low + 1, high - 1 - low, complement);
                    if (idx < 0)
                    {
                        if (~idx == low + 1)
                            break;
                        high = ~idx-1;
                    }
                    else
                        high = idx;
                }
            }
            return new int[] { -1, -1 };
        }
    }
}
