namespace CodingChallenges.Arrays.Test
{
    public class MiceAndCheeseTest
    {
        [Fact]
        public void test01()
        {
            var reward1 = new int[] { 1, 1, 3, 4 };
            var reward2 = new int[] { 4, 4, 1, 1 };
            int k = 2;

            var expected = 15;

            var output = MiceAndCheese.MiceAndCheeseMaxReward(reward1, reward2, k);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test02()
        {
            var reward1 = new int[] { 1, 1 };
            var reward2 = new int[] { 1, 1 };
            int k = 2;

            var expected = 2;

            var output = MiceAndCheese.MiceAndCheeseMaxReward(reward1, reward2, k);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test03()
        {
            var reward1 = new int[] { 3, 8, 22, 11 };
            var reward2 = new int[] { 0, 15, 21, 10 };
            int k = 2;

            var expected = 50;

            var output = MiceAndCheese.MiceAndCheeseMaxReward(reward1, reward2, k);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test04()
        {
            var reward1 = new int[] { 3, 3 };
            var reward2 = new int[] { 3, 5 };
            int k = 1;

            var expected = 8;

            var output = MiceAndCheese.MiceAndCheeseMaxReward(reward1, reward2, k);

            Assert.Equal(expected, output);
        }
    }
}
