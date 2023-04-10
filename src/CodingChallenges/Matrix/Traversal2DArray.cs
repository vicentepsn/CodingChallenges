using System.Collections.Generic;

namespace CodingChallenges.Matrix
{
    /// <summary>
    /// udemy course: Master the Coding Interview: Big Tech (FAANG) Interviews
    /// Section 23: Intro to 2D-Arrays - Basics & Traversal Algorithms
    /// </summary>
    public class Traversal2DArray
    {
        // Example (used on unit test)
        //int[,] testMatrix = {
        //  {  1,  2,  3,  4,  5 },
        //  {  6,  7,  8,  9, 10 },
        //  { 11, 12, 13, 14, 15 },
        //  { 16, 17, 18, 19, 20 } 
        //};
        //
        // DFS result => { 1, 2, 3, 4, 5, 10, 15, 20, 19, 14, 9, 8, 13, 18, 17, 12, 7, 6, 11, 16 }
        //
        // BFS result => { 1, 2, 6, 3, 7, 11, 4, 8, 12, 16, 5, 9, 13, 17, 10, 14, 18, 15, 19, 20 }
        // (start in [2,2]) => { 13, 8, 14, 18, 12, 3, 9, 7, 15, 19, 17, 11, 4, 2, 10, 6, 20, 16, 5, 1 }

        int[,] directions = {
          {-1, 0}, //up
          {0, 1}, //right
          {1, 0}, //down
          {0, -1} //left
        };

        // Complexity: T/S: O(N)
        public List<int> TraversalDFS(int [,] matrix) {
            bool[,] seen = new bool[matrix.GetLength(0), matrix.GetLength(1)];

            var values = new List<int>(matrix.GetLength(0) * matrix.GetLength(1));

            dfs(matrix, 0, 0, seen, values);

            return values;
        }

        private void dfs(int[,] matrix, int row, int col, bool[,] seen, List<int> values)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1) || seen[row, col])
                return;

            seen[row, col] = true;
            values.Add(matrix[row, col]);

            for (var dirIdx = 0; dirIdx < directions.GetLength(0); dirIdx++)
                dfs(matrix, row + directions[dirIdx, 0], col + directions[dirIdx, 1], seen, values);
        }

        // Complexity: T/S: O(N)
        public List<int> TraversalBFS(int[,] matrix, int initialRow = 0, int initialCol = 0) {
            bool[,] seen = new bool[matrix.GetLength(0), matrix.GetLength(1)];

            var values = new List<int>(matrix.GetLength(0) * matrix.GetLength(1));

            var queue = new Queue<int[]>();
            queue.Enqueue(new int[]{ initialRow, initialCol });

            while (queue.Count > 0)
            {
                var currentPos = queue.Dequeue();
                var row = currentPos[0];
                var col = currentPos[1];

                if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1) || seen[row, col])
                    continue;

                seen[row, col] = true;
                values.Add(matrix[row, col]);

                for (var dirIdx = 0; dirIdx < directions.GetLength(0); dirIdx++)
                    queue.Enqueue(new int[] { row + directions[dirIdx, 0], col + directions[dirIdx, 1] });
            }

            return values;
        }
    }
}
