using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Strings.Test
{
    public class IntToRomanTest
    {
        [Theory]
        [InlineData(0, "")]
        [InlineData(-1, "INVALID")]
        [InlineData(4000, "INVALID")]
        [InlineData(3999, "MMMCMXCIX")]
        [InlineData(853, "DCCCLIII")]
        [InlineData(482, "CDLXXXII")]
        [InlineData(729, "DCCXXIX")]
        public void ConvertIntToRomanTest(int value, string romanNumeral)
        {
            string output = IntToRoman.ConvertIntToRomanNumerals(value);

            Assert.Equal(romanNumeral, output);
        }
    }
}
