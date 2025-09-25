using System;

namespace CodingChallenges.Arrays;


/// <summary>
/// Groups: Arrays
/// Title: 42. Trapping Rain Water
/// Difficult: Hard
/// Link: https://leetcode.com/problems/trapping-rain-water/
/// Approach: Two Pointers
/// Companies: Amazon 49, Facebook 38, Goldman Sachs 36, Bloomberg 16, Microsoft 11, Google 7 (2022-04-27)
/// </summary>
public static class TrappingRainWater
{
    // O(n) / O(1)
    public static int Trap(int[] height)
    {
        if (height.Length <= 2)
            return 0;

        int left = 0;
        int right = height.Length - 1;

        int maxHeight = 0;

        var result = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] < maxHeight)
                    result += maxHeight - height[left];
                else
                    maxHeight = height[left];
                left++;
            }
            else
            {
                if (height[right] < maxHeight)
                    result += maxHeight - height[right];
                else
                    maxHeight = height[right];
                right--;
            }
        }

        return result;
    }

    public static int Trap2(int[] height)
    {
        int wather = 0;

        int left = 0;
        int right = height.Length - 1;

        int maxLeft = 0;
        int maxRight = 0;

        while (left < right)
        {
            if (height[left] <= height[right])
            {
                if (height[left] >= maxLeft)
                {
                    maxLeft = height[left];
                }
                else
                {
                    wather += maxLeft - height[left];
                }
                left++;
            }
            else
            {
                if (height[right] >= maxRight)
                {
                    maxRight = height[right];
                }
                else
                {
                    wather += maxRight - height[right];
                }
                right--;
            }
        }

        return wather;
    }

    public static int TrapOpt2(int[] height)
    {
        int wather = 0;

        int left = 0;
        int right = height.Length - 1;

        int maxLeft = height[left];
        int maxRight = height[right];

        while (left < right - 1)
        {
            if (maxLeft <= maxRight)
            {
                left++;
                while (height[left] <= maxLeft && left < right)
                {
                    wather += maxLeft - height[left];
                    left++;
                }
                maxLeft = height[left];
            }
            else
            {
                right--;
                while (height[right] <= maxRight && left < right)
                {
                    wather += maxRight - height[right];
                    right--;
                }
                maxRight = height[right];
            }
        }

        return wather;
    }

    public static int TrapOpt1(int[] height)
    {
        int wather = 0;

        if (height.Length < 3)
            return wather;

        int left = 0;
        int right = height.Length - 1;

        int maxLeft = height[left];
        int maxRight = height[right];
        int minHeigth = 0;

        while (left < right - 1)
        {
            int newHeigth = Math.Min(maxLeft, maxRight);
            int diffHeigth = newHeigth - minHeigth;

            int width = right - left - 1;
            wather += diffHeigth * width;

            minHeigth = newHeigth;

            if (height[left] <= height[right])
            {
                while(height[left] <= maxLeft && left < right - 1)
                {
                    left++;
                    int watherToRemove = Math.Min(minHeigth, height[left]);
                    wather -= watherToRemove;
                }
                maxLeft = height[left];
            }
            else
            {
                while(height[right] <= maxRight && left < right - 1)
                {
                    right--;
                    int watherToRemove = Math.Min(minHeigth, height[right]);
                    wather -= watherToRemove;
                }
                maxRight = height[right];
            }
        }

        return wather;
    }

    public static int Trap_BruteForce(int[] height)
    {
        int wather = 0;

        if (height.Length < 3)
            return wather;

        //int maxLeftIndex = 0;
        int maxLeft = height[0];
        int maxRightIndex = 1;
        int maxRight = height[maxRightIndex];

        for (int i = 1; i < height.Length - 1; i++)
        {
            if (maxLeft <= height[i])
            {
                maxLeft = height[i];
                continue;
            }
            if (maxRightIndex <= i)
            {
                maxRight = 0;
                for (int j = i + 1; j < height.Length; j++)
                {
                    if(height[j] >= maxRight)
                    {
                        maxRight = height[j];
                        maxRightIndex = j;
                    }
                }
            }
            
            if (maxRight == 0)
            {
                return wather;
            }
            
            wather += Math.Min(maxLeft, maxRight) - height[i];
        }

        return wather;
    }

    // sugerido pelo copilot
    public static int Trap_Optimized(int[] height)
    {
        int wather = 0;
        if (height.Length < 3)
            return wather;
        int maxLeftIndex = 0;
        int maxLeft = height[maxLeftIndex];
        int maxRightIndex = 1;
        int maxRight = height[maxRightIndex];
        for (int i = 1; i < height.Length - 1; i++)
        {
            if (maxLeft <= height[i])
            {
                maxLeft = height[i];
                maxLeftIndex = i;
                continue;
            }
            if (maxRightIndex <= i)
            {
                maxRight = 0;
                for (int j = i + 1; j < height.Length; j++)
                {
                    if (height[j] >= maxRight)
                    {
                        maxRight = height[j];
                        maxRightIndex = j;
                    }
                }
            }

            if (maxRight == 0)
            {
                return wather;
            }

            wather += Math.Min(maxLeft, maxRight) - height[i];
        }
        return wather;
    }

    // versão de cabeça 2025-01-19
    public static int Trap3(int[] height)
    {
        int n = height.Length;
        int left = 0;
        int right = n - 1;

        int maxTrap = Math.Min(height[left], height[right]);
        int wather = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                wather += maxTrap > height[left] ? maxTrap - height[left] : 0;
                maxTrap = Math.Max(height[left], maxTrap);
                left++;
            }
            else if (height[left] == height[right])
            {
                maxTrap = height[left];
                left++;
            }
            else
            {
                wather += maxTrap > height[right] ? maxTrap - height[right] : 0;
                maxTrap = Math.Max(maxTrap, height[right]);
                right--;
            }
        }

        return wather;
    }
}
