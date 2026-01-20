using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Arrays.Test
{
    [CollectionDefinition(name: nameof(FirstMissingPositiveTest), DisableParallelization = true)]
    public class FirstMissingPositiveTest
    {
        [Theory(Timeout = 2000)]
        [InlineData(6, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(5, new int[] { 2, 3, 1, -4, 4 })]
        [InlineData(4, new int[] { 2, -2, 3, 1, -4, -9, 8 })]
        [InlineData(4, new int[] { 2, -2, 3, 3, 3, 1, -4, -9, 8 })]
        [InlineData(1, new int[] { 7, 8, 9, 11, 12 })]
        public async Task TestCases_myBetter(int expected, int[] numbers)
        {
            FirstMissingPositive firstMissingPositive = new FirstMissingPositive();

            int result = await Task.Run(() => firstMissingPositive.firstMissingPositive_myBetter(numbers));

            Assert.Equal(expected, result);
        }

        [Theory(Timeout = 2000)]
        [InlineData(6, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(5, new int[] { 2, 3, 1, -4, 4 })]
        [InlineData(4, new int[] { 2, -2, 3, 1, -4, -9, 8 })]
        [InlineData(4, new int[] { 2, -2, 3, 3, 3, 1, -4, -9, 8 })]
        [InlineData(1, new int[] { 7, 8, 9, 11, 12 })]
        public async Task TestCases_MyMoreSpace(int expected, int[] numbers)
        {
            FirstMissingPositive firstMissingPositive = new FirstMissingPositive();

            int result = await Task.Run(() => firstMissingPositive.firstMissingPositive_MyMoreSpace(numbers));

            Assert.Equal(expected, result);
        }

        [Theory(Timeout = 2000)]
        [InlineData(6, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(5, new int[] { 2, 3, 1, -4, 4 })]
        [InlineData(4, new int[] { 2, -2, 3, 1, -4, -9, 8 })]
        [InlineData(4, new int[] { 2, -2, 3, 3, 3, 1, -4, -9, 8 })]
        [InlineData(1, new int[] { 7, 8, 9, 11, 12 })]
        public async Task TestCases_new(int expected, int[] numbers)
        {
            FirstMissingPositive firstMissingPositive = new FirstMissingPositive();

            int result = await Task.Run(() => firstMissingPositive.firstMissingPositive_new(numbers));

            Assert.Equal(expected, result);
        }

        [Theory(Timeout = 2000)]
        [InlineData(6, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(5, new int[] { 2, 3, 1, -4, 4 })]
        [InlineData(4, new int[] { 2, -2, 3, 1, -4, -9, 8 })]
        [InlineData(4, new int[] { 2, -2, 3, 3, 3, 1, -4, -9, 8 })]
        [InlineData(1, new int[] { 7, 8, 9, 11, 12 })]
        public async Task TestCase_20251219_v1(int expected, int[] numbers)
        {
            int result = await Task.Run(() => FirstMissingPositive.FirstMissingPositive_20251219_v2(numbers));

            Assert.Equal(expected, result);
        }

        //[Fact]
        //public void TestCase02()
        //{
        //    FirstMissingPositive firstMissingPositive = new FirstMissingPositive();
        //    int[] numbers = { 2, 3, 1, -4, 4 };
        //    int expected = 5;

        //    int result = firstMissingPositive.firstMissingPositive_myBetter(numbers);
        //    int result2 = firstMissingPositive.firstMissingPositive_MyMoreSpace(numbers);
        //    int result3 = firstMissingPositive.firstMissingPositive_new(numbers);

        //    Assert.Equal(expected, result);
        //    Assert.Equal(expected, result2);
        //    Assert.Equal(expected, result3);
        //}

        //[Fact]
        //public void TestCase03()
        //{
        //    FirstMissingPositive firstMissingPositive = new FirstMissingPositive();
        //    int[] numbers = { 2, -2, 3, 1, -4, -9, 8 };
        //    int expected = 4;

        //    int result = firstMissingPositive.firstMissingPositive_myBetter(numbers);
        //    int result2 = firstMissingPositive.firstMissingPositive_MyMoreSpace(numbers);
        //    int result3 = firstMissingPositive.firstMissingPositive_new(numbers);

        //    Assert.Equal(expected, result);
        //    Assert.Equal(expected, result2);
        //    Assert.Equal(expected, result3);
        //}

        //[Fact]
        //public void TestCase04()
        //{
        //    FirstMissingPositive firstMissingPositive = new FirstMissingPositive();
        //    int[] numbers = { 2, -2, 3, 3, 3, 1, -4, -9, 8 };
        //    int expected = 4;

        //    int result = firstMissingPositive.firstMissingPositive_myBetter(numbers);
        //    int result2 = firstMissingPositive.firstMissingPositive_MyMoreSpace(numbers);
        //    int result3 = firstMissingPositive.firstMissingPositive_new(numbers);

        //    Assert.Equal(expected, result);
        //    Assert.Equal(expected, result2);
        //    Assert.Equal(expected, result3);
        //}

        //[Fact]
        //public void TestCase05()
        //{
        //    FirstMissingPositive firstMissingPositive = new FirstMissingPositive();
        //    int[] numbers = { 7, 8, 9, 11, 12 };
        //    int expected = 1;

        //    int result = firstMissingPositive.firstMissingPositive_myBetter(numbers);
        //    int result2 = firstMissingPositive.firstMissingPositive_MyMoreSpace(numbers);
        //    int result3 = firstMissingPositive.firstMissingPositive_new(numbers);

        //    Assert.Equal(expected, result);
        //    Assert.Equal(expected, result2);
        //    Assert.Equal(expected, result3);
        //}
    }
}
