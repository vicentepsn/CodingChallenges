namespace CodingChallenges.Arrays;

/// <summary>
/// Groups    : Array, Hash Table, Union Find
/// Title     : 128. Longest Consecutive Sequence
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/longest-consecutive-sequence
/// Approachs : Hash Table
/// Last Try  : 2026-01-06
/// </summary>
public class LongestConsecutiveSequence
{
    // Usar abordagem do CG abaixo
    // O(n) / O(n)
    // Leetcode: 7.87% / 7.13%
    public static int LongestConsecutive(int[] nums)
    {
        if (nums.Length <= 1)
            return nums.Length;

        HashSet<int> seen = [];
        Dictionary<int, int> startsAndEnds = [];
        Dictionary<int, int> endsAndStarts = [];

        int longestConsecutive = 0;

        foreach (int num in nums)
        {
            if (seen.Contains(num))
                continue;

            seen.Add(num);

            int newStart = num;
            int newEnd = num;

            if (endsAndStarts.TryGetValue(num - 1, out int start))
            {
                endsAndStarts.Remove(num - 1);
                startsAndEnds.Remove(start);
                newStart = start;
            }

            if (startsAndEnds.TryGetValue(num + 1, out int end))
            {
                startsAndEnds.Remove(num + 1);
                endsAndStarts.Remove(end);
                newEnd = end;
            }

            endsAndStarts[newEnd] = newStart;
            startsAndEnds[newStart] = newEnd;

            longestConsecutive = Math.Max(longestConsecutive, newEnd - newStart + 1);
        }

        return longestConsecutive;
    }

    // Abordagem: Insere todos os números em um HashSet depois percorre todos os números e conta somente a sequências dos números que iniciam uma sequência
    // O(n) / O(n)
    // Leetcode: 54.34% / 83.30%
    public int LongestConsecutive_CGPT(int[] nums)
    {
        if (nums.Length == 0) return 0;

        // Insere todos os números em um HashSet
        HashSet<int> numSet = [.. nums];
        int longestStreak = 0;

        foreach (int num in numSet)
        {
            // Só começamos a contar se 'num' for o início de uma sequência
            if (!numSet.Contains(num - 1))
            {
                int currentNum = num;
                int currentStreak = 1;

                while (numSet.Contains(currentNum + 1))
                {
                    currentNum += 1;
                    currentStreak += 1;
                }

                longestStreak = Math.Max(longestStreak, currentStreak);
            }
        }

        return longestStreak;
    }
}
