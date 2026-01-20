using DataStructures;
using ListNode = DataStructures.SinglyLinkedListNodeII;
using static CodingChallenges.LinkedLists.ReverseSinglyLinkedList;

namespace CodingChallenges.LinkedLists;

/// <summary>
/// Related   : Linked List, Math
/// Title     : 2. Add Two Numbers
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/add-two-numbers/
/// Companies : Amazon 39, Microsoft 23, Facebook 22, Bloomberg 16, Apple 15, Google 13 (2022-04-01)
/// </summary>
public class AddTwoNumbers
{
    // 2026-01-07 - de cabeça
    // Leetcode: Beats 90.23% / 30.31%
    public ListNode? addTwoNumbers(ListNode? l1, ListNode? l2)
    {
        if (l1 == null && l2 == null) return null;

        ListNode headPointer = new();
        ListNode prevNode = headPointer;
        int carry = 0;

        do
        {
            int value = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
            carry = value / 10;
            value = value % 10;

            ListNode currNode = new(value);
            prevNode.next = currNode;

            prevNode = currNode;
            l1 = l1?.next;
            l2 = l2?.next;
        } while (l1 != null || l2 != null);

        if (carry > 0)
        {
            ListNode currNode = new(carry);
            prevNode.next = currNode;
        }
        return headPointer.next;
    }

    // 2026-01-07 - de cabeça
    // Leetcode: Beats 90.23% / 57.14%
    public ListNode? addTwoNumbers__(ListNode? l1, ListNode? l2)
    {
        if (l1 == null && l2 == null) return null;

        int value = (l1?.val ?? 0) + (l2?.val ?? 0);
        int carry = value / 10;
        value = value % 10;

        ListNode head = new(value);
        ListNode currNode = head;

        l1 = l1?.next;
        l2 = l2?.next;

        while (l1 != null || l2 != null)
        {
            value = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
            carry = value / 10;
            value = value % 10;

            currNode.next = new(value);
            currNode = currNode.next;

            l1 = l1?.next;
            l2 = l2?.next;
        }

        if (carry > 0)
            currNode.next = new(carry);

        return head.next;
    }

    // Time complexity : O(max(m, n)). Assume that mm and nn represents the length of l1 and l2 respectively, the algorithm above iterates at most max(m,n) times.
    // Space complexity : O(max(m, n)). The length of the new list is at most max(m, n)+1.
    public ListNode addTwoNumbers_(ListNode l1, ListNode l2)
    {
        var resultPointer = new ListNode(0);

        var previous = resultPointer;
        var accumulated = 0;
        while (l1 != null || l2 != null)
        {
            var num = (l1?.val ?? 0) + (l2?.val ?? 0) + accumulated;

            accumulated = num / 10;
            var current = new ListNode(num % 10);
            previous.next = current;
            previous = current;
            l1 = l1?.next;
            l2 = l2?.next;
        }

        if (accumulated != 0)
        {
            var current = new ListNode(accumulated);
            previous.next = current;
        }

        return resultPointer.next;
    }

    public ListNode addTwoNumbers_Leetcode(ListNode l1, ListNode l2)
    {
        ListNode dummyHead = new ListNode(0);
        ListNode p = l1, q = l2, curr = dummyHead;
        int carry = 0;
        while (p != null || q != null)
        {
            int x = (p != null) ? p.val : 0;
            int y = (q != null) ? q.val : 0;
            int sum = carry + x + y;
            carry = sum / 10;
            curr.next = new ListNode(sum % 10);
            curr = curr.next;
            if (p != null) p = p.next;
            if (q != null) q = q.next;
        }
        if (carry > 0)
        {
            curr.next = new ListNode(carry);
        }
        return dummyHead.next;
    }

    // outra versão que fiz de cabeça 2025-01-19
    public ListNode AddTwoNumbers_(ListNode l1, ListNode l2)
    {
        var cn1 = l1;
        var cn2 = l2;

        var resultHolder = new ListNode(0, null);
        var cnr = resultHolder;
        int carry = 0;

        while (cn1 != null && cn2 != null)
        {
            int newValue = cn1.val + cn2.val + carry;
            cnr.next = new ListNode(newValue % 10, null);
            carry = newValue / 10;
            cn1 = cn1.next;
            cn2 = cn2.next;
            cnr = cnr.next;
        }

        var cn = cn1 ?? cn2;
        while (cn != null)
        {
            int newValue = cn.val + carry;
            cnr.next = new ListNode(newValue % 10, null);
            carry = newValue / 10;
            cn = cn.next;
            cnr = cnr.next;
        }

        if (carry > 0)
            cnr.next = new ListNode(carry, null);

        return resultHolder.next;
    }
}
