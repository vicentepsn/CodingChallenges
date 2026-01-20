namespace CodingChallenges.DynamicProgramming;

/// <summary>
/// Groups    : Math
/// Title     : 70. Climbing Stairs
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/climbing-stairs
/// Approach  : -
/// </summary>
public class ClimbingStairs
{
    public static int ClimbStairs(int n) // ChatGPT - Não entendi
    {
        if (n <= 2) return n;

        int a = 1; // ways(1)
        int b = 2; // ways(2)

        for (int i = 3; i <= n; i++)
        {
            int c = a + b;
            a = b;
            b = c;
        }

        return b;
    }
}
