namespace CodingChallenges.Arrays;

/// <summary>
/// Groups    : Array, DP?, Greed?
/// Title     : 55. Jump Game
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/jump-game/description
/// Approachs : -
/// </summary>
public class JumpGame
{
    // O(n) / O(1)
    public bool CanJump(int[] nums)
    {
        int jumps = 0;
        int n = nums.Length;
        for (int i = 0; i < n - 1; i++)
        {
            //if (nums[i] >= n - 2) // Caso eu encontre algum que já alcance o final e queira já parar o loop
            //    return true;
            jumps = Math.Max(jumps, nums[i]);
            if (jumps == 0)
                return false;
            jumps--;
        }
        return true;
    }

}
/*
55. Jump Game

You are given an integer array nums. You are initially positioned at the array's first index, and each element in the 
array represents your maximum jump length at that position.

Return true if you can reach the last index, or false otherwise.

 

Example 1:

Input: nums = [2,3,1,1,4]
Output: true
Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
Example 2:

Input: nums = [3,2,1,0,4]
Output: false
Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.
 

Constraints:

1 <= nums.length <= 104
0 <= nums[i] <= 105

 */