using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Greedy.Test;

public class IntervalsMinGroupsTest
{
    [Fact]
    public void Test01()
    {
        int[][] input = new int[][] { new int[] { 5, 10 }, new int[] { 6, 8 }, new int[] { 1, 5 }, new int[] { 2, 3 }, new int[] { 1, 10 } };
        int expectedResult = 3;
        int result = IntervalsMinGroups.MinGroups(input);

        Assert.Equal(expectedResult, result);
    }
}
