namespace CodingChallenges.Arrays;

/// <summary>
/// Groups: Arrays, DP, BFS
/// Title: 322. Coin Change
/// Difficult: Medium/Hard
/// Link: https://leetcode.com/problems/coin-change
/// Approach: DB, Memoization
/// </summary>
public class CoinChangeClass
{
    // ATENÇÃO: A VERSÃO "CoinChange_Memo_CGPT" É MAIS FÁCIL DE EXPLICAR TEM A MESMA COMPLEXIDADE
    int minCoinsSoFar = int.MaxValue;
    Dictionary<int, int> memo = [];
    // Leetcode: Beats 5.52% / 98.47%
    // O(n × amount) / O(n + amount)
    public int CoinChange(int[] coins, int amount)
    {
        if (amount == 0) return 0;

        Array.Sort(coins, (a, b) => b.CompareTo(a));
        minCoinsSoFar = amount / coins[^1];
        
        int minCoins = CoinChange_aux(0, 0, coins, amount);

        return minCoins;
    }

    private int CoinChange_aux(int idx, int qtdCoins, int[] coins, int amount)
    {
        if (memo.TryGetValue(amount, out int value))
            return value;

        int remainAmount = amount;
        int qtdCoinIdx = remainAmount / coins[idx];
        int remain = remainAmount % coins[idx];

        qtdCoins += qtdCoinIdx;

        if (idx == coins.Length - 1 && remain > 0)
            return -1;

        if (remain == 0 || idx == coins.Length - 1)
        {
            minCoinsSoFar = Math.Min(minCoinsSoFar, qtdCoins);
            return qtdCoinIdx;
        }

        if (qtdCoins >= minCoinsSoFar)
            return -1;

        int minAmount = int.MaxValue;
        remainAmount -= qtdCoinIdx * coins[idx];
        while (qtdCoinIdx > 0)
        {
            int currMin = CoinChange_aux(idx + 1, qtdCoins, coins, remainAmount);

            if (currMin != -1 && currMin + qtdCoinIdx < minAmount)
                minAmount = currMin + qtdCoinIdx;

            qtdCoinIdx--;
            qtdCoins--;
            remainAmount += coins[idx];
        }
        
        if (remain > 0)
        {
            int currMin = CoinChange_aux(idx + 1, qtdCoins, coins, remainAmount);
            if (currMin != -1 && currMin < minAmount)
                minAmount = currMin;
        }

        int result = (minAmount == int.MaxValue) ? -1 : minAmount;

        memo[amount] = result;

        return (minAmount == int.MaxValue) ? -1 : minAmount;
    }

    // O(amount × n) / O(amount)
    // Leetcode: Beats 92.49% / 67.37
    public int CoinChange_DP_CGPT(int[] coins, int amount)
    {
        // dp[i] = mínimo de moedas para formar valor i
        int[] dp = new int[amount + 1];

        // Inicializa com um valor grande (infinito)
        for (int i = 1; i <= amount; i++)
        {
            dp[i] = amount + 1;
        }

        // Caso base: 0 moedas para formar 0
        dp[0] = 0;

        // Preenche a tabela
        for (int i = 1; i <= amount; i++)
        {
            foreach (int coin in coins)
            {
                if (coin <= i)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
        }

        // Se não foi possível formar o valor, retorna -1
        return dp[amount] > amount ? -1 : dp[amount];
    }

    // O(n * amount) / O(amount)
    // Leetcode: Beats 7.51% / 12.91
    public int CoinChange_Memo_CGPT(int[] coins, int amount)
    {
        // Dicionário para memoization: chave = valor alvo, valor = mínimo de moedas
        Dictionary<int, int> memo = new Dictionary<int, int>();
        return Helper(coins, amount, memo);
    }

    private int Helper(int[] coins, int amount, Dictionary<int, int> memo)
    {
        // Caso base
        if (amount == 0) return 0;
        if (amount < 0) return -1;

        // Se já calculado, retorna
        if (memo.ContainsKey(amount)) return memo[amount];

        int min = int.MaxValue;

        // Tenta cada moeda
        foreach (int coin in coins)
        {
            int res = Helper(coins, amount - coin, memo);
            if (res >= 0 && res < min)
            {
                min = res + 1;
            }
        }

        // Armazena no memo
        memo[amount] = (min == int.MaxValue) ? -1 : min;
        return memo[amount];
    }

}
