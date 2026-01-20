namespace CodingChallenges.Strings;

/// <summary>
/// Groups: String, Hash
/// Title: 30. Substring with Concatenation of All Words
/// Difficult: Hard
/// Link: https://leetcode.com/problems/substring-with-concatenation-of-all-words
/// Approach: Sliding Window
/// </summary>
public class SubstringWithConcatenationOfAllWords
{
    /*📊 Complexidade
- Tempo: O(n.wordLen), aproximadamente O(n), pois cada palavra é processada uma vez por janela.
- Espaço: O(m), onde m é o número de palavras.
*/
    // Leetcode: Beats 95.41% / Beats 37.61%
    public static List<int> FindSubstring(string s, string[] words)
    {
        List<int> result = [];

        int wordLength = words[0].Length;
        if (s.Length < words.Length * wordLength)
            return result;

        int totalExpectQtdWords = words.Length;

        Dictionary<string, int> expectedQtdByWord = new();
        foreach (string word in words)
        {
            expectedQtdByWord.TryGetValue(word, out int wordCount);
            expectedQtdByWord[word] = wordCount + 1;
        }

        // Percorre cada posível posição que as palavras podem começar, que é o tamanho de uma palavra
        for (int offset = 0; offset < wordLength; offset++)
        {
            int left = offset;
            int right = left;
            Dictionary<string, int> currQtdByWord = new();
            int currTotalQtdWords = 0;

            while (right + wordLength <= s.Length)
            {
                string currWord = s.Substring(right, wordLength);
                right += wordLength;
                if (expectedQtdByWord.ContainsKey(currWord))
                {
                    currQtdByWord.TryGetValue(currWord, out int currWordCount);
                    currQtdByWord[currWord] = currWordCount + 1;
                    currTotalQtdWords++;

                    while (currQtdByWord[currWord] > expectedQtdByWord[currWord])
                    {
                        string wordToRemove = s.Substring(left, wordLength);
                        currQtdByWord[wordToRemove] -= 1;
                        currTotalQtdWords--;
                        left += wordLength;
                    }

                    // Caso a contagem de palavras foi atingida
                    if (currTotalQtdWords == totalExpectQtdWords)
                        result.Add(left);
                }
                else
                {
                    currTotalQtdWords = 0;
                    currQtdByWord.Clear();

                    left = right;
                }
            }
        }

        return result;
    }

    // Leetcode: Beats 95.41% / Beats 81.19%
    public static List<int> FindSubstring_chatGPT(string s, string[] words) // 
    {
        var resultado = new List<int>();
        if (words.Length == 0 || s.Length == 0) return resultado;

        int wordLen = words[0].Length;
        int totalLen = wordLen * words.Length;

        if (s.Length < totalLen) return resultado;

        // Contagem das palavras
        var wordCount = new Dictionary<string, int>();
        foreach (var w in words)
        {
            if (!wordCount.ContainsKey(w))
                wordCount[w] = 0;
            wordCount[w]++;
        }

        // Sliding window com diferentes offsets
        for (int offset = 0; offset < wordLen; offset++)
        {
            int left = offset;
            int right = offset;
            var seen = new Dictionary<string, int>();
            int count = 0;

            while (right + wordLen <= s.Length)
            {
                string palavra = s.Substring(right, wordLen);
                right += wordLen;

                if (wordCount.ContainsKey(palavra))
                {
                    if (!seen.ContainsKey(palavra))
                        seen[palavra] = 0;
                    seen[palavra]++;
                    count++;

                    // Se excedeu a contagem esperada, mover left
                    while (seen[palavra] > wordCount[palavra])
                    {
                        string leftWord = s.Substring(left, wordLen);
                        seen[leftWord]--;
                        left += wordLen;
                        count--;
                    }

                    // Se encontrou todas as palavras
                    if (count == words.Length)
                        resultado.Add(left);
                }
                else
                {
                    // Resetar janela
                    seen.Clear();
                    count = 0;
                    left = right;
                }
            }
        }

        return resultado;
    }


    // Leetcode: Funciona, mas dá "Time limit exceded"
    public static IList<int> FindSubstring_firstTry(string s, string[] words)
    {
        int wordSize = words[0].Length;
        if (s.Length < words.Length * wordSize)
            return new List<int>();

        Dictionary<string, int> wordsCounts = new();
        IList<int> result = new List<int>();

        foreach (string word in words)
        {
            if (wordsCounts.TryGetValue(word, out int wordCount))
                wordsCounts[word] = wordCount + 1;
            else
                wordsCounts[word] = 1;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (i + wordSize > s.Length)
                break;
            string currWord = s.Substring(i, wordSize);
            if (wordsCounts.ContainsKey(currWord) && FindSubstring(s, i, words.Length, wordsCounts))
                result.Add(i);
        }

        return result;
    }

    private static bool FindSubstring(string s, int startIndex, int wordsCount, Dictionary<string, int> wordCounts)
    {
        Dictionary<string, int> wordCountsRemain = new(wordCounts);

        int wordsCountRemain = wordsCount;
        int currIndex = startIndex;
        int wordSize = wordCounts.Keys.ElementAt(0).Length;

        while (wordsCountRemain > 0 && currIndex < s.Length)
        {
            if (currIndex + wordSize > s.Length)
                break;
            string currWord = s.Substring(currIndex, wordSize);

            if (wordCountsRemain.TryGetValue(currWord, out int wordCount) && wordCount > 0)
            {
                wordCountsRemain[currWord] = wordCount - 1;
                wordsCountRemain--;
            }
            else
                return false;

            currIndex += wordSize;
        }

        return wordsCountRemain == 0;
    }

    // Leetcode: Beats 5.36% / Beats 10.27%
    public IList<int> FindSubstring_secondTry(string s, string[] words)
    {
        int wordSize = words[0].Length;
        if (s.Length < words.Length * wordSize)
            return new List<int>();

        int wordsCount = words.Length;
        Dictionary<string, int> wordsCounts = new();
        List<int> result = new List<int>();

        foreach (string word in words)
        {
            if (wordsCounts.TryGetValue(word, out int wordCount))
                wordsCounts[word] = wordCount + 1;
            else
                wordsCounts[word] = 1;
        }

        Dictionary<string, int> currWordsCounts = new();
        int currWordsCount = 0;


        int left = 0;
        int right = 0;

        while (right < s.Length)
        {
            if (right + wordSize > s.Length)
                break;

            string currWord = s.Substring(right, wordSize);
            if (wordsCounts.TryGetValue(currWord, out int wordCount))
            {
                currWordsCounts.TryGetValue(currWord, out int currWordCount);
                currWordCount++;
                currWordsCounts[currWord] = currWordCount;
                currWordsCount++;

                // Caso a contagem da palavra tenha atingido o sua contagem esperada e a contagem de palavras foi atingida
                if (currWordCount == wordCount && currWordsCount == wordsCount)
                {
                    result.Add(left);

                    currWordsCount = 0;
                    currWordsCounts = new();

                    left += 1;
                    right = left;
                    continue;
                }

                // Caso a palavra tenha excedido a sua contagem esperada, remove as palavras até encontrar a palavra excedida
                if (currWordCount > wordCount)
                {
                    currWordsCount = 0;
                    currWordsCounts = new();

                    left += 1;
                    right = left;
                    continue;
/*                    string wordToRemove = s.Substring(left, wordSize);
                while (left < right)
                {
                    currWordsCounts[wordToRemove] -= 1;
                    currWordsCount--;
                    left += wordSize;

                    if (wordToRemove == currWord)
                        break;

                    wordToRemove = s.Substring(left, wordSize);
                }*/
                }
                right += wordSize;
            }
            else
            {
                currWordsCount = 0;
                currWordsCounts = new();

                left += 1;
                right = left;
            }
        }

        return result;
    }

    private static void RestartCountersAndPointers_(ref int left, ref int right, ref Dictionary<string, int> currQtdByWord, ref int currTotalQtdWords)
    {
        currTotalQtdWords = 0;
        currQtdByWord = new();

        left += 1;
        right = left;
    }

}
