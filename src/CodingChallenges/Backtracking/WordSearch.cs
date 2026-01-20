namespace CodingChallenges.Backtracking;

/// <summary>
/// Related   : Backtracking, Array
/// Title     : 79. Word Search
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/word-search
/// Approachs : Backtracking
/// </summary>
public class WordSearch // CGPT
{
    public bool Exist(char[][] board, string word)
    {
        int m = board.Length;
        int n = board[0].Length;

        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (DFS(board, word, row, col, 0))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool DFS(char[][] board, string word, int row, int col, int index)
    {
        if (index == word.Length) return true; // palavra completa
        if (row < 0 || col < 0 || row >= board.Length || col >= board[0].Length) return false;
        if (board[row][col] != word[index]) return false;

        char temp = board[row][col];
        board[row][col] = '#'; // marca como visitado

        bool found = DFS(board, word, row + 1, col, index + 1) ||
                     DFS(board, word, row - 1, col, index + 1) ||
                     DFS(board, word, row, col + 1, index + 1) ||
                     DFS(board, word, row, col - 1, index + 1);

        board[row][col] = temp; // restaura
        return found;
    }
}
