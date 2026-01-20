namespace CodingChallenges.Stack;

/// <summary>
/// Related   : Stack, Design
/// Title     : 155. Min Stack
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/min-stack
/// Approachs : -
/// Leetcode  : Beats 100.00% / 64.81%
/// </summary>
public class MinStack
{
    private readonly List<int> mins;
    private readonly List<int> stack;

    public MinStack()
    {
        mins = [];
        stack = [];
    }

    public void Push(int val)
    {
        stack.Add(val);
        mins.Add(mins.Count == 0 ? val : Math.Min(val, mins[mins.Count - 1]));
    }

    public void Pop()
    {
        stack.RemoveAt(stack.Count - 1);
        mins.RemoveAt(mins.Count - 1);
    }

    public int Top()
    {
        return stack[stack.Count - 1];
    }

    public int GetMin()
    {
        return mins[mins.Count - 1];
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */