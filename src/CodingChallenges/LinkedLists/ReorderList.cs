using DataStructures;

namespace CodingChallenges.LinkedLists
{
    /// <summary>
    /// Related   : Linked List, Two Pointers, Stack, Recursion?
    /// Title     : 143. Reorder List
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/reorder-list/
    /// Companies : Amazon 10, Microsoft 4, Adobe 4, Facebook 2 (2022-04-01)
    /// Doc       : docs/143 Reorder List.docx
    /// </summary>
    public class ReorderList
    {
        // Time complexity: O(N). There are three steps here. To identify the middle node takes O(N) time.
        //      To reverse the second part of the list, one needs N/2 operations. The final step, to merge two lists,
        //      requires N/2 operations as well. In total, that results in O(N) time complexity.
        // Space complexity: O(1), since we do not allocate any additional data structures.
        public void reorderList(ListNode head)
        {
            ListNode tortoise = head, hare = head;

            while (hare?.next?.next != null)
            {
                hare = hare?.next?.next;
                tortoise = tortoise.next;
            }

            ListNode prev = null;
            var current = tortoise.next;
            tortoise.next = null;

            while (current != null)
            {
                var next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            var l2 = prev;
            var l1 = head;

            prev = new ListNode(0, null);
            while (l2 != null)
            {
                prev.next = l1;
                prev = prev.next;
                l1 = l1.next;
                prev.next = l2;
                prev = prev.next;
                l2 = l2.next;
            }

            if (l1 != null)
                prev.next = l1;
        }


        // Leetcode solution
        public void reorderList_leetcode(ListNode head)
        {
            if (head == null) return;

            // find the middle of linked list [Problem 876]
            // in 1->2->3->4->5->6 find 4 
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // reverse the second part of the list [Problem 206]
            // convert 1->2->3->4->5->6 into 1->2->3->4 and 6->5->4
            // reverse the second half in-place
            ListNode prev = null, curr = slow, tmp;
            while (curr != null)
            {
                tmp = curr.next;

                curr.next = prev;
                prev = curr;
                curr = tmp;
            }

            // merge two sorted linked lists [Problem 21]
            // merge 1->2->3->4 and 6->5->4 into 1->6->2->5->3->4
            ListNode first = head, second = prev;
            while (second.next != null)
            {
                tmp = first.next;
                first.next = second;
                first = tmp;

                tmp = second.next;
                second.next = first;
                second = tmp;
            }
        }
    }
}
