using System.Text;

namespace CodingChallenges.Strings;

/// <summary>
/// Groups    : String, HashTable, Math
/// Title     : 12. Integer to Roman
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/integer-to-roman
/// Approach  : -
/// </summary>
public class IntToRoman
{
    public static string ConvertIntToRomanNumerals(int num)
    {
        if (num < 0 || num >= 4000)
            return "INVALID";

        if (num == 0)
            return "";

        var map = new Dictionary<int, char>{
            { 1,    'I' },
            { 5,    'V' },
            { 10,   'X' },
            { 50,   'L' },
            { 100,  'C' },
            { 500,  'D' },
            { 1000, 'M' }
        };

        StringBuilder result = new StringBuilder();

        int order = 1000;

        while (num > 0)
        {
            int currOrderValue = num / order;

            if (currOrderValue == 0)
            {
                order /= 10;
                continue;
            }

            num -= currOrderValue * order;

            if (currOrderValue == 9)
                result.Append($"{map[order]}{map[order * 10]}");
            else if (currOrderValue >= 5)
            {
                result.Append(map[order * 5]);
                while (currOrderValue > 5)
                {
                    result.Append(map[order]);
                    currOrderValue--;
                }
            }
            else if (currOrderValue == 4)
                result.Append($"{map[order]}{map[order * 5]}");
            else // <= 3
            {
                while (currOrderValue > 0)
                {
                    result.Append(map[order]);
                    currOrderValue--;
                }
            }

            order /= 10;
        }

        return result.ToString();
    }

    public static string ConvertIntToRomanNumerals_vCGPT(int num)
    {
        if (num <= 0 || num > 3999)
            throw new ArgumentOutOfRangeException("numero", "O valor deve estar entre 1 e 3999.");

        // Tabela de valores romanos
        int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        string[] simbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        var result = new StringBuilder();

        for (int i = 0; i < values.Length; i++)
        {
            while (num >= values[i])
            {
                num -= values[i];
                result.Append(simbols[i]);
            }
        }

        return result.ToString();
    }
}
