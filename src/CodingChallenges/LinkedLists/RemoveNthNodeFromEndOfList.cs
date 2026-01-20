using ListNode = DataStructures.SinglyLinkedListNodeII;
namespace CodingChallenges.LinkedLists;

/// <summary>
/// Groups    : LinkedList
/// Title     : 19. Remove Nth Node From End of List
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/remove-nth-node-from-end-of-list
/// Approach  : -
/// </summary>
public class RemoveNthNodeFromEndOfList
{
    // Leetcode: Beats 100.00% / 15.28%
    public static ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        // Criar um nó dummy para simplificar casos em que o primeiro nó é removido
        ListNode dummy = new(0, head);
        ListNode first = dummy;
        ListNode second = dummy;

        // Avançar 'first' n+1 passos à frente
        for (int i = 0; i <= n; i++)
        {
            first = first.next!;
        }

        // Mover ambos até 'first' chegar ao fim
        while (first != null)
        {
            first = first.next!;
            second = second.next!;
        }

        // 'second' está logo antes do nó a ser removido
        second.next = second.next!.next;

        return dummy.next!;
    }

    // Versão minha com contador
    // Leetcode: Beats 100.00% / 15.28%
    public static ListNode? RemoveNthFromEnd_v2(ListNode head, int n)
    {
        ListNode headPointer = new(0, head);

        int count = 0;
        ListNode? currNode = head;

        for (; currNode != null; count++)
            currNode = currNode.next;

        currNode = headPointer;
        for (int i = 1; i <= count - n; i++)
            currNode = currNode.next;

        currNode.next = currNode.next.next;

        return headPointer.next;
    }
}
