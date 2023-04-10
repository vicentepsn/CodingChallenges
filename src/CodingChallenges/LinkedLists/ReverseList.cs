using DataStructures;

namespace CodingChallenges.LinkedLists
{
    public class ReverseList
    {
        /// <summary>
        /// Groups    : LinkedList
        /// Title     : 206. Reverse Linked List
        /// Difficult : Easy
        /// Link      : https://leetcode.com/problems/reverse-linked-list/
        /// Approach  : -
        /// </summary>
        public DataStructures.Node reverseList(DataStructures.Node head)
        {
            DataStructures.Node current = head, next, previous = null;

            while (current != null)
            {
                next = current.left;
                current.left = previous;
                previous = current;
                current = next;
            }

            return previous;
        }
    }
}
