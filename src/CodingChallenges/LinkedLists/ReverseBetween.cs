using DataStructures;

namespace CodingChallenges.LinkedLists
{
    /// <summary>
    /// Groups    : LinkedList
    /// Title     : 92. Reverse Linked List II
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/reverse-linked-list-ii/
    /// Approach  : -
    /// </summary>
    public class ReverseBetween
    {
        public Node reverseBetween(Node head, int left, int right)
        {
            Node newHeadPointer = new Node() { left = head };
            var previous = newHeadPointer;

            var current = head;

            var currentPosition = 1;

            while (currentPosition < left)
            {
                previous = current;
                current = current.left;
                currentPosition++;
            }

            var evenTail = current;
            var lastNonEven = previous;

            while (currentPosition <= right)
            {
                var next = current.left;
                current.left = previous;
                previous = current;
                current = next;
                currentPosition++;
            }

            lastNonEven.left = previous;
            evenTail.left = current;
            previous = evenTail;

            return newHeadPointer.left;
        }
        
        public Node reverseBetween_udemy(Node head, int left, int right)
        {
            var start = head;
            var current = head;

            var currentPosition = 1;

            while (currentPosition < left)
            {
                start = current;
                current = current.left;
                currentPosition++;
            }

            var tail = current;
            Node newList = null;

            while (currentPosition <= right)
            {
                var next = current.left;
                current.left = newList;
                newList = current;
                current = next;
                currentPosition++;
            }

            start.left = newList;
            tail.left = current;

            if (left > 1)
                return head;
            else
                return newList;
        }
    }

}
