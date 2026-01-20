using ListNode = DataStructures.SinglyLinkedListNodeII;
namespace CodingChallenges.LinkedLists;

public class ReverseSinglyLinkedList
{
    public static ListNode Reverse(ListNode llist)
    {
        if (llist == null)
            return null;

        if (llist.next == null)
            return llist;

        ListNode lastNode = llist;
        ListNode currNode = llist.next;
        lastNode.next = null;

        while (currNode.next != null)
        {
            var nextNode = currNode.next;
            currNode.next = lastNode;
            lastNode = currNode;
            currNode = nextNode;
        }
        currNode.next = lastNode;

        return currNode;
    }


    /// <summary>
    /// Related   : Linked List
    /// Title     : 206. Reverse Linked List
    /// Difficult : Easy
    /// Link      : https://leetcode.com/problems/reverse-linked-list/
    /// </summary>
    public ListNode ReverseList(ListNode head)
    {
        if (head == null)
            return null;

        ListNode previousNode = null;
        ListNode currNode = head;

        while (currNode.next != null) {
            ListNode nextNode = currNode.next;
            currNode.next = previousNode;
            previousNode = currNode;
            currNode = nextNode;
        }

        currNode.next = previousNode;

        return currNode;
    }

}
