using ListNode = DataStructures.SinglyLinkedListNodeII;

namespace CodingChallenges.LinkedLists;

/// <summary>
/// Groups    : LinkedList
/// Title     : 86. Partition List
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/partition-list
/// Approach  : -
/// </summary>
public class PartitionList
{
    // Leetcode: Beats 100.00% / 11.64%
    public ListNode Partition(ListNode head, int x)
    {
        ListNode part1HeadPointer = new();
        ListNode part2HeadPointer = new();

        ListNode part1Last = part1HeadPointer;
        ListNode part2Last = part2HeadPointer;

        ListNode currNode = head;
        while (currNode != null)
        {
            if (currNode.val < x)
            {
                part1Last.next = currNode;
                part1Last = currNode;
            }
            else
            {
                part2Last.next = currNode;
                part2Last = currNode;
            }
            currNode = currNode.next;
        }
        part1Last.next = part2HeadPointer.next;
        part2Last.next = null;

        return part1HeadPointer.next;
    }
}
