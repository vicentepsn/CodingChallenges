namespace CodingChallenges.Heap;

/// <summary>
/// Groups    : Heap, Design
/// Title     : 295. Find Median from Data Stream
/// Difficult : Hard
/// Link      : https://leetcode.com/problems/find-median-from-data-stream
/// Approach  : Heap
/// Leetcode  : Beats 96.49% / 19.30%
/// ATENÇÃO   : A VERSÃO GERADA PELO CG ABAIXO É MAIS SIMPLES, USAR ELA PRIMEIRO, CASO QUEIRA OTIMIZAR, USAR A MINHA VERSÃO (A FindMedianFromDataStream)
/// </summary>
public class FindMedianFromDataStream
{
    private readonly PriorityQueue<int, int> leftHeap; // max
    private readonly PriorityQueue<int, int> rightHeap; // min
    public FindMedianFromDataStream()
    {
        leftHeap = new();
        rightHeap = new();
    }
    // O(log n)
    public void AddNum(int num)
    {
        leftHeap.TryPeek(out int leftPeek, out int _);
        rightHeap.TryPeek(out int rightPeek, out int _);

        if (num == leftPeek)
        {
            if (leftHeap.Count > rightHeap.Count)
                rightHeap.Enqueue(num, num);
            else
                leftHeap.Enqueue(num, -num);
        }
        else if (num == rightPeek)
        {
            if (rightHeap.Count > leftHeap.Count)
                leftHeap.Enqueue(num, -num);
            else
                rightHeap.Enqueue(num, num);
        }
        else if (num < leftPeek)
        {
            leftHeap.Enqueue(num, -num);
            if (leftHeap.Count > rightHeap.Count + 1)
            {
                int leftToRight = leftHeap.Dequeue();
                rightHeap.Enqueue(leftToRight, leftToRight);
            }
        }
        else // if (num > rigthPeek)
        {
            rightHeap.Enqueue(num, num);
            if (rightHeap.Count > leftHeap.Count + 1)
            {
                int rightToLeft = rightHeap.Dequeue();
                leftHeap.Enqueue(rightToLeft, -rightToLeft);
            }
        }
    }
    // O(1)
    public double FindMedian()
    {
        if (rightHeap.Count == leftHeap.Count)
            return ((double)rightHeap.Peek() + leftHeap.Peek()) / 2;
        if (rightHeap.Count > leftHeap.Count)
            return rightHeap.Peek();

        return leftHeap.Peek();
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */

// CG version
// Leetcode  : Beats 35.96% / 43.57%
public class MedianFinder
{
    private readonly PriorityQueue<int, int> minHeap; // guarda os maiores números
    private readonly PriorityQueue<int, int> maxHeap; // guarda os menores números (invertido)

    public MedianFinder()
    {
        minHeap = new ();
        // maxHeap precisa simular max-heap: usamos prioridade negativa
        maxHeap = new ();
    }
    // O(log n)
    public void AddNum(int num)
    {
        // Primeiro adicionamos ao maxHeap
        maxHeap.Enqueue(num, -num);

        // Balanceamos: o maior do maxHeap deve ir para minHeap
        int maxTop = maxHeap.Dequeue();
        minHeap.Enqueue(maxTop, maxTop);

        // Se minHeap ficar maior que maxHeap, devolvemos o menor de minHeap para maxHeap
        if (minHeap.Count > maxHeap.Count)
        {
            int minTop = minHeap.Dequeue();
            maxHeap.Enqueue(minTop, -minTop);
        }
    }
    // O(1)
    public double FindMedian()
    {
        if (maxHeap.Count > minHeap.Count)
            return maxHeap.Peek();

        return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
    }
}
/*
Esse problema é clássico de estrutura de dados dinâmica: precisamos manter a mediana de um fluxo de números sem ordenar toda vez.

💡 Ideia principal
Usamos dois heaps:
- Um max-heap para a metade esquerda (menores números).
- Um min-heap para a metade direita (maiores números).
Regras:
- Balanceamos os heaps para que suas contagens diferenciem no máximo por 1.
- Se os heaps tiverem tamanhos iguais, a mediana é a média dos topos.
- Se um heap tiver mais elementos, a mediana é o topo desse heap.

🔑 Explicação
- maxHeap guarda a metade menor dos números.
- minHeap guarda a metade maior.
- Sempre garantimos que maxHeap.Count >= minHeap.Count.
- A mediana é:
- maxHeap.Peek() se maxHeap tiver mais elementos.
- (maxHeap.Peek() + minHeap.Peek()) / 2.0 se ambos tiverem o mesmo tamanho.

⏱ Complexidade
- AddNum: O(log n) (inserção em heap).
- FindMedian: O(1).
- Espaço: O(n).

⚡ Follow-up
- Se todos os números estão em [0,100]:
Podemos usar um array de contagem (counting sort) de tamanho 101.
- AddNum: incrementa contador.
- FindMedian: percorre acumulando até achar a posição da mediana.
- Complexidade: O(100) = O(1).
- Se 99% estão em [0,100]:
Usamos a mesma técnica de contagem para [0,100], mas mantemos um heap ou lista separada para os outliers.
Assim, a maioria das consultas é resolvida em tempo constante.
*/

public class MedianFinder_OtimizadoEspecial // para intervalo de 0 a 100
{
    private readonly int[] count;   // contagem de cada número [0..100]
    private int total;     // total de elementos adicionados
    private const int medianNotYetFound = -1; // evitar "números mágicos"

    public MedianFinder_OtimizadoEspecial()
    {
        count = new int[101]; // intervalo fixo
        total = 0;
    }

    public void AddNum(int num)
    {
        count[num]++;
        total++;
    }

    public double FindMedian()
    {
        int mid1 = (total + 1) / 2; // posição do primeiro elemento da mediana
        int mid2 = (total % 2 == 0) ? (total / 2 + 1) : mid1; // posição do segundo (se par)

        int cumulative = 0;
        int median1 = medianNotYetFound, median2 = medianNotYetFound;

        for (int i = 0; i <= 100; i++)
        {
            cumulative += count[i];

            if (median1 == medianNotYetFound && cumulative >= mid1)
            {
                median1 = i;
            }
            if (median2 == medianNotYetFound && cumulative >= mid2)
            {
                median2 = i;
                break;
            }
        }

        return (median1 + median2) / 2.0;
    }
}
/*
Se todos os números do fluxo estão no intervalo [0,100], podemos usar um array de contagem (counting array) para otimizar. Assim evitamos heaps e conseguimos calcular a mediana em tempo constante.

🔑 Explicação
- count[num] guarda quantas vezes cada número aparece.
- total guarda o número total de elementos.
- Para encontrar a mediana, percorremos o array acumulando até alcançar as posições da mediana (mid1 e mid2).
- Se o total for ímpar, mid1 == mid2, então retornamos apenas esse valor.
- Se for par, retornamos a média entre median1 e median2.

⏱ Complexidade
- AddNum: O(1).
- FindMedian: O(101) → constante, já que o intervalo é fixo.
- Espaço: O(101).

👉 Essa versão é extremamente eficiente para o caso especial [0,100].

*/