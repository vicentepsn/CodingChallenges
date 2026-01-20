namespace CodingChallenges.Graphs.Test;

public class NetworkDelayTimeWithNegativesTest
{
    [Fact]
    public void test1()
    {
        var input = new int[][]
        {
            new int[]{1, 4,  2},
            new int[]{1, 2,  9},
            new int[]{4, 2, -4},
            new int[]{2, 5, -3},
            new int[]{4, 5,  6},
            new int[]{3, 2,  3},
            new int[]{5, 3,  7},
            new int[]{3, 1,  5},
        };

        int n = 5, k = 1, expected = 2;

        var output = NetworkDelayTimeWithNegatives.networkDelayTime(input, n, k);

        Assert.Equal(expected, output);
    }


}