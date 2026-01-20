namespace CodingChallenges.Maths;

/// <summary>
/// Groups    : Math, HashTable, Two Pointers
/// Title     : 202. Happy Number
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/happy-number
/// Approachs : -
/// </summary>
public class HappyNumber
{
    // Leetcode: Beats 61.27% / 27.40%
    public static bool IsHappy(int n)
    {
        HashSet<int> seen = [];
        int currValue = n;

        while (true)
        {
            int rest;
            int finalValue = 0;

            while (currValue > 0)
            {
                rest = currValue % 10;
                finalValue += (int)Math.Pow(rest, 2); // ou "rest * rest"
                currValue = currValue / 10;
            }

            if (finalValue == 1)
                return true;

            if (seen.Contains(finalValue))
                return false;

            seen.Add(finalValue);
            currValue = finalValue;
        }
    }

    // Leetcode: Beats 61.27% / 57.57%
    public static bool IsHappy_ChatGPT(int n)
    {
        HashSet<int> seen = [];

        while (n != 1 && !seen.Contains(n))
        {
            seen.Add(n);
            n = GetNext(n);
        }

        return n == 1;
    }

    private static int GetNext(int n)
    {
        int totalSum = 0;
        while (n > 0)
        {
            int digit = n % 10;
            totalSum += digit * digit;
            n /= 10;
        }
        return totalSum;
    }

}
