namespace CodingChallenges.Test.Graphs;

/// <summary>
/// Groups    : Graph
/// Title     : 399. Evaluate Division
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/evaluate-division
/// Approach  : DFS
/// </summary>
public class EvaluateDivision
{
    // Leetcode: Beats 69.95% / 83.94%
    // Versão gerada pelo ChatGPT, Muito complicado.. nem me preocupei em tentar entender
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        // Grafo: cada variável mapeia para seus vizinhos e pesos
        var graph = new Dictionary<string, Dictionary<string, double>>();

        for (int i = 0; i < equations.Count; i++)
        {
            string a = equations[i][0];
            string b = equations[i][1];
            double val = values[i];

            if (!graph.ContainsKey(a)) graph[a] = new Dictionary<string, double>();
            if (!graph.ContainsKey(b)) graph[b] = new Dictionary<string, double>();

            graph[a][b] = val;
            graph[b][a] = 1.0 / val;
        }

        var result = new double[queries.Count];

        for (int i = 0; i < queries.Count; i++)
        {
            string start = queries[i][0];
            string end = queries[i][1];

            if (!graph.ContainsKey(start) || !graph.ContainsKey(end))
            {
                result[i] = -1.0;
            }
            else if (start == end)
            {
                result[i] = 1.0;
            }
            else
            {
                var visited = new HashSet<string>();
                result[i] = DFS(graph, start, end, 1.0, visited);
            }
        }

        return result;
    }

    private double DFS(Dictionary<string, Dictionary<string, double>> graph, string current, string target, double accProduct, HashSet<string> visited)
    {
        if (current == target) return accProduct;

        visited.Add(current);

        foreach (var neighbor in graph[current])
        {
            if (!visited.Contains(neighbor.Key))
            {
                double result = DFS(graph, neighbor.Key, target, accProduct * neighbor.Value, visited);
                if (result != -1.0)
                {
                    return result;
                }
            }
        }

        return -1.0;
    }
}
/*
Esse problema é resolvido modelando as equações como um grafo ponderado:
- Cada variável é um nó.
- Cada equação a / b = v gera duas arestas:
- a → b com peso v
- b → a com peso 1/v
- Para responder uma query x / y, precisamos encontrar um caminho de x até y e multiplicar os pesos ao longo do caminho.
- Se não houver caminho, retornamos -1.0.
Podemos usar DFS ou BFS para buscar o caminho.

🔑 Explicação
- Construímos um grafo com as relações de divisão.
- Para cada query, usamos DFS para tentar encontrar um caminho entre as variáveis.
- Multiplicamos os valores ao longo do caminho.
- Se não houver caminho, retornamos -1.0.

⏱ Complexidade
- Tempo: O(Q × (N + E)), onde Q = número de queries, N = número de variáveis, E = número de equações.
- Espaço: O(N + E) para armazenar o grafo.
*/