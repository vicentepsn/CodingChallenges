namespace CodingChallenges.Matrix.Test;

public class PathWithMinimumEffortTest
{
    [Fact]
    public void Test01()
    {
        int[][] heights = [[1, 2, 2], [3, 8, 2], [5, 3, 5]];

        int expected = 2;

        int output = PathWithMinimumEffort.MinimumEffortPath(heights);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test02()
    {
        int[][] heights = [[1, 2, 1, 1, 1], [1, 2, 1, 2, 1], [1, 2, 1, 2, 1], [1, 2, 1, 2, 1], [1, 1, 1, 2, 1]];

        int expected = 0;

        int output = PathWithMinimumEffort.MinimumEffortPath(heights);

        Assert.Equal(expected, output);
    }
}
