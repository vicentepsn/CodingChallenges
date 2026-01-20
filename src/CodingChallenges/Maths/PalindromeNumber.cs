namespace CodingChallenges.Maths;

/// <summary>
/// Groups    : Math
/// Title     : 9. Palindrome Number
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/palindrome-number
/// Approach  : -
/// </summary>
public class PalindromeNumber
{
    // Versão sem converter para string
    // O(log n) base 10 / O(1)
    // Leetcode: Beats 99.55% / 94.79%
    public bool IsPalindrome(int x) // CGPT
    {
        // Números negativos ou múltiplos de 10 (exceto 0) não são palíndromos
        if (x < 0 || (x % 10 == 0 && x != 0)) return false;

        int reversed = 0;
        while (x > reversed)
        {
            int digit = x % 10;
            reversed = reversed * 10 + digit;
            x /= 10;
        }

        // Para números com quantidade par de dígitos: x == reversed
        // Para números com quantidade ímpar: x == reversed/10
        return (x == reversed || x == reversed / 10);
    }

    // Leetcode: Beats 99.55% / 94.79%
    public bool IsPalindrome_string(int x)
    {
        // Números negativos ou múltiplos de 10 (exceto 0) não são palíndromos
        if (x < 0 || (x % 10 == 0 && x != 0)) return false;

        string xStr = x.ToString();
        string reversed = new string(xStr.Reverse().ToArray());
        Console.WriteLine(xStr);
        Console.WriteLine(reversed);

        return (xStr == reversed);
    }
}
