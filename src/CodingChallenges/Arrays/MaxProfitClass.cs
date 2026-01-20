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

    /// <summary>
    /// Groups    : Array, DP?, Greedy?
    /// Title     : 122. Best Time to Buy and Sell Stock II (considera quantas compras e vendas quiser)
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii
    /// Approachs : -
    /// </summary>
    public int MaxProfitII(int[] prices)
    {
        int profit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] > prices[i - 1])
            {
                profit += prices[i] - prices[i - 1];
            }
        }

        return profit;
    }
}
