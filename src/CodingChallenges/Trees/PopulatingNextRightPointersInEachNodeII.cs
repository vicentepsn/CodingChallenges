namespace CodingChallenges.Trees;

/// <summary>
/// Groups    : Binary Tree, Hash Table, Divide and Conquer, Array
/// Title     : 106. Construct Binary Tree from Inorder and Postorder Traversal
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal
/// Approach  : -
/// </summary>
public class PopulatingNextRightPointersInEachNodeII
{
    // BEST VERSION AT RUNTIME, mas com space O(n/2). Para space O(1), ver versão do ChatGPT abaixo
    // MELHOR USAR A VERSÃO DO CHATGPT!!
    // Leetcode: Beats 91.83% / 9.13% ==> 
    // O(n) / O(n / 2)
    public Node Connect(Node root) // v3
    {
        if (root == null) return null;

        Queue<Node> currLevelQueue = [];

        currLevelQueue.Enqueue(root);

        while (currLevelQueue.Count > 0)
        {
            Queue<Node> nextLevelQueue = [];
            while (currLevelQueue.Count > 0)
            {
                Node currNode = currLevelQueue.Dequeue();
                if (currLevelQueue.Count > 0)
                    currNode.next = currLevelQueue.Peek();

                if (currNode.left != null)
                    nextLevelQueue.Enqueue(currNode.left);

                if (currNode.right != null)
                    nextLevelQueue.Enqueue(currNode.right);
            }

            currLevelQueue = nextLevelQueue;
        }

        return root;
    }

    // Leetcode: Beats 84.13% / 74.04%
    // O(n) / O(1)
    public Node Connect_ChatGPT(Node root)
    {
        if (root == null) return null;

        Node current = root; // nó atual do nível
        while (current != null)
        {
            Node dummy = new Node(0); // nó fictício para construir a lista do próximo nível
            Node tail = dummy;        // ponteiro para conectar filhos

            // Percorrer o nível atual
            while (current != null)
            {
                if (current.left != null)
                {
                    tail.next = current.left;
                    tail = tail.next;
                }
                if (current.right != null)
                {
                    tail.next = current.right;
                    tail = tail.next;
                }
                current = current.next; // avançar para o próximo nó do nível
            }

            // Avançar para o próximo nível
            current = dummy.next;
        }

        return root;
    }

    // Leetcode: Beats 87.98% / 9.13%  ==> Second Try
    public Node Connect_v2(Node root)
    {
        if (root == null) return null;

        Dictionary<Node, int> nodeLevelMap = [];
        Queue<Node> nodeQueue = [];

        nodeQueue.Enqueue(root);
        nodeLevelMap[root] = 0;

        while (nodeQueue.Count > 0)
        {
            Node currNode = nodeQueue.Dequeue();
            if (nodeQueue.Count > 0 && nodeLevelMap[currNode] == nodeLevelMap[nodeQueue.Peek()])
                currNode.next = nodeQueue.Peek();

            int nextNodesLevel = nodeLevelMap[currNode] + 1;

            if (currNode.left != null)
            {
                nodeQueue.Enqueue(currNode.left);
                nodeLevelMap[currNode.left] = nextNodesLevel;
            }
            if (currNode.right != null)
            {
                nodeQueue.Enqueue(currNode.right);
                nodeLevelMap[currNode.right] = nextNodesLevel;
            }
        }

        return root;
    }

    // Leetcode: Beats 8.17% / 9.13%  ==> First try
    public Node Connect_v0(Node root)
    {
        if (root == null) return null;

        Dictionary<Node, int> nodeLevelMap = [];
        List<Node> nodesBFS = []; // Breadth-First Search (BFS)
        Queue<Node> nodeQueue = [];

        nodeQueue.Enqueue(root);
        nodeLevelMap[root] = 0;

        while (nodeQueue.Count > 0)
        {
            Node currNode = nodeQueue.Dequeue();
            int nextNodesLevel = nodeLevelMap[currNode] + 1;
            nodesBFS.Add(currNode);
            if (currNode.left != null)
            {
                nodeQueue.Enqueue(currNode.left);
                nodeLevelMap[currNode.left] = nextNodesLevel;
            }
            if (currNode.right != null)
            {
                nodeQueue.Enqueue(currNode.right);
                nodeLevelMap[currNode.right] = nextNodesLevel;
            }
        }

        for (int i = 0; i < nodesBFS.Count - 1; i++)
        {
            if (nodeLevelMap[nodesBFS[i]] == nodeLevelMap[nodesBFS[i + 1]])
                nodesBFS[i].next = nodesBFS[i + 1];
        }

        return root;
    }

    // Definition for a Node.
    public class Node {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next) {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}
