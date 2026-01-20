namespace CodingChallenges.Maths;

/// <summary>
/// Groups    : Math
/// Title     : 69. Sqrt(x)
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/sqrtx
/// Approach  : Binary Search
/// </summary>
public static class SquareRoot
{
    // O(log n)
    public static int MySqrt_ChatGPT(int x)
    {
        if (x <= 1) return x;

        int left = 1, right = x / 2, ans = 0;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            long sq = (long)mid * mid;

            if (sq == x) return mid;
            if (sq < x)
            {
                ans = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return ans;
    }
    
    // O(log n)
    public static int MySqrt_NewtonsMethod(int x) // ChatGPT
    {
        if (x == 0) return 0;

        long r = x; // usar long para evitar overflow
        while (r * r > x)
        {
            r = (r + x / r) / 2;
        }

        return (int)r;
    }


    public static int CalcSquareRoot(int number)
    {
        if (number < 2) return number;

        int left = 2;
        int right = number / 2;
        int pivot;
        long square; // use long to store result of pivot * pivot to prevent overflow

        while (left <= right) // binary search for the square root
        {
            pivot = left + (right - left) / 2;
            square = (long)pivot * pivot;

            if (square > number)
            {
                right = pivot - 1;
            }
            else if (square < number)
            {
                left = pivot + 1;
            }
            else
            {
                return pivot;
            }
        }

        return right;
    }

    public static int mySqrt(int x)
    {
        if (x < 2)
            return x; // return x if it is 0 or 1

        int left = 2, right = x / 2; // initialize left and right pointers
        int pivot;
        long num; // use long to store result of pivot * pivot to prevent overflow
        while (left <= right)
        { // binary search for the square root
            pivot = left + (right - left) / 2; // find the middle element
            num = (long)pivot * pivot;
            if (num > x)
                right = pivot - 1; // if pivot * pivot is greater than x, set right to pivot - 1
            else if (num < x)
                left = pivot + 1; // if pivot * pivot is less than x, set left to pivot + 1
            else
                return pivot; // if pivot * pivot is equal to x, return pivot
        }

        return right; // return right after the loop
    }
}

/*
Solution
We can follow the Binary Search approach to calculate the square root of an integer 'x' without using any in-built sqrt function.

Since the floor of the square root of a number x lies between 0 and x/2 for all x > 1, we can use binary search within this range to find the square root. 
The integer part (i.e., the floor) of the square root will be the final result.

Walk-through of the algorithm
Now let's walk through the code:

We first handle the base case. If the input number 'x' is less than 2, we return 'x' itself because the square root of 0 is 0 and the square root of 1 is 1.

Then, we initialize two pointers, 'left' and 'right'. The 'left' pointer is set to 2 and the 'right' pointer is set to x/2. These pointers define the range within which we will search for the square root.

We then enter a while loop, which continues until 'left' is less than or equal to 'right'.

In each iteration, we calculate the 'pivot' which is the middle element between 'left' and 'right'. The 'pivot' essentially represents our current guess for the square root.

We calculate 'num', which is the square of the 'pivot'. Since squaring a number can lead to overflow for large numbers, we use a 'long' data type for 'num'.

Next, we compare 'num' with 'x':

If 'num' is greater than 'x', it means our 'pivot' is too large. So, we reduce our 'right' pointer to 'pivot - 1' to search in the lower half.

If 'num' is less than 'x', it means our 'pivot' is too small. So, we increase our 'left' pointer to 'pivot + 1' to search in the upper half.

If 'num' equals 'x', it means we've found the exact square root, so we return 'pivot'.

If we exit the while loop without returning (which means we didn't find an exact square root), we return 'right' as our final result, which will be the largest integer less than or equal to the square root of 'x'. 

Time Complexity
The time complexity of the algorithm is O(logN) where N is the input number X because it uses binary search to find the square root.

Space Complexity
The space complexity is O(1) because it only uses a few variables to store the pointers (left, right, pivot, and num), and the size of these variables does not grow with the input size. 
*/