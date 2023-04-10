using System;

namespace CodingChallenges.Strings
{
    /// <summary>
    /// Related   : Two Pointers, String
    /// Title     : 161. One Edit Distance
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/one-edit-distance/
    /// </summary>
    public class OneEditDistance
    {
        // Complexity: T => O(N)   /   S => O(1)
        public bool IsOneEditDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;

            if (Math.Abs(n - m) > 1)
                return false;

            bool diffFound = false;

            int sIdx = 0,
                tIdx = 0;

            while (sIdx < n && tIdx < m)
            {
                if (s[sIdx] != t[tIdx])
                {
                    if (diffFound)
                        return false;

                    diffFound = true;

                    if (n > m)
                        sIdx++;
                    else if (m > n)
                        tIdx++;
                    else
                    {
                        sIdx++;
                        tIdx++;
                    }
                }
                else
                {
                    sIdx++;
                    tIdx++;
                }
            }

            return (!diffFound && (sIdx < n || tIdx < m))
                    || (diffFound && sIdx == n && tIdx == m);
        }

        // Leetcode solution
        // Complexity: T => O(N)   /   S => O(N) because strings are immutable and to create substrings costs O(N)
        public bool isOneEditDistance(string s, string t)
        {
            int ns = s.Length;
            int nt = t.Length;

            // Ensure that s is shorter than t.
            if (ns > nt)
                return isOneEditDistance(t, s);

            // The strings are NOT one edit away distance  
            // if the length diff is more than 1.
            if (nt - ns > 1)
                return false;

            for (int i = 0; i < ns; i++)
                if (s[i] != t[i])
                    // if strings have the same length
                    if (ns == nt)
                        return s.Substring(i + 1).Equals(t.Substring(i + 1));
                    // if strings have different lengths
                    else
                        return s.Substring(i).Equals(t.Substring(i + 1));

            // If there is no diffs on ns distance
            // the strings are one edit away only if
            // t has one more character. 
            return (ns + 1 == nt);
        }
    }

    /* Test Cases:
     * "", ""
     * "a", ""
     * "abc", "abc"
     * "axbc", "abc"
     * "axbc", "aybc"
     * "abcd", "abc"
     */
}
