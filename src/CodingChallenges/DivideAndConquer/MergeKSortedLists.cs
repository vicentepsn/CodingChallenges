using ListNode = DataStructures.SinglyLinkedListNodeII;

namespace CodingChallenges.DivideAndConquer;

/// <summary>
/// Related   : Divide and Conquer, Heap, Linked List, Merge Sort
/// Title     : 23. Merge k Sorted Lists
/// Difficult : Hard
/// Link      : https://leetcode.com/problems/merge-k-sorted-lists
/// Approachs : Divide and Conquer
/// ATENTION  : VER VERSÃO COM HEAP NA PASTA "Heap" (mais lenta)
/// </summary>
public class MergeKSortedLists
{
    // O(N\log k) / O(k)
    // Leetcode: Beats 98.22% / 77.40%
    public ListNode MergeKLists(ListNode[] lists) // CG
    {
        if (lists == null || lists.Length == 0) return null;
        return MergeLists(lists, 0, lists.Length - 1);
    }

    private ListNode MergeLists(ListNode[] lists, int left, int right)
    {
        if (left == right) return lists[left];
        int mid = left + (right - left) / 2;
        ListNode l1 = MergeLists(lists, left, mid);
        ListNode l2 = MergeLists(lists, mid + 1, right);
        return MergeTwoLists(l1, l2);
    }

    private ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
        ListNode dummy = new ListNode();
        ListNode tail = dummy;

        while (l1 != null && l2 != null)
        {
            if (l1.val < l2.val)
            {
                tail.next = l1;
                l1 = l1.next;
            }
            else
            {
                tail.next = l2;
                l2 = l2.next;
            }
            tail = tail.next;
        }

        tail.next = (l1 != null) ? l1 : l2;
        return dummy.next;
    }
}
/*
🔎 Observações
- Essa versão é divide and conquer, semelhante ao merge sort.
- Complexidade:
- Tempo: O(N\log k).
- Espaço: O(\log k) devido à recursão.
- É uma alternativa elegante à solução com min-heap.
*/