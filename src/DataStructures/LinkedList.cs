namespace DataStructures;

public class DoubleLinkedListNode
{
    public int data;
    public DoubleLinkedListNode left;
    public DoubleLinkedListNode right;
    public DoubleLinkedListNode(int data = 0, DoubleLinkedListNode left = null, DoubleLinkedListNode right = null)
    {
        this.data = data;
        this.left = left;
        this.right = right;
    }
}

public class SinglyLinkedListNode
{
    public int data;
    public SinglyLinkedListNode next;
    public SinglyLinkedListNode(int data = 0, SinglyLinkedListNode next = null)
    {
        this.data = data;
        this.next = next;
    }
}

public class SinglyLinkedList
{
    public SinglyLinkedListNode head;
    public SinglyLinkedListNode tail;

    public SinglyLinkedList()
    {
        this.head = null;
        this.tail = null;
    }

    public void InsertNode(int nodeData)
    {
        SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

        if (this.head == null)
        {
            this.head = node;
        }
        else
        {
            this.tail.next = node;
        }

        this.tail = node;
    }
}
