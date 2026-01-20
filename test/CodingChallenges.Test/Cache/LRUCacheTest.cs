namespace CodingChallenges.Cache.Test;

public class LRUCacheTest
{
    [Theory]
    [InlineData(4, "one+two-one-one+two+one")]
    [InlineData(2, "-one+two-one-one+two+one")]
    [InlineData(-3, "two-two-one-two")]
    [InlineData(2, "two")]
    [InlineData(-2, "-two")]
    public void LRUCacheTest00(int expected, string S)
    {
        LRUCache_SolMicrosoft solutionMicrosoft = new LRUCache_SolMicrosoft();

        int output = solutionMicrosoft.solution(S);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void LRUCacheTest01()
    {
        var operations = new string[] { "LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get" };
        var values = new int[][] { [2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4] };

        int?[] expected = new int?[] { null, null, null, 1, null, -1, null, -1, 3, 4 };

        int?[] output = CallOperations(operations, values);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void LRUCacheTest02()
    {
        var operations = new string[] { "LRUCache", "put", "get", "put", "get", "get" };
        var values = new int[][] { [1], [2, 1], [2], [3, 2], [2], [3] };

        int?[] expected = new int?[] { null, null, 1, null, -1, 2 };

        int?[] output = CallOperations(operations, values);

        Assert.Equal(expected, output);
    }

    private int?[] CallOperations(string[] operations, int[][] values)
    {
        var result = new int?[operations.Length];
        LRUCache lruCache = new LRUCache(values[0][0]);
        result[0] = null;

        for (int i = 0; i < result.Length; i++)
        {
            switch (operations[i])
            {
                //case "LRUCache":
                //    result[i] = null;
                //    //obj = new LRUCache(values[i][0]);
                //    break;
                case "put":
                    result[i] = null;
                    lruCache.Put(values[i][0], values[i][1]);
                    break;
                case "get":
                    result[i] = lruCache.Get(values[i][0]);
                    break;
            }
        }

        return result;
    }

}
