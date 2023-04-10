using System;

namespace CodingChallenges.Matrix
{
    /// <summary>
    /// Related   : Array, Dynamic Programming, Depth-First Search, Breadth-First Search, Graph, Topological Sort, Memoization, Matrix
    /// Title     : 329. Longest Increasing Path in a Matrix
    /// Difficult : Hard
    /// Link      : https://leetcode.com/problems/longest-increasing-path-in-a-matrix/
    /// Companies : ??
    /// </summary>
    public static class LongestIncreasingPathClass
    {
        private class MatrixElement : IComparable<MatrixElement>
        {
            public MatrixElement(int value, int row, int col)
            {
                Value = value;
                Row = row;
                Col = col;
            }
            public int Value;
            public int Row;
            public int Col;

            public int CompareTo(MatrixElement other) => this.Value.CompareTo(other.Value);
        }

        private static int[][] directions =
        {
            new int[]{-1,0}, // up
            new int[]{0,1},  // right
            new int[]{1,0},  // down
            new int[]{0,-1}  // left
        };

        public static int LongestIncreasingPath(int[][] matrix)
        {
            int result = 1;
            MatrixElement[] matrixElements = new MatrixElement[matrix.Length * matrix[0].Length];
            int idx = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrixElements[idx] = new MatrixElement(matrix[row][col], row, col);
                    idx++;
                }
            }

            Array.Sort(matrixElements);
            int[,] pathPositions = new int[matrix.Length, matrix[0].Length];

            foreach (var element in matrixElements)
            {
                int row = element.Row;
                int col = element.Col;

                if (pathPositions[row, col] == 0)
                    pathPositions[row, col] = 1;

                foreach (var direction in directions)
                {
                    int nextRow = row + direction[0];
                    int nextCol = col + direction[1];
                    if (nextRow >= 0 && nextRow < matrix.Length &&
                        nextCol >= 0 && nextCol < matrix[0].Length &&
                        matrix[row][col] < matrix[nextRow][nextCol])
                    {
                        if (pathPositions[row, col] >= pathPositions[nextRow, nextCol])
                        {
                            pathPositions[nextRow, nextCol] = pathPositions[row, col] + 1;
                            result = Math.Max(result, pathPositions[nextRow, nextCol]);
                        }
                    }
                }
            }

            return result;
        }

        //private static int LongestIncreasingPath(int[][] matrix, int i, int j)
        //{
        //    int result = 1;
        //    int longestFromNext = 0;

        //    foreach (var direction in directions)
        //    {
        //        int nextI = i + direction[0];
        //        int nextJ = j + direction[1];
        //        if (nextI >= 0 && nextI < matrix.Length &&
        //            nextJ >= 0 && nextJ < matrix[0].Length &&
        //            matrix[i][j] < matrix[nextI][nextJ])
        //        {
        //            longestFromNext = Math.Max(longestFromNext, LongestIncreasingPath(matrix, nextI, nextJ));
        //        }
        //    }

        //    return result + longestFromNext;
        //}

    }
}
