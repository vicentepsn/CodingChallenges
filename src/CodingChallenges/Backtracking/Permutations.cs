namespace CodingChallenges.Backtracking;

/// <summary>
/// Related   : Backtracking, Array
/// Title     : 47. Permutations
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/permutations
/// Approachs : Backtracking
/// </summary>
public class Permutations // ChatGPT
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var result = new List<IList<int>>();
        var current = new List<int>();
        var used = new bool[nums.Length];

        Backtrack(nums, used, current, result);
        return result;
    }

    private void Backtrack(int[] nums, bool[] used, List<int> current, List<IList<int>> result)
    {
        if (current.Count == nums.Length)
        {
            // adiciona uma cópia da permutação atual
            result.Add([.. current]);
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (used[i]) continue;

            // escolhe nums[i]
            used[i] = true;
            current.Add(nums[i]);

            // continua construindo
            Backtrack(nums, used, current, result);

            // desfaz a escolha
            current.RemoveAt(current.Count - 1);
            used[i] = false;
        }
    }
}
