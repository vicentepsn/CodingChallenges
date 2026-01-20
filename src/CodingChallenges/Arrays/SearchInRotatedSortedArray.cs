namespace CodingChallenges.Arrays;

/// <summary>
/// Groups    : Binary Search, Array
/// Title     : 33. Search in Rotated Sorted Array
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/search-in-rotated-sorted-array
/// Approachs : Binary Search
/// </summary>
public class SearchInRotatedSortedArray
{
    // O(max(k, log n)) => O(n) para buscar o K / O(1)
    // O(log n) usando a função FindRotationStart / O(1)
    // Leetcode: Beats 100.00% / 55.93%
    public int Search(int[] nums, int target)
    {
        int n = nums.Length;
        if (n == 1) return nums[0] == target ? 0 : -1;

        int rotationStart = FindRotationStart(nums);

        int left = 0;
        int right = n - 1;

        while (left <= right)
        {
            int midle = (left + right) / 2;
            int rotatedMidle = (midle + rotationStart) % n;

            if (nums[rotatedMidle] == target)
                return rotatedMidle;
            else if (nums[rotatedMidle] < target)
                left = midle + 1;
            else
                right = midle - 1;
        }

        return -1;
    }

    //private static int FindRotationStart_old(int[] nums)
    //{
    //    int rotationStart = 1;
    //    while (rotationStart < nums.Length && nums[rotationStart] > nums[rotationStart - 1])
    //        rotationStart++;
    //    return rotationStart;
    //}

    private static int FindRotationStart(int[] nums)
    {
        int n = nums.Length;
        if (nums[0] < nums[n - 1]) return 0;

        int left = 0;
        int right = n - 1;

        while (right - left > 1)
        {
            int midle = (right + left) / 2;

            if (nums[left] > nums[midle])
                right = midle;
            else
                left = midle;
        }

        return right;
    }

    public int Search_CGPT(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2; // igual a "(right + left) / 2"

            if (nums[mid] == target) return mid;

            // metade esquerda está ordenada
            if (nums[left] <= nums[mid])
            {
                if (target >= nums[left] && target < nums[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            // metade direita está ordenada
            else
            {
                if (target > nums[mid] && target <= nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }

        return -1;
    }
}
/*
🧩 Estratégia do método "Search_CGPT"
- O array é ordenado, mas pode estar rotacionado em algum ponto.
- Precisamos de O(log n) → usar Binary Search modificado.
- Ideia:
    1. Usamos busca binária normal.
    2. Em cada passo, verificamos qual metade está ordenada:
        - Se nums[left] <= nums[mid], então a metade esquerda está ordenada.
            - Se o target está dentro desse intervalo, buscamos à esquerda.
            - Caso contrário, buscamos à direita.
        - Caso contrário, a metade direita está ordenada.
            - Se o target está dentro desse intervalo, buscamos à direita.
            - Caso contrário, buscamos à esquerda.
*/