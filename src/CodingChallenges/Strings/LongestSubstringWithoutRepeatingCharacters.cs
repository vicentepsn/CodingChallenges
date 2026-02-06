namespace CodingChallenges.Strings;

/// <summary>
/// Groups: String, Hash
/// Title: 3. Longest Substring Without Repeating Characters
/// Difficult: Medium
/// Link: https://leetcode.com/problems/longest-substring-without-repeating-characters/
/// Approach: Sliding Window
/// </summary>
public static class LongestSubstringWithoutRepeatingCharacters
{
    // Leetcode: Runtime => Beats 99.17% / Memory => Beats 30.78%
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

    // 2026-01-03 Leetcode: Beats 94.81% / Beats 25.54%
    public static int LengthOfLongestSubstring_v2(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        Dictionary<char, int> nowRepeatedLetterIdx = new();
        nowRepeatedLetterIdx[s[0]] = 0;

        int longestSubstringSize = 1;
        int substringStartIdx = 0;
        int currSubtringSize;

        for (int i = 1; i < s.Length; i++)
        {
            char currLetter = s[i];
            if (nowRepeatedLetterIdx.TryGetValue(currLetter, out int letterIdx) && letterIdx >= substringStartIdx)
            {
                currSubtringSize = i - substringStartIdx;
                longestSubstringSize = Math.Max(longestSubstringSize, currSubtringSize);
                substringStartIdx = letterIdx + 1;
            }
            nowRepeatedLetterIdx[currLetter] = i;
        }

        currSubtringSize = s.Length - substringStartIdx;
        longestSubstringSize = Math.Max(longestSubstringSize, currSubtringSize);

        return longestSubstringSize;
    }
}
