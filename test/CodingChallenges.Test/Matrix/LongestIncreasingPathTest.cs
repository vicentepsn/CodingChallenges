namespace CodingChallenges.Matrix.Test
{
    public class LongestIncreasingPathTest
    {

        [Fact]
        public void LongestIncreasingPath01()
        {
            int[][] input = {
                new int[] { 9,9,4},
                new int[] { 6,6,8},
                new int[] { 2,1,1},
            };

            int expected = 4;

            var output = LongestIncreasingPathClass.LongestIncreasingPath(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void LongestIncreasingPath02()
        {
            int[][] input = {
                new int[] { 3,4,5},
                new int[] { 3,2,6},
                new int[] { 2,2,1},
            };

            int expected = 4;

            var output = LongestIncreasingPathClass.LongestIncreasingPath(input);

            Assert.Equal(expected, output);
        }

    }
}
