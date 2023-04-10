using System;
using System.Collections.Generic;

namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Related   : String, Hash Table, Sliding Window
    /// Title     : 340. Longest Substring with At Most K Distinct Characters
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/
    /// Companies : Amazon 3, Google 2, Microsoft 2 (2022-03-30)
    /// </summary>
    public class LongestSubstringWithAtMostKDistinctChars
    {
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            if (k == 0)
                return 0;

            int left = 0, right = 0;
            int maxLength = 0;
            int currentCount = 0;
            var dict = new Dictionary<char, int>(k + 1);

            while (right < s.Length)
            {
                if (dict.Count <= k)
                {
                    if (!dict.ContainsKey(s[right]))
                    {
                        dict[s[right]] = 0;
                        if (dict.Count > k)
                            maxLength = Math.Max(maxLength, currentCount);
                    }

                    dict[s[right]]++;
                    currentCount++;
                    right++;
                }
                else
                {
                    dict[s[left]]--;
                    if (dict[s[left]] == 0)
                        dict.Remove(s[left]);
                    currentCount--;
                    left++;
                }
            }

            if (dict.Count <= k)
                maxLength = Math.Max(maxLength, currentCount);

            return maxLength;
        }
    }
}
