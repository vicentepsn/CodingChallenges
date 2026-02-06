namespace Algoritmos.DP;

public class Knapsack01_Mochila
{
    public static int Knapsack01(int[] w, int[] v, int W)
    {
        int n = w.Length;
        var dp = new int[n + 1, W + 1];

        for (int i = 1; i <= n; i++)
        {
            for (int cap = 0; cap <= W; cap++)
            {
                dp[i, cap] = dp[i - 1, cap];
                if (cap >= w[i - 1])
                    dp[i, cap] = Math.Max(dp[i, cap], dp[i - 1, cap - w[i - 1]] + v[i - 1]);
            }
        }
        return dp[n, W];
    }
}
/*
Knapsack 0/1 (clássico de DP em entrevista)

Enunciado típico:
“Você tem itens com peso e valor e uma mochila com capacidade W. Qual o valor máximo?”

O Knapsack 0/1 é NP-Complete no formato de decisão, mas em entrevista você quase sempre usa DP pseudo-polinomial.

Ideia (DP)

dp[i][cap] = melhor valor usando os i primeiros itens e capacidade cap.

Complexidade: O(n * W).
*/