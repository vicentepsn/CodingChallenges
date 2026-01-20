namespace CodingChallenges.Graphs.Test;

public class NetworkDelayTimeTest
{
    [Fact]
    public void test1()
    {
        var input = new int[][]
        {
            new int[]{2,1,1},
            new int[]{2,3,1},
            new int[]{3,4,1},
        };

        int n = 4, k = 2, expected = 2;

        var output = NetworkDelayTime.networkDelayTime(input, n, k);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void test2()
    {
        var input = new int[][]
        {
            new int[]{1,2,1},
        };

        int n = 2, k = 1, expected = 1;

        var output = NetworkDelayTime.networkDelayTime(input, n, k);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void test3()
    {
        var input = new int[][]
        {
            new int[]{1,2,1},
        };

        int n = 2, k = 2, expected = -1;

        var output = NetworkDelayTime.networkDelayTime(input, n, k);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void test4()
    {
        var input = new int[][]
        {
            new int[]{1, 2, 9},
            new int[]{1, 4, 2},
            new int[]{2, 5, 1},
            new int[]{4, 2, 4},
            new int[]{4, 5, 6},
            new int[]{3, 2, 3},
            new int[]{5, 3, 7},
            new int[]{3, 1, 5},
        };

        int n = 5, k = 1, expected = 14;

        var output = NetworkDelayTime.networkDelayTime(input, n, k);

        Assert.Equal(expected, output);
    }

}
/*
* 
*     const t = [
*     [1, 2, 9], 
*     [1, 4, 2], 
*     [2, 5, 1], 
*     [4, 2, 4], 
*     [4, 5, 6],
*     [3, 2, 3], 
*     [5, 3, 7], 
*     [3, 1, 5]]
console.log(networkDelayTime(t, 5, 1))

Input: times = [[2,1,1],[2,3,1],[3,4,1]], n = 4, k = 2
Output: 2
Example 2:

Input: times = [[1,2,1]], n = 2, k = 1
Output: 1
Example 3:

Input: times = [[1,2,1]], n = 2, k = 2
Output: -1
*/