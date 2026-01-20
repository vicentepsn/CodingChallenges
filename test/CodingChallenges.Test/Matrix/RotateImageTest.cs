namespace CodingChallenges.Matrix.Test;

public class RotateImageTest
{
    [Fact]
    public void Test01()
    {
        int[][] matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
        int[][] expected = [[7, 4, 1], [8, 5, 2], [9, 6, 3]];

        RotateImage.Rotate(matrix);

        Assert.Equal(expected, matrix);
    }

    [Fact]
    public void Test02()
    {
        int[][] matrix = [[5, 1, 9, 11], [2, 4, 8, 10], [13, 3, 6, 7], [15, 14, 12, 16]];
        int[][] expected = [[15, 13, 2, 5], [14, 3, 4, 1], [12, 6, 8, 9], [16, 7, 10, 11]];

        RotateImage.Rotate(matrix);

        Assert.Equal(expected, matrix);
    }

    [Fact]
    public void Test_nonSquare01()
    {
        int[][] matrix = [[1, 2, 3, 20], [4, 5, 6, 21], [7, 8, 9, 22]];
        int[][] expected = [[7, 4, 1], [8, 5, 2], [9, 6, 3], [22, 21, 20]];

        int[][] output = RotateImage.RotateNonSquare_v2(matrix);
        Assert.Equal(expected, output);
        
        output = RotateImage.RotateNonSquare(matrix);
        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test_nonSquare02()
    {
        int[][] matrix = [[5, 1, 9, 11, 20], [2, 4, 8, 10, 21], [13, 3, 6, 7, 22], [15, 14, 12, 16, 23]];
        int[][] expected = [[15, 13, 2, 5], [14, 3, 4, 1], [12, 6, 8, 9], [16, 7, 10, 11], [23, 22, 21, 20]];

        int[][] output = RotateImage.RotateNonSquare_v2(matrix);
        Assert.Equal(expected, output);

        output = RotateImage.RotateNonSquare(matrix);
        Assert.Equal(expected, output);
    }
}
