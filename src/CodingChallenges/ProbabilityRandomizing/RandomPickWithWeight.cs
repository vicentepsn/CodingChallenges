namespace CodingChallenges.ProbabilityRandomizing;

/// <summary>
/// Groups    : Math, Array, Binary Search, Randomized, Prefix Sum
/// Title     : 70. Climbing Stairs
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/climbing-stairs
/// Approach  : Binary Search, Randomized, Prefix Sum
/// </summary>

// VERSÃO OTIMIZADA ABAIXO
// Leetcode: Beats 53.39% / 9.32%
public class RandomPickWithWeight
{
    private readonly int[] probsOfIndexes;
    private readonly int probsSum;
    private readonly Random rdn = new();
    private readonly int[][] indexDistribution; // faz o Prefix Sum

    // O(n) / O(n)
    public RandomPickWithWeight(int[] w)
    {
        probsOfIndexes = w;
        probsSum = probsOfIndexes[0];//probsOfIndexes.Sum();

        indexDistribution = new int[probsOfIndexes.Length][];
        indexDistribution[0] = [0, probsOfIndexes[0] - 1];

        int lastEnd = indexDistribution[0][1];
        for (int idx = 1; idx < probsOfIndexes.Length; idx++)
        {
            probsSum += probsOfIndexes[idx];
            indexDistribution[idx] = [lastEnd + 1, lastEnd + probsOfIndexes[idx]];
            lastEnd = indexDistribution[idx][1];
        }
    }

    // O(log n)
    public int PickIndex()
    {
        int rdnValue = rdn.Next(probsSum);

        int left = 0;
        int right = indexDistribution.Length - 1;
        while (left < right)
        {
            int mid = (right + left) / 2;
            if (rdnValue < indexDistribution[mid][0])
                right = mid - 1;
            else if (rdnValue > indexDistribution[mid][1])
                left = mid + 1;
            else
                return mid;
        }
        return left;
    }
}

// Leetcode: Beats 100.00% / 80.51%
// Versão otimizada em espaço => O(1)
public class RandomPickWithWeight_Otimizada
{
    private readonly int[] probsOfIndexes;
    private readonly int probsSum;
    private readonly Random rdn = new();

    // O(n) / O(1)
    public RandomPickWithWeight_Otimizada(int[] w)
    {
        probsOfIndexes = w;
        probsSum = probsOfIndexes[0];

        probsOfIndexes[0] -= 1;
        int lastEnd = probsOfIndexes[0];
        for (int idx = 1; idx < probsOfIndexes.Length; idx++)
        {
            probsSum += probsOfIndexes[idx];  // faz o Prefix Sum no próprio array original
            probsOfIndexes[idx] += lastEnd;
            lastEnd = probsOfIndexes[idx];
        }
    }

    // O(log n)
    public int PickIndex()
    {
        int rdnValue = rdn.Next(probsSum);

        if (rdnValue <= probsOfIndexes[0])
            return 0;

        int left = 1;
        int right = probsOfIndexes.Length - 1;
        while (left < right)
        {
            int mid = (right + left) / 2;
            if (rdnValue <= probsOfIndexes[mid - 1])
                right = mid - 1;
            else if (rdnValue > probsOfIndexes[mid])
                left = mid + 1;
            else
                return mid;
        }
        return left;
    }
}

// Estoura a memória no Leetcode, mas seria muito performático se a memória comportasse a soma das probabilidades
public class RandomPickWithWeight_v1
{
    private readonly int[] probsOfIndexes;
    private readonly int probsSum = 0;
    private readonly Random rdn = new();
    private readonly int[] indexDistribution;

    // O(sum) / O(sum)
    public RandomPickWithWeight_v1(int[] w)
    {
        probsOfIndexes = w;
        probsSum = probsOfIndexes.Sum();

        indexDistribution = new int[probsSum];
        int distIdx = 0;
        for (int idx = 0; idx < probsOfIndexes.Length; idx++)
        {
            int num = probsOfIndexes[idx];
            for (int i = 0; i < num; i++)
                indexDistribution[distIdx++] = idx;
        }
    }

    // O(1)
    public int PickIndex()
    {
        return indexDistribution[rdn.Next(probsSum)];
    }
}

// Mais simples
public class RandomPickWithWeight_v2
{
    private readonly int[] probsOfIndexes; // probabilidades dos índices
    private readonly int probsSum = 0;
    private readonly Random rdn = new();

    // O(n) / O(1)
    public RandomPickWithWeight_v2(int[] w)
    {
        probsOfIndexes = w;
        probsSum = probsOfIndexes.Sum();
    }

    // O(n)
    public int PickIndex()
    {
        int rdnValue = rdn.Next(probsSum);
        int idx = 0;
        while (rdnValue >= probsOfIndexes[idx]){
            rdnValue -= probsOfIndexes[idx++];
        }
        return idx;
    }
}
