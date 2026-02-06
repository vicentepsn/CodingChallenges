namespace Algoritmos.DP;

public class SubsetSum_Partition
{
    public static bool SubsetSum(int[] nums, int target)
    {
        var dp = new bool[target + 1];
        dp[0] = true;

        foreach (var x in nums)
        {
            for (int s = target; s >= x; s--)
                dp[s] = dp[s] || dp[s - x];
        }
        return dp[target];
    }
}
/*
1) Subset Sum / Partition (muito comum)

Enunciado típico (Amazon/Google):
“Dado um array de inteiros positivos e um alvo T, existe algum subconjunto que soma T?”
Variante: Partition Equal Subset Sum (“dá pra dividir em dois subconjuntos com soma igual?”)

Ideia (DP booleano)

dp[s] = true se existe subconjunto com soma s.

Complexidade: O(n * T) tempo e O(T) memória → pseudo-polinomial (boa quando T não é gigante).
*/