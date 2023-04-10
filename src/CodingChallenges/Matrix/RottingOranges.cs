using System.Collections.Generic;

namespace CodingChallenges.Matrix
{
    /// <summary>
    /// Groups    : Matrix / 2D Array (2DArray), 
    /// Title     : 994. Rotting Oranges
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/rotting-oranges/
    /// Approach  : BFS (Breadth First Search)
    /// Complexity: T/S: O(N) or O(NxM)
    /// </summary>
    public class RottingOranges
    {
        int[][] directions =
        {
            new int[]{-1,0}, // up
            new int[]{0,1},  // right
            new int[]{1,0},  // down
            new int[]{0,-1}  // left
        };

        public int OrangesRotting(int[][] grid)
        {
            const int Empty = 0;
            const int FreshOrange = 1;
            const int RottenOrange = 2;

            var totalMinutes = 0;

            var rottenOranges = new Queue<int[]>();
            var freshOrangesCount = 0;

            // O(N)
            for(int i = 0; i < grid.Length; i++)
            {
                for(int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == RottenOrange)
                        rottenOranges.Enqueue(new int[] { i, j });
                    else if (grid[i][j] == FreshOrange)
                        freshOrangesCount++;
                }
            }

            int numRottenOranges = rottenOranges.Count;
            int rottenOrangesCount = 0;
            while(rottenOranges.Count > 0)
            {
                var currentRotten = rottenOranges.Dequeue();

                foreach(var direction in directions)
                {
                    int row = currentRotten[0] + direction[0];
                    int col = currentRotten[1] + direction[1];

                    if ((!isValidPosition(grid, row, col)))
                        continue;

                    if (grid[row][col] == FreshOrange)
                    {
                        rottenOranges.Enqueue(new int[] { row, col });
                        grid[row][col] = RottenOrange;
                        freshOrangesCount--;
                    }
                }

                rottenOrangesCount++;
                if(rottenOrangesCount == numRottenOranges)
                {
                    rottenOrangesCount = 0;
                    numRottenOranges = rottenOranges.Count;

                    if (numRottenOranges > 0)
                        totalMinutes++;
                }
            }

            return freshOrangesCount == 0 ? totalMinutes : -1;
        }

        private bool isValidPosition(int[][] grid, int row, int col)
            => row >= 0 && col >= 0 && row < grid.Length && col < grid[0].Length;

    }
}
