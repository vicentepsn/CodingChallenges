using System;
using System.Collections.Generic;

namespace CodingChallenges.Strings
{
    /// <summary>
    /// Related   : String, Dynamic Programming, stack
    /// Title     : 32. Longest Valid Parentheses
    /// Difficult : Hard
    /// Link      : https://leetcode.com/problems/longest-valid-parentheses/
    /// Companies : Microsoft (entrevista 2023-03-31)
    /// </summary>
    public static class LongestValidBracketsClass
    {
        public class BracketsBlock
        {
            public int OpenedCount;
            public int ClosedCount;
        }

        // T:O(n) / S:O(1) => leetcode user solution
        public static int LongestValidBrackets(string s)
        {
            int left = 0;
            int right = 0;
            int ans = 0;
            int n = s.Length;
            for (int i = 0; i < n; i++)
            {
                if (s[i] == '(') 
                    left++;
                else 
                    right++;

                if (left == right) 
                    ans = Math.Max(ans, right * 2);
                else if (right > left) 
                    left = right = 0;
            }
            left = right = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (s[i] == ')') 
                    right++;
                else 
                    left++;
                if (left == right) 
                    ans = Math.Max(ans, right * 2);
                else if (left > right) 
                    left = right = 0;
            }
            return ans;
        }

        // T:O(n) / S:O(n) => my solition
        public static int LongestValidBrackets2(string s)
        {
            const char openBracket = '(';
            const char closeBracket = ')';

            int idx = 0;
            int longestSoFar = 0;
            Stack<BracketsBlock> stack = new Stack<BracketsBlock>();

            while (idx < s.Length)
            {
                if (stack.Count == 1 && stack.Peek().OpenedCount == 0 && s[idx] == closeBracket)
                {
                    stack.Pop();
                    idx++;
                }
                while (idx < s.Length && stack.Count == 0 && s[idx] == closeBracket)
                    idx++;

                if (idx == s.Length)
                    break;

                BracketsBlock bracketsBlock = new BracketsBlock();
                while (idx < s.Length && s[idx] == openBracket)
                {
                    bracketsBlock.OpenedCount++;
                    idx++;
                }

                stack.Push(bracketsBlock);

                if (idx == s.Length)
                    break;

                while (idx < s.Length && s[idx] == closeBracket && stack.Count > 0 && stack.Peek().OpenedCount > 0)
                {
                    bracketsBlock = stack.Pop();

                    while (idx < s.Length && s[idx] == closeBracket && bracketsBlock.OpenedCount > 0)
                    {
                        bracketsBlock.OpenedCount--;
                        bracketsBlock.ClosedCount++;
                        idx++;
                    }

                    if (stack.Count > 0 && bracketsBlock.OpenedCount == 0 && bracketsBlock.ClosedCount > 0)
                    {
                        var peek = stack.Peek();
                        peek.ClosedCount += bracketsBlock.ClosedCount;
                    }
                    else
                    {
                        stack.Push(bracketsBlock);
                    }

                    longestSoFar = Math.Max(longestSoFar, stack.Peek().ClosedCount * 2);
                }
            }

            return longestSoFar;
        }



        // This function does NOT work
        private static int longestValidBrackets(string s, int idx, int openedBrackets, int longestSoFar, int longestInBlock, bool lastWasValid)
        {
            if (idx == s.Length)
                return 0;

            //char c = s[position];

            while (idx < s.Length && s[idx] == '(')
            {
                openedBrackets++;
                idx++;
                //c = s[position];
            }
            if (idx == s.Length)
                return 0;

            while (idx < s.Length && s[idx] == ')' && openedBrackets > 0)
            {
                openedBrackets--;
                longestInBlock += 2;
                idx++;
            }

            while (idx < s.Length && s[idx] == ')')
                idx++;

            if (idx == s.Length)
                return longestInBlock;

            longestSoFar = Math.Max(longestSoFar, longestInBlock);

            //int newOpenedBrackets;
            //int newLongestSoFar;
            int newLongestInBlock = openedBrackets > 0 ? longestInBlock : 0;

            //bool lastWasValid
            //if (c == '(')
            //    return Math.Max(longestSoFar, longestValidBrackets(s, idx + 1, openedBrackets + 1, longestSoFar, longestInBlock, lastWasValid));

            if (openedBrackets == 0)
            {
                if (!lastWasValid)
                    longestInBlock = 0;
                return Math.Max(longestSoFar, longestValidBrackets(s, idx + 1, 0, longestSoFar, longestInBlock, false));
            }

            longestInBlock++;
            longestSoFar = Math.Max(longestSoFar, longestInBlock);

            openedBrackets--;
            return Math.Max(longestSoFar, longestValidBrackets(s, idx + 1, openedBrackets, longestSoFar, longestInBlock, true));

        }

        // This function does NOT work
        public static int LongestValidParentheses(string s)
        {
            int left = 0;
            int index = 0;

            int openedCounter = 0;

            int maxValid = 0;
            int currentMax = 0;
            int lastValidClosedIdx = -1;
            int openedCounterBeforeLastValidClosed = 0;

            while (index < s.Length)
            {
                char c = s[index];
                if (c == '(')
                {
                    openedCounter++;
                }
                else
                {
                    if (openedCounter > 0)
                    {
                        openedCounter--;
                        currentMax = index + 1 - left - openedCounter;
                        maxValid = Math.Max(maxValid, currentMax);

                        lastValidClosedIdx = index;
                        openedCounterBeforeLastValidClosed = openedCounter;
                    }
                    else
                    {
                        currentMax = index - left - openedCounter;
                        maxValid = Math.Max(maxValid, currentMax);
                        left = index + 1;
                    }
                }
                index++;
            }

            currentMax = index - left - openedCounter;
            maxValid = Math.Max(maxValid, currentMax);

            return maxValid;
        }

    }
}
