using CodingChallenges.LinkedList.DoubleLinkedWithChild;

namespace CodingChallenges.LinkedLists
{
    /// <summary>
    /// Groups    : LinkedList, DoubleLinkedList, Recursion
    /// Title     : 430. Flatten a Multilevel Doubly Linked List
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/flatten-a-multilevel-doubly-linked-list/
    /// Approach  : -
    /// </summary>
    public class FlattenMultilevelDoublyLinkedList
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node Flatten(Node head)
        {
            if (head == null) return head;

            var currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.child == null)
                {
                    currentNode = currentNode.next;
                }
                else
                {
                    var tail = currentNode.child;
                    while (tail.next != null)
                    {
                        tail = tail.next;
                    }

                    tail.next = currentNode.next;
                    if (tail.next != null)
                    {
                        tail.next.prev = tail;
                    }

                    currentNode.next = currentNode.child;
                    currentNode.next.prev = currentNode;
                    currentNode.child = null;
                }
            }

            return head;
        }

        public Node Flatten_withRecursion(Node head)
        {
            var current = head;

            while (current?.child == null && current != null)
            {
                current = current.next;
            }

            if (current == null)
                return head;

            var child = current.child;
            var next = current.next;
            var childTail = FlattenAndGetTail(child);
            current.child = null;
            current.next = child;
            child.prev = current;
            if (next != null)
            {
                childTail.next = next;
                next.prev = childTail;
            }

            return head;
        }

        private Node FlattenAndGetTail(Node head)
        {
            var current = head;
            var prev = current.prev;

            while (current.child == null && current != null)
            {
                prev = current;
                current = current.next;
            }

            if (current == null)
                return prev;

            var child = current.child;
            if (child != null)
            {
                var next = current.next;
                var childTail = FlattenAndGetTail(child);
                current.child = null;
                current.next = child;
                child.prev = current;
                if (next != null)
                {
                    childTail.next = next;
                    next.prev = childTail;
                }
                else
                    return childTail;

                current = next;
            }

            while (current.next != null)
            {
                current = current.next;
            }

            return current;
        }

        private Node FlattenAndGetTail_faster(Node head)
        {
            var current = head;

            while (current.child == null && current.next != null)
            {
                current = current.next;
            }

            var child = current.child;
            if (child != null)
            {
                var next = current.next;
                var childTail = FlattenAndGetTail_faster(child);
                current.child = null;
                current.next = child;
                child.prev = current;
                if (next != null)
                {
                    childTail.next = next;
                    next.prev = childTail;
                }
                else
                    return childTail;

                current = next;
            }

            while (current.next != null)
            {
                current = current.next;
            }

            return current;
        }

    }
}

namespace CodingChallenges.LinkedList.DoubleLinkedWithChild 
{ 
    // Definition for a Node.
    public class Node
    {
        public int val;
        public Node prev;
        public Node next;
        public Node child;
    }
}
