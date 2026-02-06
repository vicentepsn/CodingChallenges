namespace CodingChallenges.Tries;

/// <summary>
/// Related   : Trie
/// Title     : Search Suggestions (From Amazon prep video)
/// Difficult : Medium/Hard
/// Link      : https://www.youtube.com/watch?v=CuAXhBZ9uAg&t=11s
/// Approachs : Trie
/// </summary>
public class Trie2
{
    private class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public bool IsWord = false;
        public string Word = null;
    }

    private TrieNode root = new TrieNode();

    // Inserir palavra na Trie
    public void Insert(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            if (!node.Children.ContainsKey(c))
                node.Children[c] = new TrieNode();
            node = node.Children[c];
        }
        node.IsWord = true;
        node.Word = word;
    }

    // Buscar sugestões para um prefixo
    public List<string> GetSuggestions(string prefix)
    {
        var node = root;
        foreach (char c in prefix)
        {
            if (!node.Children.ContainsKey(c))
                return new List<string>(); // prefixo não encontrado
            node = node.Children[c];
        }

        // Fazer DFS para coletar até 3 palavras
        List<string> suggestions = new List<string>();
        DFS(node, suggestions);
        return suggestions.OrderBy(s => s).Take(3).ToList();
    }

    private static void DFS(TrieNode node, List<string> suggestions)
    {
        if (node == null || suggestions.Count >= 3) return;

        if (node.IsWord)
            suggestions.Add(node.Word);

        //foreach (var child in node.Children.Values)
        //{
        //    DFS(child, suggestions);
        //    if (suggestions.Count >= 3) break;
        //}

        // CG Sugestion / mas o OrderBy é O(n log n)
        // Ordenar os filhos pelo caractere da chave
        //foreach (var child in node.Children.OrderBy(c => c.Key))
        //{
        //    DFS(child.Value, suggestions);
        //    if (suggestions.Count >= 3) break;
        //}

        // Se eu tiver certeza que o as letrar normalmente são todas usadas, então eu poderia fazer um for de 'a' até 'z'

        if (node.Children.Count > 0)
        {
            char lastChar = node.Children.Keys.Min(); // min é o(n)
            DFS(node.Children[lastChar], suggestions);
            
            for (int count = 1; count < node.Children.Count && suggestions.Count < 3; count++) // seria no máximo O(3.n) => O(n)
            {
                lastChar = GetMinHigherThen(node.Children.Keys, lastChar);
                DFS(node.Children[lastChar], suggestions);
            }
        }
    }

    private static char GetMinHigherThen(IEnumerable<char> values, char higherThen)
    {
        char minChar = char.MaxValue;
        foreach (char value in values)
            if (value < minChar && value > higherThen)
                minChar = value;
        return minChar;
    }
}

public class SearchSuggestion
{
    public static List<List<string>> searchSuggestions(List<string> repository, string customerQuery)
    {
        Trie2 trie = new ();
        foreach (var word in repository)
            trie.Insert(word.ToLower());

        customerQuery = customerQuery.ToLower();
        List<List<string>> result = new List<List<string>>();

        // Gerar prefixos a partir do segundo caractere
        for (int i = 2; i <= customerQuery.Length; i++)
        {
            string prefix = customerQuery.Substring(0, i);
            var suggestions = trie.GetSuggestions(prefix);
            result.Add(suggestions);
        }

        return result;
    }

    // Teste
    public static void Main()
    {
        var repository = new List<string> { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
        string query = "mouse";

        var output = searchSuggestions(repository, query);

        foreach (var list in output)
        {
            Console.WriteLine("[{0}]", string.Join(", ", list));
        }
    }
}