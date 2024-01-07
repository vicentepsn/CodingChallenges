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

        // from Grokking (my solution)
        public static int searchTriplet(int[] arr, int targetSum)
        {
            if (arr == null || arr.Length < 3)
                throw new ArgumentException();

            Array.Sort(arr);
            int closestSum = -1;
            int smallestDiff = int.MaxValue;

            for (int i = 0; i < arr.Length - 2; i++)
            {
                int left = i + 1;
                int right = arr.Length - 1;

                while (left < right)
                {
                    int currentSum = arr[i] + arr[left] + arr[right];
                    if (currentSum == targetSum)
                        return currentSum;

                    int currentDiff = Math.Abs(targetSum - currentSum);

                    if (currentDiff < smallestDiff)
                    {
                        smallestDiff = currentDiff;
                        closestSum = currentSum;
                    }
                    else if (currentDiff == smallestDiff && currentSum < closestSum)
                    {
                        closestSum = currentSum;
                    }

                    if (currentSum < targetSum)
                        left++;
                    else
                        right--;
                }
            }

            return closestSum;
        }

        // From Grokking (their solution)
        public static int searchTriplet2(int[] arr, int targetSum)
        {
            if (arr == null || arr.Length < 3)
                throw new ArgumentException();

            Array.Sort(arr);
            int smallestDifference = int.MaxValue;
            for (int i = 0; i < arr.Length - 2; i++)
            {
                int left = i + 1, right = arr.Length - 1;
                while (left < right)
                {
                    // comparing the sum of three numbers to the 'targetSum' can cause overflow
                    // so, we will try to find a target difference
                    int targetDiff = targetSum - arr[i] - arr[left] - arr[right];
                    if (targetDiff == 0) //  we've found a triplet with an exact sum
                        return targetSum; // return sum of all the numbers

                    // the second part of the above 'if' is to handle the smallest sum when we have 
                    // more than one solution
                    if (Math.Abs(targetDiff) < Math.Abs(smallestDifference)
                        || (Math.Abs(targetDiff) == Math.Abs(smallestDifference)
                                              && targetDiff > smallestDifference))
                        smallestDifference = targetDiff; // save the closest and the biggest difference

                    if (targetDiff > 0)
                        left++; // we need a triplet with a bigger sum
                    else
                        right--; // we need a triplet with a smaller sum
                }
            }
            return targetSum - smallestDifference;
        }

    }

}
