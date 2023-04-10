namespace CodingChallenges.Strings.Test
{
    public class LongestValidBracketsTest
    {
        [Fact]
        public void Test_01()
        {
            string input = "";
            int expected = 0;

            var output = LongestValidBracketsClass.LongestValidBrackets(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test_02()
        {
            string input = ")))";
            int expected = 0;

            var output = LongestValidBracketsClass.LongestValidBrackets(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test_03()
        {
            string input = "(()";
            int expected = 2;

            var output = LongestValidBracketsClass.LongestValidBrackets(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test_04()
        {
            string input = ")()())";
            int expected = 4;

            var output = LongestValidBracketsClass.LongestValidBrackets(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test_05()
        {
            string input = "(()())";
            int expected = 6;

            var output = LongestValidBracketsClass.LongestValidBrackets(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test_06()
        {
            string input = ")))()(((";
            int expected = 2;

            var output = LongestValidBracketsClass.LongestValidBrackets(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test_07()
        {
            string input = "(((((((())))()()))()()";
            int expected = 20;

            var output = LongestValidBracketsClass.LongestValidBrackets(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test_08()
        {
            string input = "((())))()()()()((()((";
            int expected = 8;

            var output = LongestValidBracketsClass.LongestValidBrackets(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test_09()
        {
            string input = ")(((((()())()()))()(()))(";
            int expected = 22;

            var output = LongestValidBracketsClass.LongestValidBrackets(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test_10()
        {
            string input = "()(()(()(()(()(()(()";
            int expected = 2;

            var output = LongestValidBracketsClass.LongestValidBrackets(input);

            Assert.Equal(expected, output);
        }
    }
}
