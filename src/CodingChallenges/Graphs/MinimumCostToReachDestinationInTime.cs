namespace CodingChallenges.Graphs;

/// <summary>
/// Groups    : Graph, DP, Array
/// Title     : 1928. Minimum Cost to Reach Destination in Time
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/minimum-cost-to-reach-destination-in-time/
/// Approach  : Dijkstra modificado
/// </summary>
public class MinimumCostToReachDestinationInTime
{
    // O((V + E) log V) / O(V + E) (adjacency list + estruturas)
    public int MinCost(int maxTime, int[][] edges, int[] passingFees) // CG
    {
        /*Dictionary<string, int> edgesDistance = 
            edges.ToDictionary(a => a[0] < a[1] ? $"{a[0]}/{[1]}" : $"{a[1]}/{[0]}", b => b[2]);

        int n = passingFees.Length;
        var neighbors = new Lint<int>[n];
        for (int i = 0; i < n; i++)
            neighbors[i] = new ();

        foreach (int[] edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }*/

        int n = passingFees.Length;

        // Grafo como lista de adjacência
        List<(int, int)>[] graph = new List<(int, int)>[n];
        for (int i = 0; i < n; i++) graph[i] = new List<(int, int)>();
        foreach (var e in edges)
        {
            int u = e[0], v = e[1], t = e[2];
            graph[u].Add((v, t));
            graph[v].Add((u, t));
        }

        // minTime[city] = menor tempo para chegar nessa cidade
        int[] minTime = new int[n];
        Array.Fill(minTime, int.MaxValue);
        minTime[0] = 0;

        // PriorityQueue: (custo, cidade, tempo)
        var pq = new PriorityQueue<(int cost, int city, int time), int>();
        pq.Enqueue((passingFees[0], 0, 0), passingFees[0]);

        while (pq.Count > 0)
        {
            var (cost, city, time) = pq.Dequeue();

            // Se chegamos ao destino dentro do tempo
            if (city == n - 1) return cost;

            foreach (var (next, t) in graph[city])
            {
                int newTime = time + t;
                if (newTime > maxTime) continue;

                int newCost = cost + passingFees[next];

                // Só vale a pena explorar se chegamos mais rápido
                if (newTime < minTime[next])
                {
                    minTime[next] = newTime;
                    pq.Enqueue((newCost, next, newTime), newCost);
                }
            }
        }

        return -1;
    }
}
