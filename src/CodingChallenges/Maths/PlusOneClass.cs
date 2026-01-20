using System.Numerics;

namespace CodingChallenges.Maths;

/// <summary>
/// Groups    : Math, Array
/// Title     : 66. Plus One
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/plus-one
/// Approach  : -
/// Companies : Microsoft (na minha entrevista para a Irlanda)
/// </summary>
public class PlusOneClass
{
    // O(n) / O(1)
    // Leetcode: Beats 100.00% / 95.07%
    public static int[] PlusOne(int[] digits)
    {
        int i = digits.Length - 1;
        for (; i >= 0 && digits[i] == 9; i--)
            digits[i] = 0;

        if (i == -1)
            return [1, .. digits];
        
        digits[i] += 1;
        return digits;
    }

    // Leetcode: Beats 100.00% / 12.33%
    public static int[] PlusOne_firstTry(int[] digits)
    {
        int carry = 1;
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            int newDigit = digits[i] + carry;
            if (newDigit < 10)
            {
                carry = 0;
                digits[i] = newDigit;
                break;
            }
            digits[i] = newDigit % 10;
            carry = 1;
        }
        if (carry == 1)
            return [1, .. digits];

        return [.. digits];
    }
}
