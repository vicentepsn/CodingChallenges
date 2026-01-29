using System.Text;

namespace CodingChallenges.Strings;

public class CompressionAndDecompression
{
    private int index = 0;
    public string Decompress(string compressedString)
    {
        int number = 0;
        StringBuilder result = new ();

        while (index < compressedString.Length)
        {
            if (char.IsDigit(compressedString[index]))
            {
                number = number * 10 + (compressedString[index] - '0');
                index++;
            }
            else if (compressedString[index] == '[')
            {
                index++;
                string curr = Decompress(compressedString);
                for (int i = 0; i < number; i++)
                    result.Append(curr);
                number = 0;
            }
            else if (compressedString[index] == ']')
            {
                index++;
                return result.ToString();
            }
            else
            {
                result.Append(compressedString[index]);
                index++;
            }
        }

        return result.ToString();
    }
}
