using ListNode = DataStructures.SinglyLinkedListNodeII;

namespace CodingChallenges.LinkedLists;

/// <summary>
/// Groups    : LinkedList
/// Title     : 82. Remove Duplicates from Sorted List II
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii
/// Approach  : -
/// </summary>
public class RemoveDuplicatesFromSortedListII
{
    public static ListNode DeleteDuplicates(ListNode head)
    {
        ListNode headPointer = new(0, head);

        ListNode prevNode = headPointer;
        ListNode currNode = head;
        ListNode? nextNode = currNode?.next;

        while (currNode != null)
        {
            if (nextNode != null && currNode.val == nextNode.val)
            {
                while (nextNode != null && currNode.val == nextNode.val)
                {
                    nextNode = nextNode.next;
                }
                prevNode.next = nextNode;
                currNode = nextNode;
                nextNode = nextNode?.next;
            }
            else
            {
                prevNode = currNode;
                currNode = currNode.next;
                nextNode = nextNode?.next;
            }

        }

        return headPointer.next;
    }
}
