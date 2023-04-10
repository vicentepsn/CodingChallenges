using System;

namespace CodingChallenges.Strings
{
    /// <summary>
    /// Groups: String, Hash
    /// Title: 3. Longest Substring Without Repeating Characters
    /// Difficult: Medium
    /// Link: https://leetcode.com/problems/longest-substring-without-repeating-characters/
    /// Approach: Sliding Window
    /// </summary>
    public static class LengthOfLongestSubstring
    {
        public static int GetLengthOfLongestSubstring(string s)
        {
            int?[] indexes = new int?[128];

            int maxLength = 0;
            int lastNonRepitedIndex = 0;
            int length;

            for (int i = 0; i < s.Length; i++)
            {
                int currentChar = s[i];
                if (indexes[currentChar] != null && indexes[currentChar] >= lastNonRepitedIndex)
                {
                    length = i - lastNonRepitedIndex;
                    maxLength = Math.Max(maxLength, length);
                    lastNonRepitedIndex = (int)indexes[currentChar] + 1;
                }
                indexes[currentChar] = i;
            }

            length = s.Length - lastNonRepitedIndex;
            maxLength = Math.Max(maxLength, length);

            return maxLength;
        }
    }
}
