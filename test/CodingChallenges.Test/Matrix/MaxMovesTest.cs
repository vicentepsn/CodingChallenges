using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Matrix.Test;

public class MaxMovesTest
{
    [Fact]
    public void Test01()
    {
        char[][] movementGrid = [
            ['0', '0', '0', '0', '0', '0', '0', '0'],
            ['0', '0', '0', '0', '0', '0', '0', '0'],
            ['0', '0', '0', '0', '0', '0', '0', '0'],
            ['0', '0', '0', '0', 'X', 'X', '0', '0'],
            ['0', 'X', '0', '0', 'R', 'X', '0', '0'],
            ['0', '0', '0', 'X', 'X', '0', '0', '0'],
            ['0', '0', '0', '0', '0', '0', '0', '0'],
            ['0', '0', '0', '0', '0', '0', '0', '0']
        ];

        int expectedMoves = 9;

        int actualMoves = MaxMoves.CountPossibleMovements(movementGrid);

        Assert.Equal(expectedMoves, actualMoves);
    }
}
