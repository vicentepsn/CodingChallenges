namespace CodingChallenges.Matrix.Test;

public class SpiralMatrixTest
{
    [Fact]
    public void Test01()
    {
        int[][] matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
        List<int> expected = [1, 2, 3, 6, 9, 8, 7, 4, 5];

        List<int> output = SpiralMatrix.SpiralOrder(matrix);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test02()
    {
        int[][] matrix = [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12]];
        List<int> expected = [1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7];

        List<int> output = SpiralMatrix.SpiralOrder(matrix);

        Assert.Equal(expected, output);
    }
}
