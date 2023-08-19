using System.Collections.Generic;

namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Related   : Array, Math
    /// Title     : Circular Array Rotation
    /// Difficult : Easy
    /// Link      : https://www.hackerrank.com/challenges/circular-array-rotation/problem
    /// Companies : ?? (2023-05)
    /// </summary>
    public static class CircularArrayRotationClass
    {
        public static List<int> CircularArrayRotation(List<int> a, int k, List<int> queries)
        {
            int n = a.Count;
            int q = queries.Count;

            List<int> result = new List<int>(q);

            foreach (int querie in queries)
            {
                int OrigZeroPosition = k % n;
                int rotatedPosition = (querie + n - OrigZeroPosition) % n;
                result.Add(a[rotatedPosition]);
            }

            return result;
        }
    }
}
