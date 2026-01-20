using System.Text;

namespace CodingChallenges.Strings;

public class TextJustification
{
    public static List<string> FullJustify(string[] words, int maxWidth)
    {
        int wordIdx = 0;
        var result = new List<string>();

        while (wordIdx < words.Length)
        {
            //if (wordIdx == words.Length - 1)
            //{
            //    result.Add($"{words[wordIdx]}{new string(' ', maxWidth - words[wordIdx].Length)}");
            //    return result;
            //}
            int currLineLength = words[wordIdx].Length;
            int nextWordIdx = wordIdx + 1;
            int wordsCount = 1;

            while (nextWordIdx < words.Length && currLineLength + 1 + words[nextWordIdx].Length <= maxWidth)
            {
                currLineLength += 1 + words[nextWordIdx].Length;
                nextWordIdx++;
                wordsCount++;
            }

            //if (wordsCount == 1)
            //{
            //    result.Add($"{words[wordIdx]}{new string(' ', maxWidth - words[wordIdx].Length)}");
            //    wordIdx++;
            //    continue;
            //}

            var line = new StringBuilder(words[wordIdx]);
            wordIdx++;

            if (wordsCount == 1 || nextWordIdx == words.Length) // se for a última linha e tiver mais de uma palavra
            {
                while (wordIdx < nextWordIdx)
                {
                    line.Append(" ");
                    line.Append(words[wordIdx]);
                    wordIdx++;
                }
                line.Append(new string(' ', maxWidth - currLineLength));
            }
            else
            {
                int maxSpaces = wordsCount - 1 + maxWidth - currLineLength;
                int minSpacesByWord = maxSpaces / (wordsCount - 1);
                int excededSpaces = maxSpaces % (wordsCount - 1);

                while (wordIdx < nextWordIdx)
                {
                    line.Append(new string(' ', minSpacesByWord + (excededSpaces > 0 ? 1 : 0)));
                    excededSpaces--;
                    line.Append(words[wordIdx]);
                    wordIdx++;
                }
            }

            result.Add(line.ToString());
        }

        return result;
    }
}
