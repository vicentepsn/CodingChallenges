using System;
using System.Text;

namespace CodingChallenges.Matrix
{

    /// <summary>
    /// Related   : Array, Dynamic Programming, Depth-First Search, Breadth-First Search, Graph, Topological Sort, Memoization, Matrix
    /// Title     : 2328. Number of Increasing Paths in a Grid
    /// Difficult : Hard
    /// Link      : https://leetcode.com/problems/number-of-increasing-paths-in-a-grid/description/
    /// Companies : Microsoft (my test 2023-04-05)
    /// Descript. : Given a matrix of integers, find the number of strictly increasing paths that can be taken
    ///             to travel from any cell to any other cell using only adjacent cells in all four directions.
    ///             The answer should be returned modulo 10^9 + 7 to avoid very large values. Note that two
    ///             paths are considered different if they do not have the same sequence of visited cells.
    /// </summary>
    public static class NumberIncreasingPathsClass
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

        public static int CountPaths(int[][] grid)
        {
            int result = 0;
            int moduleOf = (int)Math.Pow(10, 9) + 7;

            MatrixElement[] matrixElements = new MatrixElement[grid.Length * grid[0].Length];
            int idx = 0;

            for (int row = 0; row < grid.Length; row++)
                for (int col = 0; col < grid[row].Length; col++)
                    matrixElements[idx++] = new MatrixElement(grid[row][col], row, col);

            Array.Sort(matrixElements);
            int[,] paths = new int[grid.Length, grid[0].Length];

            for (int i = matrixElements.Length - 1; i >= 0; i--)
            {
                var element = matrixElements[i];
                int row = element.Row;
                int col = element.Col;

                foreach (var direction in directions)
                {
                    int nextRow = row + direction[0];
                    int nextCol = col + direction[1];
                    if (nextRow >= 0 && nextRow < grid.Length &&
                        nextCol >= 0 && nextCol < grid[0].Length &&
                        grid[row][col] > grid[nextRow][nextCol])
                    {
                        paths[nextRow, nextCol] = (paths[nextRow, nextCol] + paths[row, col] + 1) % moduleOf;
                    }
                }
            }

            for (int row = 0; row < grid.Length; row++)
                for (int col = 0; col < grid[row].Length; col++)
                    result = (result + paths[row, col]) % moduleOf;

            return (result + matrixElements.Length) % moduleOf;
        }




        static int counter;

        public static int NumberIncreasingPaths_Old(int[][] matrix)
        {
            int result = 0;
            int moduleOf = (int)Math.Pow(10, 9) + 7;

            counter = 0;

            MatrixElement[] matrixElements = new MatrixElement[matrix.Length * matrix[0].Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    result = (1 + result + numberIncreasingPaths(matrix, i, j)) % moduleOf;
                }
            }

            return result;
        }

        private static int numberIncreasingPaths(int[][] matrix, int i, int j)
        {
            counter++;
            int result = 0;
            int moduleOf = 10 ^ 9 + 7;
            var value = matrix[i][j];

            if (i > 0)
            {
                var next = matrix[i - 1][j];
                if (value < next)
                    result = (1 + result + numberIncreasingPaths(matrix, i - 1, j)) % moduleOf;
            }
            if (i < matrix.Length - 1)
            {
                var next = matrix[i + 1][j];
                if (value < next)
                    result = (1 + result + numberIncreasingPaths(matrix, i + 1, j)) % moduleOf;
            }
            if (j > 0)
            {
                var next = matrix[i][j - 1];
                if (value < next)
                    result = (1 + result + numberIncreasingPaths(matrix, i, j - 1)) % moduleOf;
            }
            if (j < matrix[i].Length - 1)
            {
                var next = matrix[i][j + 1];
                if (value < next)
                    result = (1 + result + numberIncreasingPaths(matrix, i, j + 1)) % moduleOf;
            }

            return result;
        }
    }
}
