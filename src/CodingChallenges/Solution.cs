using System;
using System.Collections.Generic;

//namespace CodingChallenges
//{
public class Solution
{
    // Coding challange from Microsoft(2023-04)
    public int solution(int[] A)
    {
        int n = A.Length;
        int idx = 0;
        int number = 1;

        while (idx < n)
        {
            if (A[idx] == number)
            {
                idx++;
                number++;
            }
            else if (A[idx] <= 0 || A[idx] > n || A[idx] == A[A[idx] - 1])
            {
                A[idx] = A[--n];
            }
            else
            {
                int temp = A[A[idx] - 1];
                A[A[idx] - 1] = A[idx];
                A[idx] = temp;
            }

        }

        return number;
    }

    // Coding challange from Microsoft(2023-04)
    public int solution1(int[] A)
    {
        int result = 0;
        Array.Sort(A);

        int left = 0;
        int right = 1;
        while (right < A.Length)
        {
            if (A[right] <= A[left] + 1)
            {
                result++;
                right++;
            }
            else
            {
                left = right;
                right++;
            }
        }

        return result;
    }

    /// <summary>
    /// Given an array of integers, find the minimum number of elements that must be removed, 
    /// so that every pair of remaining elements differ by more than one.
    /// Coding challange from Microsoft (2023-04)
    /// </summary>
    /// <param name="A"></param>
    /// <returns></returns>
    public int solution12(int[] A)
    {
        int result = 0;
        //Array.Sort(A);
        HashSet<int> set = new HashSet<int>(A.Length);

        //int left = 0;
        //int right = 1;
        foreach(int number in A)
        {
            if(set.Contains(number) || set.Contains(number + 1) || set.Contains(number - 1))
            {
                result++;
            }
            else
            {
                set.Add(number);
            }
        }

        return result;
    }

    // Coding challange from Microsoft (2023-04)
    public static char[] ShuffleWord(string word)
    {
        Random rnd = new Random();
        char[] result = new char[word.Length];
        List<int> availablePositions = new List<int>(word.Length);

        for(int i = 0; i < word.Length; i++)
            availablePositions.Add(i);
 
        foreach(char letter in word)
        {
            int idx = rnd.Next(availablePositions.Count);
            int position = availablePositions[idx];
            availablePositions[idx] = availablePositions[availablePositions.Count - 1];

            availablePositions.RemoveAt(availablePositions.Count - 1);

            result[position] = letter;
        }

        return result;
    }
}
//}
