using ListNode = DataStructures.SinglyLinkedListNodeII;

namespace CodingChallenges.Heap;

/// <summary>
/// Related   : Heap, Divide and Conquer, Linked List, Merge Sort
/// Title     : 23. Merge k Sorted Lists
/// Difficult : Hard
/// Link      : https://leetcode.com/problems/merge-k-sorted-lists
/// Approachs : Heap
/// ATENTION  : VER VERSÃO "Divide and Conquer" NA PASTA "DivideAndConquer" (mais rápida)
/// </summary>
public class MergeKSortedLists
{
    // O(N\log k) / O(k)
    // Leetcode: Beats 63.79% / 38.52%
    public ListNode MergeKLists(ListNode[] lists) // ChatGPT
    {
        if (lists == null || lists.Length == 0) return null;

        // Min-Heap (PriorityQueue disponível em .NET 6+)
        var pq = new PriorityQueue<ListNode, int>();

        foreach (var node in lists)
        {
            if (node != null)
            {
                pq.Enqueue(node, node.val);
            }
        }

        ListNode dummy = new ListNode();
        ListNode tail = dummy;

        while (pq.Count > 0)
        {
            var smallest = pq.Dequeue();
            tail.next = smallest;
            tail = tail.next;

            if (smallest.next != null)
            {
                pq.Enqueue(smallest.next, smallest.next.val);
            }
        }

        return dummy.next;
    }
}
/*
 - Complexidade:
- Tempo: O(N\log k), pois cada inserção/remoção na heap custa \log k.
- Espaço: O(k) para armazenar os ponteiros na heap.
*/