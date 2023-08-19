namespace CodingChallenges.Test
{
    public class SolutionTest
    {
        Solution solution = new Solution();

        [Fact]
        public void Test_01()
        {
            int[] input = { 1, 3, 6, 4, 1, 2 };
            int expected = 5;

            var output = solution.solution(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test_02()
        {
            int[] input = { 1, 2, 3 };
            int expected = 4;

            var output = solution.solution(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test_03()
        {
            int[] input = { -1, -3 };
            int expected = 1;

            var output = solution.solution(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Solition1_01()
        {
            int[] input = { 2, 5, 1, 3 };

            var expected = 1;

            var output = solution.solution1(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Solition1_02()
        {
            int[] input = { -1, 0, 1, -2, -2, 4, -1 };

            var expected = 4;

            var output = solution.solution1(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Solition1_03()
        {
            int[] input = { -1, -2, -3, -2, 2 };

            var expected = 2;

            var output = solution.solution1(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Solition1_04()
        {
            int[] input = { 1 };

            var expected = 0;

            var output = solution.solution1(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Solition1_05()
        {
            int[] input = { 1, 3, 5, 7, 9 };

            var expected = 0;

            var output = solution.solution1(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Solition1_06()
        {
            int[] input = { 1, 1, 1, 1, 1 };

            var expected = 4;

            var output = solution.solution1(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Solition1_07()
        {
            int[] input = { 3, -1, 7, 1, 1, 1, 1 };

            var expected = 3;

            var output = solution.solution1(input);

            Assert.Equal(expected, output);
        }

        /// <summary>
        /// This is not actually a useful test. A Usefull test should find the probality 
        /// </summary>
        [Fact]
        public void ShuffleWord_01()
        {
            var input = "abcdefg";
            
            //var expected = new List<int> { 5, 3 };

            var output = Solution.ShuffleWord(input);
            var expected = output;
            Array.Sort(expected);

            Assert.Equal(expected, output);
        }
    }
}
