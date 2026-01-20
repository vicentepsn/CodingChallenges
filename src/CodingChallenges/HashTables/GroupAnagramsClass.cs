using System.Text;

namespace CodingChallenges.HashTables;

/// <summary>
/// Groups    : HashTable, String
/// Title     : 49. Group Anagrams
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/group-anagrams/
/// Approachs : -
/// Companies : Foi usada na Phonescreen da Amazon em 2024-09-11
/// </summary>
public class GroupAnagramsClass
{
    // Complexity: T => O(N.K), where K is the maximum length of a string in 'strs'   /   S  =>  O(K)
    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, IList<string>> groupAnagramsMap = [];

        foreach (string word in strs)
        {
            string anagramHash = GetAnagramHash(word);

            if (!groupAnagramsMap.ContainsKey(anagramHash))
                groupAnagramsMap[anagramHash] = new List<string>();

            groupAnagramsMap[anagramHash].Add(word);
        }

        return groupAnagramsMap.Values.ToList();
    }

    private static string GetAnagramHash(string str)
    {
        int numberOfLetters = 26;
        int[] charCounts = new int[numberOfLetters];

        foreach (char c in str)
            charCounts[c - 'a']++;

        StringBuilder result = new();

        for (int i = 0; i < numberOfLetters; i++)
            if (charCounts[i] > 0)
                result.Append($"{(char)(i + 'a')}{charCounts[i]}");

        return result.ToString();
    }

    // Complexity: T => O(N.K Log K), where K is the maximum length of a string in 'strs'   /   S  =>  O(N.K)
    public IList<IList<string>> GroupAnagrams_v0(string[] strs)
    {
        var dict = new Dictionary<string, IList<string>>();

        foreach (var word in strs)
        {
            var charArr = word.ToArray();
            Array.Sort(charArr);
            var sortedChars = new string(charArr);
            if (dict.ContainsKey(sortedChars))
                dict[sortedChars].Add(word);
            else
                dict[sortedChars] = new List<string> { word };
        }

        return dict.Values.ToList();
    }

    // Complexity: T => O(N.K), where K is the maximum length of a string in 'strs'   /   S  =>  O(N.K)
    public IList<IList<string>> GroupAnagrams_v1(string[] strs)
    {
        if (strs.Length == 0) 
            return new List<IList<string>>();

        var ans = new Dictionary<string, IList<string>>();
        int[] count = new int[26];
        foreach(string s in strs)
        {
            foreach (char c in s.ToCharArray()) 
                count[c - 'a']++;

            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < 26; i++)
                sb.Append($"#{count[i]}");

            string key = sb.ToString();
            if (!ans.ContainsKey(key)) 
                ans[key] = new List<string>();
            ans[key].Add(s);
        }
        return ans.Values.ToList();
    }

}
