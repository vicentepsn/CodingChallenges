namespace CodingChallenges.Strings.Test
{
    public class SubstringWithConcatenationOfAllWordsTest
    {
        [Fact]
        public void Test01()
        {
            string inputString = "barfoothefoobarman";
            string[] inputWords = ["foo", "bar"];

            List<int> expectedOutput = [0, 9];

            List<int> output = SubstringWithConcatenationOfAllWords.FindSubstring(inputString, inputWords);

            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Test02()
        {
            string inputString = "wordgoodgoodgoodbestword";
            string[] inputWords = ["word", "good", "best", "word"];

            List<int> expectedOutput = [];

            List<int> output = SubstringWithConcatenationOfAllWords.FindSubstring(inputString, inputWords);

            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Test03()
        {
            string inputString = "barfoofoobarthefoobarman";
            string[] inputWords = ["bar", "foo", "the"];

            List<int> expectedOutput = [6, 9, 12];

            List<int> output = SubstringWithConcatenationOfAllWords.FindSubstring(inputString, inputWords);

            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Test04()
        {
            string inputString = "lingmindraboofooowingdingbarrwingmonkeypoundcake";
            string[] inputWords = ["fooo", "barr", "wing", "ding", "wing"];

            List<int> expectedOutput = [13];

            List<int> output = SubstringWithConcatenationOfAllWords.FindSubstring(inputString, inputWords);

            Assert.Equal(expectedOutput, output);
        }

        //[Fact]
        //public void Test05()
        //{
        //    string inputString = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        //    string[] inputWords = ["a", "a", "a"];

        //    List<int> expectedOutput = [6, 9, 12];

        //    List<int> output = SubstringWithConcatenationOfAllWords.FindSubstring(inputString, inputWords);

        //    Assert.Equal(expectedOutput, output);
        //}

        [Fact]
        public void Test06()
        {
            string inputString = "ababaab";
            string[] inputWords = ["ab", "ba", "ba"];

            List<int> expectedOutput = [1];

            List<int> output = SubstringWithConcatenationOfAllWords.FindSubstring(inputString, inputWords);

            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Test07()
        {
            string inputString = "abaababbaba";
            string[] inputWords = ["ab", "ba", "ab", "ba"];

            List<int> expectedOutput = [1,3];

            List<int> output = SubstringWithConcatenationOfAllWords.FindSubstring(inputString, inputWords);

            Assert.Equal(expectedOutput, output);
        }
    }
}
