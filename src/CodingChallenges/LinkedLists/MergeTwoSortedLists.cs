using DataStructures;

namespace CodingChallenges.LinkedLists
{
    /// <summary>
    /// Related   : Linked List, Math
    /// Title     : 21. Merge Two Sorted Lists
    /// Difficult : Easy
    /// Link      : https://leetcode.com/problems/merge-two-sorted-lists/
    /// Companies : Amazon 20, Adobe 12, Microsoft 12, Facebook 12, Apple 4, Bloomberg 4, Google 3
    /// </summary>
    public class MergeTwoSortedLists
    {
        // Time complexity : O(n + m) Because exactly one of l1 and l2 is incremented on each loop iteration,
        //      the while loop runs for a number of iterations equal to the sum of the lengths of the two lists.
        //      All other work is constant, so the overall complexity is linear.
        // Space complexity : O(1) The iterative approach only allocates a few pointers, so it has a constant overall memory footprint.
        public SinglyLinkedListNode MergeTwoLists(SinglyLinkedListNode list1, SinglyLinkedListNode list2)
        {
            var resultPointer = new SinglyLinkedListNode(0);

            var previous = resultPointer;
            while (list1 != null && list2 != null)
            {
                if (list1.data < list2.data)
                {
                    previous.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    previous.next = list2;
                    list2 = list2.next;
                }
                previous = previous.next;
            }
            if (list1 != null)
                previous.next = list1;

            if (list2 != null)
                previous.next = list2;

            return resultPointer.next;
        }

        // Leetcode solution
        // Approach 1: Recursion
        // Time complexity : O(n + m) Because each recursive call increments the pointer to l1 or l2 by
        //      one(approaching the dangling null at the end of each list), there will be exactly one call to
        //      mergeTwoLists per element in each list.Therefore, the time complexity is linear in the combined size of the lists.
        // Space complexity : O(n + m) The first call to mergeTwoLists does not return until the ends of both l1 and l2 have
        //      been reached, so n + m stack frames consume O(n + m) space.
        public SinglyLinkedListNode mergeTwoLists_recur(SinglyLinkedListNode l1, SinglyLinkedListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }
            else if (l1.data < l2.data)
            {
                l1.next = mergeTwoLists_recur(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = mergeTwoLists_recur(l1, l2.next);
                return l2;
            }

        }

        public SinglyLinkedListNode mergeTwoLists(SinglyLinkedListNode l1, SinglyLinkedListNode l2)
        {
            // maintain an unchanging reference to node ahead of the return node.
            SinglyLinkedListNode prehead = new SinglyLinkedListNode(-1);

            SinglyLinkedListNode prev = prehead;
            while (l1 != null && l2 != null)
            {
                if (l1.data <= l2.data)
                {
                    prev.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    prev.next = l2;
                    l2 = l2.next;
                }
                prev = prev.next;
            }

            // At least one of l1 and l2 can still have nodes at this point, so connect
            // the non-null list to the end of the merged list.
            prev.next = l1 == null ? l2 : l1;

            return prehead.next;
        }
    }
}
