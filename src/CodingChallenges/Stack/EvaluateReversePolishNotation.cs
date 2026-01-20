namespace CodingChallenges.Stack;

/// <summary>
/// Related   : Stack, Math, Array
/// Title     : 150. Evaluate Reverse Polish Notation
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/evaluate-reverse-polish-notation
/// Approachs : -
/// </summary>
public class EvaluateReversePolishNotation
{
    // Leetcode  : Beats 59.03% / 19.74%
    public static int EvalRPN(string[] tokens)
    {
        if (tokens.Length == 1) return int.Parse(tokens[0]);

        Stack<int> numbers = [];

        foreach (string token in tokens)
        {
            if (token == "+")
                numbers.Push(numbers.Pop() + numbers.Pop());
            else if (token == "*")
                numbers.Push(numbers.Pop() * numbers.Pop());
            else if (token == "-")
            {
                int number = numbers.Pop();
                numbers.Push(numbers.Pop() - number);
            }
            else if (token == "/")
            {
                int number = numbers.Pop();
                numbers.Push(numbers.Pop() / number);
            }
            else
                numbers.Push(int.Parse(token));
        }

        return numbers.Pop();
    }

    // Leetcode  : Beats 73.06% / 73.34%
    public static int EvalRPN_v2(string[] tokens)
    {
        if (tokens.Length == 1) return int.Parse(tokens[0]);

        Stack<int> numbers = [];
        int lastNumber = 0;

        foreach (string token in tokens)
        {
            if (token == "+")
                lastNumber = lastNumber + numbers.Pop();
            else if (token == "*")
                lastNumber = lastNumber * numbers.Pop();
            else if (token == "-")
                lastNumber = numbers.Pop() - lastNumber;
            else if (token == "/")
                lastNumber = numbers.Pop() / lastNumber;
            else
            {
                numbers.Push(lastNumber);
                lastNumber = int.Parse(token);
            }
        }

        return lastNumber;
    }
}
