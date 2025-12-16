namespace CodingChallenges.Strings;

public class AnagramGrouped
{
    // Amazon PhoneScreen 2024-09-11
    public static List<List<string>> GetGroupedAnagrams(List<string> words)
    {
        if (words == null) return null;

        Dictionary<string, List<string>> groupedAmagrams = [];

        foreach (string word in words)
        {
            Dictionary<char, int> lettersQts = new(word.Length);

            for (int i = 0; i < word.Length; i++)
                lettersQts[word[i]] = lettersQts.GetValueOrDefault(word[i], 0) + 1;

            string anagramHash = string.Join(",", lettersQts.Select(i => $"{i.Key}{i.Value}"));

            if (groupedAmagrams.ContainsKey(anagramHash))
                groupedAmagrams[anagramHash].Add(word);
            else
                groupedAmagrams[anagramHash] = [word];
        }

        return [.. groupedAmagrams.Values];
    }
}
