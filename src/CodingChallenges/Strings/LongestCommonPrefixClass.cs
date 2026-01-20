using System.Text;

namespace CodingChallenges.Strings;

/// <summary>
/// Groups    : String, HashTable, Math
/// Title     : 13. Roman to Integer
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/roman-to-integer/
/// Approach  : -
/// </summary>
public class LongestCommonPrefixClass
{
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 1)
            return strs[0];

        var result = new StringBuilder();

        for (int i = 0; i < strs[0].Length; i++)
        {
            char letter = strs[0][i];
            for (int j = 1; j < strs.Length; j++)
            {
                if (i == strs[j].Length || strs[j][i] != letter)
                    return result.ToString();
            }
            result.Append(letter);
        }

        return result.ToString();
    }
}
