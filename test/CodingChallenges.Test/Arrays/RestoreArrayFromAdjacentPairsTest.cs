namespace CodingChallenges.Arrays.Test;

public class RestoreArrayFromAdjacentPairsTest
{
    [Fact]
    public void Test01()
    {
        int[][] adjacentPairs = [[2, 1], [3, 4], [3, 2]];
        int[] expected = [1, 2, 3, 4];

        int[] output = RestoreArrayFromAdjacentPairs.RestoreArray(adjacentPairs);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test02()
    {
        int[][] adjacentPairs = [[4, -2], [1, 4], [-3, 1]];
        int[] expected = [-3,1,4,-2];

        int[] output = RestoreArrayFromAdjacentPairs.RestoreArray(adjacentPairs);

        Assert.Equal(expected, output);
    }
}
