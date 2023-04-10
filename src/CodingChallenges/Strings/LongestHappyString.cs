using System.Text;

namespace CodingChallenges.Strings
{
    /// <summary>
    /// Related   : String, Greedy, Heap (Priority Queue)
    /// Title     : 1405. Longest Happy String
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/longest-happy-string/
    /// Companies : Microsoft 43 (2022-05-02)
    /// </summary>
    public class LongestHappyString
    {
        // O((a+b+c).3) / O(1)
        public string LongestDiverseString(int a, int b, int c)
        {
            int[] remain = new int[] { a, b, c };

            int countAll = a + b + c;
            var result = new StringBuilder(countAll);

            int last = -1;
            while (countAll > 0)
            {
                int current = getMaxDiffLast_Idx(remain, last);
                if (current == -1)
                    break;

                if ((remain[current] > countAll - remain[current]) && (remain[current] > 2))
                {
                    result.Append((char)('a' + current));
                    countAll--;
                    remain[current]--;
                }
                result.Append((char)('a' + current));
                countAll--;
                remain[current]--;
                last = current;
            }

            return result.ToString();
        }

        private static int getMaxDiffLast_Idx(int[] arr, int last)
        {
            int maxIdx = -1;
            int maxValue = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > maxValue && i != last)
                {
                    maxIdx = i;
                    maxValue = arr[i];
                }
            }
            return maxIdx;
        }
    }
}
