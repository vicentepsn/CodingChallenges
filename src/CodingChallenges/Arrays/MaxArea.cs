using System;

namespace CodingChallenges.Arrays
{
    /// <summary>
    /// Groups: Arrays
    /// Title: 11. Container With Most Water
    /// Difficult: Medium
    /// Link: https://leetcode.com/problems/container-with-most-water/
    /// Approach: Two Pointers
    /// </summary>
    public static class MaxArea
    {
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
                    } while (heights[lastLeft] >= heights[left] && left < right);
                }
                else
                {
                    int lastRight = right;
                    do
                    {
                        right--;
                    } while (heights[lastRight] >= heights[right] && left < right);
                }
            }

            return maxArea;
        }

    }
}
