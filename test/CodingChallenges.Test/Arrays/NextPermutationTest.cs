namespace CodingChallenges.Arrays.Test
{
    public class NextPermutationTest
    {
        [Fact]
        public void Test01()
        {
            int[] input = { 2, 1, 2, 2, 2, 2, 2, 1 };
            int[] expected = { 2, 2, 1, 1, 2, 2, 2, 2 };

            NextPermutation.nextPermutation(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void Test02()
        {
            int[] input = { 2, 2, 4, 0, 1, 2, 4, 4, 0 };
            int[] expected = { 2, 2, 4, 0, 1, 4, 0, 2, 4 };

            NextPermutation.nextPermutation(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void Test03()
        {
            int[] input = { 1, 1, 5 };
            int[] expected = { 1, 5, 1 };

            NextPermutation.nextPermutation(input);

            Assert.Equal(expected, input);
        }
    }
}
