namespace CodingChallenges.BinarySearch;

/// <summary>
/// Related   : Binary Search, Array
/// Title     : 2187. Minimum Time to Complete Trips
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/minimum-time-to-complete-trips
/// Approachs : Binary Search
/// </summary>
public class MinimumTimeToCompleteTrips
{
    public long MinimumTime(int[] time, int totalTrips) // CG
    {
        long left = 1;
        long right = (long)time.Min() * totalTrips; // limite superior
        long answer = right;

        while (left <= right)
        {
            long mid = left + (right - left) / 2;

            // calcular número de viagens possíveis até 'mid'
            long trips = 0;
            foreach (int t in time)
            {
                trips += mid / t;
                if (trips >= totalTrips) break; // otimização
            }

            if (trips >= totalTrips)
            {
                answer = mid;
                right = mid - 1; // tentar menor tempo
            }
            else
            {
                left = mid + 1; // precisamos de mais tempo
            }
        }

        return answer;
    }
}

/*    public long MinimumTime(int[] busTimes, int totalTrips) {
        long left = 1;
        long right = busTimes.Min() * totalTrips;
        long answer = right;
        Console.WriteLine($"{right}");

        while (left <= right){
            long time = (left + right) / 2;
            long totalTripsAtTime = GetTotalTripsAtATime(busTimes, time, totalTrips);
            if (totalTripsAtTime < totalTrips){
                left = time + 1;
            }   
            else{ //if (totalTripsAtTime >= totalTrips){
                right = time - 1;
                answer = time;
            }
            //else
            //    return time;
        }

        return answer;
    }

    private static long GetTotalTripsAtATime(int[] busTimes, long time, int totalTrips){
        long trips = 0;
        foreach (int busTime in busTimes){
            trips += time / busTime;
            if (trips > totalTrips) break; // otimização
        }
        Console.WriteLine($"{time}/{trips}");
        return trips;
    }*/
