namespace CodingChallenges.Heap;

/// <summary>
/// Groups    : Heap, Array
/// Title     : 502. IPO
/// Difficult : Hard
/// Link      : https://leetcode.com/problems/ipo
/// Approach  : Heap
/// </summary>
public class IPO // ChatGPT
{
    public static int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
    {
        int n = profits.Length;

        // Min-heap ordenado por capital necessário
        var minCapitalHeap = new PriorityQueue<(int capital, int profit), int>();
        for (int i = 0; i < n; i++)
        {
            minCapitalHeap.Enqueue((capital[i], profits[i]), capital[i]);
        }

        // Max-heap de lucros disponíveis
        var maxProfitHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        for (int i = 0; i < k; i++)
        {
            // Adiciona todos os projetos que podem ser iniciados com o capital atual
            while (minCapitalHeap.Count > 0 && minCapitalHeap.Peek().capital <= w)
            {
                var project = minCapitalHeap.Dequeue();
                maxProfitHeap.Enqueue(project.profit, project.profit);
            }

            // Se não há projetos disponíveis, paramos
            if (maxProfitHeap.Count == 0) break;

            // Escolhe o projeto mais lucrativo
            w += maxProfitHeap.Dequeue();
        }

        return w;
    }
}

/*
🧩 Entendendo o problema
- Temos n projetos, cada um com:
- profits[i]: lucro obtido ao concluir.
- capital[i]: capital mínimo necessário para iniciar.
- Inicialmente temos w capital.
- Podemos escolher até k projetos.
- Objetivo: maximizar o capital final.

💡 Estratégia
A melhor abordagem é usar dois heaps (PriorityQueue):
- Ordenamos os projetos por capital necessário (min-heap).
- Mantemos um max-heap de lucros disponíveis para os projetos que podemos iniciar com o capital atual.
- Para cada rodada (até k vezes):
- Movemos todos os projetos cujo capital[i] <= w para o max-heap de lucros.
- Escolhemos o projeto com maior lucro (do max-heap).
- Atualizamos o capital w += lucro escolhido.
- Repetimos.
👉 Isso garante que sempre escolhemos o projeto mais lucrativo dentre os disponíveis.

🔎 Observações
- Complexidade:
- Tempo: O(n log n + k log n) (inserções e remoções em heaps).
- Espaço: O(n).
- Essa abordagem é eficiente mesmo para n = 10^5.

*/