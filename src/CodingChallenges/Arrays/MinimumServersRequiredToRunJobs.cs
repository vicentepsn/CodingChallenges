namespace CodingChallenges.Arrays;

/// Groups    : Array, Intervals, Sorting, Greedy??
/// Title     : --
/// Difficult : Medium / Hard
/// Link      : --
/// Approachs : Sorting, Get intersections
/// Last Try  : 2026-01-28 - In a FAANG interview
/// </summary>
public class MinimumServersRequiredToRunJobs
{
    private const int MinutesInADay = 1440;

    // Complexity: Runtime => O(N) / Space => O(n)
    public static int MinServersRequired(List<(int start, int duration)> jobs)
    {
        var (allDayJobs, events) = GetEvents(jobs);

        events.Sort((a, b) => a.time == b.time ? b.type.CompareTo(a.type) : a.time.CompareTo(b.time));

        int minServersRequired = 1;
        int currServersRequired = 0;

        for (int i = 0; i < events.Count; i++)
        {
            var (time, type) = events[i];
            if (type == EventType.Start)
            {
                currServersRequired++;
                minServersRequired = Math.Max(minServersRequired, currServersRequired);
            }
            else
                currServersRequired--;
        }

        return allDayJobs + minServersRequired;
    }

    private static (int allDayJobs, List<(int time, EventType type)> jobIntervals) GetEvents(List<(int start, int duration)> jobs)
    {
        List<(int time, EventType type)> events = new();

        int allDayJobs = 0;

        foreach (var job in jobs)
        {
            allDayJobs += job.duration / MinutesInADay;
            int remainJobDuration = job.duration % MinutesInADay;
            if (job.start + remainJobDuration > MinutesInADay)
            {
                events.Add(new(job.start, EventType.Start));
                events.Add(new(MinutesInADay, EventType.End));
                events.Add(new(0, EventType.Start));
                events.Add(new(remainJobDuration - (MinutesInADay - job.start), EventType.End));
            }
            else
            {
                events.Add(new(job.start, EventType.Start));
                events.Add(new(job.start + remainJobDuration, EventType.End));
            }
        }

        return (allDayJobs, events);
    }

    private enum EventType
    {
        Start = 0,
        End = 1
    }

    // Approachs: Intervals with Priority Queue
    // Complexity: Runtime => O(N Lon N) / Space => O(n)
    public static int MinServersRequired_intervals(List<(int start, int duration)> jobs)
    {
        PriorityQueue<int, int> finishes = new();

        var (allDayJobs, intervals) = GetJobIntervals(jobs);

        intervals.Sort((a, b) => a.start == b.start ? a.end.CompareTo(b.end) : a.start.CompareTo(b.start));

        int minServersRequired = 1;
        int currServersRequired = 1;
        finishes.Enqueue(intervals[0].end, intervals[0].end);
        int maxInterval = intervals[0].end;

        for (int i = 1; i < intervals.Count; i++)
        {
            var interval = intervals[i];
            currServersRequired++;
            while (interval.start >= maxInterval && finishes.Count > 1)
            {
                finishes.Dequeue();
                maxInterval = finishes.Peek();
                currServersRequired--;
            }

            if (interval.start >= maxInterval)
            {
                finishes.Dequeue();
                maxInterval = interval.end;
                currServersRequired = 1;
            }
            else
            {
                maxInterval = Math.Min(maxInterval, interval.end);
                minServersRequired = Math.Max(minServersRequired, currServersRequired);
            }
            finishes.Enqueue(interval.end, interval.end);
        }

        return allDayJobs + minServersRequired;
    }

    private static (int allDayJobs, List<(int start, int end)> jobIntervals) GetJobIntervals(List<(int start, int duration)> jobs)
    {
        List<(int start, int end)> intervals = new();

        int allDayJobs = 0;

        foreach (var job in jobs)
        {
            allDayJobs += job.duration / MinutesInADay;
            int remainJobDuration = job.duration % MinutesInADay;
            if (job.start + remainJobDuration > MinutesInADay)
            {
                intervals.Add(new(job.start, MinutesInADay));
                intervals.Add(new(0, remainJobDuration - (MinutesInADay - job.start)));
            }
            else
            {
                intervals.Add(new(job.start, job.start + remainJobDuration));
            }
        }

        return (allDayJobs, intervals);
    }
}
