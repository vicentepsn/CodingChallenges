namespace CodingChallenges.Arrays;

/// Groups    : Array, Binary Search, Intervals
/// Title     : 57. Insert Interval
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/insert-interval
/// Approachs : Binary Search, Merging
/// Last Try  : 2026-01-06
/// </summary>
public class InsertInterval
{
    // Em uma entrevista, talvez começar com a solução abaixo primeiro
    // Leetcode: Beats 98.97% / 51.21%   ///  Ou Beats 100.00% / 93.85% se usar a função BuildMergedArray
    public static int[][] Insert(int[][] intervals, int[] newInterval)
    {
        if (intervals.Length == 0) return [newInterval];

        int n = intervals.Length;

        int idxStart = Array.BinarySearch(intervals, newInterval, new IntervalComparerStart());
        int idxEnd = Array.BinarySearch(intervals, newInterval, new IntervalComparerEnd());

        if (idxStart < 0) idxStart = ~idxStart;
        if (idxEnd < 0) idxEnd = ~idxEnd;

        if ((idxStart <= n && idxEnd == n) || (idxEnd < n && newInterval[1] < intervals[idxEnd][0]))
            idxEnd--;

        //if (idxEnd == -1)//(idxStart == 0 && newInterval[1] < intervals[idxStart][0])
        //    return [newInterval, .. intervals];

        //if (idxStart == n)
        //    return [ .. intervals, newInterval];

        if (idxEnd != -1 && idxStart != n)
        {
            newInterval[0] = Math.Min(newInterval[0], intervals[idxStart][0]);
            newInterval[1] = Math.Max(newInterval[1], intervals[idxEnd][1]);
        }

        //if (idxStart == 0)
        //    return (idxEnd == n - 1) ? [newInterval] : [newInterval, .. intervals.Skip(idxEnd + 1)];

        //if (idxEnd == n - 1)
        //    return [.. intervals.Take(idxStart), newInterval];

        //return [.. intervals.Take(idxStart), newInterval, .. intervals.Skip(idxEnd + 1)];
        return BuildMergedArray(intervals, newInterval, n, idxStart, idxEnd);
    }

    private static int[][] BuildMergedArray(int[][] intervals, int[] newInterval, int n, int idxStart, int idxEnd)
    {
        //int[][] result = new int[idxStart + 1 + n - (idxEnd + 1)][]; // simplificar para => new int[idxStart + n - idxEnd][]
        int[][] result = new int[idxStart + n - idxEnd][]; // simplificar para => new int[idxStart + n - idxEnd][]

        int i = 0;
        for (; i < idxStart; i++)
            result[i] = intervals[i];

        result[i++] = newInterval;
        int idx = idxEnd + 1;
        for (; i < idxStart + n - idxEnd; i++)
            result[i] = intervals[idx++];

        return result;
    }

    private class IntervalComparerStart : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            return x[1].CompareTo(y[0]);
        }
    }
    private class IntervalComparerEnd : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            return x[0].CompareTo(y[1]);
        }
    }

    // Leetcode: Beats 98.97% / 11.55%
    public static int[][] Insert_v2(int[][] intervals, int[] newInterval)
    {
        if (intervals.Length == 0) return [newInterval];

        int n = intervals.Length;

        int idxStart = 0;
        int idxEnd = n - 1;

        for (; idxStart < n; idxStart++)
            if (newInterval[0] <= intervals[idxStart][1])
                break;

        for (; idxEnd >= 0; idxEnd--)
            if (newInterval[1] >= intervals[idxEnd][0])
                break;

        //if (idxEnd == -1)
        //    return [newInterval, .. intervals];
        //if (idxStart == n)
        //    return [.. intervals, newInterval];
        //if (idxStart > idxEnd)
        //    return [.. intervals.Take(idxStart), newInterval, .. intervals.Skip(idxEnd + 1)];

        if (idxEnd != -1 && idxStart != n)
        {
            newInterval[0] = Math.Min(newInterval[0], intervals[idxStart][0]);
            newInterval[1] = Math.Max(newInterval[1], intervals[idxEnd][1]);
        }

        //if (idxStart == 0 && idxEnd == n - 1)
        //    return [newInterval];

        //if (idxStart == 0)
        //    return [newInterval, .. intervals.Skip(idxEnd + 1)];
        //if (idxStart == n - 1)
        //    return [.. intervals.Take(idxStart), newInterval];

        return [.. intervals.Take(idxStart), newInterval, .. intervals.Skip(idxEnd + 1)];
    }

    // Leetcode: Beats 98.97% / 17.24%
    public int[][] Insert_ChatGPT(int[][] intervals, int[] newInterval)
    {
        List<int[]> result = [];
        int i = 0;
        int n = intervals.Length;

        // 1. Adicionar todos os intervalos que terminam antes do newInterval começar
        while (i < n && intervals[i][1] < newInterval[0])
        {
            result.Add(intervals[i]);
            i++;
        }

        // 2. Mesclar todos os intervalos que se sobrepõem ao newInterval
        while (i < n && intervals[i][0] <= newInterval[1])
        {
            newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
            newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
            i++;
        }
        result.Add(newInterval);

        // 3. Adicionar os intervalos restantes
        while (i < n)
        {
            result.Add(intervals[i]);
            i++;
        }

        return [.. result];
    }


}
