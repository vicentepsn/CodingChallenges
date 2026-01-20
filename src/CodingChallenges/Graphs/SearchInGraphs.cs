namespace CodingChallenges.Graphs;

/// <summary>
/// Udemy course: Master the Coding Interview: Bit Tech (FAANG) Interviews
/// Section: Intro to Graphs - Representation & Traversal Algorithms
/// Link: https://www.udemy.com/course/master-the-coding-interview-big-tech-faang-interviews/learn/lecture/22504148#overview
/// </summary>
public class SearchInGraphs
{
    private readonly int[][] adjacencyList = new int[][]{
        new int[]{ 1, 3 },
        new int[]{ 0},
        new int[]{ 3, 8 },
        new int[]{ 0, 2, 4, 5 },
        new int[]{ 3, 6 },
        new int[]{ 3 },
        new int[]{ 4, 7},
        new int[]{6},
        new int[]{ 2}
    };

    public List<int> TraversalBFS(int[][] graph) {
        var seen = new List<bool>(graph.Length);
        var queue = new Queue<int>();
        queue.Enqueue(0);
        var values = new List<int>(graph.Length);

        while(queue.Count > 0) {
            var vertex = queue.Dequeue();

            values.Add(vertex);
            seen[vertex] = true;

            var connections = graph[vertex];
            for(var i = 0; i<connections.Length; i++) {
                var connection = connections[i];
                if(!seen[connection]) {
                    queue.Enqueue(connection);
                }
            }
        }

        return values;
    }

    public List<int> TraversalDFS(int[][] graph)
    {
        var values = new List<int>(graph.Length);
        TraversalDFS(0, graph, values, new List<bool>(graph.Length));
        return values;
    }

    public void TraversalDFS(int vertex, int[][] graph, List<int> values, List<bool> seen) {
        values.Add(vertex);
        seen[vertex] = true;

        var connections = graph[vertex];
        for (var i = 0; i < connections.Length; i++)
        {
            var connection = connections[i];

            if (!seen[connection])
            {
                TraversalDFS(connection, graph, values, seen);
            }
        }
    }

    private readonly int[][] adjacencyMatrix = new int[][]{
        new int[]{0, 1, 0, 1, 0, 0, 0, 0, 0},
        new int[]{1, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[]{0, 0, 0, 1, 0, 0, 0, 0, 1},
        new int[]{1, 0, 1, 0, 1, 1, 0, 0, 0},
        new int[]{0, 0, 0, 1, 0, 0, 1, 0, 0},
        new int[]{0, 0, 0, 1, 0, 0, 0, 0, 0},
        new int[]{0, 0, 0, 0, 1, 0, 0, 1, 0},
        new int[]{0, 0, 0, 0, 0, 0, 1, 0, 0},
        new int[]{0, 0, 1, 0, 0, 0, 0, 0, 0}
    };

    public List<int> TraversalBFS_Matrix(int[][] graph) {
        var seen = new List<bool>(graph.Length);
        var queue = new Queue<int>();
        queue.Enqueue(0);
        var values = new List<int>(graph.Length);

        while (queue.Count > 0)
        {
            var vertex = queue.Dequeue();

            values.Add(vertex);
            seen[vertex] = true;

            var connections = graph[vertex];
            for (var v = 0; v < connections.Length; v++)
            {
                if (connections[v] > 0 && !seen[v]) {
                    queue.Enqueue(v);
                }
            }
        }

        return values;
    }

    public List<int> TraversalDFS_Matrix(int[][] graph)
    {
        var values = new List<int>(graph.Length);
        TraversalDFS_Matrix(0, graph, values, new List<bool>(graph.Length));
        return values;
    }

    public void TraversalDFS_Matrix(int vertex, int[][] graph, List<int> values, List<bool> seen)
    {
        values.Add(vertex);
        seen[vertex] = true;

        var connections = graph[vertex];
        for (var v = 0; v < connections.Length; v++)
        {
            if (connections[v] > 0 && !seen[v])
            {
                TraversalDFS_Matrix(v, graph, values, seen);
            }
        }
    }

}
