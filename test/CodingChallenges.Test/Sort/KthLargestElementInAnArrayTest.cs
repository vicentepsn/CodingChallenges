namespace CodingChallenges.Sort.Test
{
    public class KthLargestElementInAnArrayTest
    {
        [Fact]
        public void test1()
        {
            int[] input = { 3, 2, 1, 5, 6, 4 };
            int[] expected = { 1, 2, 3, 4, 5, 6 };

            KthLargestElementInAnArray.QuickSort(input, 0, input.Length - 1);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void FindKthLargestElementInAnArray_1()
        {
            int[] input = { 3, 2, 1, 5, 6, 4 };
            int k = 2;
            int expected = 5;

            var output = KthLargestElementInAnArray.FindKthLargest(input, k);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void FindKthLargestElementInAnArray_2()
        {
            int[] input = { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            int k = 4;
            int expected = 4;

            var output = KthLargestElementInAnArray.FindKthLargest(input, k);

            Assert.Equal(expected, output);
        }
    }
}
