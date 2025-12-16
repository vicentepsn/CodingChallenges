using System.Collections.Generic;

namespace CodingChallenges.Arrays;

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
    public int MaxNumberOfFamilies1(int n, int[][] reservedSeats)
    {
        int maxNumberOfFamilies = 2 * n;

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
                maxNumberOfFamilies--;
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
                    maxNumberOfFamilies--;
                }
            }
        }

        return maxNumberOfFamilies;
    }

    public int MaxNumberOfFamilies_(int n, int[][] reservedSeats)
    {
        var maxNumberOfFamilies = n * 2;
        Dictionary<int, bool[]> ocupiedBlocks = new Dictionary<int, bool[]>();
        //HashSet<int> ocupiedRows = new();

        foreach (var reservedSeat in reservedSeats)
        {
            int row = reservedSeat[0];
            int col = reservedSeat[1];
            //if (col == 1 || col == 10 || (ocupiedBlocksInRow[1] && ocupiedBlocksInRow[2])) //ocupiedRows.Contains(row))
            //    continue;

            ocupiedBlocks.TryGetValue(row, out bool[] ocupiedBlocksInRow);
            if (col == 1 || col == 10 || (ocupiedBlocksInRow != null && ocupiedBlocksInRow[1] && ocupiedBlocksInRow[2])) //ocupiedRows.Contains(row))
                continue;
            if (ocupiedBlocksInRow == null)
            {
                ocupiedBlocksInRow = new bool[4];
                ocupiedBlocks.Add(row, ocupiedBlocksInRow);

                maxNumberOfFamilies--;
            }

            if (col <= 3)
                ocupiedBlocksInRow[0] = true; // l
            else if (col >= 8)
                ocupiedBlocksInRow[3] = true; // r
            else if (col <= 5)
                ocupiedBlocksInRow[1] = true; // lm
            else // (col >= 6)
                ocupiedBlocksInRow[2] = true; // mr

            if ((ocupiedBlocksInRow[0] || ocupiedBlocksInRow[1]) && (ocupiedBlocksInRow[1] || ocupiedBlocksInRow[2]) && (ocupiedBlocksInRow[2] || ocupiedBlocksInRow[3]))
            {
                maxNumberOfFamilies--;
                //ocupiedRows.Add(row);
                ocupiedBlocksInRow[1] = true;
                ocupiedBlocksInRow[2] = true;
            }
        }

        return maxNumberOfFamilies;
    }

    public int MaxNumberOfFamilies(int n, int[][] reservedSeats) // _refresh
    {
        const int MaxFamiliesPerRow = 2;
        const int BlocksPerRow = 4;
        int maxNumberOfFamilies = n * MaxFamiliesPerRow;
        Dictionary<int, bool[]> reservedBlocks = []; // there are 4 blocks: left [1,2], left/midle [3,4], midle/right [5,6] and right [7,8]

        foreach (int[] reservedSeat in reservedSeats)
        {
            int row = reservedSeat[0];
            int seat = reservedSeat[1];

            if (seat == 1 || seat == 10)
                continue;

            int reservedBlockInRow = (seat - 2) / 2;

            reservedBlocks.TryGetValue(row, out bool[] rowReservedBlocks);

            if (rowReservedBlocks == null)
            {
                rowReservedBlocks = new bool[BlocksPerRow];
                rowReservedBlocks[reservedBlockInRow] = true;
                reservedBlocks[row] = rowReservedBlocks;
                maxNumberOfFamilies--;
                continue;
            }

            if (rowReservedBlocks[RowBlocks.LeftMidle] && rowReservedBlocks[RowBlocks.MidleRight])
                continue;

            rowReservedBlocks[reservedBlockInRow] = true;

            if ((rowReservedBlocks[RowBlocks.Left] && rowReservedBlocks[RowBlocks.MidleRight]) 
                || (rowReservedBlocks[RowBlocks.LeftMidle] && rowReservedBlocks[RowBlocks.MidleRight])
                || (rowReservedBlocks[RowBlocks.LeftMidle] && rowReservedBlocks[RowBlocks.Right]))
            {
                maxNumberOfFamilies--;
                rowReservedBlocks[RowBlocks.LeftMidle] = true;
                rowReservedBlocks[RowBlocks.MidleRight] = true;
            }
        }

        return maxNumberOfFamilies;
    }

    static class RowBlocks
    {
        public const int Left = 0;
        public const int LeftMidle = 1;
        public const int MidleRight = 2;
        public const int Right = 3;
    }

}
