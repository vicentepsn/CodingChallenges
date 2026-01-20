namespace CodingChallenges.BitManipulation;

/// <summary>
/// Groups    : Bit Manipulation
/// Title     : 190. Reverse Bits
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/reverse-bits
/// Approach  : -
/// </summary>
public class ReverseBitsClass
{
    public int ReverseBits(int n)
    {
        int result = 0;
        for (int i = 0; i < 32; i++)
        {
            int bit = n & 1; // "&" => operador de 'e' binário

            result = (result << 1) | bit; // desloca o resultado para esquerda ("<<") e adiciona o bit ("|" ou binário)

            n >>= 1; // desloca o número para direita (">>")
        }

        return result;
    }
}

// Otimizado para múltiplas chamadas
public class ReverseBitsClass_MultiplasChamadas
{
    // Pré-calcula inversão de 8 bits
    static uint[] cache = new uint[256];

    static ReverseBitsClass_MultiplasChamadas()
    {
        for (int i = 0; i < 256; i++)
        {
            uint val = (uint)i;
            uint rev = 0;
            for (int j = 0; j < 8; j++)
            {
                rev = (rev << 1) | (val & 1);
                val >>= 1;
            }
            cache[i] = rev;
        }
    }

    public uint reverseBits(uint n)
    {
        return (cache[n & 0xFF] << 24) |
               (cache[(n >> 8) & 0xFF] << 16) |
               (cache[(n >> 16) & 0xFF] << 8) |
               (cache[(n >> 24) & 0xFF]);
    }
}
/*
Esse problema pede para inverter os 32 bits de um inteiro. A ideia é percorrer cada bit de n, deslocá-lo para a posição invertida e construir o resultado.

🔑 Explicação
- n & 1 pega o bit menos significativo.
- result << 1 desloca os bits já construídos para abrir espaço.
- | bit adiciona o novo bit.
- n >>= 1 move para o próximo bit.
- Após 32 iterações, result contém os bits invertidos.

⏱ Complexidade
- Tempo: O(32) → constante.
- Espaço: O(1)

⚡ Follow-up (otimização para muitas chamadas)
Se a função for chamada muitas vezes:
- Podemos usar memoization para armazenar resultados de 8 bits (1 byte).
- Como um inteiro tem 4 bytes, basta inverter cada byte usando a tabela pré-calculada e combinar.
- Isso reduz o custo para O(4) operações de lookup em vez de 32 deslocamentos.
*/