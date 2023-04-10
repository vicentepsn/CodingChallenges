namespace CodingChallenges.Arrays.Test
{
    public class TrappingRainWaterTest
    {
        [Fact]
        public void Test1()
        {
            int[] input = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            int expected = 6;

            var output = TrappingRainWater.Trap(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test2()
        {
            int[] input = new int[] { 4, 2, 0, 3, 2, 5 };
            int expected = 9;

            var output = TrappingRainWater.Trap(input);

            Assert.Equal(expected, output);
        }
    }
}