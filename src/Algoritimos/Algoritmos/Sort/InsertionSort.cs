namespace Algoritmos.Sort;

public class InsertionSort
{
    /*
    | Algoritmo          | Complexidade Média | Melhor Caso | Pior Caso  | Estável | Observações                         |
| ------------------ | ------------------ | ----------- | ---------- | ------- | ----------------------------------- |
| **Insertion Sort** | O(n²)              | O(n)        | O(n²)      | ✅ Sim   | Bom para listas pequenas            |
| **Merge Sort**     | O(n log n)         | O(n log n)  | O(n log n) | ✅ Sim   | Usa memória extra                   |
| **Quick Sort**     | O(n log n)         | O(n log n)  | O(n²)      | ❌ Não   | Geralmente o mais rápido na prática |

    
    
    
    static void Main()
    {
        int[] numeros = { 5, 2, 9, 1, 5, 6 };
        InsertionSort(numeros);

        Console.WriteLine("Vetor ordenado: " + string.Join(", ", numeros));
    }
*/
    public static void Sort(int[] vetor)
    {
        for (int i = 1; i < vetor.Length; i++)
        {
            int chave = vetor[i];
            int j = i - 1;

            // Move os elementos maiores que a chave uma posição à frente
            while (j >= 0 && vetor[j] > chave)
            {
                vetor[j + 1] = vetor[j];
                j--;
            }

            vetor[j + 1] = chave;
        }
    }
}
