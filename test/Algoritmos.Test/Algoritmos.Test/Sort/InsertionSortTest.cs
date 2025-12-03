namespace Algoritmos.Sort.Test
{
    public class InsertionSortTest
    {
        [Fact]
        public void Test1()
        {
            int[] numeros = { 38, 27, 43, 3, 9, 82, 10 };
            int[] expected = { 3, 9, 10, 27, 38, 43, 82 };
            InsertionSort.Sort(numeros);

            Assert.Equal(expected, numeros);
        }
    }
}