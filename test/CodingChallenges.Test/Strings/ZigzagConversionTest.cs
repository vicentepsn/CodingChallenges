namespace CodingChallenges.Strings.Test;

public class ZigzagConversionTest
{
    /*
    Example 1:

    Input: s = "PAYPALISHIRING", numRows = 3
    Output: "PAHNAPLSIIGYIR"
    Example 2:

    Input: s = "PAYPALISHIRING", numRows = 4
    Output: "PINALSIGYAHRPI"
    Explanation:
    P     I    N
    A   L S  I G
    Y A   H R
    P     I
    Example 3:

    Input: s = "A", numRows = 1
    Output: "A"
        */
    [Fact]
    public void Test01()
    {
        string input = "PAYPALISHIRING";
        int numRows = 3;

        string output = ZigzagConversion.Convert(input, numRows);

        string expected = "PAHNAPLSIIGYIR";
        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test02()
    {
        string input = "PAYPALISHIRING";
        int numRows = 4;

        string output = ZigzagConversion.Convert(input, numRows);

        string expected = "PINALSIGYAHRPI";
        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test03()
    {
        string input = "A";
        int numRows = 1;

        string output = ZigzagConversion.Convert(input, numRows);

        string expected = "A";
        Assert.Equal(expected, output);
    }
}
