namespace CodingChallenges.BitManipulation;

/// <summary>
/// Groups    : Bit Manipulation
/// Title     : 137. Single Number II
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/single-number-ii
/// Approach  : -
/// </summary>
public class SingleNumberClassII
{
    public int SingleNumber(int[] nums)
    {
        int ones = 0, twos = 0;

        foreach (int num in nums)
        {
            // Atualiza 'ones' e 'twos' com base no número atual
            ones = (ones ^ num) & ~twos;
            twos = (twos ^ num) & ~ones;
        }

        return ones; // no final, 'ones' contém o número único
    }
}
