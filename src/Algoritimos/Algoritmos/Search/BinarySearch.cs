namespace Algoritmos.Search;

public class BinarySearch
{
    public static int Search(int[] vetor, int valor)
    {
        int inicio = 0;
        int fim = vetor.Length - 1;

        while (inicio <= fim)
        {
            int meio = (inicio + fim) / 2;

            if (vetor[meio] == valor)
                return meio;
            else if (vetor[meio] < valor)
                inicio = meio + 1;
            else
                fim = meio - 1;
        }

        return -1; // Não encontrado
    }

    static void Main()
    {
        int[] numeros = { 10, 20, 30, 40, 50, 60 };
        int valorBuscado = 40;

        int resultado = Search(numeros, valorBuscado);

        if (resultado != -1)
            Console.WriteLine($"Valor {valorBuscado} encontrado na posição {resultado}.");
        else
            Console.WriteLine("Valor não encontrado.");
    }

}
