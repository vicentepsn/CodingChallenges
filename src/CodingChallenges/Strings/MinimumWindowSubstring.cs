namespace CodingChallenges.Strings;

/// <summary>
/// Groups: String, Hash, Sliding Window
/// Title: 76. Minimum Window Substring
/// Difficult: Hard
/// Link: https://leetcode.com/problems/minimum-window-substring
/// Approach: Sliding Window
/// </summary>
public class MinimumWindowSubstring
{
    // Leetcode: Beats 81.12% / 26.20%
    public static string MinWindow(string s, string t)
    {
        int m = s.Length;
        int n = t.Length;
        string minSubstring = "";

        if (m < n)
            return minSubstring;

        int minWindow = int.MaxValue;

        Dictionary<char, int> qtdByChar = new();
        for (int i = 0; i < n; i++)
        {
            qtdByChar.TryGetValue(t[i], out int qtdChar);
            qtdByChar[t[i]] = qtdChar - 1;
        }
        int qtdValidChar = qtdByChar.Count;

        int left = 0;
        int right = 0;

        int validCharCount = 0;

        while (left < m && right < m)
        {
            char letter = s[right];
            right++;

            if (qtdByChar.TryGetValue(letter, out int qtdChar))
            {
                qtdByChar[letter] = ++qtdChar;

                if (qtdChar == 0)
                    validCharCount++;
            }

            if (validCharCount == qtdValidChar)
            {
                int currMinWindow = right - left;
                if (currMinWindow < minWindow)
                {
                    minWindow = currMinWindow;
                    minSubstring = s.Substring(left, currMinWindow);
                }

                int previousLeft = left;
                do {
                    char letterToRemove = s[left];
                    left++;

                    if (qtdByChar.TryGetValue(letterToRemove, out int qtdCharToRemove))
                    {
                        qtdByChar[letterToRemove] = --qtdCharToRemove;

                        if (qtdCharToRemove == -1)
                            validCharCount--;
                    }
                } while (left < m && validCharCount == qtdValidChar);

                if (left > previousLeft + 1)
                {
                    currMinWindow = right - left + 1;
                    if (currMinWindow < minWindow)
                    {
                        minWindow = currMinWindow;
                        minSubstring = s.Substring(left - 1, currMinWindow);
                    }
                }
            }
        }
        
        return minSubstring;
    }

    // Leetcode: Beats 61.83% / 62.77%
    public string MinWindow_CGPT(string s, string t)
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length)
            return "";

        // Contagem dos caracteres de t
        var need = new Dictionary<char, int>();
        foreach (char c in t)
        {
            if (!need.ContainsKey(c))
                need[c] = 0;
            need[c]++;
        }

        var window = new Dictionary<char, int>();
        int have = 0, needCount = need.Count;
        int left = 0;
        int minLen = int.MaxValue;
        int minStart = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];
            if (!window.ContainsKey(c))
                window[c] = 0;
            window[c]++;

            if (need.ContainsKey(c) && window[c] == need[c])
                have++;

            // Quando todos os caracteres necessários estão na janela
            while (have == needCount)
            {
                // Atualiza menor janela
                if (right - left + 1 < minLen)
                {
                    minLen = right - left + 1;
                    minStart = left;
                }

                // Contrai pela esquerda
                char leftChar = s[left];
                window[leftChar]--;
                if (need.ContainsKey(leftChar) && window[leftChar] < need[leftChar])
                    have--;
                left++;
            }
        }

        return minLen == int.MaxValue ? "" : s.Substring(minStart, minLen);
    }

}
