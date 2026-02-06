namespace Algoritmos.Graphs;

// O(V + E)
public class TopologicalSortKahn
{
    private readonly int V;
    private readonly List<int>[] adj;

    public TopologicalSortKahn(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; i++)
            adj[i] = [];
    }

    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
    }

    public void TopologicalSort()
    {
        int[] indegree = new int[V];
        for (int i = 0; i < V; i++)
        {
            foreach (var neighbor in adj[i])
                indegree[neighbor]++;
        }

        Queue<int> q = new Queue<int>();
        for (int i = 0; i < V; i++)
            if (indegree[i] == 0)
                q.Enqueue(i);

        List<int> topoOrder = [];

        while (q.Count > 0)
        {
            int node = q.Dequeue();
            topoOrder.Add(node);

            foreach (var neighbor in adj[node])
            {
                indegree[neighbor]--;
                if (indegree[neighbor] == 0)
                    q.Enqueue(neighbor);
            }
        }

        if (topoOrder.Count != V)
            Console.WriteLine("O grafo não é um DAG (possui ciclo).");
        else
        {
            Console.WriteLine("Ordenação Topológica (Kahn):");
            Console.WriteLine(string.Join(" ", topoOrder));
        }
    }
}

/*
class Program
{
    static void Main()
    {
        TopologicalSortKahn g = new TopologicalSortKahn(6);
        g.AddEdge(5, 2);
        g.AddEdge(5, 0);
        g.AddEdge(4, 0);
        g.AddEdge(4, 1);
        g.AddEdge(2, 3);
        g.AddEdge(3, 1);

        g.TopologicalSort();
    }
}

📌 Comparação rápida

Algoritmo   /  Estrutura usada  /  Vantagem                 /  Desvantagem

DFS         /  Pilha + Recursão / Simples de implementar    / Pode estourar stack em grafos grandes
Kahn        /  Fila + Indegree  / Detecta ciclos facilmente / Precisa calcular indegree

 */