namespace CodingChallenges.Arrays.Test
{
    public class TwoSumTest
    {
        [Fact]
        public void TwoSum_BS01()
        {
            var input = new int[] { 2, 7, 11, 15 };
            var target = 9;
            var expected = new int[] { 1, 2 };

            var output = TwoSumII.TwoSum_BS(input, target);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void TwoSum_BS02()
        {
            var input = new int[] { -38, -10, -8, 0, 2, 7, 11, 15, 21, 25 };
            var target = 9;
            var expected = new int[] { 5, 6 };

            var output = TwoSumII.TwoSum_BS(input, target);

            Assert.Equal(expected, output);
        }
    }
}
