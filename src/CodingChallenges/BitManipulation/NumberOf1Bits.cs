namespace CodingChallenges.BitManipulation;

/// <summary>
/// Groups    : Bit Manipulation
/// Title     : 191. Number of 1 Bits
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/single-number
/// Approach  : -
/// </summary>
public class NumberOf1Bits
{
    public int HammingWeight(int n)
    {
        int bitCount = 0;

        while (n > 0)
        {
            if ((n & 1) == 1)
                bitCount++;
            n >>= 1;
        }

        return bitCount;
    }

    public int HammingWeight(uint n)
    {
        int count = 0;
        while (n != 0)
        {
            count += (int)(n & 1); // soma se o último bit for 1
            n >>= 1;               // desloca para a direita
        }
        return count;
    }

    /*
⚡ Versão otimizada (Brian Kernighan’s Algorithm)
Esse algoritmo remove o bit mais à direita que está em 1 a cada passo:
*/
    public int HammingWeight_opt(uint n)
    {
        int count = 0;
        while (n != 0)
        {
            n &= (n - 1); // remove o bit 1 mais à direita
            count++;
        }
        return count;
    }
}

public class NumberOf1Bits_MultiplasChamadas
{
    // Pré-calcula inversão de 8 bits
    static int[] cache = new int[256];

    static NumberOf1Bits_MultiplasChamadas()
    {
        for (int i = 0; i < 256; i++)
        {
            int val = i;
            int bitCount = 0;
            while (val > 0)
            {
                if ((val & 1) == 1)
                    bitCount++;
                val >>= 1;
            }
            cache[i] = bitCount;
        }
    }

    public int HammingWeight(int n)
    {
        return (cache[n & 0xFF] << 24) |
               (cache[(n >> 8) & 0xFF] << 16) |
               (cache[(n >> 16) & 0xFF] << 8) |
               (cache[(n >> 24) & 0xFF]);
    }
}

public class NumberOf1Bits_MultiplasChamadas_ChatGpt
{
    // Tabela de lookup para todos os valores de 0 a 255
    private static readonly int[] bitCount = new int[256];

    // Construtor estático para preencher a tabela uma vez
    static NumberOf1Bits_MultiplasChamadas_ChatGpt()
    {
        for (int i = 0; i < 256; i++)
        {
            int val = i;
            int count = 0;
            while (val != 0)
            {
                val &= (val - 1); // Brian Kernighan’s Algorithm
                count++;
            }
            bitCount[i] = count;
        }
    }

    public int HammingWeight(uint n)
    {
        // Divide o inteiro em 4 bytes e soma os resultados da tabela
        return bitCount[n & 0xFF] +
               bitCount[(n >> 8) & 0xFF] +
               bitCount[(n >> 16) & 0xFF] +
               bitCount[(n >> 24) & 0xFF];
    }
}
