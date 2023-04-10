using System.Collections.Generic;

namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Related   : String, Hash Table, Sliding Window
    /// Title     : 386. Cinema Seat Allocation
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/cinema-seat-allocation/
    /// Companies : Microsoft 16, Amazon 2  (2022-05-02)
    /// </summary>
    public class CinemaSeatAllocation
    {
        // O(r) / O(n)  => r: num of reserved seats
        public int MaxNumberOfFamilies(int n, int[][] reservedSeats)
        {
            int count = 2 * n;

            // Only (l)eft, (r)ight, (m)idle, (n)one, lm = 'left or midle' and mr = 'midle or right'
            var rowsAvailability = new Dictionary<int, string>();

            foreach (int[] reservedSeat in reservedSeats)
            {
                int row = reservedSeat[0];
                int col = reservedSeat[1];
                if (col == 1 || col == 10)
                    continue;

                if (!rowsAvailability.ContainsKey(row))
                {
                    count--;
                    if (col <= 3)
                        rowsAvailability[row] = "mr";
                    else if (col >= 8)
                        rowsAvailability[row] = "lm";
                    else if (col <= 5)
                        rowsAvailability[row] = "r";
                    else // (col >= 6)
                        rowsAvailability[row] = "l";
                }
                else
                {
                    //if(rowsAvailability[row] == 'n')
                    //    continue;

                    if ((rowsAvailability[row] == "lm" && col <= 3)
                        || (rowsAvailability[row] == "mr" && col >= 8))
                    {
                        rowsAvailability[row] = "m";
                    }
                    else if (rowsAvailability[row] == "lm" && col >= 6 && col <= 7)
                    {
                        rowsAvailability[row] = "l";
                    }
                    else if (rowsAvailability[row] == "mr" && col >= 4 && col <= 5)
                    {
                        rowsAvailability[row] = "r";
                    }
                    else if (((rowsAvailability[row] == "l" || rowsAvailability[row] == "lm") && col <= 5)
                        || ((rowsAvailability[row] == "r" || rowsAvailability[row] == "mr") && col >= 6)
                        || (rowsAvailability[row] == "m" && col >= 4 && col <= 7))
                    {
                        rowsAvailability[row] = "n";
                        count--;
                    }
                }
            }

            return count;
        }
    }
}
