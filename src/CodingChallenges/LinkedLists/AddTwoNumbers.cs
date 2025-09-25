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
        public SinglyLinkedListNode addTwoNumbers(SinglyLinkedListNode l1, SinglyLinkedListNode l2)
        {
            var resultPointer = new SinglyLinkedListNode(0);

            var previous = resultPointer;
            var accumulated = 0;
            while (l1 != null || l2 != null)
            {
                var num = (l1?.data ?? 0) + (l2?.data ?? 0) + accumulated;

                accumulated = num / 10;
                var current = new SinglyLinkedListNode(num % 10);
                previous.next = current;
                previous = current;
                l1 = l1?.next;
                l2 = l2?.next;
            }

            if (accumulated != 0)
            {
                var current = new SinglyLinkedListNode(accumulated);
                previous.next = current;
            }

            return resultPointer.next;
        }

        public SinglyLinkedListNode addTwoNumbers_Leetcode(SinglyLinkedListNode l1, SinglyLinkedListNode l2)
        {
            SinglyLinkedListNode dummyHead = new SinglyLinkedListNode(0);
            SinglyLinkedListNode p = l1, q = l2, curr = dummyHead;
            int carry = 0;
            while (p != null || q != null)
            {
                int x = (p != null) ? p.data : 0;
                int y = (q != null) ? q.data : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                curr.next = new SinglyLinkedListNode(sum % 10);
                curr = curr.next;
                if (p != null) p = p.next;
                if (q != null) q = q.next;
            }
            if (carry > 0)
            {
                curr.next = new SinglyLinkedListNode(carry);
            }
            return dummyHead.next;
        }

        // outra versão que fiz de cabeça 2025-01-19
        public SinglyLinkedListNode AddTwoNumbers_(SinglyLinkedListNode l1, SinglyLinkedListNode l2)
        {
            var cn1 = l1;
            var cn2 = l2;

            var resultHolder = new SinglyLinkedListNode(0, null);
            var cnr = resultHolder;
            int carry = 0;

            while (cn1 != null && cn2 != null)
            {
                int newValue = cn1.data + cn2.data + carry;
                cnr.next = new SinglyLinkedListNode(newValue % 10, null);
                carry = newValue / 10;
                cn1 = cn1.next;
                cn2 = cn2.next;
                cnr = cnr.next;
            }

            var cn = cn1 ?? cn2;
            while (cn != null)
            {
                int newValue = cn.data + carry;
                cnr.next = new SinglyLinkedListNode(newValue % 10, null);
                carry = newValue / 10;
                cn = cn.next;
                cnr = cnr.next;
            }

            if (carry > 0)
                cnr.next = new SinglyLinkedListNode(carry, null);

            return resultHolder.next;
        }

    }
}
