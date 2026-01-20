namespace CodingChallenges.Matrix;

/// <summary>
/// Groups: Matrix
/// Title: 54. Spiral Matrix
/// Difficult: Medium
/// Link: https://leetcode.com/problems/spiral-matrix
/// Approach: 
/// </summary>
public class SpiralMatrix
{
    // Leetcode: Beats 100.00% / 20.52%
    public static List<int> SpiralOrder(int[][] matrix)
    {
        int m = matrix.Length;
        if (m == 1)
            return [.. matrix[0]];

        int n = matrix[0].Length;

        int limitTop = 0;
        int limitRight = n - 1;
        int limitBotton = m - 1;
        int limitLeft = 0;
        List<int> result = [];
        Directions currDirection = Directions.Right;
        int currRow = 0;
        int currColumn = -1;

        while (limitTop <= limitBotton && limitLeft <= limitRight)
        {
            switch (currDirection)
            {
                case Directions.Right:
                    while (currColumn < limitRight)
                    {
                        result.Add(matrix[currRow][++currColumn]);
                    }
                    limitTop++;
                    currDirection = Directions.Down;
                    break;
                case Directions.Down:
                    while (currRow < limitBotton)
                    {
                        result.Add(matrix[++currRow][currColumn]);
                    }
                    limitRight--;
                    currDirection = Directions.Left;
                    break;
                case Directions.Left:
                    while (currColumn > limitLeft)
                    {
                        result.Add(matrix[currRow][--currColumn]);
                    }
                    limitBotton--;
                    currDirection = Directions.Up;
                    break;
                case Directions.Up:
                    while (currRow > limitTop)
                    {
                        result.Add(matrix[--currRow][currColumn]);
                    }
                    limitLeft++;
                    currDirection = Directions.Right;
                    break;
            }
        }

        return result;
    }

    public enum Directions
    {
        Left,
        Down,
        Right,
        Up
    }
}
