/*
namespace Algoritmos.Graphs;

public class TopologicalSort
{
    bool top_sort(List<List<int>> adj_list)
    {
        Queue<int> q = [];
        for (int i = 0; i < adj_list.Count; i++)
            if (indegree[i] == 0)
                q.Enqueue(i);
        while (!q.empty())
        {
            int u = q.front(); q.pop();
            top_order.push_back(u);
            removed[u] = true;
            for (int k = 0; k < adj_list[u].size(); k++)
            {
                int v = adj_list[u][k];
                if (!removed[v] & &--indegree[v] == 0)
                    q.push(v);

            }

        }

        return adj_list.size() == top_order.size();
    }
//Complexidade 0 (V + A)
//
}

*/