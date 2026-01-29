namespace CodingChallenges.Matrix;

/// <summary>
/// Related   : Matrix, DP
/// Title     : 221. Maximal Square
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/maximal-square
/// Companies : DP
/// </summary>
public class MaximalSquareClass
{
    // Leetcode: Beats 93.07% / 90.10%
    // see test cases bellow
    // O(n*n) / O(1)
    public static int MaximalSquare(char[][] matrix)
    {
        char maxinalSquare = '0';

        // Start check from second line and column
        for (int row = 1; row < matrix.Length; row++)
        {
            for (int col = 1; col < matrix[0].Length; col++)
            {
                if (matrix[row][col] == '0') 
                    continue;
                //char minTopLeft = matrix[row - 1][col] < matrix[row][col - 1] ? matrix[row - 1][col] : matrix[row][col - 1];
                //matrix[row][col] = minTopLeft < matrix[row - 1][col - 1] ? minTopLeft : matrix[row - 1][col - 1];
                //maxinalSquare = maxinalSquare > matrix[row][col] ? maxinalSquare : matrix[row][col];
                matrix[row][col] = (char)(Math.Min(matrix[row - 1][col - 1], (char)Math.Min(matrix[row - 1][col], matrix[row][col - 1])) + 1);
                maxinalSquare = (char)Math.Max(maxinalSquare, matrix[row][col]);
            }
        }

        //if (maxinalSquare == '0')
        //{

        //int i = 0;
        //while (i < matrix.Length && matrix[i][0] != '1') i++;
        //if (i < matrix.Length)
        //    maxinalSquare = '1';
        //else
        //{
        //    while (i < matrix[0].Length && matrix[0][i] != '1') i++;
        //    if (i < matrix[0].Length) maxinalSquare = '1';
        //}
        //}

        // If no ones has been found from second row end column, check if there is at least a one in the first row and column
        if (maxinalSquare == '0' && HasOneOnFirstRowAndColumn(matrix))
            return 1;

        int width = (maxinalSquare - '0');

        return width * width;
    }

    private static bool HasOneOnFirstRowAndColumn(char[][] matrix)
    {
        for (int row = 0; row < matrix.Length; row++)
            if (matrix[row][0] == '1')
                return true;
        for (int col = 0; col < matrix[0].Length; col++)
            if (matrix[0][col] == '1')
                return true;

        //for (int i = 0; i < Math.Max(matrix.Length, matrix[0].Length); i++)
        //    if ((i < matrix.Length && matrix[i][0] == '1') || (i < matrix[0].Length && matrix[0][i] == '1'))
        //        return true;

        return false;
    }

    public int MaximalSquare_CGPT(char[][] matrix)
    {
        if (matrix == null || matrix.Length == 0) return 0;

        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int maxSide = 0;

        // dp[i][j] = tamanho do maior quadrado terminando em (i,j)
        int[,] dp = new int[rows + 1, cols + 1];

        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= cols; j++)
            {
                if (matrix[i - 1][j - 1] == '1')
                {
                    dp[i, j] = Math.Min(
                        Math.Min(dp[i - 1, j], dp[i, j - 1]),
                        dp[i - 1, j - 1]
                    ) + 1;

                    maxSide = Math.Max(maxSide, dp[i, j]);
                }
            }
        }

        return maxSide * maxSide; // área do maior quadrado
    }

}
/*
Test cases:

char[][] matrix = [
    ['1', '0', '1', '0', '0'], 
    ['1', '0', '1', '1', '1'], 
    ['1', '1', '1', '1', '1'], 
    ['1', '0', '0', '1', '0']]; // Expected output: 4

matrix = [
    ['0','1'],['1','0']]; // Expected output: 1

matrix = [['0']];// Expected output: 0

*/
