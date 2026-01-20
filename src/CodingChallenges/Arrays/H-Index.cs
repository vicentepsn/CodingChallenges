using System;

namespace CodingChallenges.Arrays;

/// <summary>
/// Groups    : Array, Sort, Counting Sort
/// Title     : 274. H-Index
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/h-index
/// Approachs : -
/// </summary>
public class H_Index
{
    // O(n log n) / O(1)
    public int HIndex_v1(int[] citations)
    {
        Array.Sort(citations, (a, b) => b.CompareTo(a));

        int hIndex = 0;
        while (hIndex < citations.Length && citations[hIndex] >= hIndex + 1)
            hIndex++;

        return hIndex;
    }

    // O(n) / O(n)
    /* 🔑 Ideia da solução otimizada
- O h-index nunca pode ser maior que o número de artigos n.
- Então criamos um array auxiliar count de tamanho n+1, onde:
    - count[i] = número de artigos com exatamente i citações(limitando valores maiores que n para count[n]).
- Depois percorremos count de trás para frente acumulando quantos artigos têm pelo menos aquele número de citações.
- O primeiro índice i em que o acumulado \geq i é o h-index. */
    public int HIndex(int[] citations)
    {
        int n = citations.Length;
        int[] count = new int[n + 1];

        // Contagem limitada
        foreach (int c in citations)
        {
            if (c >= n)
                count[n]++;
            else
                count[c]++;
        }

        int total = 0;
        for (int i = n; i >= 0; i--)
        {
            total += count[i];
            if (total >= i)
                return i;
        }

        return 0;
    }
}


/*
274. H-Index

Given an array of integers citations where citations[i] is the number of citations a researcher received for their ith paper, 
return the researcher's h-index.

According to the definition of h-index on Wikipedia (https://en.wikipedia.org/wiki/H-index): The h-index is defined as the maximum 
value of h such that the given researcher has published at least h papers that have each been cited at least h times.

Example 1:

Input: citations = [3,0,6,1,5]
Output: 3
Explanation: [3,0,6,1,5] means the researcher has 5 papers in total and each of them had received 3, 0, 6, 1, 5 citations respectively.
Since the researcher has 3 papers with at least 3 citations each and the remaining two with no more than 3 citations each, their h-index is 3.

Example 2:

Input: citations = [1,3,1]
Output: 1
 

Constraints:

n == citations.length
1 <= n <= 5000
0 <= citations[i] <= 1000
 */
