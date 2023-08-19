namespace CodingChallenges.Arrays.Test
{
    public class FindMissingObservationsTest
    {
        [Fact]
        public void test01()
        {
            int[] rolls = { 3, 2, 4, 3 };
            int mean = 4;
            int n = 2;

            var output = FindMissingObservations.MissingRolls(rolls, mean, n);
            int[] expected = { 6, 6 };

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test02()
        {
            int[] rolls = { 1, 5, 6 };
            int mean = 3;
            int n = 4;

            var output = FindMissingObservations.MissingRolls(rolls, mean, n);
            int nRollsSum = output.Sum();

            int mRollsSum = rolls.Sum();
            int m = rolls.Length;

            int expectedNRollsSum = (m + n) * mean - mRollsSum;

            int[] expected = { 3, 2, 2, 2 };

            Assert.Equal(expectedNRollsSum, nRollsSum);
            Assert.Equal(expected, output);
        }

        [Fact]
        public void test03()
        {
            int[] rolls = { 1, 2, 3, 4 };
            int mean = 6;
            int n = 4;

            var output = FindMissingObservations.MissingRolls(rolls, mean, n);
            int[] expected = { };

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test04()
        {
            int[] rolls = { 1, 1, 1, 2 };
            int mean = 1;
            int n = 4;

            var output = FindMissingObservations.MissingRolls(rolls, mean, n);
            int[] expected = { };

            Assert.Equal(expected, output);
        }
    }
}
