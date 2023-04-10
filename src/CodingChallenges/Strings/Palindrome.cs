using System;

namespace CodingChallenges.Strings
{
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
            //Regex rgx = new Regex("[^a-zA-Z0-9]");
            //s = rgx.Replace(s, "").ToLower();

            int left = 0,
                right = s.Length - 1;

            while (left < right)
            {
                if (!Char.IsLetterOrDigit(s[left]))
                {
                    left++;
                    continue;
                }
                if (!Char.IsLetterOrDigit(s[right]))
                {
                    right--;
                    continue;
                }
                if (Char.ToLower(s[left]) != Char.ToLower(s[right]))
                    return false;

                left++;
                right--;
            }
            return true;
        }
    }


}
