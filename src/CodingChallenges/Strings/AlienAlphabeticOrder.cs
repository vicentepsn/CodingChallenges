namespace CodingChallenges.Strings;

/// <summary>
/// Identifica a order de um alfabelo alternativo ("alienígena")
/// </summary>
/// <remarks>Exercício de entrevista em 2026-01-20
/// </remarks>
public class AlienAlphabeticOrder
{
    public string AlienOrder(string[] words) // CG
    {
        var graph = new Dictionary<char, HashSet<char>>();
        var indegree = new Dictionary<char, int>();

        // Inicializar nós
        foreach (var word in words)
        {
            foreach (var c in word)
            {
                if (!graph.ContainsKey(c)) graph[c] = new HashSet<char>();
                if (!indegree.ContainsKey(c)) indegree[c] = 0;
            }
        }

        // Construir arestas
        for (int i = 0; i < words.Length - 1; i++)
        {
            string w1 = words[i], w2 = words[i + 1];
            int minLen = Math.Min(w1.Length, w2.Length);

            // Caso inválido: prefixo
            if (w1.Length > w2.Length && w1.StartsWith(w2))
            {
                return "";
            }

            for (int j = 0; j < minLen; j++)
            {
                if (w1[j] != w2[j])
                {
                    if (!graph[w1[j]].Contains(w2[j]))
                    {
                        graph[w1[j]].Add(w2[j]);
                        indegree[w2[j]]++;
                    }
                    break; // só a primeira diferença importa
                }
            }
        }

        // Topological Sort (Kahn’s Algorithm)
        var queue = new Queue<char>();
        foreach (var kvp in indegree)
        {
            if (kvp.Value == 0) queue.Enqueue(kvp.Key);
        }

        var result = new List<char>();
        while (queue.Count > 0)
        {
            char c = queue.Dequeue();
            result.Add(c);
            foreach (var nei in graph[c])
            {
                indegree[nei]--;
                if (indegree[nei] == 0) queue.Enqueue(nei);
            }
        }

        // Se não usamos todas as letras → ciclo
        if (result.Count < indegree.Count) return "";

        return new string(result.ToArray());
    }

    public static IList<char> GetAlianAlphabeticOrder(string[] alienOrderedWords)
    {
        List<char> result = [];
        Dictionary<char, HashSet<char>> precedentes = [];
        HashSet<char> allLetters = [];

        string prevWord = alienOrderedWords[0];
        AddLettersFromWord(allLetters, prevWord);
        for (int i = 1; i < alienOrderedWords.Length; i++)
        {
            string currWord = alienOrderedWords[i];
            AddLettersFromWord(allLetters, currWord);
            //Console.WriteLine($"{prevWord}, {currWord}");

            int j = 0;
            while (j < prevWord.Length && j < currWord.Length && prevWord[j] == currWord[j])
                j++;

            if (j < prevWord.Length && j < currWord.Length)
            {
                if (!precedentes.ContainsKey(prevWord[j]))
                    precedentes[prevWord[j]] = [];
                precedentes[prevWord[j]].Add(currWord[j]);
                //Console.WriteLine($"{prevWord[j]}, {currWord[j]}");
            }
            prevWord = currWord;
        }

        while (precedentes.Count > 1)
        {
            char startPoint = FindStartPoint(precedentes);
            result.Add(startPoint);
            precedentes.Remove(startPoint);
            allLetters.Remove(startPoint);
        }
        result.Add(precedentes.ElementAt(0).Key);
        result.Add(precedentes.ElementAt(0).Value.ElementAt(0));
        allLetters.Remove(precedentes.ElementAt(0).Key);
        allLetters.Remove(precedentes.ElementAt(0).Value.ElementAt(0));

        result.AddRange(allLetters);
        return [..result];
    }

    private static void AddLettersFromWord(HashSet<char> allLetters, string word)
    {
        foreach(char letter in word)
            allLetters.Add(letter);
    }

    private static char FindStartPoint(Dictionary<char, HashSet<char>> precedentes)
    {
        HashSet<char> charsOnStart = [];
        foreach (char c in precedentes.Keys)
            charsOnStart.Add(c);

        foreach (var chars in precedentes.Values)
            foreach (char c in chars)
                charsOnStart.Remove(c);

        return charsOnStart.ElementAt(0);
    }
}
