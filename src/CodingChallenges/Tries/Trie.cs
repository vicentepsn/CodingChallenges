namespace CodingChallenges.Tries;

/// <summary>
/// Related   : Trie, Design, Hash Table, String
/// Title     : 208. Implement Trie (Prefix Tree)
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/implement-trie-prefix-tree
/// Approachs : Trie
/// </summary>
public class Trie
{
    private readonly TrieNode root;

    public Trie()
    {
        root = new ();
    }

    // Insere uma palavra no Trie
    public void Insert(string word)
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
        node.IsEndOfWord = true;
    }

    // Busca uma palavra completa
    public bool Search(string word)
    {
        TrieNode node = root;
        foreach (char c in word)
        {
            if (!node.Children.ContainsKey(c))
            {
                return false;
            }
            node = node.Children[c];
        }
        return node.IsEndOfWord;
    }

    // Verifica se existe alguma palavra com o prefixo
    public bool StartsWith(string prefix)
    {
        TrieNode node = root;
        foreach (char c in prefix)
        {
            if (!node.Children.ContainsKey(c))
            {
                return false;
            }
            node = node.Children[c];
        }
        return true;
    }
}
/*
public class TrieNode // pode ser criado como privado dentro da classe Trie
{
    public Dictionary<char, TrieNode> Children { get; set; }
    public bool IsEndOfWord { get; set; }

    public TrieNode()
    {
        Children = [];
        IsEndOfWord = false;
    }
}
*/