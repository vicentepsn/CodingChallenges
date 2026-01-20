namespace CodingChallenges.Arrays;

/// <summary>
/// Groups    : Array, Sorting, Intervals
/// Title     : 56. Merge Intervals
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/merge-intervals
/// Approachs : Sorting, merge
/// Last Try  : 2026-01-06
/// </summary>
public class MergeIntervals
{
    // Leetcode: Beats 98.94% / 31.37  (ou 58.48% / 27.61% caso usado o método CompareIntervals abaixo para ordenação)
    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 1) return intervals;

        //Array.Sort(intervals, CompareIntervals);
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        List<int[]> mergedIntervals = [];

        int startInterval = intervals[0][0];
        int endInterval = intervals[0][1];

        for (int i = 1; i < intervals.Length; i++)
        {
            int currStartInterval = intervals[i][0];
            int currEndInterval = intervals[i][1];

            if (currStartInterval > endInterval)
            {
                mergedIntervals.Add([startInterval, endInterval]);
                startInterval = currStartInterval;
                endInterval = currEndInterval;
                continue;
            }

            endInterval = Math.Max(endInterval, currEndInterval);
        }

        mergedIntervals.Add([startInterval, endInterval]);

        return [.. mergedIntervals];
    }

    //private int CompareIntervals(int[] a, int[] b)
    //{
    //    int compareA = a[0].CompareTo(b[0]);
    //    if (compareA != 0)
    //        return compareA;

    //    return a[1].CompareTo(b[1]);
    //}
}
