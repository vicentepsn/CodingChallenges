using Node = DataStructures.GraphNode2;

namespace CodingChallenges.Graphs;

/// <summary>
/// Groups    : Graph, Hash Table
/// Title     : 133. Clone Graph
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/clone-graph
/// Approach  : DFS
/// </summary>
public class CloneGraphClass
{
    private readonly Dictionary<Node, Node> oldToNewMap = [];

    // Leetcode: Beats 95.02% / 40.12%
    public Node CloneGraph(Node node)
    {
        if (node == null) return node;

        if (oldToNewMap.ContainsKey(node))
            return oldToNewMap[node];

        Node clonedNode = new() { val = node.val, neighbors = [] };
        oldToNewMap[node] = clonedNode;

        foreach (Node neighbor in node.neighbors)
            clonedNode.neighbors.Add(CloneGraph(neighbor));

        return clonedNode;
    }
}

// Definition for a Node.
/*
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/