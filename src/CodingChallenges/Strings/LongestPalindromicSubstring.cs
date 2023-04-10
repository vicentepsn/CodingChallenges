using System;

namespace CodingChallenges.Strings
{
    /// <summary>
    /// Related   : String, Dynamic Programming
    /// Title     : 5. Longest Palindromic Substring
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/longest-palindromic-substring/
    /// Companies : Amazon 37, Microsoft 21, Google 11, Adobe 10, Facebook 7 (2022-04-12)
    /// </summary>
    public class LongestPalindromicSubstring
    {
        /// Complexity Analysis
        /// Time complexity : O(n^2). Since expanding a palindrome around its center could take O(n) time, the overall complexity is O(n^2).
        /// Space complexity : O(1).
        public static string LongestPalindrome(string s)
        {
            if (s.Length == 1)
                return s;

            int left = (s.Length + 1) / 2 - 1;
            int right = s.Length / 2;

            int longestStart = left;

            int longestSize = 1;
            Console.WriteLine($"a {left} {right}");
            if (left != right)
                PalindromeSize(s, left, right, ref longestSize, ref longestStart);

            var maxPossibleSize = left + right + 1;
            while (maxPossibleSize > longestSize)
            {
                PalindromeSize(s, left, left, ref longestSize, ref longestStart);
                PalindromeSize(s, left - 1, left, ref longestSize, ref longestStart);
                if (left != right)
                    PalindromeSize(s, right, right, ref longestSize, ref longestStart);
                PalindromeSize(s, right, right + 1, ref longestSize, ref longestStart);

                left--;
                right++;
                maxPossibleSize = (left * 2) + 1;
            }
            Console.WriteLine($"b {longestStart}");
            var result = s.Substring(longestStart, longestSize);
            return result;
        }

        public static void PalindromeSize(string s, int left, int right, ref int longestSize, ref int longestStart)
        {
            var maxPossibleSizeFromLeft = left + right + 1;
            var maxPossibleSizeFromRight = (2 * s.Length) - left - right - 1;
            if (Math.Min(maxPossibleSizeFromLeft, maxPossibleSizeFromRight) <= longestSize)
                return;

            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            Console.WriteLine($"c {left} {right}");
            var newSize = right - left - 1;
            Console.WriteLine($"newSize {newSize}");
            if (newSize > longestSize)
            {
                longestSize = newSize;
                longestStart = left + 1;
            }
        }

        public string LongestPalindrome_Leetcode(string s)
        {
            if (s == null || s.Length < 1) return "";
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            return s.Substring(start, end - start + 1); // Java => s.Substring(start, end + 1);
        }

        private int ExpandAroundCenter(string s, int left, int right)
        {
            int L = left, R = right;
            while (L >= 0 && R < s.Length && s[L] == s[R])
            {
                L--;
                R++;
            }
            return R - L - 1;
        }
    }
}
