namespace CodingChallenges.Matrix;

public class WaterFlowClass
{
    // r c => O(row * col) / O(row * col)
    public static int[][] WaterFlow(int[][] heighMap)
    {
        int[][] result = new int[heighMap.Length][];
        bool[][] seen = new bool[heighMap.Length][]; // initialized with false

        for (int i = 0; i < heighMap.Length; i++)
        {
            result[i] = new int[heighMap[0].Length]; // initialized with 0
            seen[i] = new bool[heighMap[0].Length]; // initialized with false
        }

        for (int row = 0; row < heighMap.Length; row++)
        {
            for (int col = 0; col < heighMap[0].Length; col++)
            {
                if (seen[row][col])
                    continue;

                seen[row][col] = true;
                result[row][col] = GetMinHeight(heighMap, row, col, result, seen);
            }
        }

        return result;
    }

    private static readonly int[][] directions = [
      [-1, 0],
      [0, 1],
      [1,0],
      [0,-1]];

    private static int GetMinHeight(int[][] heighMap, int row, int col, int[][] result, bool[][] seen)
    {
        int nextRow = row, nextCol = col;
        int minHeight = heighMap[row][col];

        foreach (var direction in directions)
        {
            int currRow = row + direction[0];
            int currCol = col + direction[1];

            if (currRow >= 0 && currRow < heighMap.Length && currCol >= 0 && currCol < heighMap[0].Length)
            {
                if (heighMap[currRow][currCol] < minHeight)
                {
                    minHeight = heighMap[currRow][currCol]; // <= fixed (added)
                    nextRow = currRow;
                    nextCol = currCol;
                }
            }
        }

        if (nextRow == row && nextCol == col)
            return heighMap[row][col];

        if (seen[nextRow][nextCol])
            return result[nextRow][nextCol]; // <= fixed (before was "minHeight[nextRow][nextRow];")

        return GetMinHeight(heighMap, nextRow, nextCol, result, seen);
    }
}
