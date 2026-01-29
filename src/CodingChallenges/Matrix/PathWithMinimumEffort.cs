namespace CodingChallenges.Matrix;

/// <summary>
/// Groups    : Matrix, "Graph", Priority Queue
/// Title     : 1631. Path With Minimum Effort
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/path-with-minimum-effort
/// Approach  : Dijkstra
/// Complexity: T: 2N + E + E.log N + N.log N => E.log N  /  S: O(E + N)
/// </summary>
public class PathWithMinimumEffort
{
    private static (int row, int col)[] directions = [
        new (-1,0), new (0,1), new (1,0), new (0,-1)
    ];
    // Leetcode: Beats 94.59% / 77.03%
    public static int MinimumEffortPath(int[][] heights)
    {
        int rows = heights.Length, cols = heights[0].Length;
        int[,] maxDiff = new int[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                maxDiff[i, j] = int.MaxValue;

        maxDiff[0, 0] = 0;
        PriorityQueue<(int row, int col), int> queue = new();

        queue.Enqueue(new(0, 0), 0);

        while (queue.Count > 0)
        {
            var (row, col) = queue.Dequeue();

            if (row == rows - 1 && col == cols - 1)
                return maxDiff[row, col];

            foreach (var (dRow, dCol) in directions)
            {
                int newRow = row + dRow;
                int newCol = col + dCol;

                if (newRow >= 0 && newCol >= 0 && newRow < rows && newCol < cols)
                {
                    int diff = Math.Max(maxDiff[row, col], Math.Abs(heights[row][col] - heights[newRow][newCol]));
                    if (diff < maxDiff[newRow, newCol])
                    {
                        maxDiff[newRow, newCol] = diff;
                        queue.Enqueue(new(newRow, newCol), diff);
                    }
                }
            }
        }

        throw new Exception("Something is wrong!");
    }
}
