using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.Arrays
{
    public static class SquaringASortedArray
    {
        // iterate from the center
        public static int[] MakeSquares(int[] arr)
        {
            int n = arr.Length;
            int[] squares = new int[n];

            int right = 0;
            while (arr[right] < 0) // find first positive number
                right++;

            int left = right - 1;

            int position = 0;

            while (left >= 0 && right < arr.Length)
            {
                if (Math.Abs(arr[left]) < Math.Abs(arr[right]))
                {
                    squares[position++] = arr[left] * arr[left--];
                }
                else
                    squares[position++] = arr[right] * arr[right++];
            }
            while (left >= 0)
            {
                squares[position++] = arr[left] * arr[left--];
            }
            while (right < arr.Length)
            {
                squares[position++] = arr[right] * arr[right++];
            }

            return squares;
        }

        // iterate from the corners
        public static int[] makeSquares(int[] arr)
        {
            int n = arr.Length;
            int[] squares = new int[n];

            int right = n - 1;
            int left = 0;

            int position = right;

            while (left <= right)
            {
                if (Math.Abs(arr[left]) > Math.Abs(arr[right]))
                {
                    squares[position--] = arr[left] * arr[left++];
                }
                else
                    squares[position--] = arr[right] * arr[right--];
            }

            return squares;
        }


    }
}
