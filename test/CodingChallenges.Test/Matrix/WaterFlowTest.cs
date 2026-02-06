namespace CodingChallenges.Matrix.Test;

public class WaterFlowTest
{
    [Fact]
    public void Test01()
    {
        int[][] input = [
            [1, 2, 3],
            [7, 8, 9],
            [4, 5, 6],
            ];
        int[][] expected = [
            [1, 1, 1],
            [1, 1, 1],
            [4, 4, 4],
            ];
        var output = WaterFlowClass.WaterFlow(input);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test02()
    {
        int[][] input = [
            [1, 2, 3],
            [7, 8, 9],
            [0, 5, 6],
            ];
        int[][] expected = [
            [1, 1, 1],
            [0, 1, 1],
            [0, 0, 0],
            ];
        var output = WaterFlowClass.WaterFlow(input);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test03()
    {
        int[][] input = [
            [1, 2],
            [7, 8],
            ];
        int[][] expected = [
            [1, 1],
            [1, 1],
            ];
        var output = WaterFlowClass.WaterFlow(input);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test04()
    {
        int[][] input = [
            [1],
            ];
        int[][] expected = [
            [1],
            ];
        var output = WaterFlowClass.WaterFlow(input);

        Assert.Equal(expected, output);
    }
}
