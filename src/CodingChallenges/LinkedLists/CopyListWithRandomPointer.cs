using Node = DataStructures.NodeWithRandom;

namespace CodingChallenges.LinkedLists;

/// <summary>
/// Related   : Linked List, Hash Table
/// Title     : 138. Copy List with Random Pointer
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/copy-list-with-random-pointer/
/// Companies : Facebook 66, Microsoft 15, Amazon 15, Bloomberg 4, Google 3 (2022-04-01)
/// Doc       : docs/Copy List with Random Pointer.docx
/// 
/// Amazon PhoneScreen 2x em 2025-09-25 e 2025-12-08
/// </summary>
public class CopyListWithRandomPointer
{
    public static Node CopyRandomList(Node head)
        => CopyRandomList_Recursive(head);

    // HashMap which holds old nodes as keys and new nodes as its values.
    private Dictionary<Node, Node> visitedHash;

    // Approach 1: Recursive (Leetcode)
    // Esse método não permite usar o método como estático caso ele possa ser usado de forma concorrente, devido a variável na classe
    public Node CopyRandomList_Recursive_leetcode(Node head)
    {
        if (head == null)
            return null;

        visitedHash = [];

        // If we have already processed the current node, then we simply return the cloned version of
        // it.
        if (this.visitedHash.ContainsKey(head))
            return this.visitedHash[head];

        // Create a new node with the value same as old node. (i.e. copy the node)
        Node node = new Node(head.val, null, null);

        // Save this value in the hash map. This is needed since there might be
        // loops during traversal due to randomness of random pointers and this would help us avoid
        // them.
        this.visitedHash[head] = node;

        // Recursively copy the remaining linked list starting once from the next pointer and then from
        // the random pointer.
        // Thus we have two independent recursive calls.
        // Finally we update the next and random pointers for the new node created.
        node.next = this.CopyRandomList_Recursive_leetcode(head.next);
        node.random = this.CopyRandomList_Recursive_leetcode(head.random);

        return node;
    }

    // Approach 2: Iterative with O(N) Space
    // Time Complexity : O(N) because we make one pass over the original linked list.
    // Space Complexity : O(N) as we have a dictionary containing mapping from old list nodes to new list nodes.
    //      Since there are N nodes, we have O(N) space complexity.
    public Node CopyRandomList_Iterative_leetcode1(Node head)
    {
        if (head == null)
            return null;

        visitedHash = [];

        Node oldNode = head;

        // Creating the new head node.
        Node newNode = new Node(oldNode.val);
        this.visitedHash[oldNode] = newNode;

        // Iterate on the linked list until all nodes are cloned.
        while (oldNode != null)
        {
            // Get the clones of the nodes referenced by random and next pointers.
            newNode.random = this.getClonedNode(oldNode.random);
            newNode.next = this.getClonedNode(oldNode.next);

            // Move one step ahead in the linked list.
            oldNode = oldNode.next;
            newNode = newNode.next;
        }
        return this.visitedHash[head];
    }
    private Node getClonedNode(Node node)
    {
        // If the node exists then
        if (node != null)
        {
            // Check if the node is in the visited dictionary
            if (this.visitedHash.ContainsKey(node))
            {
                // If its in the visited dictionary then return the new node reference from the dictionary
                return this.visitedHash[node];
            }
            else
            {
                // Otherwise create a new node, add to the dictionary and return it
                this.visitedHash[node] = new Node(node.val, null, null);
                return this.visitedHash[node];
            }
        }
        return null;
    }

    // Approach 3: Iterative with O(1) Space
    // Time Complexity : O(N)
    // Space Complexity : O(1)
    public static Node CopyRandomList_Iterative_leetcode2(Node head)
    {
        if (head == null)
            return null;

        // Creating a new weaved list of original and copied nodes.
        Node currNode = head;
        while (currNode != null)
        {
            // Cloned node
            Node newNode = new Node(currNode.val);

            // Inserting the cloned node just next to the original node.
            // If A->B->C is the original linked list,
            // Linked list after weaving cloned nodes would be A->A'->B->B'->C->C'
            newNode.next = currNode.next;
            currNode.next = newNode;
            currNode = newNode.next;
        }

        currNode = head;

        // Now link the random pointers of the new nodes created.
        // Iterate the newly created list and use the original nodes' random pointers,
        // to assign references to random pointers for cloned nodes.
        while (currNode != null)
        {
            currNode.next.random = (currNode.random != null) ? currNode.random.next : null;
            currNode = currNode.next.next;
        }

        // Unweave the linked list to get back the original linked list and the cloned list.
        // i.e. A->A'->B->B'->C->C' would be broken to A->B->C and A'->B'->C'
        Node currOldNode = head; // A->B->C
        Node currNewNode = head.next; // A'->B'->C'
        Node headNew = head.next;
        while (currOldNode != null)
        {
            currOldNode.next = currOldNode.next.next;
            currNewNode.next = (currNewNode.next != null) ? currNewNode.next.next : null;
            currOldNode = currOldNode.next;
            currNewNode = currNewNode.next;
        }
        return headNew;
    }

    public static Node CopyRandomList_Recursive(Node head)
    {
        if (head == null)
            return null;

        Dictionary<Node, Node> oldToNewMap = [];

        Node newHead = new Node(head.val);

        oldToNewMap[head] = newHead;

        newHead.next = CopyRandomList_Recursive(head.next, oldToNewMap);
        newHead.random = CopyRandomList_Recursive(head.random, oldToNewMap);

        return newHead;
    }
    private static Node CopyRandomList_Recursive(Node node, Dictionary<Node, Node> oldToNewMap)
    {
        if (node == null)
            return null;

        oldToNewMap.TryGetValue(node, out Node newNode);

        if (newNode == null)
        {
            newNode = new Node(node.val);
            oldToNewMap[node] = newNode;
            newNode.next = CopyRandomList_Recursive(node.next, oldToNewMap);
            newNode.random = CopyRandomList_Recursive(node.random, oldToNewMap);
        }

        return newNode;
    }

    public static Node CopyRandomList_Iterative(Node head)
    {
        if (head == null)
            return null;

        Dictionary<Node, Node> oldToNewMap = [];

        Node newHead = new(head.val);

        oldToNewMap[head] = newHead;

        Node currNode = head.next;
        //Node leftNewNode = newHead;

        while (currNode != null)
        {
            Node newNode = new(currNode.val);
            oldToNewMap[currNode] = newNode;
            currNode = currNode.next;

            //leftNewNode.next = newNode;
            //leftNewNode = newNode;
        }

        currNode = head;
        while (currNode != null)
        {
            Node newNode = oldToNewMap[currNode];
            newNode.next = currNode.next == null ? null : oldToNewMap[currNode.next]; // use a variável "leftNewNode" para preencher o "next" na primeira iteração e remover essa linha
            newNode.random = currNode.random == null ? null : oldToNewMap[currNode.random];

            currNode = currNode.next;
        }

        return newHead;
    }
}

