using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenges.Stack
{
    /// <summary>
    /// Groups    : String, Stack
    /// Title     : 1249. Minimum Remove to Make Valid Parentheses
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/
    /// Approach  : 1 - Two Pointers, 2 - using stack
    /// </summary>
    public static class MinRemoveToMakeValidParentheses
    {
        // Faster solution ***
        public static string MinRemoveToMakeValid(string s)
        {
            var stack = new Stack<int>();

            var indexesToRemove = new Queue<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else if (s[i] == ')')
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        indexesToRemove.Enqueue(i);
                    }
                }
            }
            
            var removeFromStack = new Stack<int>(stack.Count);
            while(stack.Count > 0)
                removeFromStack.Push(stack.Pop());

            var resultString = new StringBuilder(s.Length);
            var left = 0;
            while (removeFromStack.Count > 0 || indexesToRemove.Count > 0)
            {
                var valueFromStack = removeFromStack.Count > 0 ? removeFromStack.Peek() : int.MaxValue;
                var valueFromQueue = indexesToRemove.Count > 0 ? indexesToRemove.Peek() : int.MaxValue;
                
                var right = (valueFromStack < valueFromQueue) ? removeFromStack.Pop() : indexesToRemove.Dequeue();
                var length = right - left;
                if (length > 0)
                    resultString.Append(s.Substring(left, length));

                left = right + 1;
            }

            if (left < s.Length)
                resultString.Append(s.Substring(left));

            return resultString.ToString();
        }

        public static string MinRemoveToMakeValid_DO_NOT_WORK(string s)
        {
            var leftPointer = 0;
            var rightPointer = s.Length - 1;

            var removeFromLeft = new Queue<int>(s.Length / 2);
            var removeFromRight = new Stack<int>(s.Length / 2);

            var resultString = new StringBuilder(s.Length);

            while (leftPointer < rightPointer)
            {
                if (s[leftPointer] == '(' && s[rightPointer] == ')') 
                {
                    leftPointer++;
                    rightPointer--;
                    continue;
                }

                if (s[leftPointer] != '(')
                {
                    if (s[leftPointer] == ')')
                        removeFromLeft.Enqueue(leftPointer);

                    leftPointer++;
                }

                if (s[rightPointer] != ')')
                {
                    if (s[rightPointer] == '(')
                        removeFromRight.Push(rightPointer);

                    rightPointer--;
                }
            }

            if (s[leftPointer] == '(')
                removeFromLeft.Enqueue(leftPointer);

            if (s[rightPointer] == ')')
                removeFromRight.Push(rightPointer);

            var left = 0;

            while (removeFromLeft.Count > 0)
            {
                var right = removeFromLeft.Dequeue();
                var length = right - left;
                if (length > 0)
                    resultString.Append(s.Substring(left, length));

                left = right + 1;
            }

            while (removeFromRight.Count > 0)
            {
                var right = removeFromRight.Pop();
                var length = right - left;
                if (length > 0)
                    resultString.Append(s.Substring(left, length));

                left = right + 1;
            }

            if (left < s.Length)
                resultString.Append(s.Substring(left));

            return resultString.ToString();
        }


        public static string MinRemoveToMakeValid_usingStack(string s)
        {
            var stack = new Stack<int>();

            string[] strArray = s.Select(x => x.ToString()).ToArray();

            for (int i = 0; i < s.Length; i++)
            {
                if (strArray[i] == "(")
                {
                    stack.Push(i);
                }
                else if (strArray[i] == ")")
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        strArray[i] = "";
                    }
                }
            }

            while (stack.Count > 0)
            {
                int index = stack.Pop();
                strArray[index] = "";
            }

            return string.Join("", strArray);
        }
    }
}
