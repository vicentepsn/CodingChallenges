namespace CodingChallenges.Maths;

/// <summary>
/// Groups    : Math
/// Title     : 50. Pow(x, n)
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/sqrtx
/// Approach  : Binary Search
/// </summary>
public class Pow_x_y
{
    public double MyPow(double x, int n) // CG
    {
        if (n == 0) return 1.0;

        long exp = n; // usar long para evitar overflow quando n = int.MinValue
        if (exp < 0)
        {
            x = 1 / x;
            exp = -exp;
        }

        double result = 1.0;
        double current = x;

        while (exp > 0)
        {
            if ((exp % 2) == 1)
            {
                result *= current;
            }
            current *= current;
            exp /= 2;
        }

        return result;
    }
}
