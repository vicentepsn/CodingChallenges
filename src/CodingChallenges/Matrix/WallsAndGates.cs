using System.Collections.Generic;

namespace CodingChallenges.Matrix
{
    /// <summary>
    /// Groups    : Matrix / 2D Array (2DArray), 
    /// Difficult : Medium
    /// Approach  : BFS (Breadth First Search), DFS (Depth First Serch)
    /// Complexity: BFS or DFS: T/S: O(N)
    /// == Leetcode ==
    /// Title     : XXX. Walls and Gates (Need premium access)
    /// Link      : https://leetcode.com/problems/walls-and-gates/
    /// == udemy ==
    /// Section   : 2D-Arrays - Question #22 - Walls And Gates (Medium)
    /// Link      : https://www.udemy.com/course/master-the-coding-interview-big-tech-faang-interviews/learn/lecture/22433906#overview
    /// </summary>
    public class WallsAndGates
    {
        int[][] directions =
        {
            new int[]{-1,0}, // up
            new int[]{0,1},  // right
            new int[]{1,0},  // down
            new int[]{0,-1}  // left
        };

        const int Wall = -1;
        const int Gate = 0;

        public int[][] OrangesRotting(int[][] grid)
        {
            var queue = new Queue<int[]>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == Gate)
                        queue.Enqueue(new int[] { i, j });
                }
            }

            int numInQueue = queue.Count;
            int queueCount = 0;
            int step = 1;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                foreach (var direction in directions)
                {
                    int row = current[0] + direction[0];
                    int col = current[1] + direction[1];

                    if (isValidPosition(grid, row, col)
                        && grid[row][col] > step)
                    {
                        queue.Enqueue(new int[] { row, col });
                        grid[row][col] = step;
                    }
                }

                queueCount++;
                if (queueCount == numInQueue)
                {
                    queueCount = 0;
                    numInQueue = queue.Count;

                    step++;
                }
            }

            return grid;
        }

        public int[][] OrangesRotting_DFS(int[][] grid)
        {
            var queue = new Queue<int[]>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == Gate)
                        queue.Enqueue(new int[] { i, j });
                }
            }

            int step = 1;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                foreach (var direction in directions)
                {
                    int row = current[0] + direction[0];
                    int col = current[1] + direction[1];

                    dfs(grid, row, col, step);
                }
            }

            return grid;
        }

        private void dfs(int[][] grid, int row, int col, int currentStep)
        {
            if(!isValidPosition(grid, row, col) || currentStep > grid[row][col])
                return;

            grid[row][col] = currentStep;

            foreach (var direction in directions)
            {
                int nextRow = row + direction[0];
                int nextCol = col + direction[1];

                dfs(grid, nextRow, nextCol, currentStep + 1);
            }
        }

        private bool isValidPosition(int[][] grid, int row, int col)
            => row >= 0 && col >= 0 && row < grid.Length && col < grid[0].Length;


    }
}
