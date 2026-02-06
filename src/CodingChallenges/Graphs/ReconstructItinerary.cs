using DataStructures;

namespace CodingChallenges.Graphs;

/// <summary>
/// Related   : Graph Theory, DFS, Eulerian Circuit
/// Title     : 332. Reconstruct Itinerary
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/reconstruct-itinerary
/// Companies : 
/// </summary>
public class ReconstructItinerary
{
    // O(E log E), onde E = número de tickets (devido ao uso de min-heap). / O(E) para armazenar o grafo.
    public static IList<string> FindItinerary(IList<IList<string>> tickets) // CG
    {
        // Grafo: origem -> min-heap de destinos
        var graph = new Dictionary<string, PriorityQueue<string, string>>();

        foreach (var ticket in tickets)
        {
            string from = ticket[0];
            string to = ticket[1];

            if (!graph.ContainsKey(from))
            {
                graph[from] = new ();
            }
            graph[from].Enqueue(to, to);
        }

        var result = new List<string>();
        DFS("JFK", graph, result);

        result.Reverse();
        return result;
    }

    private static void DFS(string airport, Dictionary<string, PriorityQueue<string, string>> graph, List<string> result)
    {
        if (graph.ContainsKey(airport))
        {
            var pq = graph[airport];
            while (pq.Count > 0)
            {
                string next = pq.Dequeue();
                DFS(next, graph, result);
            }
        }
        result.Add(airport);
    }

    // Versão iterativa com milha, mesma idéia da de cima
    public IList<string> FindItinerary_vIterativa(IList<IList<string>> tickets) // CG
    {
        var graph = new Dictionary<string, PriorityQueue<string, string>>();
        foreach (var t in tickets)
        {
            graph.TryAdd(t[0], new PriorityQueue<string, string>());
            graph[t[0]].Enqueue(t[1], t[1]);
        }

        var stack = new Stack<string>();
        var route = new List<string>();
        stack.Push("JFK");

        while (stack.Count > 0)
        {
            var top = stack.Peek();
            if (graph.ContainsKey(top) && graph[top].Count > 0)
            {
                var next = graph[top].Dequeue(); // menor destino
                stack.Push(next);
            }
            else
            {
                route.Add(stack.Pop()); // backtracking: fecha o nó
            }
        }

        route.Reverse();
        return route;
    }

    public static IList<string> FindItinerary_FirstTry(IList<IList<string>> tickets)
    {
        int ticketsQtd = tickets.Count;
        if (ticketsQtd == 1) return tickets[0];
        //Console.WriteLine(ticketsQtd);
        Dictionary<string, HashSet<string>> ticketsMap = [];

        foreach (var ticket in tickets)
        {
            string departureAirport = ticket[0];
            string arrivalAirport = ticket[1];
            if (!ticketsMap.ContainsKey(departureAirport))
                ticketsMap[departureAirport] = [];
            ticketsMap[departureAirport].Add(arrivalAirport);
        }

        List<string> result = GetReverseItinerary(ticketsMap, "JFK", ticketsQtd, 0)!;
        result.Reverse();

        return result;
    }

    private static List<string>? GetReverseItinerary(Dictionary<string, HashSet<string>> ticketsMap, string departureAirport, int ticketsQtd, int usedTickets)
    {
        //Console.WriteLine($"usedTickets: {usedTickets}, '{departureAirport}'");
        if (usedTickets == ticketsQtd) return [departureAirport];

        usedTickets++;

        ticketsMap.TryGetValue(departureAirport, out var arrivalAirports);
        if (arrivalAirports == null || arrivalAirports.Count == 0) return null;

        List<string>? reverseItinerary = null;
        foreach (string arrivalAirport in arrivalAirports.ToArray())
        {
            arrivalAirports.Remove(arrivalAirport);

            var nextItinerary = GetReverseItinerary(ticketsMap, arrivalAirport, ticketsQtd, usedTickets);

            arrivalAirports.Add(arrivalAirport);

            if (nextItinerary == null)
                continue;

            int lastPosition = nextItinerary.Count - 1;
            if (reverseItinerary == null)
                reverseItinerary = nextItinerary;
            else
            {
                //Console.WriteLine(nextItinerary[lastPosition]);
                //Console.WriteLine(reverseItinerary![lastPosition]);
                //Console.WriteLine(nextItinerary[lastPosition].CompareTo(reverseItinerary![lastPosition]));
                reverseItinerary = nextItinerary[lastPosition].CompareTo(reverseItinerary![lastPosition]) < 0 ? nextItinerary : reverseItinerary;
            }
        }

        reverseItinerary!.Add(departureAirport);

        return reverseItinerary;
    }
}
/*
🔎 Observações
- Complexidade:
- Tempo: O(E log E), onde E = número de tickets (devido ao uso de min-heap).
- Espaço: O(E) para armazenar o grafo.
- O uso de PriorityQueue garante que sempre escolhemos o destino lexicograficamente menor.
- O resultado é construído invertido, por isso fazemos Reverse() no final.

Quer que eu também te mostre uma versão sem PriorityQueue (usando SortedList ou ordenando listas manualmente), útil em ambientes onde não há suporte nativo para min-heap?
*/