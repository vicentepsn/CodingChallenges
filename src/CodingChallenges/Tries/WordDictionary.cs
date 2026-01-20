namespace CodingChallenges.Tries;

/// <summary>
/// Related   : Trie, Design, Hash Table, String
/// Title     : 211. Design Add and Search Words Data Structure
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/design-add-and-search-words-data-structure
/// Approachs : Trie
/// </summary>
public class WordDictionary
{
    private readonly TrieNode root;

    public WordDictionary()
    {
        root = new ();
    }

    // Adiciona uma palavra ao Trie
    public void AddWord(string word)
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

    // Busca uma palavra (com suporte ao '.')
    public bool Search(string word)
    {
        return SearchHelper(word, 0, root);
    }

    private bool SearchHelper(string word, int index, TrieNode node)
    {
        if (index == word.Length)
        {
            return node.IsEndOfWord;
        }

        char c = word[index];
        if (c == '.')
        {
            // tenta todos os filhos
            foreach (var child in node.Children.Values)
            {
                if (SearchHelper(word, index + 1, child))
                {
                    return true;
                }
            }
            return false;
        }
        else
        {
            if (!node.Children.ContainsKey(c))
            {
                return false;
            }
            return SearchHelper(word, index + 1, node.Children[c]);
        }
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
