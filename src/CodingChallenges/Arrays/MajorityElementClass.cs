namespace CodingChallenges.Arrays;

public class MajorityElementClass
{
    /// <summary>
    /// Related   : Array, Hash Table
    /// Title     : 169. Majority Element
    /// Difficult : Easy (with dictionary) / Hard (with space complexity O(1) )
    /// Link      : https://leetcode.com/problems/majority-element/description
    /// Approachs : -
    /// </summary>
    public static int MajorityElement(int[] nums)
    {
        int candidate = 0;
        int count = 0;

        // ** ESSE ALGORÍTMO SÓ É POSSÍVEL PORQUE EXISTE A RESTRIÇÃO QUE GARANTE QUE EXISTE UM NÚMERO MAJORITÁRIO,
        // OU SEJA, O NÚMERO PRECISA SER A MAIOR PARTE DO ARRAY, PELO MENOS A METADE + 1
        // ** O ALGORÍTMO NÃO FUNCIONA CASO A RESTRIÇÃO NÃO SEJA GARANTIDA
        foreach (int num in nums)
        {
            if (count == 0)
            {
                candidate = num;
            }
            count += (num == candidate) ? 1 : -1;
        }

        return candidate;
    }

    // Essa implementação garante que a entrada tem um elemento majoritário, e retorna -1 caso não tenha
    public static int MajorityElement_v2(int[] nums)
    {
        Dictionary<int, int> numCounts = [];
        int halfSize = nums.Length / 2;

        foreach (int num in nums)
        {
            if (numCounts.TryGetValue(num, out int value))
            {
                numCounts[num] = ++value;
                if (value > halfSize)
                    return num;
            }
            else 
                numCounts[num] = 1;
        }

        return -1;
    }

}
/*
Given an array “nums” of size “n”, return the majority element.
The majority element is the element that appears more than "n / 2" times. You may assume that the majority element always exists in the array.

Example 1:
Input: nums = [3,2,3]
Output: 3
Example 2:
Input: nums = [2,2,1,1,1,2,2]
Output: 2
 
Constraints:
•	n == nums.length
•	1 <= n <= 5 * 104
•	-109 <= nums[i] <= 109
•	The input is generated such that a majority element will exist in the array.
*/