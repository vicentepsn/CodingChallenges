using System.Linq;

namespace CodingChallenges.Graph
{
    /// <summary>
    /// Groups    : Graph
    /// Title     : 743. Network Delay Time (This is for positive values only)
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/network-delay-time/
    /// Approach  : Bellman-Ford (for graphs With Negatives weighs)
    /// Complexity: T: O(n + (n-1).e) => O(N.E)  /  S: O(N)
    /// </summary>
    public class NetworkDelayTimeWithNegatives
    {
        public static int networkDelayTime(int[][] times, int n, int k)
        {
            var distances = new int[n];
            for (int i = 0; i < n; i++)
                distances[i] = int.MaxValue;
            distances[k - 1] = 0;

            int iterations;
            var updateCount = 0;
            for (iterations = 0; iterations < n; iterations++)
            {
                updateCount = 0;
                for (var j = 0; j < times.Length; j++)
                {
                    var source = times[j][0];
                    var target = times[j][1];
                    var weight = times[j][2];

                    if (distances[source - 1] + weight < distances[target - 1])
                    {
                        distances[target - 1] = distances[source - 1] + weight;
                        updateCount++;
                    }
                }

                if (updateCount == 0) break;
            }

            // If there is a negative cycle
            if (iterations == n && updateCount > 0)
                return -1;

            var ans = distances.Max();
            return ans == int.MaxValue ? -1 : ans;
        }
    }
}
