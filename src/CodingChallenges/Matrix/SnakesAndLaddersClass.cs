namespace CodingChallenges.Matrix;

/// <summary>
/// Related   : Matrix, Breadth-First Search
/// Title     : 909. Snakes and Ladders
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/snakes-and-ladders
/// Approachs : Breadth-First Search
/// </summary>
public class SnakesAndLaddersClass
{
    public int SnakesAndLadders(int[][] board) // versão do ChatGPT, usa BFS
    {
        int n = board.Length;
        int target = n * n;

        // Função para converter número da casa em coordenadas (linha, coluna)
        (int r, int c) GetCoordinates(int square)
        {
            int quot = (square - 1) / n;
            int rem = (square - 1) % n;
            int row = n - 1 - quot;
            int col = (quot % 2 == 0) ? rem : (n - 1 - rem);
            return (row, col);
        }

        Queue<int> queue = new Queue<int>();
        HashSet<int> visited = new HashSet<int>();

        queue.Enqueue(1);
        visited.Add(1);
        int moves = 0;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                int curr = queue.Dequeue();
                if (curr == target) return moves;

                for (int dice = 1; dice <= 6; dice++)
                {
                    int next = curr + dice;
                    if (next > target) break;

                    var (r, c) = GetCoordinates(next);
                    if (board[r][c] != -1)
                    {
                        next = board[r][c]; // aplica snake ou ladder
                    }

                    if (!visited.Contains(next))
                    {
                        visited.Add(next);
                        queue.Enqueue(next);
                    }
                }
            }
            moves++;
        }

        return -1;
    }

    // NÃO FUNCIONA para o test case 216 de 217.. Desisti
    int[] seen;
    int n;
    int result;
    int destinationPoint;
    bool destinationPointReached;
    const int MaxDiceValue = 6;
    const int MinDiceValue = 1;

    public int SnakesAndLadders_DFS(int[][] board)
    {
        n = board.Length;
        destinationPoint = n * n;
        result = (destinationPoint - 1) / MaxDiceValue + 1;
        seen = new int[n * n];
        destinationPointReached = false;

        for (int i = 1; i < seen.Length; i++)
            seen[i] = destinationPoint;
        seen[0] = 0;
        SnakesAndLadders(board, 0, 1);

        return destinationPointReached ? result : -1;
    }

    private void SnakesAndLadders(int[][] board, int steps, int currBoardPoint)
    {
        steps++;
        if (steps > result) return;

        if (CheckDestinationPointIsReached(currBoardPoint + MaxDiceValue, steps))
            return;

        for (int squareMoves = MaxDiceValue; squareMoves >= MinDiceValue; squareMoves--)
        {
            int nextBoardPoint = currBoardPoint + squareMoves;

            (int nextRow, int nextCol) = BoardToMatrixPoint(nextBoardPoint);
            if (board[nextRow][nextCol] != -1)
            {
                nextBoardPoint = board[nextRow][nextCol];

                if (CheckDestinationPointIsReached(nextBoardPoint, steps))
                    return;
            }

            if (seen[nextBoardPoint - 1] <= steps)
                continue;
            
            seen[nextBoardPoint - 1] = steps;


            SnakesAndLadders(board, steps, nextBoardPoint);
        }
    }

    private bool CheckDestinationPointIsReached(int nextBoardPoint, int steps)
    {
        if (nextBoardPoint >= destinationPoint)
        {
            result = Math.Min(result, steps);
            destinationPointReached = true;
            return true;
        }
        return false;
    }

    private (int row, int col) BoardToMatrixPoint(int boardPoint)
    {
        int positionInLine = (boardPoint - 1) % n + 1;
        int currLine = (boardPoint - 1) / n + 1;
        int row = n - currLine;
        int col = currLine % 2 == 1 ? positionInLine - 1 : n - positionInLine;

        return (row, col);
    }
}
