using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges.Sort
{
    public class ReorderDataInLogFiles
    {
        public string[] ReorderLogFiles(string[] logs)
        {
            var letterLogs = new List<string[]>(logs.Length);
            var digitLogs = new List<string>(logs.Length);

            foreach (string log in logs)
            {
                var logParts = log.Split(' ', 2);
                if (Char.IsDigit(logParts[1][0]))
                    digitLogs.Add(log);
                else
                {
                    letterLogs.Add(logParts);
                }
            }

            letterLogs.Sort(new LogPartsComparer());

            var result = letterLogs.Select(p => $"{p[0]} {p[1]}").Concat(digitLogs).ToArray();
            return result;

        }

        class LogPartsComparer : Comparer<string[]>
        {
            public override int Compare(string[] a, string[] b)
            {
                var compLogContent = a[1].CompareTo(b[1]);
                if (compLogContent != 0)
                    return compLogContent;

                return a[0].CompareTo(b[0]);
            }
        }
    }
}
