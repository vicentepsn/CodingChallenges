namespace CodingChallenges.Matrix;

// Amazon interview Live Coding (Code Quality) 2025-12-12
// Descrição no projeto de entrevistas
public class MaxMoves
{
    private const char _initialPositionSimbol = 'R';
    private const char _blockSimbol = 'X';
    private const int _invalidRowOrColumn = -1;

    private static readonly Point[] _directions =
    {
        new(row: -1, col:  0),  // up
        new(row: -1, col:  1),  // up-right
        new(row:  0, col:  1),  // right
        new(row:  1, col:  1),  // right-down
        new(row:  1, col:  0),  // down
        new(row:  1, col: -1),  // down-left
        new(row:  0, col: -1),  // left
        new(row: -1, col: -1)   // left-up
    };


    public static int CountPossibleMovements(char[][] movementMatrix)
    {
        if (movementMatrix.Length == 0
            || (movementMatrix.Length > 0 && movementMatrix[0].Length == 0))
            return 0;

        int rowsCount = movementMatrix.Length;
        int columnsCount = movementMatrix[0].Length;

        var startPoint = GetInitialPosition(movementMatrix);

        // Começar com variáveis e depois mudar para Point
        if (startPoint.Row == _invalidRowOrColumn)
            throw new ArgumentException("No initial position informed");

        int movementCount = 0;
        foreach (var direction in _directions)
        {
            // alterar para Point
            int currRow = startPoint.Row + direction.Row;
            int currColumn = startPoint.Col + direction.Col;

            while (currRow >= 0 && currRow < rowsCount
            && currColumn >= 0 && currColumn < columnsCount
            && movementMatrix[currRow][currColumn] != _blockSimbol)
            {
                movementCount++;
                currRow += direction.Row;
                currColumn += direction.Col;
            }
        }
        
        return movementCount;
    }

    private static Point GetInitialPosition(char[][] movementMatrix)
    {
        for (int row = 0; row < movementMatrix.Length; row++)
        {
            for (int column = 0; column < movementMatrix[row].Length; column++)
            {
                if (movementMatrix[row][column] == _initialPositionSimbol)
                    return new(row, column);
            }
        }

        return new(_invalidRowOrColumn, _invalidRowOrColumn);
    }
}

/// <param name="col">The Column index of the new Point</param>
public struct Point(int row, int col)
{
    public int Row = row;
    /// <summary>
    /// The column index of the Point.
    /// </summary>
    public int Col = col;
}
