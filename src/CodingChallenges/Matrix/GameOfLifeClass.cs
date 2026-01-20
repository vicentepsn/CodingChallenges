namespace CodingChallenges.Matrix;

/// <summary>
/// Related   : Matrix
/// Title     : 289. Game of Life
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/game-of-life
/// Approachs : -
/// </summary>
public class GameOfLifeClass
{
    private static readonly Position[] Directions = [
        new (row: -1, col: 0), // up
        new (row: -1, col: 1), // up/right
        new (row: 0, col: 1), // right
        new (row: 1, col: 1), // right/dow
        new (row: 1, col: 0), // donw
        new (row: 1, col: -1), // donw/left
        new (row: 0, col: -1), // left
        new (row: -1, col: -1), // lert/up
    ];

    private static readonly int _minNeighborsToKeepAlive = 2;
    private static readonly int _maxNeighborsToKeepAlive = 3;
    private static readonly int _numNeighborsToBecomeAlive = 3;

    // Solução in-place
    // Leetcode: Beats 100.00% / 90.26%
    public static void GameOfLife(int[][] board)
    {
        int nRows = board.Length;
        int nCols = board[0].Length;
        for (int row = 0; row < nRows; row++)
        {
            for (int col = 0; col < nCols; col++)
            {
                int livingCount = 0;
                foreach (var direction in Directions)
                {
                    Position neighborPosition = new(row: row + direction.Row, col: col + direction.Col);

                    if (IsValidPosition(neighborPosition, nRows, nCols) && IsAliveInInitialState(board[neighborPosition.Row][neighborPosition.Col]))
                        livingCount++;
                }

                if (board[row][col] == LivingState.Alive)
                {
                    if (livingCount < _minNeighborsToKeepAlive || livingCount > _maxNeighborsToKeepAlive)
                        board[row][col] = LivingState.TurningDead;
                }
                else // board[row][col] == LivingState.Dead
                    if (livingCount == _numNeighborsToBecomeAlive)
                        board[row][col] = LivingState.TurningAlive;
            }
        }

        // Consolida dos estados de transição para estados finais
        for (int row = 0; row < nRows; row++)
        {
            for (int col = 0; col < nCols; col++)
            {
                if (board[row][col] == LivingState.TurningAlive)
                    board[row][col] = LivingState.Alive;
                else if (board[row][col] == LivingState.TurningDead)
                    board[row][col] = LivingState.Dead;
            }
        }
    }

    private static bool IsAliveInInitialState(int livingState)
        => livingState == LivingState.Alive || livingState == LivingState.TurningDead;

    private static bool IsValidPosition(Position position, int nRows, int nCols)
        => position.Row >= 0 && position.Row < nRows && position.Col >= 0 && position.Col < nCols;

    private class LivingState
    {
        public static int Dead = 0;
        public static int Alive = 1;
        public static int TurningDead = 2;
        public static int TurningAlive = 3;
    }

    private struct Position(int row, int col)
    {
        public int Row = row;
        public int Col = col;
    }
}
