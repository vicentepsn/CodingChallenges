namespace CodingChallenges.Maths.Test;

public class HappyNumberTest
{
    [Fact]
    public void Test01()
    {
        int n = 19;
        bool expected = true;

        bool output = HappyNumber.IsHappy(n);

        Assert.Equal(expected, output);
    }
}
