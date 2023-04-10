namespace CodingChallenges.Sort.Test
{
    public class BinarySearchExtensionsTest
    {

        [Fact]
        public void test1()
        {
            int[] input = { 1, 3, 3, 5, 5, 5, 8, 9 };
            int t = 5;
            int[] expected = { 3, 5 };

            var output = BinarySearchExtensions.BirarySearchFirstAndLast(input, t);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test2()
        {
            int[] input = { 1, 3, 3, 5, 5, 5, 8, 9 };
            int t = 4;
            int[] expected = { -1, -1 };

            var output = BinarySearchExtensions.BirarySearchFirstAndLast(input, t);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test3()
        {
            int[] input = { 1, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 8, 9, 9, 9, 9, 9, 99, 9, };
            int t = 5;
            int[] expected = { 15, 24 };

            var output = BinarySearchExtensions.BirarySearchFirstAndLast(input, t);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void BinarySearch_GetFist()
        {
            int[] input = { 1, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 8, 9, 9, 9, 9, 9, 99, 9, };
            int t = 5;
            int expected = 15;

            var output = BinarySearchExtensions.BirarySearchFirst(input, t);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void BinarySearch_GetLast()
        {
            int[] input = { 1, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 8, 9, 9, 9, 9, 9, 99, 9, };
            int t = 5;
            int expected = 24;

            var output = BinarySearchExtensions.BirarySearchLast(input, t);

            Assert.Equal(expected, output);
        }
    }
}
