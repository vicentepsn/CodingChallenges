using System.Collections.Generic;

namespace CodingChallenges.Matrix
{
    /// <summary>
    /// Groups    : Matrix / 2D Array (2DArray), 
    /// Title     : 200. Number of Islands
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/number-of-islands/
    /// Approach  : BFS (Breadth First Search)
    /// </summary>
    public class NumberOfIslands
    {
        int[][] directions =
        {
            new int[]{-1,0}, // up
            new int[]{0,1},  // right
            new int[]{1,0},  // down
            new int[]{0,-1}  // left
        };

        // udemy solution with BFS
        // Complexity: T: O(M x N) / S: O(max(M,N))
        //
        // For DFS soluction (see: https://replit.com/@ZhangMYihua/Number-of-Islands-DFS#index.js), complexity: T: O(M x N) / S: O(M x N)
        public int NumIslands(char[][] grid)
        {
            var inLand = new Queue<int[]>();

            const char land = '1';
            const char water = '0';

            var numIslands = 0;

            for(int row = 0; row < grid.Length; row++)
            {
                for(int col = 0; col < grid[row].Length; col++)
                {
                    if(grid[row][col] == land)
                    {
                        numIslands++;
                        inLand.Enqueue(new int[] { row, col });
                        grid[row][col] = water;

                        while (inLand.Count > 0)
                        {
                            var currentLand = inLand.Dequeue();
                            foreach (var direction in directions)
                            {
                                int rowAdj = currentLand[0] + direction[0];
                                int colAdj = currentLand[1] + direction[1];
                                if ((!isValidPosition(grid, rowAdj, colAdj)) || grid[rowAdj][colAdj] == water)
                                    continue;

                                if (grid[rowAdj][colAdj] == land)
                                    inLand.Enqueue(new int[] { rowAdj, colAdj });

                                grid[rowAdj][colAdj] = water;
                            }
                        }
                    }
                }
            }

            return numIslands;
        }

        public int NumIslands_MySolution(char[][] grid)
        {
            var seen = new bool[grid.Length, grid[0].Length];
            var inLand = new Queue<int[]>();
            var inWater = new Queue<int[]>();

            const char land = '1';
            const char water = '0';

            var numIslands = 0;

            if (grid[0][0] == land)
            {
                inLand.Enqueue(new int[] { 0, 0 });
                numIslands++;
            }
            else
                inWater.Enqueue(new int[] { 0, 0 });

            seen[0, 0] = true;

            while (inLand.Count > 0 || inWater.Count > 0)
            {
                if (inLand.Count > 0)
                {
                    var currentLand = inLand.Dequeue();
                    foreach (var direction in directions)
                    {
                        int row = currentLand[0] + direction[0];
                        int col = currentLand[1] + direction[1];
                        if ((!isValidPosition(grid, row, col)) || seen[row, col])
                            continue;

                        if (grid[row][col] == land)
                            inLand.Enqueue(new int[] { row, col });
                        else
                            inWater.Enqueue(new int[] { row, col });

                        seen[row, col] = true;
                    }
                }
                else
                {
                    var currentWater = inWater.Dequeue();
                    foreach (var direction in directions)
                    {
                        int row = currentWater[0] + direction[0];
                        int col = currentWater[1] + direction[1];
                        if ((!isValidPosition(grid, row, col)) || seen[row, col])
                            continue;

                        seen[row, col] = true;

                        if (grid[row][col] == land)
                        {
                            inLand.Enqueue(new int[] { row, col });
                            numIslands++;
                            break;
                        }
                        else
                            inWater.Enqueue(new int[] { row, col });
                    }
                }
            }

            return numIslands;
        }

        private bool isValidPosition(char[][] grid, int row, int col)
            => row >= 0 && col >= 0 && row < grid.Length && col < grid[0].Length;
    }
}
