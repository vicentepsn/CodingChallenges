using System.Numerics;

namespace CodingChallenges.Maths;

/// <summary>
/// Groups    : Math, Array
/// Title     : 172. Factorial Trailing Zeroes
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/factorial-trailing-zeroes
/// Approach  : -
/// </summary>
public class FactorialTrailingZeroes
{
    public int TrailingZeroes(int n) // ChatGPT
    {
        int count = 0;
        while (n > 0)
        {
            n /= 5;
            count += n;
        }
        return count;
    }

    // Naive solution (estoura o tempo no leetcode)
    public static int TrailingZeroes_naive(int n)
    {
        if (n <= 1) return 0;

        BigInteger factorial = n;
        for (int i = n - 1; i > 1; i--)
            factorial *= i;

        BigInteger rest = factorial % 10;
        int trailingZeroes = 0;
        while (rest == 0 & factorial > 0)
        {
            trailingZeroes++;
            factorial /= 10;
            rest = factorial % 10;
        }
        return trailingZeroes;
    }
}
/*
🧩 Entendendo o problema
- Um zero à direita em n! vem de fatores de 10 = 2 × 5.
- Como há sempre mais fatores de 2 do que de 5, o número de zeros é determinado pela quantidade de fatores de 5 em n!.
👉 Fórmula:
zeros}=\left\lfloor \frac{n}{5}\right\rfloor +\left\lfloor \frac{n}{25}\right\rfloor +\left\lfloor \frac{n}{125}\right\rfloor +\dots 

Ou seja, somamos quantas vezes 5, 25, 125, etc. aparecem como divisores até que 5^k>n.

💡 Estratégia
- Dividir repetidamente n por 5.
- Somar os quocientes.
- Isso roda em O(log n), pois cada passo divide por 5.
*/