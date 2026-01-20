namespace CodingChallenges.Arrays.Test;

public class LongestConsecutiveSequenceTest
{
    [Fact]
    public void Teste01()
    {
        int[] nums = [100, 4, 200, 1, 3, 2];
        int expected = 4;

        int output = LongestConsecutiveSequence.LongestConsecutive(nums);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Teste02()
    {
        int[] nums = [0, 3, 7, 2, 5, 8, 4, 6, 0, 1];
        int expected = 9;

        int output = LongestConsecutiveSequence.LongestConsecutive(nums);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Teste03()
    {
        int[] nums = [1, 0, 1, 2];
        int expected = 3;

        int output = LongestConsecutiveSequence.LongestConsecutive(nums);

        Assert.Equal(expected, output);
    }
}
