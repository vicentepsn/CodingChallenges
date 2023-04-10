using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenges.HashTables
{
    /// <summary>
    /// Groups    : HashTable, String
    /// Title     : 49. Group Anagrams
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/group-anagrams/
    /// Approachs : -
    /// </summary>
    public class GroupAnagrams
    {
        // Complexity: T => O(N.K Log K), where K is the maximum length of a string in 'strs'   /   S  =>  O(N.K)
        public IList<IList<string>> groupAnagrams(string[] strs)
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
        public IList<IList<string>> groupAnagrams_Opt(string[] strs)
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
}
