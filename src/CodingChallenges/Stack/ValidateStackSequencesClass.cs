using System.Collections.Generic;

namespace CodingChallenges.Stack
{
    /// <summary>
    /// Related   : Array, Stack, Simulation
    /// Title     : 946. Validate Stack Sequences
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/validate-stack-sequences/description/
    /// Companies : Amazon 3, Google 2, Microsoft 2 (2023-05)
    /// </summary>
    public static class ValidateStackSequencesClass
    {
        public static bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            Stack<int> stack = new Stack<int>(pushed.Length);

            int pushedIdx = 0;
            int poppedIdx = 0;

            while (pushedIdx < pushed.Length || stack.Count > 0)
            {
                if (pushedIdx < pushed.Length && pushed[pushedIdx] == popped[poppedIdx])
                {
                    pushedIdx++;
                    poppedIdx++;
                }
                else if (stack.Count > 0 && stack.Peek() == popped[poppedIdx])
                {
                    stack.Pop();
                    poppedIdx++;
                }
                else if (pushedIdx < pushed.Length)
                {
                    stack.Push(pushed[pushedIdx]);
                    pushedIdx++;
                }
                else
                    return false;
            }

            return true;
        }

    }
}
