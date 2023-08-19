using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Strings.Test
{
    public class RemovingStarsFromAStringTest
    {
        [Fact]
        public void test1()
        {
            string input = "leet**cod*e";
            var expected = "lecoe";

            var output = RemovingStarsFromAString.RemoveStars(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test2()
        {
            string input = "erase*****";
            var expected = "";

            var output = RemovingStarsFromAString.RemoveStars(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test3()
        {
            string input = "a*bcd*e**fghijlm";
            var expected = "bfghijlm";

            var output = RemovingStarsFromAString.RemoveStars(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test4()
        {
            string input = "";
            var expected = "";

            var output = RemovingStarsFromAString.RemoveStars(input);

            Assert.Equal(expected, output);
        }

        // INVALID TEST CASES ACCORDING WITH THE PROBLEM DESCRIPTION
        //[Fact]
        //public void test5()
        //{
        //    string input = "****";
        //    var expected = "";

        //    var output = RemovingStarsFromAString.RemoveStars(input);

        //    Assert.Equal(expected, output);
        //}

        //[Fact]
        //public void test6()
        //{
        //    string input = "ab****";
        //    var expected = "";

        //    var output = RemovingStarsFromAString.RemoveStars(input);

        //    Assert.Equal(expected, output);
        //}

        [Fact]
        public void test7()
        {
            string input = "abcd";
            var expected = "abcd";

            var output = RemovingStarsFromAString.RemoveStars(input);

            Assert.Equal(expected, output);
        }

    }
}
