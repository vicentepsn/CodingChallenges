using System.Collections.Generic;

namespace CodingChallenges.DynamicProgramming
{
    /// <summary>
    /// Groups: Math, Dynamic Programming DP, Recursion
    /// Title: 509. Fibonacci Number
    /// Difficult: easy
    /// Link: https://leetcode.com/problems/fibonacci-number/
    /// Approach: Memorization
    /// </summary>
    public class Fibonacci
    {
        // Complexity: T = O(N), S = O(1)
        public static long CalcFibonacci(int n)
        {
            if (n <= 1)
                return n;

            var queue = new Queue<long>(2);
            queue.Enqueue(0);
            queue.Enqueue(1);

            for (int i = 2; i < n; i++)
                queue.Enqueue(queue.Dequeue() + queue.Peek());

            return queue.Dequeue() + queue.Dequeue();
        }

        // Complexity: T = O(N), S = O(N)
        public static int CalcFibonacci_2(int n)
        {
            if (n <= 1)
                return n;

            var results = new int[n];
            results[0] = 0;
            results[1] = 1;

            for (int i = 2; i < n; i++)
                results[i] = results[i - 1] + results[i - 2];

            return results[n - 1] + results[n - 2];
        }

        // Complexity: T/S = O(2^n) (exponential)
        public static int CalcFibonacci_Recursive(int n)
        {
            if (n <= 1)
                return n;

            return CalcFibonacci_Recursive(n - 1) + CalcFibonacci_Recursive(n - 2);
        }
    }
}
