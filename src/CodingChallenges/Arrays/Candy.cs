namespace CodingChallenges.Arrays;

/// <summary>
/// Related   : Array, Greedy
/// Title     : 135. Candy
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/candy/
/// Companies : 
/// </summary>
public class Candy
{
    /*
🔑 Ideia da solução
- Inicializamos um array candies com 1 doce para cada criança.
- Fazemos duas passagens:
    - Esquerda → Direita: se ratings[i] > ratings[i-1], então candies[i] = candies[i-1] + 1.
    - Direita → Esquerda: se ratings[i] > ratings[i+1], então candies[i] = Math.Max(candies[i], candies[i+1] + 1).
- No final, somamos todos os valores de candies. */
    // O(n) / O(n)
    public int GiveCandies(int[] ratings)
    {
        int n = ratings.Length;
        int[] candies = new int[n];

        // Cada criança começa com 1 doce
        for (int i = 0; i < n; i++)
        {
            candies[i] = 1;
        }

        // Passagem da esquerda para a direita
        for (int i = 1; i < n; i++)
        {
            if (ratings[i] > ratings[i - 1])
            {
                candies[i] = candies[i - 1] + 1;
            }
        }

        // Passagem da direita para a esquerda
        for (int i = n - 2; i >= 0; i--)
        {
            if (ratings[i] > ratings[i + 1])
            {
                candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
            }
        }

        // Soma total
        int total = 0;
        foreach (int c in candies)
        {
            total += c;
        }

        return total;
    }
}
/*
135. Candy

There are n children standing in a line. Each child is assigned a rating value given in the integer array ratings.

You are giving candies to these children subjected to the following requirements:

Each child must have at least one candy.
Children with a higher rating get more candies than their neighbors.
Return the minimum number of candies you need to have to distribute the candies to the children.

 

Example 1:

Input: ratings = [1,0,2]
Output: 5
Explanation: You can allocate to the first, second and third child with 2, 1, 2 candies respectively.
Example 2:

Input: ratings = [1,2,2]
Output: 4
Explanation: You can allocate to the first, second and third child with 1, 2, 1 candies respectively.
The third child gets 1 candy because it satisfies the above two conditions.
 

Constraints:

n == ratings.length
1 <= n <= 2 * 104
0 <= ratings[i] <= 2 * 104
*/