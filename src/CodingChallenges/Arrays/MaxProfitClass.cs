namespace CodingChallenges.Arrays;

/// <summary>
/// Groups    : Array, DP?
/// Title     : 121. Best Time to Buy and Sell Stock
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
/// Approachs : -
/// </summary>
public class MaxProfitClass
{
    public int MaxProfit(int[] prices)
    {
        if (prices.Length <= 1)
            return 0;

        int maxProfit = 0;
        int minValue = prices[0];

        for (int i = 1; i < prices.Length; i++)
        {
            int diff = prices[i] - minValue;
            maxProfit = Math.Max(maxProfit, diff);
            minValue = Math.Min(minValue, prices[i]);
        }

        return maxProfit;
    }
}
