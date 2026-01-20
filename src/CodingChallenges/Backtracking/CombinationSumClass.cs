namespace CodingChallenges.Backtracking;

/// <summary>
/// Related   : Backtracking, Array
/// Title     : 39. Combination Sum
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/combination-sum
/// Approachs : Backtracking
/// </summary>
public class CombinationSumClass
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var result = new List<IList<int>>();
        var current = new List<int>();
        Backtrack(candidates, target, 0, current, result);
        return result;
    }

    private void Backtrack(int[] candidates, int target, int start, List<int> current, List<IList<int>> result)
    {
        if (target == 0)
        {
            result.Add(new List<int>(current));
            return;
        }

        for (int i = start; i < candidates.Length; i++)
        {
            if (candidates[i] > target) continue; // otimização: não precisa explorar

            current.Add(candidates[i]);
            // como podemos usar o mesmo número várias vezes, passamos "i" novamente
            Backtrack(candidates, target - candidates[i], i, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}
