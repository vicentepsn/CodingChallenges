using CodingChallenges.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Others.Test
{
    public class TheTimeInWordsTest
    {
        [Fact]
        public void test01()
        {
            int h = 1;
            int m = 0;

            var expected = "one o' clock";

            var output = TheTimeInWords.timeInWords(h, m);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test02()
        {
            int h = 5;
            int m = 1;

            var expected = "one minute past five";

            var output = TheTimeInWords.timeInWords(h, m);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test03()
        {
            int h = 5;
            int m = 10;

            var expected = "ten minutes past five";

            var output = TheTimeInWords.timeInWords(h, m);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test04()
        {
            int h = 5;
            int m = 15;

            var expected = "quarter past five";

            var output = TheTimeInWords.timeInWords(h, m);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test05()
        {
            int h = 5;
            int m = 30;

            var expected = "half past five";

            var output = TheTimeInWords.timeInWords(h, m);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test06()
        {
            int h = 5;
            int m = 40;

            var expected = "twenty minutes to six";

            var output = TheTimeInWords.timeInWords(h, m);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test07()
        {
            int h = 5;
            int m = 45;

            var expected = "quarter to six";

            var output = TheTimeInWords.timeInWords(h, m);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test08()
        {
            int h = 5;
            int m = 47;

            var expected = "thirteen minutes to six";

            var output = TheTimeInWords.timeInWords(h, m);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test09()
        {
            int h = 5;
            int m = 28;

            var expected = "twenty eight minutes past five";

            var output = TheTimeInWords.timeInWords(h, m);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test010()
        {
            int h = 12;
            int m = 47;

            var expected = "thirteen minutes to one";

            var output = TheTimeInWords.timeInWords(h, m);

            Assert.Equal(expected, output);
        }
    }
}
