namespace CodingChallenges.HashTables;

public class IsAnagramClass
{
    /// <summary>
    /// Groups    : HashTable, String
    /// Title     : 242. Valid Anagram
    /// Difficult : Easy
    /// Link      : https://leetcode.com/problems/valid-anagram/
    /// Approachs : -
    /// </summary>

    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        Dictionary<char, int> dict = [];

        foreach (char c in s)
        {
            if (!dict.ContainsKey(c))
                dict[c] = 0;

            dict[c]++;
        }

        foreach (char c in t)
        {
            if (!dict.ContainsKey(c))
                return false;

            dict[c]--;

            if (dict[c] == 0)
                dict.Remove(c);
        }

        return dict.Count == 0;
    }
}
