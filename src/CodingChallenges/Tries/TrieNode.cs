namespace CodingChallenges.Tries;

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
