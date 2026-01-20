using System.Text;

namespace CodingChallenges.Strings;

/// <summary>
/// Related   : Stack, Math, String, Recursion
/// Title     : 224. Basic Calculator
/// Difficult : Hard
/// Link      : https://leetcode.com/problems/basic-calculator
/// Approachs : -
/// </summary>
public class BasicCalculator
{
    // Leetcode: Beats 100.00% / 58.06%
    public int Calculate_ChatGPT(string s)
    {
        int result = 0;
        int sign = 1; // 1 para positivo, -1 para negativo
        int num = 0;
        Stack<int> stack = new();

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (char.IsDigit(c))
            {
                num = num * 10 + (c - '0');
            }
            else if (c == '+')
            {
                result += sign * num;
                num = 0;
                sign = 1;
            }
            else if (c == '-')
            {
                result += sign * num;
                num = 0;
                sign = -1;
            }
            else if (c == '(')
            {
                // Guardar o resultado atual e o sinal
                stack.Push(result);
                stack.Push(sign);
                result = 0;
                sign = 1;
            }
            else if (c == ')')
            {
                result += sign * num;
                num = 0;

                // Recuperar sinal e resultado anterior
                int prevSign = stack.Pop();
                int prevResult = stack.Pop();
                result = prevResult + prevSign * result;
            }
            // ignorar espaços
        }

        if (num != 0)
        {
            result += sign * num;
        }

        return result;
    }

    // Leetcode: Beats 14.84% / 7.10%
    public static int Calculate(string s)
    {
        int idx = 0;
        int result = EvaluateParenteses(s, ref idx);
        return result;
    }

    private static int EvaluateParenteses(string s, ref int idx)
    {
        int result = 0;
        while (idx < s.Length && s[idx] != ')')
        {
            if (s[idx] == ' ' || s[idx] == '+')
            {
                idx++;
                continue;
            }

            if (s[idx] == '-' && char.IsDigit(GetNextNonSpaceChar(s, idx + 1)))
            {
                idx++;
                SkipSpaceChars(s, ref idx);
                int value = int.Parse($"-{GetNumber(s, ref idx)}");
                result += value;
            }
            else if (char.IsDigit(s[idx]))
            {
                int value = int.Parse(GetNumber(s, ref idx));
                result += value;
            }
            else if (s[idx] == '-' && GetNextNonSpaceChar(s, idx + 1) == '(')
            {
                idx++;
                SkipSpaceChars(s, ref idx);
                idx++;
                int value = -1 * EvaluateParenteses(s, ref idx);
                result += value;
            }
            else if (s[idx] == '(')
            {
                idx++;
                int value = EvaluateParenteses(s, ref idx);
                result += value;
            }
        }
        idx++;
        return result;
    }

    private static char GetNextNonSpaceChar(string s, int idx)
    {
        for (; idx < s.Length; idx++)
            if (s[idx] != ' ')
                return s[idx];
        return '\0';
    }
    private static void SkipSpaceChars(string s, ref int idx)
    {
        while (idx < s.Length && s[idx] == ' ')
            idx++;
    }

    private static string GetNumber(string s, ref int idx)
    {
        StringBuilder number = new();
        number.Append(s[idx++]);
        for (; idx < s.Length; idx++)
        {
            if (char.IsDigit(s[idx]))
                number.Append(s[idx]);
            else
                break;
        }

        return number.ToString();
    }

}
