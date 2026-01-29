namespace Algoritmos.Graphs;

// https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm
public class Dijkstra2
{
    public const int UNDEFINED = -1;
    public const int INFINITY = int.MaxValue;

    public static ShortestDistance[] FindShortestDistance(Graph graph, int sourceId)
    {
        PriorityQueue<int, int> queue = new();

        Dictionary<int, ShortestDistance> result = graph.Nodes.ToDictionary(n => n.Id, b => new ShortestDistance(b.Id));

        result[sourceId].Distance = 0;

        queue.Enqueue(sourceId, 0);

        while (queue.Count > 0)
        {
            queue.TryDequeue(out int currNode, out int currNodePriority);
            // como o C# não permite repriorização (alteração da prioridade), eu tenho que incluir mais de uma vez o ítem na fila
            // e ignorar as prioridades diferentes da melhor até agora (que seriam excluídas, se fosse possível no C#)
            while (result[currNode].Distance != currNodePriority)
            {
                queue.TryDequeue(out currNode, out currNodePriority);
            }

            foreach (var neighborId in graph.GetNode(currNode).Neighbors)
            {
                int distToNeighbor = result[currNode].Distance + graph.GetEdgeDistance(currNode, neighborId);
                if (distToNeighbor < result[neighborId].Distance)
                {
                    result[neighborId].Distance = distToNeighbor;
                    result[neighborId].Previous = currNode;
                    queue.Enqueue(neighborId, distToNeighbor);
                }
            }
        }

        return result.Values.ToArray();
    }

    public class ShortestDistance(int nodeId, int previous = UNDEFINED, int distance = INFINITY) : IComparable
    {
        public readonly int NodeId = nodeId;
        public int Previous = previous;
        public int Distance = distance;

        public int CompareTo(object? obj)
            => (obj != null && Distance == ((ShortestDistance)obj).Distance && Previous == ((ShortestDistance)obj).Previous) ? 0 : -1;
    }

    public class Graph(GraphNode[] nodes, GraphEdge[] edges)
    {
        private readonly Dictionary<int, GraphNode> graphNodes = nodes.ToDictionary(n => n.Id);
        private readonly Dictionary<string, int> edgeDistance = edges.ToDictionary(a => $"{a.NodeAIdx}/{a.NodeBIdx}", b => b.Distance);

        public int GetEdgeDistance(int nodeAId, int nodeBId)
            => (nodeAId < nodeBId) ? edgeDistance[$"{nodeAId}/{nodeBId}"] : edgeDistance[$"{nodeBId}/{nodeAId}"];
        
        public GraphNode GetNode(int nodeId)
            => graphNodes[nodeId];

        public int Count { get => graphNodes.Count; }
        public IEnumerable<GraphNode> Nodes { get => graphNodes.Values; }
    }

    public class GraphNode(int id, List<int> neighbors)
    {
        public readonly int Id = id;
        public readonly List<int> Neighbors = neighbors;
    }

    public class GraphEdge(int nodeAIdx, int nodeBIdx, int distance)
    {
        public int NodeAIdx = (nodeAIdx < nodeBIdx) ? nodeAIdx : nodeBIdx;
        public int NodeBIdx = (nodeAIdx < nodeBIdx) ? nodeBIdx : nodeAIdx;
        public int Distance = distance;
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