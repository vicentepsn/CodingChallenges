namespace CodingChallenges.Matrix.Test
{
    public class NumberIncreasingPathsTest
    {
        [Fact]
        public void NumberIncreasingPaths_01()
        {
            int[][] input = {
                new int[] { 1,2},
                new int[] { 4,3},
            };

            int expected = 11;

            var output = NumberIncreasingPathsClass.CountPaths(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void NumberIncreasingPaths_02()
        {
            int[][] input = {
                new int[] { 3,4,5},
                new int[] { 3,2,6},
                new int[] { 2,2,1},
            };

            int expected = 23;

            var output = NumberIncreasingPathsClass.CountPaths(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void NumberIncreasingPaths_03()
        {
            int[][] input = {
                new int[] { 7,8,9},
                new int[] { 6,1,2},
                new int[] { 5,4,3},
            };

            int expected = 59;

            var output = NumberIncreasingPathsClass.CountPaths(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void NumberIncreasingPaths_04()
        {
            int[][] input = {
                new int[] { 1,1},
                new int[] { 3,4},
            };

            int expected = 8;

            var output = NumberIncreasingPathsClass.CountPaths(input);

            Assert.Equal(expected, output);
        }

    }
}
