using System.Collections.Generic;

namespace CodingChallenges.Strings
{
    /// <summary>
    /// Groups    : String, HashTable, Math
    /// Title     : 13. Roman to Integer
    /// Difficult : Easy
    /// Link      : https://leetcode.com/problems/roman-to-integer/
    /// Approach  : -
    /// </summary>
    public class RomanToInt
    {
        public static int romanToInt(string s)
        {
            var map = new Dictionary<char, int>{
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            var result = 0;

            var last = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                var c = s[i];
                var current = map[c];

                if (last <= current)
                    result += current;
                else
                    result -= current;

                last = current;
            }

            return result;
        }
    }
}
