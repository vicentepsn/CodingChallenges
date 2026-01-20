namespace CodingChallenges.Strings;

/// <summary>
/// Related   : String, Stack
/// Title     : 20. Valid Parentheses
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/valid-parentheses
/// Approachs : -
/// </summary>
public class ValidParentheses
{
    // Leetcode: Beats 44.13% / 70.11%
    public bool IsValid(string s)
    {
        if (s.Length == 1) return false;

        var closeToOpenMap = new Dictionary<char, char> {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };
        // HashSet<char> openParenteses = ['(', '[', '}'];

        Stack<char> openParentheses = [];

        foreach (char parenthese in s)
        {
            // if (openParenteses.Contains(parenthese))
            if (parenthese == '(' || parenthese == '[' || parenthese == '{')
                openParentheses.Push(parenthese);
            else
            {
                if (openParentheses.Count > 0 && closeToOpenMap[parenthese] == openParentheses.Peek())
                    openParentheses.Pop();
                else
                    return false;
            }
        }

        return openParentheses.Count == 0;
    }

    // Leetcode: Beats 84.38% / 15.19%
    public bool IsValid_v2(string s)
    {
        if (s.Length == 1) return false;

        Stack<char> openParentheses = [];

        foreach (char parenthese in s)
        {
            if (parenthese == '(' || parenthese == '[' || parenthese == '{')
                openParentheses.Push(parenthese);
            else
            {
                if (openParentheses.Count > 0 && (
                    (parenthese == ')' && openParentheses.Peek() == '(')
                    || (parenthese == ']' && openParentheses.Peek() == '[')
                    || (parenthese == '}' && openParentheses.Peek() == '{')))
                    openParentheses.Pop();
                else
                    return false;
            }
        }

        return openParentheses.Count == 0;
    }
}
