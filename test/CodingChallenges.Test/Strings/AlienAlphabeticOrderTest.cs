namespace CodingChallenges.Strings.Test;

public class AlienAlphabeticOrderTest
{
    [Fact]
    public void Teste01()
    {
        string[] imput = ["xww", "wxyz", "wxyw", "ywz", "ywx"];
        char[] expected = ['z', 'x', 'w', 'y'];

        var output = AlienAlphabeticOrder.GetAlianAlphabeticOrder(imput);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Teste02()
    {
        string[] imput = ["baa", "abcd", "abca", "cab", "cad"];
        char[] expected = ['b', 'd', 'a', 'c'];

        var output = AlienAlphabeticOrder.GetAlianAlphabeticOrder(imput);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Teste03()
    {
        string[] imput = ["caa", "aaa", "aab"];
        char[] expected = ['c', 'a', 'b'];

        var output = AlienAlphabeticOrder.GetAlianAlphabeticOrder(imput);

        Assert.Equal(expected, output);
    }
}
