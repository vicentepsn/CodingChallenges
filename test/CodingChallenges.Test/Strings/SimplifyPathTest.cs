namespace CodingChallenges.Strings.Test
{
    public class SimplifyPathTest
    {
        [Fact]
        public void Test1()
        {
            string input = "/home/";
            string expected = "/home";

            var output = SimplifyPathClass.SimplifyPath(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test2()
        {
            string input = "/../";
            string expected = "/";

            var output = SimplifyPathClass.SimplifyPath(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test3()
        {
            string input = "/home//foo/";
            string expected = "/home/foo";

            var output = SimplifyPathClass.SimplifyPath(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test4()
        {
            string input = "/a/b///c/.././d/../f/";
            string expected = "/a/b/f";

            var output = SimplifyPathClass.SimplifyPath(input);

            Assert.Equal(expected, output);
        }
    }
}
