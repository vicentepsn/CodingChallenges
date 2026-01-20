namespace CodingChallenges.Arrays;

/// <summary>
/// Groups    : Array, DP, Divide and Conquer
/// Title     : 918. Maximum Sum Circular Subarray
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/maximum-sum-circular-subarray
/// Approachs : Kadane's Algorithm
/// ATENÇÃO   : Essa solução combina Kadane’s Algorithm para máximo e mínimo, aproveitando a ideia de que o subarray circular é o complemento do subarray mínimo
/// </summary>
public class MaximumSumCircularSubarray // CGPT
{
    // O(n) / O(1)
    // Leetcode: Beats 100.00% / 55.93%
    public int MaxSubarraySumCircular(int[] nums)
    {
        int totalSum = 0;
        int maxSum = nums[0], curMax = 0;
        int minSum = nums[0], curMin = 0;

        foreach (int num in nums)
        {
            // Kadane para máximo
            curMax = Math.Max(num, curMax + num);
            maxSum = Math.Max(maxSum, curMax);

            // Kadane para mínimo
            curMin = Math.Min(num, curMin + num);
            minSum = Math.Min(minSum, curMin);

            totalSum += num;
        }

        // Caso especial: todos negativos
        if (maxSum < 0) return maxSum;

        // Máximo entre caso normal e caso circular
        return Math.Max(maxSum, totalSum - minSum);
    }
}
/*
Esse é o problema 918. Maximum Sum Circular Subarray, que é uma variação do Maximum Subarray (Kadane’s Algorithm), mas considerando que o array é circular.

🧩 Entendendo o problema
- Queremos o máximo subarray sum em um array circular.
- Isso significa que o subarray pode:
- Estar inteiramente dentro do array (caso normal → Kadane).
- Atravessar o final e o início do array (caso circular).
👉 Para lidar com o caso circular:
- O máximo circular é igual a:
\mathrm{totalSum}-\mathrm{minSubarraySum}- Onde:
- totalSum = soma de todos os elementos.
- minSubarraySum = soma mínima de um subarray (usando Kadane invertido).
- Mas atenção: se todos os números forem negativos, o resultado é apenas o máximo normal (não podemos pegar o array inteiro).

🔎 Observações
- Complexidade:
- Tempo: O(n) (uma única passagem pelo array).
- Espaço: O(1).
- Essa solução combina Kadane’s Algorithm para máximo e mínimo, aproveitando a ideia de que o subarray circular é o complemento do subarray mínimo.

 */