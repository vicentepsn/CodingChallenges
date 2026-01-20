using ListNode = DataStructures.SinglyLinkedListNodeII;

namespace CodingChallenges.LinkedLists;

/// <summary>
/// Groups    : LinkedList
/// Title     : 25. Reverse Nodes in k-Group
/// Difficult : Hard
/// Link      : https://leetcode.com/problems/reverse-nodes-in-k-group
/// Approach  : -
/// </summary>
public class ReverseNodesInKGroup
{
    // A MINHA VERSÃO ABAIXO ESTÁ MAIS FÁCIL DE EXPLICAR EM UMA ENTREVISTA

    // Leetcode: Beats 32.82% / 76.34%
    // CGPT version em 2026-01-06
    public ListNode ReverseKGroup_CGPT(ListNode head, int k)
    {
        if (head == null || k == 1) return head;

        // Dummy node para simplificar manipulação de ponteiros
        ListNode dummy = new ListNode(0);
        dummy.next = head;

        ListNode prevGroupEnd = dummy;

        while (true)
        {
            // Verificar se há k nós restantes
            ListNode kth = GetKthNode(prevGroupEnd, k);
            if (kth == null) break;

            ListNode groupStart = prevGroupEnd.next;
            ListNode nextGroupStart = kth.next;

            // Reverter grupo
            ListNode prev = kth.next;
            ListNode curr = groupStart;
            while (curr != nextGroupStart)
            {
                ListNode tmp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = tmp;
            }

            // Conectar grupos
            prevGroupEnd.next = kth;
            prevGroupEnd = groupStart;
        }

        return dummy.next;
    }

    private ListNode GetKthNode(ListNode start, int k)
    {
        while (start != null && k > 0)
        {
            start = start.next;
            k--;
        }
        return start;

    }

    // Leetcode: Beats 100.00% / 96.18%
    public ListNode ReverseKGroup_my(ListNode head, int k)
    {
        if (head == null || k == 1) return head;

        // Dummy node para simplificar manipulação de ponteiros
        ListNode headPointer = new ListNode(0);
        headPointer.next = head;

        ListNode prevGroupEnd = headPointer;

        while (true)
        {
            // Verificar se há k nós restantes
            ListNode kth = GetKthNode(prevGroupEnd, k); // kth é o 'currGroupNewStart'
            if (kth == null) break;

            ListNode nextGroupStart = kth.next;
            ListNode currGroupNewEnd = prevGroupEnd.next;
            
            ListNode prev = nextGroupStart; // já prepara para conectar o primeiro (novo último) do grupo com o primeiro do próximo grupo
            ListNode curr = currGroupNewEnd;
            while (curr != nextGroupStart)
            {
                ListNode tmp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = tmp;
            }

            // Conectar grupos
            prevGroupEnd.next = kth; // kth agora é o primeiro do grupo revertido

            prevGroupEnd = currGroupNewEnd;
        }

        return headPointer.next;
    }

}
