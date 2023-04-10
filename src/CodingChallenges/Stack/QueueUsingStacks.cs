using System.Collections.Generic;

namespace CodingChallenges.Stack
{
    internal class QueueUsingStacks
    {
    }

    /// <summary>
    /// Groups    : Queue, Stack
    /// Title     : 232. Implement Queue using Stacks
    /// Difficult : Easy
    /// Link      : https://leetcode.com/problems/implement-queue-using-stacks/
    /// Approach  : -
    /// </summary>
    public class MyQueue
    {

        private Stack<int> enqueueStack, dequeueStack;

        public MyQueue()
        {
            enqueueStack = new Stack<int>();
            dequeueStack = new Stack<int>();
        }

        public void Push(int x)
        {
            enqueueStack.Push(x);
        }

        public int Pop()
        {
            UpdateStack();
            return dequeueStack.Pop();
        }

        public int Peek()
        {
            UpdateStack();
            return dequeueStack.Peek();
        }

        public bool Empty()
        {
            return enqueueStack.Count == 0 && dequeueStack.Count == 0;
        }

        private void UpdateStack()
        {
            if (dequeueStack.Count == 0)
            {
                while (enqueueStack.Count > 0)
                    dequeueStack.Push(enqueueStack.Pop());
            }
        }
    }

    /**
     * Your MyQueue object will be instantiated and called as such:
     * MyQueue obj = new MyQueue();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Peek();
     * bool param_4 = obj.Empty();
     */
}
