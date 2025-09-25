namespace CodingChallenges.Stack;

/// <summary>
/// Related   : Stack
/// Title     : Largest Rectangle
/// Difficult : Medium
/// Link      : https://www.hackerrank.com/challenges/largest-rectangle/problem
/// Companies : 
/// </summary>
public class LargestRetangle
{
    // O(n²)
    public static long largestRectangle_naive(List<int> h)
    {
        long maxArea = 0;
        for (int i = 0; i < h.Count; i++)
        {
            int currHeight = h[i];

            int left = i - 1;
            while (left >= 0 && h[left] >= currHeight)
                left--;

            int right = left + 1;
            while (right < h.Count && h[right] >= currHeight)
                right++;

            long currArea = currHeight * (right - left - 1);
            maxArea = Math.Max(maxArea, currArea);
        }
        return maxArea;
    }

    // O(n)
    public static long largestRectangle(List<int> h)
    {
        Stack<int> s = new Stack<int>();
        int maxArea = 0;

        for (int i = 0; i < h.Count;)
        {
            if (s.Count == 0 || h[s.Peek()] < h[i])
            {
                s.Push(i++);
            }
            else
            {
                int topIndex = s.Pop();

                int newArea = h[topIndex] * (s.Count == 0 ? i : i - s.Peek() - 1);

                maxArea = Math.Max(maxArea, newArea);
            }
        }

        while (s.Count != 0)
        {
            int topIndex = s.Pop();

            int newArea = h[topIndex] * (s.Count == 0 ? h.Count : h.Count - s.Peek() - 1);

            maxArea = Math.Max(maxArea, newArea);
        }

        return maxArea;
    }
}
