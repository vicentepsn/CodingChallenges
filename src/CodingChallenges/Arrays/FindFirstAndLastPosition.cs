namespace CodingChallenges.Arrays;

/// <summary>
/// Groups    : Binary Search, Array
/// Title     : 34. Find First and Last Position of Element in Sorted Array
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array
/// Approachs : Binary Search
/// </summary>
public class FindFirstAndLastPosition // CG
{
    // O(max(k, log n)) => O(n) para buscar o K / O(1)
    // Leetcode: Beats 100.00% / 99.77%
    public static int[] SearchRange(int[] nums, int target)
    {
        int first = FindBound(nums, target, true);
        if (first == -1) return [-1, -1]; // não encontrado
        int last = FindBound(nums, target, false);
        return [first, last];
    }

    private static int FindBound(int[] nums, int target, bool isFirst) // encontrar limite (bound)
    {
        int left = 0, right = nums.Length - 1;
        int bound = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                bound = mid;
                if (isFirst)
                {
                    right = mid - 1; // continua procurando à esquerda
                }
                else
                {
                    left = mid + 1; // continua procurando à direita
                }
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return bound;
    }
}
/*
🧩 Estratégia
- Como o array está ordenado, podemos usar Binary Search para encontrar:
- O primeiro índice do target.
- O último índice do target.
- Isso garante complexidade O(log n).

🔎 Observações
- Complexidade:
- Tempo: O(log n) (duas buscas binárias).
- Espaço: O(1).
- Essa abordagem é robusta e funciona mesmo com arrays grandes (até 10^5 elementos).


 
 */