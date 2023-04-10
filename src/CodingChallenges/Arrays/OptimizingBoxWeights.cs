using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges.Arrays
{
    /// <summary>
    /// 
    /// </summary>
    public class OptimizingBoxWeights
    {
        public static List<int> minimalHeaviestSetA(List<int> arr)
        {
            arr.Sort();

            int right = arr.Count - 1;
            int left = 0;

            int difference = arr[right--];

            while (left <= right)
            {
                if (arr[left] < difference)
                {
                    difference -= arr[left];
                    left++;
                }
                else
                {
                    difference += arr[right];
                    right--;
                }
            }

            var result = arr.Skip(right + 1).ToList();

            return result;
        }

    }
}
