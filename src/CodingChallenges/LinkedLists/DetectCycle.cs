using DataStructures;

namespace CodingChallenges.LinkedLists
{
    /// <summary>
    /// Groups    : LinkedList
    /// Title     : 142. Linked List Cycle II
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/linked-list-cycle-ii/
    /// Approach  : -
    /// </summary>
    public class DetectCycle
    {
        public DoubleLinkedListNode detectCycle(DoubleLinkedListNode head)
        {
            var tortoise = head;
            var hare = head;

            do
            {
                tortoise = tortoise?.left?.left;
                hare = hare?.left;

                if (tortoise == null)
                    return null;
            } while (tortoise != hare);

            var left = head;
            var right = tortoise;
            while (left != right)
            {
                left = left.left;
                right = right.left;
            }

            return left;
        }
    }
}
