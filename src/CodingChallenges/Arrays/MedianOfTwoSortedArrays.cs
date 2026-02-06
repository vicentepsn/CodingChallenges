namespace CodingChallenges.Arrays;

/// <summary>
/// Groups    : Binary Search, Divide and Conquer
/// Title     : 4. Median of Two Sorted Arrays
/// Difficult : Hard
/// Link      : https://leetcode.com/problems/median-of-two-sorted-arrays
/// Approach1 : Merge Sort (with two pointers) => O(n + m) / O(1)
/// Approach2 : Binary Search => O(log(min(m,n))) / O(1)
/// </summary>
public class MedianOfTwoSortedArrays
{
    // Leetcode: Beats 100.00% / 55.90%
    // Versão gerada pelo CG.. não me preocupei em tentar entender
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        // Garantir que nums1 seja a menor array
        if (nums1.Length > nums2.Length)
        {
            return FindMedianSortedArrays(nums2, nums1);
        }

        int m = nums1.Length;
        int n = nums2.Length;
        int totalLeft = (m + n + 1) / 2;

        int left = 0, right = m;

        while (left <= right)
        {
            int i = (left + right) / 2;   // partição em nums1
            int j = totalLeft - i;        // partição em nums2

            int nums1LeftMax = (i == 0) ? int.MinValue : nums1[i - 1];
            int nums1RightMin = (i == m) ? int.MaxValue : nums1[i];

            int nums2LeftMax = (j == 0) ? int.MinValue : nums2[j - 1];
            int nums2RightMin = (j == n) ? int.MaxValue : nums2[j];

            if (nums1LeftMax <= nums2RightMin && nums2LeftMax <= nums1RightMin)
            {
                // Encontramos a partição correta
                if ((m + n) % 2 == 1)
                {
                    return Math.Max(nums1LeftMax, nums2LeftMax);
                }
                else
                {
                    return (Math.Max(nums1LeftMax, nums2LeftMax) +
                            Math.Min(nums1RightMin, nums2RightMin)) / 2.0;
                }
            }
            else if (nums1LeftMax > nums2RightMin)
            {
                right = i - 1;
            }
            else
            {
                left = i + 1;
            }
        }

        throw new ArgumentException("Input arrays are not valid.");
    }

    //public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    //{
    //    var maxHeapSize = (nums1.Length + nums2.Length) / 2 + 1;
    //    var maxHeap = new IntPriorityQueue((a, b) => a.CompareTo(b), maxHeapSize);
    //    var minHeap = new IntPriorityQueue((a, b) => b.CompareTo(a), maxHeapSize);


    //    return 0;
    //}

}

// LeetCode version
public class MedianOfTwoSortedArrays_MergeSort // with tow pointers
{
    int p1 = 0, p2 = 0;

    private int GetMin(int[] nums1, int[] nums2)
    {
        if (p1 < nums1.Length && p2 < nums2.Length)
        {
            return nums1[p1] < nums2[p2] ? nums1[p1++] : nums2[p2++];
        }
        else if (p1 < nums1.Length)
        {
            return nums1[p1++];
        }
        else if (p2 < nums2.Length)
        {
            return nums2[p2++];
        }

        return -1;
    }

    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int m = nums1.Length, n = nums2.Length;
        if ((m + n) % 2 == 0)
        {
            for (int i = 0; i < (m + n) / 2 - 1; ++i)
            {
                int tmp = GetMin(nums1, nums2);
            }

            return (double)(GetMin(nums1, nums2) + GetMin(nums1, nums2)) / 2;
        }
        else
        {
            for (int i = 0; i < (m + n) / 2; ++i)
            {
                int tmp = GetMin(nums1, nums2);
            }

            return GetMin(nums1, nums2);
        }
    }
}
/*
Esse é um dos problemas mais clássicos de algoritmos: encontrar a mediana de duas arrays ordenadas em tempo O(log(m+n)).
A ideia é usar busca binária na menor array para particionar as duas arrays de forma que:
- Todos os elementos à esquerda da partição sejam menores ou iguais aos elementos à direita.
- Assim conseguimos calcular a mediana diretamente.

🔑 Explicação
- Usamos busca binária na menor array (nums1).
- i é a posição da partição em nums1, e j é a posição correspondente em nums2.
- Garantimos que os elementos à esquerda sejam menores ou iguais aos da direita.
- Se (m+n) for ímpar, a mediana é o maior elemento da esquerda.
- Se for par, é a média entre o maior da esquerda e o menor da direita.

⏱ Complexidade
- Tempo: O(log(min(m, n)))
- Espaço: O(1)

👉 Quer que eu também monte uma versão mais simples em O(m+n) (merge direto das arrays) para comparação, mesmo que não seja a solução ótima?
*/

