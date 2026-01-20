namespace CodingChallenges.Matrix;

/// <summary>
/// Groups    : Matrix / 2D Array (2DArray), 
/// Title     : 130. Surrounded Regions
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/surrounded-regions
/// Approach  : DFS
/// </summary>
public class SurroundedRegions
{
    const char _notSurrounded = 'N';
    const char _region = 'O';
    const char _surrounded = 'X';

    // Leetcode: Beats 100.00% / 56.86%
    public static void Solve(char[][] board)
    {
        int rows = board.Length;
        int cols = board[0].Length;

        int leftBorderCol = 0;
        int rightBorderCol = cols - 1;
        for (int row = 0; row < rows; row++)
        {
            if (board[row][leftBorderCol] == _region)
                DFS(board, row, leftBorderCol);
            if (board[row][rightBorderCol] == _region)
                DFS(board, row, rightBorderCol);
        }
        int topBorderRow = 0;
        int bottonBorderRow = rows - 1;
        for (int col = 0; col < cols; col++)
        {
            if (board[topBorderRow][col] == _region)
                DFS(board, topBorderRow, col);
            if (board[bottonBorderRow][col] == _region)
                DFS(board, bottonBorderRow, col);
        }

        for (int row = 0; row < rows; row++)
            for (int col = 0; col < cols; col++)
                board[row][col] = board[row][col] == _notSurrounded ? _region : _surrounded;
    }

    private static void DFS(char[][] board, int row, int col)
    {
        int rows = board.Length;
        int cols = board[0].Length;

        if (row < 0 || col < 0 || row >= rows || col >= cols || board[row][col] != _region)
            return;

        board[row][col] = _notSurrounded;

        DFS(board, row - 1, col); // up
        DFS(board, row, col + 1); // right
        DFS(board, row + 1, col); // down
        DFS(board, row, col - 1); // left
    }
}
