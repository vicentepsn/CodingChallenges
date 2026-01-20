namespace CodingChallenges.Tries;

/// <summary>
/// Related   : Trie, String
/// Title     : 212. Word Search II
/// Difficult : Hard
/// Link      : https://leetcode.com/problems/word-search-ii
/// Approachs : Trie
/// </summary>
public class WordSearchII
{
    private class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; }
        public string Word { get; set; }

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            Word = null;
        }
    }

    public IList<string> FindWords(char[][] board, string[] words)
    {
        TrieNode root = BuildTrie(words);
        HashSet<string> result = [];
        int m = board.Length;
        int n = board[0].Length;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                DFS(board, i, j, root, result);
            }
        }

        return [.. result];
    }

    private void DFS(char[][] board, int i, int j, TrieNode node, HashSet<string> result)
    {
        char c = board[i][j];
        if (c == '#' || !node.Children.ContainsKey(c)) return;

        node = node.Children[c];
        if (node.Word != null)
        {
            result.Add(node.Word);
            node.Word = null; // evita duplicados
        }

        board[i][j] = '#'; // marca como visitado

        int[][] dirs = new int[][] {
            new int[] {1,0}, new int[] {-1,0}, new int[] {0,1}, new int[] {0,-1}
        };

        foreach (var dir in dirs)
        {
            int ni = i + dir[0], nj = j + dir[1];
            if (ni >= 0 && nj >= 0 && ni < board.Length && nj < board[0].Length)
            {
                DFS(board, ni, nj, node, result);
            }
        }

        board[i][j] = c; // restaura
    }

    private TrieNode BuildTrie(string[] words)
    {
        TrieNode root = new TrieNode();
        foreach (string word in words)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
            }
            node.Word = word; // marca fim da palavra
        }
        return root;
    }
}