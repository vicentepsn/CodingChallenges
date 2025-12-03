namespace Algoritmos.Sort;

public class QuickSort
{
    /*
| Algoritmo          | Complexidade Média | Melhor Caso | Pior Caso  | Estável | Observações                         |
| ------------------ | ------------------ | ----------- | ---------- | ------- | ----------------------------------- |
| **Insertion Sort** | O(n²)              | O(n)        | O(n²)      | ✅ Sim   | Bom para listas pequenas            |
| **Merge Sort**     | O(n log n)         | O(n log n)  | O(n log n) | ✅ Sim   | Usa memória extra                   |
| **Quick Sort**     | O(n log n)         | O(n log n)  | O(n²)      | ❌ Não   | Geralmente o mais rápido na prática |

     */
    public static void Sort(int[] vetor, int inicio, int fim)
    {
        if (inicio < fim)
        {
            int p = Particionar(vetor, inicio, fim);

            // Ordena as duas metades separadamente
            Sort(vetor, inicio, p - 1);
            Sort(vetor, p + 1, fim);
        }
    }

    static int Particionar(int[] vetor, int inicio, int fim)
    {
        int pivo = vetor[fim];
        int i = inicio - 1;

        for (int j = inicio; j < fim; j++)
        {
            if (vetor[j] <= pivo)
            {
                i++;
                Trocar(vetor, i, j);
            }
        }

        Trocar(vetor, i + 1, fim);
        return i + 1;
    }

    static void Trocar(int[] vetor, int a, int b)
    {
        int temp = vetor[a];
        vetor[a] = vetor[b];
        vetor[b] = temp;
    }

    //static void Main()
    //{
    //    int[] numeros = { 10, 7, 8, 9, 1, 5 };
    //    Sort(numeros, 0, numeros.Length - 1);

    //    Console.WriteLine("Vetor ordenado: " + string.Join(", ", numeros));
    //}

}
