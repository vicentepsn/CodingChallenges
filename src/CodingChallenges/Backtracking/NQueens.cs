namespace CodingChallenges.Backtracking;

/// <summary>
/// Related   : Backtracking, Array
/// Title     : 51. N-Queens
/// Difficult : Hard
/// Link      : https://leetcode.com/problems/n-queens
/// Approachs : Backtracking
/// </summary>
public class NQueens // ChatGPT
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        var result = new List<IList<string>>();
        var board = new char[n][];
        for (int i = 0; i < n; i++)
        {
            board[i] = new string('.', n).ToCharArray();
        }

        bool[] cols = new bool[n];          // colunas ocupadas
        bool[] diag1 = new bool[2 * n];     // diagonal principal (row - col)
        bool[] diag2 = new bool[2 * n];     // diagonal secundária (row + col)

        Backtrack(0, n, board, cols, diag1, diag2, result);
        return result;
    }

    private void Backtrack(int row, int n, char[][] board, bool[] cols, bool[] diag1, bool[] diag2, List<IList<string>> result)
    {
        if (row == n)
        {
            var solution = new List<string>();
            for (int i = 0; i < n; i++)
            {
                solution.Add(new string(board[i]));
            }
            result.Add(solution);
            return;
        }

        for (int col = 0; col < n; col++)
        {
            if (cols[col] || diag1[row - col + n] || diag2[row + col]) continue;

            // coloca rainha
            board[row][col] = 'Q';
            cols[col] = diag1[row - col + n] = diag2[row + col] = true;

            Backtrack(row + 1, n, board, cols, diag1, diag2, result);

            // remove rainha (backtrack)
            board[row][col] = '.';
            cols[col] = diag1[row - col + n] = diag2[row + col] = false;
        }
    }
}
