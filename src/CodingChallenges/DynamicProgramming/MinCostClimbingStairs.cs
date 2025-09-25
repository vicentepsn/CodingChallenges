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
        // O(2^N) / O(N)
        public static int minCostClimbingStairsUp(int[] cost)
        {
            steps = 0;
            if (cost.Length <= 1)
                return 0;

            int result = Math.Min(minCostClimbingStairsUp(cost, 0), minCostClimbingStairsUp(cost, 1));
            Console.WriteLine($"Up - Steps: {steps}");
            return result;
        }

        private static int minCostClimbingStairsUp(int[] cost, int position){
            steps++;
            if (position >= cost.Length)
                return 0;

            // esse if otimiza a base de parada e diminue o número de chamadas recursivas para menos da metade
            if (position >= cost.Length - 2)
                return cost[position];

            return cost[position] + Math.Min(minCostClimbingStairsUp(cost, position + 1), minCostClimbingStairsUp(cost, position + 2));
        }

        private static int steps;
        // O(2^N) / O(N)
        public static int minCostClimbingStairsDown(int[] cost)
        {
            steps = 0;
            if (cost.Length <= 1)
                return 0;

            int result = Math.Min(minCostClimbingStairsMyDown(cost, cost.Length - 1), minCostClimbingStairsMyDown(cost, cost.Length - 2));
            Console.WriteLine($"Down - Steps: {steps}");
            return result;
        }

        private static int minCostClimbingStairsMyDown(int[] cost, int position)
        {
            steps++;
            if (position < 0)
                return 0;

            // esse if otimiza a base de parada e diminue o número de chamadas recursivas para menos da metade
            if (position <= 1)
                return cost[position];

            return cost[position] + Math.Min(minCostClimbingStairsMyDown(cost, position - 1), minCostClimbingStairsMyDown(cost, position - 2));
        }

        // O(N) / O(N)
        private static int?[] minConts;
        public static int minCostClimbingStairsDownDP(int[] cost)
        {
            steps = 0;
            minConts = new int?[cost.Length];
            if (cost.Length <= 1)
                return 0;

            int result = Math.Min(minCostClimbingStairsMyDownDP(cost, cost.Length - 1), minCostClimbingStairsMyDownDP(cost, cost.Length - 2));
            Console.WriteLine($"DownDP - Steps: {steps}");
            return result;
        }

        private static int minCostClimbingStairsMyDownDP(int[] cost, int position)
        {
            steps++;
            if (position < 0)
                return 0;

            // esse if otimiza a base de parada e diminue o número de chamadas recursivas em algumas chamadas
            if (position <= 1)
                return cost[position];

            if (!minConts[position].HasValue)
                minConts[position] = cost[position] + Math.Min(minCostClimbingStairsMyDownDP(cost, position - 1), minCostClimbingStairsMyDownDP(cost, position - 2));

            return (int)minConts[position];
        }

        // O(N) / O(N)
        public static int minCostClimbingStairsArray(int[] cost)
        {
            //// Constraints:
            //// 2 <= cost.length <= 1000
            //int[] mins = new int[cost.Length + 1];
            //mins[0] = cost[0];
            //mins[1] = cost[1];
            //for (int i = 2; i < cost.Length + 1; i++)
            //{
            //    mins[i] = cost[i - 1] + Math.Min(mins[i - 1], mins[i - 2]);
            //}
            //return Math.Min(mins[cost.Length - 1], mins[cost.Length]);
            steps = 0;
            int n = cost.Length;

            if (n <= 1)
                return 0;

            int[] mins = new int[cost.Length];
            mins[0] = cost[0];
            mins[1] = cost[1];
            for (int i = 2; i < cost.Length; i++)
            {
                mins[i] = cost[i] + Math.Min(mins[i - 1], mins[i - 2]);
            }
            Console.WriteLine($"UpArray - Steps: {n}");
            return Math.Min(mins[n - 1], mins[n - 2]);
        }

        // O(N) / O(1) => complexidade de espaço otimizada
        public static int minCostClimbingStairsArray2(int[] cost)
        {
            steps = 0;
            int n = cost.Length;

            if (n <= 1)
                return 0;

            int minA = cost[0];
            int minB = cost[1];
            //bool minsPosition = true; // true = minA, false = minB
            for (int i = 2; i < cost.Length; i++)
            {
                int currMins = cost[i] + Math.Min(minA, minB);
                //if (minsPosition)
                //    minA = currMins;
                //else
                //    minB = currMins;
                //minsPosition = !minsPosition; // alterna entre minA e minB
                minA = minB;
                minB = currMins;
            }
            Console.WriteLine($"UpArray - Steps: {n}");
            return Math.Min(minA, minB);
        }


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
