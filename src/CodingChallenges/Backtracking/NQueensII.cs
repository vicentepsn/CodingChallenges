namespace CodingChallenges.Backtracking;

/// <summary>
/// Related   : Backtracking, Array
/// Title     : 52. N-Queens II
/// Difficult : Hard
/// Link      : https://leetcode.com/problems/n-queens-ii
/// Approachs : Backtracking
/// </summary>
public class NQueensII // CGPT
{
    public int TotalNQueens(int n)
    {
        int count = 0;
        bool[] cols = new bool[n];              // colunas ocupadas
        bool[] diag1 = new bool[2 * n];         // diagonais principais (row - col)
        bool[] diag2 = new bool[2 * n];         // diagonais secundárias (row + col)

        Backtrack(0, n, cols, diag1, diag2, ref count);
        return count;
    }

    private void Backtrack(int row, int n, bool[] cols, bool[] diag1, bool[] diag2, ref int count)
    {
        if (row == n)
        {
            count++;
            return;
        }

        for (int col = 0; col < n; col++)
        {
            if (cols[col] || diag1[row - col + n] || diag2[row + col]) continue;

            // coloca rainha
            cols[col] = diag1[row - col + n] = diag2[row + col] = true;

            Backtrack(row + 1, n, cols, diag1, diag2, ref count);

            // remove rainha (backtrack)
            cols[col] = diag1[row - col + n] = diag2[row + col] = false;
        }
    }
}
