namespace CodingChallenges.Matrix;

// Amazon interview Live Coding (Code Quality) 2025-12-12
// Descrição no projeto de entrevistas
public class MaxMoves
{
    private static readonly char _initialPositionSimbol = 'R';
    private static readonly char _blockSimbol = 'X';
    private static readonly int _invalidRowOrColumn = -1;

    private static readonly MatrixPosition[] _directions =
    {
        new(row: -1, column:  0),  // up
        new(row: -1, column:  1),  // up-right
        new(row:  0, column:  1),  // right
        new(row:  1, column:  1),  // right-down
        new(row:  1, column:  0),  // down
        new(row:  1, column: -1),  // down-left
        new(row:  0, column: -1),  // left
        new(row: -1, column: -1)   // left-up
    };


    public static int CountPossibleMovements(char[][] movementMatrix)
    {
        if (movementMatrix.Length == 0
            || (movementMatrix.Length > 0 && movementMatrix[0].Length == 0))
            return 0;

        int rowsCount = movementMatrix.Length;
        int columnsCount = movementMatrix[0].Length;

        (int startRow, int startColumn) = GetInitialPosition(movementMatrix);

        if (startRow == _invalidRowOrColumn)
            throw new ArgumentException("No initial position informed");

        int movementCount = 0;
        foreach (var direction in _directions)
        {
            int currRow = startRow + direction.Row;
            int currColumn = startColumn + direction.Column;

            while (currRow >= 0 && currRow < rowsCount
            && currColumn >= 0 && currColumn < columnsCount
            && movementMatrix[currRow][currColumn] != _blockSimbol)
            {
                movementCount++;
                currRow += direction.Row;
                currColumn += direction.Column;
            }
        }

        return movementCount;
    }

    private static (int Row, int Column) GetInitialPosition(char[][] movementMatrix)
    {
        for (int row = 0; row < movementMatrix.Length; row++)
        {
            for (int column = 0; column < movementMatrix[row].Length; column++)
            {
                if (movementMatrix[row][column] == _initialPositionSimbol)
                    return (row, column);
            }
        }

        return (_invalidRowOrColumn, _invalidRowOrColumn);
    }
}

public struct MatrixPosition(int row, int column)
{
    public int Row = row;
    public int Column = column;
}
