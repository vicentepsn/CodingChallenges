using CodingChallenges.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Strings.Test
{
    public class LongestBinaryGapTest
    {
        [Theory()]
        [InlineData(2, 9)]
        [InlineData(4, 529)]
        [InlineData(1, 20)]
        [InlineData(0, 15)]
        [InlineData(0, 32)]
        public void TestCases(int expected, int N)
        {
            LongestBinaryGap longestBinaryGap = new LongestBinaryGap();

            //int result = await Task.Run(() => longestBinaryGap.GetLongestBinaryGap(N));
            int result = longestBinaryGap.GetLongestBinaryGap(N);

            Assert.Equal(expected, result);
        }

        [Theory()]
        //[InlineData(2, 819399173, 16244239, 13032961)]
        [InlineData(8, 1073741727, 1073741631, 1073741679)]
        //[InlineData(1, 20)]
        //[InlineData(0, 15)]
        //[InlineData(0, 32)]
        public void TestCases2(int expected, int A, int B, int C)
        {
            LongestBinaryGap longestBinaryGap = new LongestBinaryGap();

            //int result = await Task.Run(() => longestBinaryGap.GetLongestBinaryGap(N));
            int result = longestBinaryGap.CountConformArrays(A, B, C);

            Assert.Equal(expected, result);
        }
    }
}
