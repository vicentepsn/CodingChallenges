using DataStructures;

namespace CodingChallenges.LinkedLists
{
    /// <summary>
    /// Related   : Linked List, Math
    /// Title     : 2. Add Two Numbers
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/add-two-numbers/
    /// Companies : Amazon 39, Microsoft 23, Facebook 22, Bloomberg 16, Apple 15, Google 13 (2022-04-01)
    /// </summary>
    public class AddTwoNumbers
    {
        // Time complexity : O(max(m, n)). Assume that mm and nn represents the length of l1 and l2 respectively, the algorithm above iterates at most max(m,n) times.
        // Space complexity : O(max(m, n)). The length of the new list is at most max(m, n)+1.
        public ListNode addTwoNumbers(ListNode l1, ListNode l2)
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
    }
}
