using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

namespace CodingChallenges.Strings
{
    /// <summary>
    /// Related   : String, Stack, Simulation
    /// Title     : 2390. Removing Stars From a String
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/removing-stars-from-a-string/description/
    /// Approachs : -
    /// Companies : Amazon (2023-04-12)
    /// </summary>
    public static class RemovingStarsFromAString
    {
        // My sotution using char array
        // Time complexity: O(n) / Space complexity: O(n)
        public static string RemoveStars_MySolution(string s)
        {
            char[] resultArray = new char[s.Length];
            int idx = s.Length - 1;
            int resultIdx = idx;
            int starCount = 0;

            while (idx >= 0)
            {
                if (s[idx] == '*')
                {
                    starCount++;
                }
                else if (starCount > 0)
                {
                    starCount--;
                }
                else
                {
                    resultArray[resultIdx] = s[idx];
                    resultIdx--;
                }
                idx--;
            }

            var result = resultIdx + 1 == resultArray.Length 
                ? "" 
                : new string(resultArray, resultIdx + 1, resultArray.Length - resultIdx - 1);
            return result;
        }

        // Author sotution using Two Pointers
        // Time complexity: O(n) / Space complexity: O(n)
        public static string RemoveStars(string s)  //_TwoPointers
        {
            char[] ch = new char[s.Length];
            int j = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '*')
                {
                    j--;
                }
                else
                {
                    ch[j++] = c;
                }
            }

            //StringBuilder answer = new StringBuilder();
            //for (int i = 0; i < j; i++)
            //{
            //    answer.Append(ch[i]);
            //}

            //return answer.ToString();
            return new string(ch, 0, j);
        }

        // Author sotution using stack
        // Time complexity: O(n) / Space complexity: O(n)
        public static string RemoveStars_Stack(string s)
        {
            Stack<char> st = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '*')
                {
                    st.Pop();
                }
                else
                {
                    st.Push(s[i]);
                }
            }

            //
            //StringBuilder answer = new StringBuilder();
            //while (!st.Any())
            //{
            //    answer.Append(st.Pop());
            //}

            //return answer.reverse().toString();

            var answer = st.Reverse().ToArray();
            return new string(answer);
        }

        // Author sotution using strings
        // Time complexity: O(n) / Space complexity: O(n)
        public static string RemoveStars_Strings(string s)
        {
            int j = 0;
            StringBuilder answer = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '*')
                {
                    answer.Remove(answer.Length - 1, 1);
                }
                else
                {
                    answer.Append(s[i]);
                }
            }
            return answer.ToString();
        }
    }
}
