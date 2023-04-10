﻿namespace CodingChallenges.Arrays.Test
{
    public class CinemaSeatAllocationTest
    {
        [Fact]
        public void test01()
        {
            int[][] input = new int[][]{ new int[] { 1, 2 },new int[] { 1, 3 }, new int[] { 1, 8 }, new int[] { 2, 6 },
                new int[] { 3, 1 },new int[] { 3, 10 }};
            int n = 3;

            var obj = new CinemaSeatAllocation();
            int output = obj.MaxNumberOfFamilies(n, input);
            int expected = 4;

            Assert.Equal(expected, output);

        }

        [Fact]
        public void test02()
        {
            int[][] input = new int[][] { new int[] { 4, 3 }, new int[] { 1, 4 }, new int[] { 4, 6 }, new int[] { 1, 7 } };
            int n = 4;

            var obj = new CinemaSeatAllocation();
            int output = obj.MaxNumberOfFamilies(n, input);
            int expected = 4;

            Assert.Equal(expected, output);

        }

        [Fact]
        public void test03()
        {
            int[][] input = new int[][]{ new int[] { 1, 6 },new int[] { 1, 8 }, new int[] { 1, 3 }, new int[] { 2, 3 },
                new int[] { 1,10 },new int[] { 1,2 },new int[] { 1,5},new int[] { 2,2 },new int[] { 2,4 },
                new int[] { 2,10 },new int[] { 1,7 },new int[] { 2,5 }};
            int n = 2;

            var obj = new CinemaSeatAllocation();
            int output = obj.MaxNumberOfFamilies(n, input);
            int expected = 1;

            Assert.Equal(expected, output);

        }
    }
}
