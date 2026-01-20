namespace CodingChallenges.Matrix;

/// <summary>
/// Groups: Matrix
/// Title: 36. Valid Sudoku
/// Difficult: Hard
/// Link: https://leetcode.com/problems/valid-sudoku
/// Approach: 
/// </summary>
public class ValidSudoku
{
    // Leetcode: Beats 96.68% / 85.59%
    public static bool IsValidSudoku(char[][] board)
    {
        for (int row = 0; row < 9; row++)
        {
            bool[] seen = new bool[9];
            for (int column = 0; column < 9; column++)
            {
                if (board[row][column] == '.')
                    continue;

                int seenIdx = board[row][column] - '1';
                if (seen[seenIdx])
                    return false;

                seen[seenIdx] = true;
            }
        }

        for (int column = 0; column < 9; column++)
        {
            bool[] seen = new bool[9];
            for (int row = 0; row < 9; row++)
            {
                if (board[row][column] == '.')
                    continue;

                int seenIdx = board[row][column] - '1';
                if (seen[seenIdx])
                    return false;

                seen[seenIdx] = true;
            }
        }

        for (int blockRow = 0; blockRow < 3; blockRow++)
        {
            for (int blockColunm = 0; blockColunm < 3; blockColunm++)
            {
                int startRow = blockRow * 3;
                int startColumn = blockColunm * 3;
                bool[] seen = new bool[9];
                for (int rowInBlock = 0; rowInBlock < 3; rowInBlock++)
                {
                    for (int columnInBlock = 0; columnInBlock < 3; columnInBlock++)
                    {
                        int row = startRow + rowInBlock;
                        int column = startColumn + columnInBlock;
                        if (board[row][column] == '.')
                            continue;

                        int seenIdx = board[row][column] - '1';
                        if (seen[seenIdx])
                            return false;

                        seen[seenIdx] = true;
                    }
                }
            }
        }

        return true;
    }
}
