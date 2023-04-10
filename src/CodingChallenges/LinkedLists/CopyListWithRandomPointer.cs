using Node = CodingChallenges.LinkedList.RandomNode.Node;
using System.Collections.Generic;

namespace CodingChallenges.LinkedLists
{
    /// <summary>
    /// Related   : Linked List, Hash Table
    /// Title     : 138. Copy List with Random Pointer
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/merge-two-sorted-lists/
    /// Companies : Facebook 66, Microsoft 15, Amazon 15, Bloomberg 4, Google 3 (2022-04-01)
    /// Doc       : docs/Copy List with Random Pointer.docx
    /// </summary>
    public class CopyListWithRandomPointer
    {
        public Node CopyRandomList(Node head)
        {
            var origNodes = new Dictionary<Node, int>();

            var copyNodes = new List<Node>();

            var copyHeadPointer = new Node(-1);

            var currOrig = head;
            var leftCopy = copyHeadPointer;

            var position = 0;
            while (currOrig != null)
            {
                origNodes[currOrig] = position;

                var newCopy = new Node(currOrig.val);

                copyNodes.Add(newCopy);

                leftCopy.next = newCopy;
                leftCopy = newCopy;

                currOrig = currOrig.next;
                position++;
            }

            currOrig = head;
            var currCopy = copyHeadPointer.next;
            while (currOrig != null)
            {
                if (currOrig.random != null)
                {
                    var randomNodePos = origNodes[currOrig.random];
                    currCopy.random = copyNodes[randomNodePos];
                }

                currOrig = currOrig.next;
                currCopy = currCopy.next;
            }

            return copyHeadPointer.next;
        }


        // HashMap which holds old nodes as keys and new nodes as its values.
        Dictionary<Node, Node> visitedHash = new Dictionary<Node, Node>();

        // Approach 1: Recursive (Leetcode)
        public Node copyRandomList(Node head)
        {

            if (head == null)
            {
                return null;
            }

            // If we have already processed the current node, then we simply return the cloned version of
            // it.
            if (this.visitedHash.ContainsKey(head))
            {
                return this.visitedHash[head];
            }

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
            node.next = this.copyRandomList(head.next);
            node.random = this.copyRandomList(head.random);

            return node;
        }

        // HashMap which holds old nodes as keys and new nodes as its values.
        Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
        // Approach 2: Iterative with O(N) Space
        // Time Complexity : O(N) because we make one pass over the original linked list.
        // Space Complexity : O(N) as we have a dictionary containing mapping from old list nodes to new list nodes.
        //      Since there are N nodes, we have O(N) space complexity.
        public Node copyRandomList_2(Node head)
        {

            if (head == null)
            {
                return null;
            }

            Node oldNode = head;

            // Creating the new head node.
            Node newNode = new Node(oldNode.val);
            this.visited[oldNode] = newNode;

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
            return this.visited[head];
        }
        public Node getClonedNode(Node node)
        {
            // If the node exists then
            if (node != null)
            {
                // Check if the node is in the visited dictionary
                if (this.visited.ContainsKey(node))
                {
                    // If its in the visited dictionary then return the new node reference from the dictionary
                    return this.visited[node];
                }
                else
                {
                    // Otherwise create a new node, add to the dictionary and return it
                    this.visited[node] = new Node(node.val, null, null);
                    return this.visited[node];
                }
            }
            return null;
        }

        // Approach 3: Iterative with O(1) Space
        // Time Complexity : O(N)
        // Space Complexity : O(1)
        public Node copyRandomList_3(Node head)
        {

            if (head == null)
            {
                return null;
            }

            // Creating a new weaved list of original and copied nodes.
            Node ptr = head;
            while (ptr != null)
            {

                // Cloned node
                Node newNode = new Node(ptr.val);

                // Inserting the cloned node just next to the original node.
                // If A->B->C is the original linked list,
                // Linked list after weaving cloned nodes would be A->A'->B->B'->C->C'
                newNode.next = ptr.next;
                ptr.next = newNode;
                ptr = newNode.next;
            }

            ptr = head;

            // Now link the random pointers of the new nodes created.
            // Iterate the newly created list and use the original nodes' random pointers,
            // to assign references to random pointers for cloned nodes.
            while (ptr != null)
            {
                ptr.next.random = (ptr.random != null) ? ptr.random.next : null;
                ptr = ptr.next.next;
            }

            // Unweave the linked list to get back the original linked list and the cloned list.
            // i.e. A->A'->B->B'->C->C' would be broken to A->B->C and A'->B'->C'
            Node ptr_old_list = head; // A->B->C
            Node ptr_new_list = head.next; // A'->B'->C'
            Node head_old = head.next;
            while (ptr_old_list != null)
            {
                ptr_old_list.next = ptr_old_list.next.next;
                ptr_new_list.next = (ptr_new_list.next != null) ? ptr_new_list.next.next : null;
                ptr_old_list = ptr_old_list.next;
                ptr_new_list = ptr_new_list.next;
            }
            return head_old;
        }

    }
} // end namespace

namespace CodingChallenges.LinkedList.RandomNode
{
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
        public Node(int _val, Node next, Node random)
        {
            val = _val;
            this.next = next;
            this.random = random;
        }
    }
}