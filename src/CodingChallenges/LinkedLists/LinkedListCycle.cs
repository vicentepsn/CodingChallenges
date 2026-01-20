using ListNode = DataStructures.SinglyLinkedListNode;

namespace CodingChallenges.LinkedLists;

/// <summary>
/// Groups    : LinkedList
/// Title     : 141. Linked List Cycle
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/linked-list-cycle-ii/
/// Approach  : -
/// </summary>
public class LinkedListCycle
{
    public bool HasCycle(ListNode head)
    {
        ListNode? turtoise = head;
        ListNode? rabbit = head?.next;

        while (turtoise != null && rabbit != null)
        {
            if (turtoise == rabbit)
                return true;

            turtoise = turtoise.next;
            rabbit = rabbit.next?.next;
        }

        return false;
    }

    //Definition for singly-linked list.
    //public class ListNode {
    //    public int val;
    //    public ListNode next;
    //    public ListNode(int x) {
    //        val = x;
    //        next = null;
    //    }
    //}

}