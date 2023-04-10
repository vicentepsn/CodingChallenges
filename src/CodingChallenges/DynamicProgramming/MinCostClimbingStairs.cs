using System;

namespace CodingChallenges.DynamicProgramming
{
    /// <summary>
    /// Related   : Array, Dynamic Programming
    /// Title     : 746. Min Cost Climbing Stairs
    /// Difficult : Easy
    /// Link      : https://leetcode.com/problems/min-cost-climbing-stairs/
    /// Companies : Amazon 3, Microsoft 2 (2022-04-22)
    /// </summary>
    public class MinCostClimbingStairs
    {
        // O(N) / O(1)
        public static int minCostClimbingStairs(int[] cost)
        {
            // Constraints:
            // 2 <= cost.length <= 1000
            int[] mins = new int[] { cost[0], cost[1] };

            int minsPosition = 0;
            for (int i = 2; i < cost.Length; i++)
            {
                mins[minsPosition] = cost[i] + Math.Min(mins[0], mins[1]);
                minsPosition = minsPosition == 0 ? 1 : 0;
            }

            return Math.Min(mins[0], mins[1]);
        }

        // O(N) / O(1)
        public int minCostClimbingStairs_Leetcode(int[] cost)
        {
            int downOne = 0;
            int downTwo = 0;
            for (int i = 2; i < cost.Length + 1; i++)
            {
                int temp = downOne;
                downOne = Math.Min(downOne + cost[i - 1], downTwo + cost[i - 2]);
                downTwo = temp;
            }

            return downOne;
        }

        // O(2^N) / O(N)
        public static int minCostClimbingStairs_recursion(int[] cost)
        {
            return Math.Min(MinCost(cost, cost.Length - 1), MinCost(cost, cost.Length - 2));
        }

        private static int MinCost(int[] cost, int i)
        {
            if (i <= 1)
                return cost[i];

            return cost[i] + Math.Min(MinCost(cost, i - 1), MinCost(cost, i - 2));
        }
    }

    
}
