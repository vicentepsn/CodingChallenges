namespace CodingChallenges.Strings;

/// <summary>
/// Related   : String, Hash Table
/// Title     : 205. Isomorphic Strings
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/isomorphic-strings
/// Approachs : -
/// </summary>
public class IsomorphicStrings
{
    // Beats: 79.28% / 83.40
    public static bool IsIsomorphic(string s, string t)
    {
        Dictionary<char, char> map = [];
        HashSet<char> existInT = []; // necessário para checar se a letra já não existe na string T mapeada para outra letra em S. Ex: S="abcd", T="xyxz"

        for (int i = 0; i < s.Length; i++)
        {
            char letterS = s[i];
            char letterT = t[i];

            if (map.TryGetValue(letterS, out char letterMapped))
            {
                if (letterMapped != letterT)
                    return false;
            }
            else
            {
                if (existInT.Contains(letterT))
                    return false;
                existInT.Add(letterT);
                map[letterS] = letterT;
            }
        }

        return true;
    }

    /// <summary>
    /// Related   : String, Hash Table
    /// Title     : 290. Word Pattern
    /// Difficult : Easy
    /// Link      : https://leetcode.com/problems/word-pattern
    /// Approachs : EXATAMENTE O MESMO APPROUCH DA DE CIMA
    /// </summary>
    public bool WordPattern(string pattern, string s)
    {
        Dictionary<char, string> map = new();
        HashSet<string> existInSWords = new();

        string[] sWords = s.Split(' ');

        if (pattern.Length != sWords.Length)
            return false;

        for (int i = 0; i < pattern.Length; i++)
        {
            char letter = pattern[i];
            string word = sWords[i];

            if (map.TryGetValue(letter, out string? wordMapped))
            {
                if (wordMapped != word)
                    return false;
            }
            else
            {
                if (existInSWords.Contains(word))
                    return false;
                existInSWords.Add(word);
                map[letter] = word;
            }
        }

        return true;
    }

}
