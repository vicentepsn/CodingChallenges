using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges.Strings
{
    /// <summary>
    /// Related   : String, Greedy, Sorting
    /// Title     : 1647. Minimum Deletions to Make Character Frequencies Unique
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/minimum-deletions-to-make-character-frequencies-unique/
    /// Companies : Microsoft 15 (2022-05-03)
    /// </summary>
    public class MinimumDeletionsToMakeCharacterFrequenciesUnique
    {
        // O(N+KlogK) / O(k)
        public int MinDeletions(string s)
        {
            var dict = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (!dict.ContainsKey(c))
                    dict[c] = 0;
                dict[c]++;
            }

            var frequencies = dict.Values.ToArray();
            if (frequencies.Length == 1)
                return 0;

            Array.Sort(frequencies, (a, b) => b.CompareTo(a));

            int current = frequencies[0] - 1;
            int deletionCount = 0;
            for (int i = 1; i < frequencies.Length; i++)
            {
                if (current < frequencies[i])
                    deletionCount += frequencies[i] - current;
                else
                    current = frequencies[i];

                if (current > 0)
                    current--;
            }

            return deletionCount;
        }
    }
}
