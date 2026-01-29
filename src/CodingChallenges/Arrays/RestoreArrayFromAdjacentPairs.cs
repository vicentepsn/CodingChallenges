namespace CodingChallenges.Arrays;

/// <summary>
/// Related   : Array, Hash Table
/// Title     : 1743. Restore the Array From Adjacent Pairs
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/restore-the-array-from-adjacent-pairs
/// Companies : DP
/// </summary>
public class RestoreArrayFromAdjacentPairs
{
    public static int[] RestoreArray(int[][] adjacentPairs)
    {
        Dictionary<int, List<int>> pairsMap = [];
        HashSet<int> uniqueNumbers = [];

        foreach (var pair in adjacentPairs)
        {
            int a = pair[0], b = pair[1];
            if (!pairsMap.ContainsKey(a))
                pairsMap[a] = [];
            pairsMap[a].Add(b);
            if (!pairsMap.ContainsKey(b))
                pairsMap[b] = [];
            pairsMap[b].Add(a);

            if (!uniqueNumbers.Remove(a))
                uniqueNumbers.Add(a);

            if (!uniqueNumbers.Remove(b))
                uniqueNumbers.Add(b);
        }

        int[] result = new int[adjacentPairs.Length + 1];

        int currNumber = Math.Min(uniqueNumbers.ElementAt(0), uniqueNumbers.ElementAt(1));
        result[0] = currNumber;

        for (int i = 1; i < result.Length; i++)
        {
            int nextNumber = pairsMap[currNumber][0];
            pairsMap[nextNumber].Remove(currNumber);

            result[i] = nextNumber;
            currNumber = nextNumber;
        }

        return result;
    }

    // Leetcode: beats 72.50% / 100.00%
    public int[] RestoreArray_CGPT(int[][] adjacentPairs)
    {
        // 1. Construir grafo
        var graph = new Dictionary<int, List<int>>();
        foreach (var pair in adjacentPairs)
        {
            int u = pair[0], v = pair[1];
            if (!graph.ContainsKey(u)) graph[u] = new List<int>();
            if (!graph.ContainsKey(v)) graph[v] = new List<int>();
            graph[u].Add(v);
            graph[v].Add(u);
        }

        int n = adjacentPairs.Length + 1;
        int[] result = new int[n];

        // 2. Encontrar ponto inicial (grau == 1)
        int start = -1;
        foreach (var kvp in graph)
        {
            if (kvp.Value.Count == 1)
            {
                start = kvp.Key;
                break;
            }
        }

        // 3. Reconstruir array
        result[0] = start;
        result[1] = graph[start][0]; // como eu sei que ele só tem um item, já pego a posição 0

        for (int i = 2; i < n; i++)
        {
            var neighbors = graph[result[i - 1]];
            // escolher o vizinho que não é o anterior
            result[i] = neighbors[0] == result[i - 2] ? neighbors[1] : neighbors[0];
        }

        return result;
    }

}
