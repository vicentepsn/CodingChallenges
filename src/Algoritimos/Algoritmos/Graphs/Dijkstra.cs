namespace Algoritmos.Graphs;

// https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm
/*
Complexidade

Com fila de prioridade: O((V + E) log V)

Espaço: O(V + E) (adjacency list + estruturas)
*/
public class Dijkstra
{
    public const int UNDEFINED = -1;
    public const int INFINITY = int.MaxValue;

    public static ShortestDistance[] FindShortestDistance(Neighbor[][] graph, int sourceIdx)
    {
        PriorityQueue<int, int> queue = new();
        
        var result = new ShortestDistance[graph.Length];
        for (int i = 0; i < graph.Length; i++)
        {
            result[i] = new ShortestDistance();
        }
        result[sourceIdx].Distance = 0;

        queue.Enqueue(sourceIdx, 0);

        while (queue.Count > 0)
        {
            queue.TryDequeue(out int currNode, out int currNodePriority);
            // como o C# não permite repriorização (alteração da prioridade), eu tenho que incluir mais de uma vez o ítem na fila
            // e ignorar as prioridades diferentes da melhor até agora (que seriam excluídas, se fosse possível no C#)
            while (result[currNode].Distance != currNodePriority)
            {
                queue.TryDequeue(out currNode, out currNodePriority);
            }

            foreach (var neighbors in graph[currNode])
            {
                int distToNeighbor = result[currNode].Distance + neighbors.Distance;
                if (distToNeighbor < result[neighbors.NodeIdx].Distance)
                {
                    result[neighbors.NodeIdx].Distance = distToNeighbor;
                    result[neighbors.NodeIdx].Previous = currNode;
                    queue.Enqueue(neighbors.NodeIdx, distToNeighbor);
                }
            }
        }

        return result;
    }

    public struct Neighbor(int nodeIdx, int distance)
    {
        public int NodeIdx = nodeIdx;
        public int Distance = distance;
    }

    public class ShortestDistance (int previous = UNDEFINED, int distance = INFINITY) : IComparable
    {
        public int Previous = previous;
        public int Distance = distance;

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            if (Distance == ((ShortestDistance)obj).Distance && Previous == ((ShortestDistance)obj).Previous)
                return 0;
            return 1;
        }
    }
}

/*

Pseudocódigo com PriorityQueue

1   function Dijkstra(Graph, source):
2       Q ← Queue storing vertex priority
3       
4       dist[source] ← 0                          // Initialization
5       Q.add_with_priority(source, 0)            // associated priority equals dist[·]
6
7       for each vertex v in Graph.Vertices:
8           if v ≠ source
9               prev[v] ← UNDEFINED               // Predecessor of v
10              dist[v] ← INFINITY                // Unknown distance from source to v
11              Q.add_with_priority(v, INFINITY)
12
13
14      while Q is not empty:                     // The main loop
15          u ← Q.extract_min()                   // Remove and return best vertex
16          for each arc (u, v) :                 // Go through all v neighbors of u
17              alt ← dist[u] + Graph.Edges(u, v)
18              if alt < dist[v]:
19                  prev[v] ← u
20                  dist[v] ← alt
21                  Q.decrease_priority(v, alt)
22
23      return (dist, prev) 
 */