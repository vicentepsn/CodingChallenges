using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Arrays.Test;

public class InsertIntervalTest
{
    [Fact]
    public void Test01()
    {
        int[][] intervals = [[1, 3], [6, 9]];
        int[] newInterval = [2, 5];
        int[][] expected = [[1, 5], [6, 9]];

        int[][] output = InsertInterval.Insert(intervals, newInterval);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test02()
    {
        int[][] intervals = [[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]];
        int[] newInterval = [4, 8];
        int[][] expected = [[1, 2], [3, 10], [12, 16]];

        int[][] output = InsertInterval.Insert(intervals, newInterval);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test03()
    {
        int[][] intervals = [[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]];
        int[] newInterval = [2, 13];
        int[][] expected = [[1, 16]];

        int[][] output = InsertInterval.Insert(intervals, newInterval);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test04()
    {
        int[][] intervals = [[3, 5], [6, 7], [8, 10], [12, 16]];
        int[] newInterval = [1, 2];
        int[][] expected = [[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]];

        int[][] output = InsertInterval.Insert(intervals, newInterval);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test05()
    {
        int[][] intervals = [[1, 2], [3, 5], [6, 7], [8, 10]];
        int[] newInterval = [12, 16];
        int[][] expected = [[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]];

        int[][] output = InsertInterval.Insert(intervals, newInterval);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test06()
    {
        int[][] intervals = [[0, 2], [3, 9]];
        int[] newInterval = [6, 8];
        int[][] expected = [[0, 2], [3, 9]];

        int[][] output = InsertInterval.Insert(intervals, newInterval);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test07()
    {
        int[][] intervals = [];
        int[] newInterval = [6, 8];
        int[][] expected = [[6, 8]];

        int[][] output = InsertInterval.Insert(intervals, newInterval);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test08()
    {
        int[][] intervals = [[3, 5], [12, 15]];
        int[] newInterval = [6, 6];
        int[][] expected = [[3, 5], [6, 6], [12, 15]];

        int[][] output = InsertInterval.Insert(intervals, newInterval);

        Assert.Equal(expected, output);
    }
}
