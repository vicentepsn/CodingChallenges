using System;

namespace CodingChallenges.Strings;

/// <summary>
/// Groups    : String
/// Title     : 680. Valid Palindrome II (Almost Palindrome)
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/valid-palindrome-ii/
/// Approach  : -
/// </summary>
public partial class Palindrome
{
    public bool ValidPalindrome(string s)
    {
        return ValidPalindrome(ref s, 0, s.Length - 1, true);
    }

    public bool ValidPalindrome(ref string s, int left, int right, bool hasTolerance)
    {

        while (left < right)
        {
            if (s[left] != s[right])
            {
                if (hasTolerance)
                {
                    return ValidPalindrome(ref s, left + 1, right, false)
                        || ValidPalindrome(ref s, left, right - 1, false);
                }
                else
                    return false;
            }


            left++;
            right--;
        }
        return true;
    }
}

//using System.Text.RegularExpressions;
//using System.Text;

/// <summary>
/// Groups    : String
/// Title     : 125. Valid Palindrome
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/valid-palindrome/
/// Approach  : -
/// </summary>
public partial class Palindrome
{
    public bool IsPalindrome(string s)
    {
        int left = 0,
            right = s.Length - 1;

        while (left < right)
        {
            if (!char.IsLetterOrDigit(s[left]))
            {
                left++;
                continue;
            }
            if (!char.IsLetterOrDigit(s[right]))
            {
                right--;
                continue;
            }
            if (char.ToLower(s[left]) != char.ToLower(s[right]))
                return false;

            left++;
            right--;
        }
        return true;
    }

    public bool IsPalindrome_v2(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            while (left < right && !char.IsLetterOrDigit(s[left]))
                left++;
            while (left < right && !char.IsLetterOrDigit(s[right]))
                right--;

            if (left < right)
            {
                if (char.ToLower(s[left]) == char.ToLower(s[right]))
                {
                    left++;
                    right--;
                }
                else
                    return false;
            }
        }

        return true;
    }
}
