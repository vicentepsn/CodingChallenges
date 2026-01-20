namespace CodingChallenges.Arrays;

/// <summary>
/// Groups: Arrays
/// Title: 11. Container With Most Water
/// Difficult: Medium
/// Link: https://leetcode.com/problems/container-with-most-water/
/// Approach: Two Pointers
/// </summary>
public class ContainerWithMostWater
{
    // Leetcode: Beats 99.54%
    public int MaxArea(int[] height)
    {
        int maxArea = 0;
        int left = 0;
        int right = height.Length - 1;

        while (left < right)
        {
            int minHeight = Math.Min(height[left], height[right]);
            int currWidth = right - left;
            int currArea = minHeight * currWidth;
            maxArea = Math.Max(maxArea, currArea);

            if (height[left] < height[right])
                left++;
            else
                right--;
        }

        return maxArea;
    }
}

// implementação antiga
public static class MaxArea
{
    // Leetcode: Beats 16.87%
    public static int GetMaxArea(int[] heights)
    {
        int left = 0,
            right = heights.Length - 1,
            maxArea = 0;

        while (left < right)
        {
            int minHeight = Math.Min(heights[right], heights[left]);
            int width = (right - left);
            int area = minHeight * width;

            maxArea = Math.Max(maxArea, area);

            if (heights[left] < heights[right])
            {
                int lastLeft = left;
                do
                {
                    left++;
                } while (left < right && heights[lastLeft] >= heights[left] + (left - lastLeft));
            }
            else
            {
                int lastRight = right;
                do
                {
                    right--;
                } while (left < right && heights[lastRight] >= heights[right] + (lastRight - right));
            }
        }

        return maxArea;
    }

}
