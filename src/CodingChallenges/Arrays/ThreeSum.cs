using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges.MyArrays;

/// <summary>
/// Groups    : Array, Sort, Hash Table
/// Title     : 15. 3Sum
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/3sum/
/// Approachs : Two Pointers
/// </summary>
public class ThreeSum
{
    // VER ÚLTIMA IMPLEMENTAÇÃO ABAIXO

    // Time Complexity: O(n^2) (complete is O(N*logN + N^2), only sorting is O(N*logN)). twoSumII is O(n), and we call it n times.
    // Space complexity: Ignoring the space required for the output array, the space complexity of the above algorithm will be O(n)
    //                   which is required for sorting.
    public static IList<IList<int>> threeSum(int[] nums)
    {
        const int target = 0;
        var result = new List<IList<int>>();

        if (nums.Length < 3)
            return result;

        Array.Sort(nums); // O(N*logN)

        for (int i = 0; i < nums.Length - 2 && nums[i] <= target; i++)
        {
            if (i == 0 || nums[i] != nums[i - 1])
                twoSumII(nums, i, result, target);
                //twoSum(nums, i, result);
        }

        return result;
    }

    // only for reference of brute force
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

    /*// Java version from Grokking

    //public static List<List<Integer>> searchTriplets(int[] arr)
    //{
    //    Arrays.sort(arr);
    //    List<List<Integer>> triplets = new ArrayList<>();
    //    for (int i = 0; i < arr.length - 2; i++)
    //    {
    //        if (i > 0 && arr[i] == arr[i - 1]) // skip same element to avoid duplicate triplets
    //            continue;
    //        searchPair(arr, -arr[i], i + 1, triplets);
    //    }

    //    return triplets;
    //}

    //private static void searchPair(int[] arr, int targetSum,
    //                              int left, List<List<Integer>> triplets)
    //{
    //    int right = arr.length - 1;
    //    while (left < right)
    //    {
    //        int currentSum = arr[left] + arr[right];
    //        if (currentSum == targetSum)
    //        { // found the triplet
    //            triplets.add(Arrays.asList(-targetSum, arr[left], arr[right]));
    //            left++;
    //            right--;
    //            while (left < right && arr[left] == arr[left - 1])
    //                left++; // skip same element to avoid duplicate triplets
    //            while (left < right && arr[right] == arr[right + 1])
    //                right--; // skip same element to avoid duplicate triplets
    //        }
    //        else if (targetSum > currentSum)
    //            left++; // we need a pair with a bigger sum
    //        else
    //            right--; // we need a pair with a smaller sum
    //    }
    //}*/

    // 2025-12-31 => O(n²) => similar a primeira implementação acima, mas sem separar o código para uma outra função TwoSumII
    public IList<IList<int>> ThreeSum_(int[] nums)
    {
        Array.Sort(nums);

        var result = new List<IList<int>>();
        for (int i = 0; i < nums.Length - 2; i++)
        {
            // devido a soma dos dois primeiros números sempre precisar do mesmo número para completar zero, depois de passar
            // por um número pela primeira vez, se houver reptições desse primeiro nº como [-1,-1,2], ele não deve se repetir como primeiro número
            // novamente, para garantir que não haverão triplets repetidos
            if (i > 0 && nums[i - 1] == nums[i])
                continue;

            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right)
            {
                int soma = nums[i] + nums[left] + nums[right];
                if (soma > 0)
                    right--;
                else if (soma < 0)
                    left++;
                else
                {
                    result.Add(new List<int>([nums[i], nums[left], nums[right]]));
                    right--;
                    left++;
                    while (left < right && nums[right] == nums[right + 1])
                        right--;
                    while (left < right && nums[left] == nums[left - 1])
                        left++;
                }
            }
        }

        return result;
    }

}
