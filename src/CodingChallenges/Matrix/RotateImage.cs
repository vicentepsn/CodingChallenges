namespace CodingChallenges.Matrix;

/// <summary>
/// Groups: Matrix
/// Title: 48. Rotate Image
/// Difficult: Medium
/// Link: https://leetcode.com/problems/rotate-image
/// Approach: 
/// </summary>
public class RotateImage
{
    // Leetcode: Beats 100% / 50.08% (89.38% se não usar variáveis starRow/Column and row/column
    public static void Rotate(int[][] matrix)
    {
        int n = matrix.Length;
        int totalLevels = n / 2;
        for (int level = 0; level < totalLevels; level++)
        {
            int limit = n - level - 1;
            for (int i = 0; i < limit - level; i++)
            {
                int startRow = level;
                int startColumn = level + i;
                int movingValue = matrix[startRow][startColumn];

                int row = level + i;
                int column = limit;
                int temp = matrix[row][column];
                matrix[row][column] = movingValue;
                movingValue = temp;

                row = limit;
                column = limit - i;
                temp = matrix[row][column];
                matrix[row][column] = movingValue;
                movingValue = temp;

                row = limit - i;
                column = level;
                temp = matrix[row][column];
                matrix[row][column] = movingValue;

                matrix[startRow][startColumn] = temp;
            }
        }
    }

    // Identica à de cima, porém sem usar variáveis starRow/Column and row/column
    // Leetcode: Beats 100% / 89.38%
    public static void Rotate_(int[][] matrix)
    {
        for (int level = 0; level < matrix.Length / 2; level++)
        {
            int limit = matrix.Length - level - 1;
            for (int i = 0; i < limit - level; i++)
            {
                int temp1 = matrix[level + i][limit];
                matrix[level + i][limit] = matrix[level][level + i];
                int temp2 = temp1;

                temp1 = matrix[limit][limit - i];
                matrix[limit][limit - i] = temp2;
                temp2 = temp1;

                temp1 = matrix[limit - i][level];
                matrix[limit - i][level] = temp2;

                matrix[level][level + i] = temp1;
            }
        }
    }

    // Leetcode: Beats 100% / 79.06%
    public void Rotate_CGPT(int[][] matrix)
    {
        int n = matrix.Length;

        // 1. Transpose the matrix (swap rows and columns)
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int temp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = temp;
            }
        }

        // 2. Reverse each row (to complete the 90° rotation)
        for (int i = 0; i < n; i++)
        {
            Array.Reverse(matrix[i]);
        }
    }

    public static int[][] RotateNonSquare(int[][] matrix)
    {
        int n = matrix.Length;
        int m = matrix[0].Length;

        int[][] result = new int[m][];
        for (int i = 0; i < m; i++)
            result[i] = new int[n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                result[j][n - 1 - i] = matrix[i][j];

        return result;
    }

    public static int[][] RotateNonSquare_v2(int[][] matrix)
    {
        int n = matrix.Length;
        int m = matrix[0].Length;

        int[][] result = new int[m][];
        for (int i = 0; i < m; i++)
            result[i] = new int[n];

        // 1. Transpose the matrix (swap rows and columns)
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                result[j][i] = matrix[i][j];

        // 2. Reverse each row (to complete the 90° rotation)
        for (int i = 0; i < m; i++)
            Array.Reverse(result[i]);

        return result;
    }


}
