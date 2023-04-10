using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges.Arrays
{
    public class ProcessLogs
    {
        /*
     * Complete the 'processLogs' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. STRING_ARRAY logs
     *  2. INTEGER threshold
     */

        public static List<string> processLogs(List<string> logs, int threshold)
        {
            var dict = new Dictionary<int, int>();
            foreach (var transaction in logs)
            {
                var t = transaction.Split(' ');

                var sender = int.Parse(t[0]);
                var recipient = int.Parse(t[1]);

                if (!dict.ContainsKey(sender))
                    dict[sender] = 0;
                dict[sender]++;

                if (sender != recipient)
                {
                    if (!dict.ContainsKey(recipient))
                        dict[recipient] = 0;
                    dict[recipient]++;
                }
            }

            var result = dict.Where(kp => kp.Value >= threshold).Select(x => x.Key).OrderBy(v => v).Select(v => v.ToString()).ToList();

            return result;
        }

    }
}
