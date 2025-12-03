namespace Algoritmos.Sort;

public class MergeSort
{
    /*
| Algoritmo          | Complexidade Média | Melhor Caso | Pior Caso  | Estável | Observações                         |
| ------------------ | ------------------ | ----------- | ---------- | ------- | ----------------------------------- |
| **Insertion Sort** | O(n²)              | O(n)        | O(n²)      | ✅ Sim   | Bom para listas pequenas            |
| **Merge Sort**     | O(n log n)         | O(n log n)  | O(n log n) | ✅ Sim   | Usa memória extra                   |
| **Quick Sort**     | O(n log n)         | O(n log n)  | O(n²)      | ❌ Não   | Geralmente o mais rápido na prática |

    
    
    static void Main()
    {
        int[] numeros = { 38, 27, 43, 3, 9, 82, 10 };
        MergeSort(numeros, 0, numeros.Length - 1);

        Console.WriteLine("Vetor ordenado: " + string.Join(", ", numeros));
    }
 */
    public static void Sort(int[] vetor, int inicio, int fim)
    {
        if (inicio < fim)
        {
            int meio = (inicio + fim) / 2;

            // Divide em duas metades
            Sort(vetor, inicio, meio);
            Sort(vetor, meio + 1, fim);

            // Combina as metades
            Merge(vetor, inicio, meio, fim);
        }
    }

    static void Merge(int[] vetor, int inicio, int meio, int fim)
    {
        int n1 = meio - inicio + 1;
        int n2 = fim - meio;

        int[] esquerda = new int[n1];
        int[] direita = new int[n2];

        for (int i = 0; i < n1; i++)
            esquerda[i] = vetor[inicio + i];
        for (int j = 0; j < n2; j++)
            direita[j] = vetor[meio + 1 + j];

        int k = inicio, i1 = 0, j1 = 0;

        // Intercala os dois subvetores
        while (i1 < n1 && j1 < n2)
        {
            if (esquerda[i1] <= direita[j1])
            {
                vetor[k] = esquerda[i1];
                i1++;
            }
            else
            {
                vetor[k] = direita[j1];
                j1++;
            }
            k++;
        }

        // Copia o restante dos elementos
        while (i1 < n1)
        {
            vetor[k++] = esquerda[i1++];
        }

        while (j1 < n2)
        {
            vetor[k++] = direita[j1++];
        }
    }
}
