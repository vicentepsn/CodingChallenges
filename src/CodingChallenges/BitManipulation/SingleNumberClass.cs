namespace CodingChallenges.BitManipulation;

/// <summary>
/// Groups    : Bit Manipulation
/// Title     : 136. Single Number
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/single-number
/// Approach  : -
/// </summary>
public class SingleNumberClass
{
    public int SingleNumber(int[] nums)
    {
        int result = 0;

        for (int i = 0; i < nums.Length; i++)
            result ^= nums[i];

        return result;
    }
}
