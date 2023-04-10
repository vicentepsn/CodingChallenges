namespace CodingChallenges.Strings.Test
{
    public class LongestPalindromicSubstringTest
    {
        [Fact]
        public void test01()
        {
            var input = "babad";
            var expected = "aba";

            var output = LongestPalindromicSubstring.LongestPalindrome(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test02()
        {
            var input = "adam";
            var expected = "ada";

            var output = LongestPalindromicSubstring.LongestPalindrome(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test03()
        {
            var input = "cbbd";
            var expected = "bb";

            var output = LongestPalindromicSubstring.LongestPalindrome(input);

            Assert.Equal(expected, output);
        }
    }
}
