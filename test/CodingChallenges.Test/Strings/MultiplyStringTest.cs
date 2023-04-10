namespace CodingChallenges.Strings.Test
{
    public class MultiplyStringTest
    {
        [Fact]
        public void test1()
        {
            var n1 = "123";
            var n2 = "234";
            var expected = "28782";

            var output = MultiplyStrings.Multiply_NotReversing(n1, n2);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Multiply_Reverse()
        {
            var n1 = "123";
            var n2 = "234";
            var expected = "28782";

            var output = MultiplyStrings.Multiply(n1, n2);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Multiply_Optimized()
        {
            var n1 = "123";
            var n2 = "234";
            var expected = "28782";

            var output = MultiplyStrings.Multiply_Optimized(n1, n2);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Multiply_Optimized2()
        {
            var n1 = "999";
            var n2 = "99";
            var expected = "98901";

            var output = MultiplyStrings.Multiply_Optimized(n1, n2);

            Assert.Equal(expected, output);
        }
    }
}
