using ListNode = DataStructures.SinglyLinkedListNodeII;

namespace CodingChallenges.LinkedLists;

/// <summary>
/// Groups    : LinkedList
/// Title     : 61. Rotate List
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/rotate-list
/// Approach  : -
/// </summary>
public class RotateList
{
    // Leetcode: Beats 100.00% / 29.49%
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head == null || head.next == null || k == 0) return head;

        int count = 1;

        ListNode currNode = head;
        for (; currNode.next != null; count++)
            currNode = currNode.next;

        k = k % count;
        if (k == 0) return head;

        ListNode tail = currNode;
        tail.next = head;

        currNode = head;
        for (int position = 0; position < count - k - 1; position++)
            currNode = currNode.next;

        head = currNode.next;
        currNode.next = null;

        return head;
    }
}
