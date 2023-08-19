using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Related   : Array, Math, Simulation
    /// Title     : 2028. Find Missing Observations
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/find-missing-observations/
    /// Companies : Microsoft 2, Amazon (last 6 months 2023-04-14)
    /// </summary>
    public static class FindMissingObservations
    {
        public static int[] MissingRolls(int[] rolls, int mean, int n)
        {
            int m = rolls.Length;
            int rollsMTotal = rolls.Sum();
            int avgTotal = (m + n) * mean;
            int rollsNMax = n * 6;
            int rollsNMin = n;

            if(rollsMTotal + rollsNMin > avgTotal 
                || rollsMTotal + rollsNMax < avgTotal)
            {
                return new int[] { };
            }

            int[] result = new int[n];
            int avgN = (avgTotal - rollsMTotal) / n;
            int rest = (avgTotal - rollsMTotal) % n;
            int i = 0;
            int additional = 6 - avgN;

            while (rest > 0)
            {
                result[i++] = avgN + (rest > additional ? additional : rest);
                rest -= additional;
            }

            for(;i < n; i++)
                result[i] = avgN;

            return result;
        }
    }
}
