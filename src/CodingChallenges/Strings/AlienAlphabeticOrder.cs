namespace CodingChallenges.Strings;

/// <summary>
/// Identifica a order de um alfabelo alternativo ("alienígena")
/// </summary>
/// <remarks>Exercício de entrevista em 2026-01-20
/// </remarks>
public class AlienAlphabeticOrder
{
    public static IList<char> GetAlianAlphabeticOrder(string[] alienOrderedWords)
    {
        IList<char> result = [];
        Dictionary<char, List<char>> precedentes = [];

        string prevWord = alienOrderedWords[0];
        for (int i = 1; i < alienOrderedWords.Length; i++)
        {
            string currWord = alienOrderedWords[i];
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
        }
        result.Add(precedentes.ElementAt(0).Key);
        result.Add(precedentes.ElementAt(0).Value[0]);

        return result;
    }

    private static char FindStartPoint(Dictionary<char, List<char>> precedentes)
    {
        HashSet<char> charsOnStart = [];
        foreach (char c in precedentes.Keys)
            charsOnStart.Add(c);

        foreach (List<char> chars in precedentes.Values)
            foreach (char c in chars)
                charsOnStart.Remove(c);

        return charsOnStart.ElementAt(0);
    }
}
