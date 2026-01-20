namespace CodingChallenges.Graphs;

/// <summary>
/// Groups    : Graph, DFS, BFS, Topological Sort
/// Title     : 210. Course Schedule II
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/course-schedule-ii
/// Approach  : -
/// </summary>
public class CourseScheduleII
{
    // Leetcode: Beats 75.92% / 71.37%
    // Versão gerada pelo ChatGPT.. não me preocupei em tentar entender
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        // Grafo de adjacência
        var graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            graph[i] = new List<int>();
        }

        // Grau de entrada (in-degree)
        int[] inDegree = new int[numCourses];

        foreach (var pre in prerequisites)
        {
            int course = pre[0];
            int prereq = pre[1];
            graph[prereq].Add(course);
            inDegree[course]++;
        }

        // Fila para cursos sem pré-requisitos
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (inDegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        var order = new List<int>();

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            order.Add(current);

            foreach (var neighbor in graph[current])
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        // Se conseguimos ordenar todos os cursos, retornamos a ordem
        if (order.Count == numCourses)
        {
            return order.ToArray();
        }

        // Caso contrário, existe ciclo → impossível concluir
        return new int[0];
    }
}
/*
Esse problema é uma continuação do Course Schedule I, mas agora precisamos retornar uma ordem válida dos cursos (topological sort).
A ideia é usar Kahn’s Algorithm (BFS) ou DFS com pilha. Vamos implementar a versão com BFS, que é bem clara:

🔑 Explicação
- Construímos o grafo e calculamos o grau de entrada de cada curso.
- Cursos com grau de entrada 0 podem ser feitos imediatamente.
- Removemos esses cursos e atualizamos os graus dos vizinhos.
- Se conseguimos visitar todos os cursos, retornamos a ordem.
- Caso contrário, existe um ciclo e retornamos [].

⏱ Complexidade
- Tempo: O(V + E), onde V = número de cursos, E = número de pré-requisitos.
- Espaço: O(V + E) para armazenar o grafo e o grau de entrada.
*/