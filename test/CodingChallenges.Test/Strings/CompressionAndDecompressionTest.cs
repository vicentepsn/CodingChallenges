namespace CodingChallenges.Strings.Test;

public class CompressionAndDecompressionTest
{
    [Fact]
    public void Test01()
    {
        string input = "3[abc]4[ab]c";
        string expected = "abcabcabcababababc";

        CompressionAndDecompression compressionAndDecompression = new();
        string output = compressionAndDecompression.Decompress(input);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test02()
    {
        string input = "10[a]";
        string expected = "aaaaaaaaaa";

        CompressionAndDecompression compressionAndDecompression = new();
        string output = compressionAndDecompression.Decompress(input);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test03()
    {
        string input = "2[3[a]b]";
        string expected = "aaabaaab";

        CompressionAndDecompression compressionAndDecompression = new();
        string output = compressionAndDecompression.Decompress(input);

        Assert.Equal(expected, output);
    }
}
