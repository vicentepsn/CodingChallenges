
namespace CodingChallenges.Matrix;

/// <summary>
/// Groups    : Binary Search, Matrix
/// Title     : 74. Search a 2D Matrix
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/search-a-2d-matrix
/// Approachs : Binary Search
/// </summary>
public class SearchA2DMatrix
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int maxSequentialPosition = rows * cols - 1;

        int left = 0;
        int right = maxSequentialPosition;

        while (left <= right)
        {
            int sequentialMidle = (left + right) / 2;

            (int row, int col) = SequentialToMatrixPoint(sequentialMidle, cols);

            if (matrix[row][col] == target)
                return true;
            else if (matrix[row][col] < target)
                left = sequentialMidle + 1;
            else
                right = sequentialMidle - 1;
        }

        return false;
    }

    private static (int row, int col) SequentialToMatrixPoint(int sequentialIdx, int cols)
        => (sequentialIdx / cols, sequentialIdx % cols);
}
