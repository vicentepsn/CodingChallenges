using System.Text;

namespace CodingChallenges.Strings;

/// <summary>
/// Groups    : String, Two pointers
/// Title     : 151. Reverse Words in a String
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/reverse-words-in-a-string
/// Approach  : -
/// </summary>
public class ReverseWordsClass
{
    public string ReverseWords(string s)
    {
        if (string.IsNullOrEmpty(s))
            return "";

        var result = new StringBuilder();
        int right = s.Length - 1;
        int left;

        while (right >= 0)
        {
            while (right >= 0 && s[right] == ' ')
                right--;

            if (right < 0)
                return result.ToString();

            left = right - 1;
            while (left >= 0 && s[left] != ' ')
                left--;

            if (result.Length > 0)
                result.Append(' ');
            result.Append(s.Substring(left + 1, right - left));
        }

        return result.ToString();
    }
}
