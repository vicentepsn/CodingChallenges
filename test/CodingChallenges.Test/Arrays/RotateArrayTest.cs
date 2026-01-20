using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Arrays.Test
{
    public class RotateArrayTest
    {
        [Fact]
        public void test01()
        {
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] expected = { 8, 9, 10, 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;

            RotateArray.Rotate(input, k);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void test02()
        {
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int[] expected = { 10, 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int k = 3;

            RotateArray.Rotate(input, k);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void test03()
        {
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int[] expected = { 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int k = 1;

            RotateArray.Rotate(input, k);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void test04()
        {
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int[] expected = { 8, 9, 10, 11, 12, 1, 2, 3, 4, 5, 6, 7 };
            int k = 5;

            RotateArray.Rotate(input, k);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void test05()
        {
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] expected = { 11, 12, 13, 14, 15, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int k = 5;

            RotateArray.Rotate(input, k);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void test06()
        {
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] expected = { 11, 12, 13, 14, 15, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int k = 20;

            RotateArray.Rotate(input, k);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void test07()
        {
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int k = 30;

            RotateArray.Rotate(input, k);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void test08()
        {
            int[] input = { 1, 2, 3, 4, 5, 6 };
            int[] expected = { 3, 4, 5, 6, 1, 2 };
            int k = 4;

            RotateArray.Rotate(input, k);

            Assert.Equal(expected, input);
        }
    }
}
