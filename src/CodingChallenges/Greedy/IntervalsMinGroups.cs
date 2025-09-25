namespace CodingChallenges.Greedy;

/// <summary>
/// Related   : Greedy, 2D array, Comparer (comparison, comparador)
/// Title     : 2406. Divide Intervals Into Minimum Number of Groups
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/divide-intervals-into-minimum-number-of-groups/
/// Companies : ??
/// </summary>
public class IntervalsMinGroups
{
    public class IntervalsComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            int compareSize = x[0].CompareTo(y[0]);
            if (compareSize != 0)
                return compareSize;

            return (y[1] - y[0]).CompareTo(x[1] - x[0]);
        }
    }

    public static int MinGroups(int[][] intervals)
    {
        var intervalsComparer = new IntervalsComparer();
        bool[] visitedIntervals = new bool[intervals.Length];
        Array.Sort(intervals, intervalsComparer);

        int groupsCount = 1;
        int left = 0;
        visitedIntervals[0] = true;

        while (left < intervals.Length)
        {
            int next = intervals[left][1] + 1;

            int right = left + 1;
            while (right < intervals.Length)
            {
                int position = Array.BinarySearch(intervals, right, intervals.Length - right, new int[] { next, Int32.MaxValue }, intervalsComparer);
                right = ~position;

                while (right < intervals.Length && visitedIntervals[right])
                    right++;

                if (right < intervals.Length)
                {
                    visitedIntervals[right] = true;
                    next = intervals[right][1] + 1;
                }

            }
            left++;
            while (left < intervals.Length && visitedIntervals[left])
                left++;

            if (left < intervals.Length)
            {
                groupsCount++;
                visitedIntervals[left] = true;
            }

        }

        return groupsCount;
    }

}
