namespace CodingChallenges.Graphs;

/// <summary>
/// Groups    : Graph, DP, Array
/// Title     : 1514. Path with Maximum Probability
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/path-with-maximum-probability
/// Approach  : Dijkstra modificado
/// </summary>
public class PathWithMaximumProbability
{
    // O((V + E) log V) / O(V + E) (adjacency list + estruturas)
    // Leetcode: Beats 72.22% / 20.37%
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node) // No CGPT
    {
        var graph = new List<(int neighbor, double succProb)>[n];

        for (int i = 0; i < n; i++) graph[i] = [];

        for (int i = 0; i < edges.Length; i++)
        {
            graph[edges[i][0]].Add(new(edges[i][1], succProb[i]));
            graph[edges[i][1]].Add(new(edges[i][0], succProb[i]));
        }
        
        var nodeSuccProb = new double[n];
        nodeSuccProb[start_node] = 1;

        var queue = new PriorityQueue<int, double>();

        queue.Enqueue(start_node, 0);

        while (queue.Count > 0)
        {
            int currNodeIdx = queue.Dequeue();
            if (currNodeIdx == end_node) return nodeSuccProb[end_node];

            foreach (var (neighborIdx, prob) in graph[currNodeIdx])
            {
                double newProb = nodeSuccProb[currNodeIdx] * prob;
                if (newProb > nodeSuccProb[neighborIdx])
                {
                    nodeSuccProb[neighborIdx] = newProb;
                    queue.Enqueue(neighborIdx, -newProb);
                }
            }
        }

        return 0;
    }
}
