using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Matrix.Test;

public class SnakesAndLaddersTest
{
    [Fact]
    public void Test01()
    {
        int[][] board = [
            [-1, -1, -1, -1, -1, -1],
            [-1, -1, -1, -1, -1, -1],
            [-1, -1, -1, -1, -1, -1],
            [-1, 35, -1, -1, 13, -1],
            [-1, -1, -1, -1, -1, -1],
            [-1, 15, -1, -1, -1, -1]
        ];

        int expected = 4;
        SnakesAndLaddersClass snakesAndLadders = new();

        int output = snakesAndLadders.SnakesAndLadders(board);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test02()
    {
        int[][] board = [
            [-1,-1],
            [-1,3]
        ];

        int expected = 1;
        SnakesAndLaddersClass snakesAndLadders = new();

        int output = snakesAndLadders.SnakesAndLadders(board);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test03()
    {
        int[][] board = [
            [-1,-1,-1],
            [-1,9,8],
            [-1,8,9]
        ];

        int expected = 1;
        SnakesAndLaddersClass snakesAndLadders = new();

        int output = snakesAndLadders.SnakesAndLadders(board);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test04()
    {
        int[][] board = [
            [1,1,-1],
            [1,1,1],
            [-1,1,1]
        ];

        int expected = -1;
        SnakesAndLaddersClass snakesAndLadders = new();

        int output = snakesAndLadders.SnakesAndLadders(board);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test05()
    {
        int[][] board = [
            [-1,1,2,-1],
            [2,13,15,-1],
            [-1,10,-1,-1],
            [-1,6,2,8]
        ];

        int expected = 2;
        SnakesAndLaddersClass snakesAndLadders = new();

        int output = snakesAndLadders.SnakesAndLadders(board);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test06()
    {
        int[][] board = [
            [-1,-1,30,14,15,-1],
            [23,9,-1,-1,-1,9],
            [12,5,7,24,-1,30],
            [10,-1,-1,-1,25,17],
            [32,-1,28,-1,-1,32],
            [-1,-1,23,-1,13,19]
        ];

        int expected = 2;
        SnakesAndLaddersClass snakesAndLadders = new();

        int output = snakesAndLadders.SnakesAndLadders(board);

        Assert.Equal(expected, output);
    }

    [Fact]
    public void Test07()
    {
        int[][] board = [
            [-1,-1,-1,-1,48,5,-1],
            [12,29,13,9,-1,2,32],
            [-1,-1,21,7,-1,12,49],
            [42,37,21,40,-1,22,12],
            [42,-1,2,-1,-1,-1,6],
            [39,-1,35,-1,-1,39,-1],
            [-1,36,-1,-1,-1,-1,5]
        ];

        int expected = 3;
        SnakesAndLaddersClass snakesAndLadders = new();

        int output = snakesAndLadders.SnakesAndLadders(board);

        Assert.Equal(expected, output);
    }
}
