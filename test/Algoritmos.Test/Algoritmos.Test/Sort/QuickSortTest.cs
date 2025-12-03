namespace Algoritmos.Sort.Test;

public class QuickSortTest
{
    [Fact]
    public void Test01()
    {
        int[] numeros = { 38, 27, 43, 3, 9, 82, 10 };
        int[] expected = { 3, 9, 10, 27, 38, 43, 82 };
        QuickSort.Sort(numeros, 0, numeros.Length - 1);

        Assert.Equal(expected, numeros);
    }
}
