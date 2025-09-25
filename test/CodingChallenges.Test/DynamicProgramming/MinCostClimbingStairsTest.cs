using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.DynamicProgramming.Test
{
    public class MinCostClimbingStairsTest
    {
        [Fact]
        public void TestUp()
        {
            var cost = new int[] { 10, 15, 20, 5, 8, 7, 1, 10, 16 }; 
            var expected = 37;
            var output = MinCostClimbingStairs.minCostClimbingStairsUp(cost);
            Assert.Equal(expected, output);
        }

        [Fact]
        public void TestDownRegular()
        {
            var cost = new int[] { 10, 15, 20, 5, 8, 7, 1, 10, 16 };
            var expected = 37;
            var output = MinCostClimbingStairs.minCostClimbingStairsDown(cost);
            Assert.Equal(expected, output);
        }

        [Fact]
        public void TestDownDP()
        {
            var cost = new int[] { 10, 15, 20, 5, 8, 7, 1, 10, 16 };
            var expected = 37;
            var output = MinCostClimbingStairs.minCostClimbingStairsDownDP(cost);
            Assert.Equal(expected, output);
        }

        [Fact]
        public void TestUpArray()
        {
            var cost = new int[] { 10, 15, 20, 5, 8, 7, 1, 10, 16 };
            var expected = 37;
            var output = MinCostClimbingStairs.minCostClimbingStairsArray(cost);
            Assert.Equal(expected, output);
        }

        [Fact]
        public void TestUpArray2()
        {
            var cost = new int[] { 10, 15, 20, 5, 8, 7, 1, 10, 16 };
            var expected = 37;
            var output = MinCostClimbingStairs.minCostClimbingStairsArray2(cost);
            Assert.Equal(expected, output);
        }
    }
}
