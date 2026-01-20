using ListNode = DataStructures.SinglyLinkedListNodeII;

namespace CodingChallenges.LinkedLists;

/// <summary>
/// Groups    : LinkedList
/// Title     : 92. Reverse Linked List II
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/reverse-linked-list-ii/
/// Approach  : -
/// </summary>
public class ReverseLinkedListInterval
{
    public ListNode reverseBetween(ListNode head, int left, int right)
    {
        ListNode newHeadPointer = new() { next = head };
        var previous = newHeadPointer;

        var current = head;

        var currentPosition = 1;

        while (currentPosition < left)
        {
            previous = current;
            current = current.next;
            currentPosition++;
        }

        var evenTail = current;
        var lastNonEven = previous;

        while (currentPosition <= right)
        {
            var next = current.next;
            current.next = previous;
            previous = current;
            current = next;
            currentPosition++;
        }

        lastNonEven.next = previous;
        evenTail.next = current;
        previous = evenTail;

        return newHeadPointer.next;
    }

    // Leetcode: Beats 100.00% / 47.04%
    public ListNode reverseBetween_udemy(ListNode head, int left, int right)
    {
        var start = head;
        var current = head;

        var currentPosition = 1;

        while (currentPosition < left)
        {
            start = current;
            current = current.next;
            currentPosition++;
        }

        var tail = current;
        ListNode newList = null;

        while (currentPosition <= right)
        {
            var next = current.next;
            current.next = newList;
            newList = current;
            current = next;
            currentPosition++;
        }

        start.next = newList;
        tail.next = current;

        if (left > 1)
            return head;
        else
            return newList;
    }

    // Eu fiz em 2026-01-06, tá mais fácil de explicar em uma entrevista
    // Leetcode: Beats 100.00% / 16.20%
    public static ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (left == right) return head;

        int position = 1;

        ListNode? newHead = null;
        ListNode? currNode = head;
        ListNode? block1Tail = null;

        bool hasPart1 = left > 1;
        if (hasPart1)
        {
            newHead = head;
            while (position < left - 1)
            {
                currNode = currNode!.next;
                position++;
            }
            block1Tail = currNode;
            currNode = currNode!.next;
            position++;
        }

        ListNode subTail = currNode!;
        ListNode? prevNode = null;

        while (position <= right)
        {
            ListNode? nextNode = currNode!.next;
            currNode.next = prevNode;
            prevNode = currNode;
            currNode = nextNode;
            position++;
        }

        ListNode subHead = prevNode!;

        subTail.next = currNode;

        if (hasPart1)
            block1Tail!.next = subHead;
        else
            newHead = subHead;

        return newHead!;
    }
}
