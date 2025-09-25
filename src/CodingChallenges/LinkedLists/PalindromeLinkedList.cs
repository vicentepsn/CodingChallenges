using DataStructures;
using System.Collections.Generic;

namespace CodingChallenges.LinkedLists
{
    //public class ListListNode  ==> see DataStructures
    //{
    //    public int val;
    //    public ListListNode next;
    //    public ListListNode(int val = 0, ListListNode next = null)
    //    {
    //        this.val = val;
    //        this.next = next;
    //    }
    //}

    /// <summary>
    /// 234. Palindrome Linked List
    /// https://leetcode.com/problems/palindrome-linked-list/
    /// </summary>
    public class PalindromeLinkedList
    {


        public bool IsPalindrome(DataStructures.SinglyLinkedListNode head)
        {
            DataStructures.SinglyLinkedListNode rabbit = head,
                turtle = head,
                reversenext = null;

            while (rabbit?.next?.next != null)
            {
                rabbit = rabbit.next?.next;

                var newTurtle = turtle.next;
                turtle.next = reversenext;
                reversenext = turtle;
                turtle = newTurtle;
            }

            DataStructures.SinglyLinkedListNode fromMidle;
            if (rabbit?.next != null)
            {
                var newTurtle = turtle.next;
                turtle.next = reversenext;
                reversenext = turtle;
                turtle = newTurtle;
                fromMidle = turtle;
            }
            else
                fromMidle = turtle.next;


            while (reversenext != null)
            {
                if (reversenext.data != fromMidle.data)
                    return false;

                reversenext = reversenext.next;
                fromMidle = fromMidle.next;
            }

            return true;
        }

        public bool IsPalindrome_v1(DataStructures.SinglyLinkedListNode head)
        {
            DataStructures.SinglyLinkedListNode rabbit = head,
                turtle = head,
                reversePointer = new DataStructures.SinglyLinkedListNode();

            while (rabbit?.next?.next != null)
            {
                var ListNode = new DataStructures.SinglyLinkedListNode(turtle.data, reversePointer.next);
                reversePointer.next = ListNode;
                turtle = turtle.next;

                rabbit = rabbit.next?.next;
            }

            if (rabbit?.next != null)
            {
                var ListNode = new DataStructures.SinglyLinkedListNode(turtle.data, reversePointer.next);
                reversePointer.next = ListNode;
            }
            var fromMidle = turtle.next;

            var reversenext = reversePointer.next;

            while (reversenext != null)
            {
                if (reversenext.data != fromMidle.data)
                    return false;

                reversenext = reversenext.next;
                fromMidle = fromMidle.next;
            }

            return true;
        }

        public bool IsPalindrome_BruteFroce(DataStructures.SinglyLinkedListNode head)
        {
            var input = new List<int>();

            var ListNode = head;
            while (ListNode != null)
            {
                input.Add(ListNode.data);
                ListNode = ListNode.next;
            }

            var i = 0;
            var j = input.Count - 1;

            while (i < j)
            {
                if (input[i] != input[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }

    }
}
