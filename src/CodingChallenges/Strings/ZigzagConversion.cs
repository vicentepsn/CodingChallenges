using System.Text;

namespace CodingChallenges.Strings;

public class ZigzagConversion
{
    public static string Convert(string s, int numRows)
    {
        if (numRows == 1 || s.Length <= numRows)
            return s;

        var result = new StringBuilder();
        for (int row = 0; row < numRows && row < s.Length; row++)
        {
            result.Append(s[row]);
            int nextIdx = row + ((row == 0 || row == numRows - 1) ? (numRows - 1) * 2 : (numRows - 1 - row) * 2);
            while (nextIdx < s.Length)
            {
                result.Append(s[nextIdx]);
                if (row == 0 || row == numRows - 1) {
                    nextIdx += (numRows - 1) * 2;
                }
                else
                {
                    nextIdx += row * 2;
                    if (nextIdx < s.Length)
                    {
                        result.Append(s[nextIdx]);
                        nextIdx += (numRows - 1 - row) * 2;
                    }
                }
            }
        }
        return result.ToString();
    }


    public static string Convert_ChatGPT(string s, int numRows)
    {
        if (numRows == 1 || s.Length <= numRows)
            return s;

        // Criar um array de StringBuilder para cada linha
        StringBuilder[] linhas = new StringBuilder[numRows];
        for (int i = 0; i < numRows; i++)
            linhas[i] = new StringBuilder();

        int linhaAtual = 0;
        bool descendo = true;

        foreach (char c in s)
        {
            linhas[linhaAtual].Append(c);

            // Se estiver descendo, incrementa a linha
            if (descendo)
            {
                linhaAtual++;
                // Se chegou na última linha, muda direção
                if (linhaAtual == numRows - 1)
                    descendo = false;
            }
            else
            {
                linhaAtual--;
                // Se chegou na primeira linha, muda direção
                if (linhaAtual == 0)
                    descendo = true;
            }
        }

        // Concatenar todas as linhas
        StringBuilder resultado = new StringBuilder();
        foreach (var sb in linhas)
            resultado.Append(sb.ToString());

        return resultado.ToString();
    }
}
