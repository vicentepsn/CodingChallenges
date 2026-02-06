namespace CodingChallenges.Strings.Test
{
    public class LengthOfLongestSubstringTest
    {
        [Fact]
        public void Test1()
        {
            string input = "acabcbdca";
            int expected = 4;

            var output = LongestSubstringWithoutRepeatingCharacters.GetLengthOfLongestSubstring(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test2()
        {
            string input = "abcabcbb";
            int expected = 3;

            var output = LongestSubstringWithoutRepeatingCharacters.GetLengthOfLongestSubstring(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test3()
        {
            string input = "bbbbb";
            int expected = 1;

            var output = LongestSubstringWithoutRepeatingCharacters.GetLengthOfLongestSubstring(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test4()
        {
            string input = "pwwkew";
            int expected = 3;

            var output = LongestSubstringWithoutRepeatingCharacters.GetLengthOfLongestSubstring(input);

            Assert.Equal(expected, output);
        }
    }
}
