namespace CodingChallenges.Backtracking;

/// <summary>
/// Related   : Backtracking, Array
/// Title     : 77. Combinations
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/combinations
/// Approachs : Backtracking
/// </summary>
public class Combinations // CG
{
    public IList<IList<int>> Combine(int n, int k)
    {
        var result = new List<IList<int>>();
        var current = new List<int>();
        Backtrack(1, n, k, current, result);
        return result;
    }

    private void Backtrack(int start, int n, int k, List<int> current, List<IList<int>> result)
    {
        if (current.Count == k)
        {
            result.Add([.. current]);
            return;
        }

        for (int i = start; i <= n; i++)
        {
            current.Add(i);
            Backtrack(i + 1, n, k, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}
