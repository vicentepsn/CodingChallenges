namespace CodingChallenges.Arrays;

/// <summary>
/// Groups    : Array, DP?, Greed?
/// Title     : 45. Jump Game II
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/jump-game-ii/
/// Approachs : -
/// </summary>
public class JumpGameII
{
    public int Jump(int[] nums)
    {
        int jumps = 0;
        int currentEnd = 0; // limite de alcance do salto atual
        int farthest = 0; // posição mais distante que conseguimos alcançar até agora

        for (int i = 0; i < nums.Length - 1; i++)
        {
            farthest = Math.Max(farthest, i + nums[i]);

            if (i == currentEnd)
            {
                jumps++;
                currentEnd = farthest;
            }
        }
        /*
- Iteramos pelo array (até o penúltimo índice):
    - Atualizamos farthest com o máximo entre o valor atual e i + nums[i].
    - Quando i chega em currentEnd, significa que precisamos dar um salto:
        - Incrementamos jumps.
        - Atualizamos currentEnd para farthest.
No final, jumps será o número mínimo de saltos
*/

        return jumps;
    }
}
/*
45. Jump Game II

You are given a 0-indexed array of integers nums of length n. You are initially positioned at index 0.

Each element nums[i] represents the maximum length of a forward jump from index i. In other words, 
if you are at index i, you can jump to any index (i + j) where:

0 <= j <= nums[i] and
i + j < n
Return the minimum number of jumps to reach index n - 1. The test cases are generated such that you can reach index n - 1.

 

Example 1:

Input: nums = [2,3,1,1,4]
Output: 2
Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.
Example 2:

Input: nums = [2,3,0,1,4]
Output: 2
 

Constraints:

1 <= nums.length <= 104
0 <= nums[i] <= 1000
It's guaranteed that you can reach nums[n - 1].
*/