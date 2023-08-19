namespace CodingChallenges.Stack.Test
{
    public class ValidateStackSequencesTest
    {

        [Fact]
        public void ValidateStackSequences_01()
        {
            int[] pushed = { 1, 2, 3, 4, 5 };
            int[] popped = { 4, 5, 3, 2, 1 };

            var expected = true;

            var output = ValidateStackSequencesClass.ValidateStackSequences(pushed, popped);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void ValidateStackSequences_02()
        {
            int[] pushed = { 1, 2, 3, 4, 5 };
            int[] popped = { 4, 3, 5, 1, 2 };

            var expected = false;

            var output = ValidateStackSequencesClass.ValidateStackSequences(pushed, popped);

            Assert.Equal(expected, output);
        }

    }
}
