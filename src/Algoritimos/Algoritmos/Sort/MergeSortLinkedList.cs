namespace Algoritmos.Sort;
using Node = DataStructures.NodeWithNext;

public static class MergeSortLinkedList
{
    // T => O(n.log(n)) / S => O(log n)  * recursão
    public static Node? MergeSort(Node? head)
    {
        if (head == null || head.Next == null)
            return head;

        Node middle = GetMiddle(head);
        Node? nextToMiddle = middle.Next;

        middle.Next = null; // quebra a lista ao meio

        Node? left = MergeSort(head);
        Node? right = MergeSort(nextToMiddle);

        return SortedMerge(left, right);
    }

    private static Node GetMiddle(Node head)
    {
        Node slow = head;
        Node fast = head;

        while (fast.Next != null && fast.Next.Next != null)
        {
            slow = slow.Next!;
            fast = fast.Next.Next!;
        }

        return slow;
    }

    private static Node? SortedMerge(Node? a, Node? b)
    {
        if (a == null) return b;
        if (b == null) return a;

        if (a.Value <= b.Value)
        {
            a.Next = SortedMerge(a.Next, b);
            return a;
        }
        else
        {
            b.Next = SortedMerge(a, b.Next);
            return b;
        }
    }

    private static Node? SortedMerge_Iterative(Node? a, Node? b)
    {
        if (a == null) return b;
        if (b == null) return a;

        Node headPointer = new(0);

        Node currNode = headPointer;
        while (a != null && b != null)
        {
            if (a.Value <= b.Value)
            {
                currNode.Next = a;
                a = a.Next;
            }
            else
            {
                currNode.Next = b;
                b = b.Next;
            }

            currNode = currNode.Next;
        }

        if (a != null && b == null)
            currNode.Next = a;
        if (a == null && b != null)
            currNode.Next = b;

        return headPointer.Next;
    }

}
