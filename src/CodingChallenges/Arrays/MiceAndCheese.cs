using System;

namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Related   : Array, Greedy, Sorting, Heap (Priority Queue)
    /// Title     : 2611. Mice and Cheese
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/mice-and-cheese/
    /// Companies : ??
    /// </summary>
    public static class MiceAndCheese
    {
        public struct RewardCompare
        {
            public int Diff;
            public int Index;
            public int MouseWinner;
        }

        private static int compareRewardCompare(RewardCompare r1, RewardCompare r2)
        {
            if (r1.Diff > r2.Diff)
                return -1;
            else if (r1.Diff < r2.Diff)
                return 1;
            else
                return 0;
        }

        public static int MiceAndCheeseMaxReward(int[] reward1, int[] reward2, int k)
        {
            int n = reward1.Length;
            var rewardCompare = new RewardCompare[n];

            for (int i = 0; i < n; i++)
            {
                rewardCompare[i].Diff = Math.Abs(reward1[i] - reward2[i]);
                rewardCompare[i].Index = i;
                if (reward1[i] > reward2[i])
                {
                    rewardCompare[i].MouseWinner = 1;
                }
                else
                {
                    rewardCompare[i].MouseWinner = 2;
                }
            }

            Array.Sort(rewardCompare, compareRewardCompare); // sort by bigger Diff

            int remainMouse1 = k;

            int result = 0;
            int idx = 0;
            for (; n - idx > remainMouse1 && remainMouse1 > 0; idx++)
            {
                if (rewardCompare[idx].MouseWinner == 1)
                {
                    result += reward1[rewardCompare[idx].Index];
                    remainMouse1--;
                }
                else
                    result += reward2[rewardCompare[idx].Index];
            }

            if (remainMouse1 > 0)
            {
                for (; idx < n; idx++)
                    result += reward1[rewardCompare[idx].Index];
            }
            else
            {
                for (; idx < n; idx++)
                    result += reward2[rewardCompare[idx].Index];
            }

            return result;
        }
    }
}
