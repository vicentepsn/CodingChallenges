namespace CodingChallenges.Arrays.Test
{
    public class CircularArrayRotationTest
    {
        [Fact]
        public void CircularArrayRotation_01()
        {
            List<int> input = new List<int> { 3, 4, 5 };
            List<int> queries = new List<int> { 1, 2 };
            int k = 2;

            var expected = new List<int> { 5, 3 };

            var output = CircularArrayRotationClass.CircularArrayRotation(input, k, queries);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void CircularArrayRotation_02()
        {
            List<int> input = new List<int> { 1, 2, 3 };
            List<int> queries = new List<int> { 0, 1, 2 };
            int k = 2;

            var expected = new List<int> { 2, 3, 1 };

            var output = CircularArrayRotationClass.CircularArrayRotation(input, k, queries);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void CircularArrayRotation_03()
        {
            List<int> input = new List<int> { 0, 1, 2 };
            List<int> queries = new List<int> { 0, 1, 2 };
            int k = 5;

            var expected = new List<int> { 1, 2, 0 };

            var output = CircularArrayRotationClass.CircularArrayRotation(input, k, queries);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void CircularArrayRotation_04()
        {
            List<int> input = new List<int> { 0, 1, 2 };
            List<int> queries = new List<int> { 0, 1, 2 };
            int k = 4;

            var expected = new List<int> { 2, 0, 1 };

            var output = CircularArrayRotationClass.CircularArrayRotation(input, k, queries);

            Assert.Equal(expected, output);
        }
    }
}
