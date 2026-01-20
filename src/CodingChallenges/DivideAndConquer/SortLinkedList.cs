using ListNode = DataStructures.SinglyLinkedListNodeII;

namespace CodingChallenges.DivideAndConquer;

/// <summary>
/// Related   : Divide and Conquer, Linked List, Sorting, Merge Sort
/// Title     : 148. Sort List
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/sort-list
/// Approachs : Divide and Conquer
/// </summary>
public class SortLinkedList // ChatGPT
{
    public static ListNode SortList(ListNode head)
    {
        if (head == null || head.next == null) return head;

        // Divide a lista em duas metades
        ListNode mid = GetMid(head);
        ListNode left = SortList(head);
        ListNode right = SortList(mid);

        // Faz merge das duas metades ordenadas
        return Merge(left, right);
    }

    private static ListNode GetMid(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;
        ListNode prev = null;

        while (fast?.next != null)
        {
            prev = slow;
            slow = slow.next;
            fast = fast.next.next;
        }

        // corta a lista no meio
        prev.next = null;
        return slow;
    }

    private static ListNode Merge(ListNode l1, ListNode l2)
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
