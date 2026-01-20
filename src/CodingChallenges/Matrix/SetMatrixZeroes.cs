namespace CodingChallenges.Matrix;

/// <summary>
/// Related   : Matrix
/// Title     : 73. Set Matrix Zeroes
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/set-matrix-zeroes
/// Approachs : -
/// </summary>
public class SetMatrixZeroes
{
    // Leetcode: Beats 100.00% / 91.53%
    // Para que seja possível usar espaço constante, a primeira linha e coluna devem ser usadas como marcadores
    public static void SetZeroes(int[][] matrix)
    {
        int nRows = matrix.Length;
        int nColumns = matrix[0].Length;

        // Como as primeiras linhas e colunas são marcadores, eu não posso usar a posição (0, 0) para marcar se existem zeros nelas mesmas,
        // então eu uso varáveis para isso
        bool firstRowHasZero = false;
        bool firstColumnHasZero = false;

        for (int row = 0; row < nRows; row++) // verifica se a primeira linha tem zeros
            if (matrix[row][0] == 0)
                firstRowHasZero = true;
        for (int column = 0; column < nColumns; column++) // verifica se a primeira coluna tem zeros
            if (matrix[0][column] == 0)
                firstColumnHasZero = true;

        // Percorre o restante da matriz e marca a coluna e a linha caso encontrar um zero
        for (int row = 1; row < nRows; row++)
        {
            for (int column = 1; column < nColumns; column++)
            {
                if (matrix[row][column] == 0)
                {
                    matrix[0][column] = 0;
                    matrix[row][0] = 0;
                }
            }
        }

        // Atribui zero para todos as colunas da linha marcada
        for (int row = 1; row < nRows; row++)
        {
            if (matrix[row][0] == 0)
                for (int column = 1; column < nColumns; column++)
                    matrix[row][column] = 0;
        }
        for (int column = 1; column < nColumns; column++) // Atribui zero para todos as linhas da coluna marcada
        {
            if (matrix[0][column] == 0)
                for (int row = 1; row < nRows; row++)
                    matrix[row][column] = 0;
        }

        if (firstRowHasZero) // caso a primeira linha tenha zeros, atribui zero para os demais posições da primeira linha
            for (int row = 0; row < nRows; row++)
                matrix[row][0] = 0;
        if (firstColumnHasZero) // caso a primeira coluna tenha zeros, atribui zero para os demais posições da primeira coluna
            for (int column = 0; column < nColumns; column++)
                matrix[0][column] = 0;
    }
}
