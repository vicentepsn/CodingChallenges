namespace CodingChallenges.Arrays.Test;

public class CoinChangeTest
{
    [Fact]
    public void Test01()
    {
        var coinChange = new CoinChangeClass();

        int[] coins = [1, 2, 5];
        int amoung = 11;

        int expected = 3;

        int output = coinChange.CoinChange(coins, amoung);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test02()
    {
        var coinChange = new CoinChangeClass();

        int[] coins = [2];
        int amoung = 3;

        int expected = -1;

        int output = coinChange.CoinChange(coins, amoung);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test03()
    {
        var coinChange = new CoinChangeClass();

        int[] coins = [1];
        int amoung = 0;

        int expected = 0;

        int output = coinChange.CoinChange(coins, amoung);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test04()
    {
        var coinChange = new CoinChangeClass();

        int[] coins = [1];
        int amoung = 1;

        int expected = 1;

        int output = coinChange.CoinChange(coins, amoung);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test05()
    {
        var coinChange = new CoinChangeClass();

        int[] coins = [276, 201, 266, 375, 167];
        int amoung = 435;

        int expected = -1;

        int output = coinChange.CoinChange(coins, amoung);

        Assert.Equal(expected, output);
    }
}
