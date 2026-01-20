namespace CodingChallenges.Strings.Test;

public class BasicCalculatorTest
{
    [Fact]
    public void Test01()
    {
        string input = "1 + 1";
        int expected = 2;

        int output = BasicCalculator.Calculate(input);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test02()
    {
        string input = " 2-1 + 2 ";
        int expected = 3;

        int output = BasicCalculator.Calculate(input);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test03()
    {
        string input = "(1+(4+5+2)-3)+(6+8)";
        int expected = 23;

        int output = BasicCalculator.Calculate(input);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test04()
    {
        string input = "- (3 + (4 + 5))";
        int expected = -12;

        int output = BasicCalculator.Calculate(input);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test05()
    {
        string input = "-2147483648";
        int expected = -2147483648;

        int output = BasicCalculator.Calculate(input);

        Assert.Equal(expected, output);
    }
}
