namespace CodingChallenges.Graphs.BFS;

/// <summary>
/// Related   : Graph (implicity), Breadth-First Search, Hash Table
/// Title     : 127. Word Ladder
/// Difficult : Hard
/// Link      : https://leetcode.com/problems/word-ladder
/// Approachs : Breadth-First Search
/// </summary>
/// MUITO SEMELHANTE AO DA CLASSE MinimumGeneticMutation
public class WordLadder
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> wordSet = [.. wordList];
        if (!wordSet.Contains(endWord)) return 0;

        Queue<(string word, int steps)> queue = new();
        queue.Enqueue((beginWord, 1));
        HashSet<string> visited = [];
        visited.Add(beginWord);

        while (queue.Count > 0)
        {
            var (current, steps) = queue.Dequeue();
            if (current == endWord)
                return steps;

            char[] wordLetters = current.ToCharArray();
            for (int i = 0; i < wordLetters.Length; i++)
            {
                char oldChar = wordLetters[i];
                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (c == oldChar)
                        continue;
                    wordLetters[i] = c;
                    string newWord = new(wordLetters);
                    if (wordSet.Contains(newWord) && !visited.Contains(newWord))
                    {
                        visited.Add(newWord);
                        queue.Enqueue((newWord, steps + 1));
                    }
                }
                wordLetters[i] = oldChar; // restaura
            }
        }

        return 0;
    }
}