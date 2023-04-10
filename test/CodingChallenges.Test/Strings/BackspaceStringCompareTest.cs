namespace CodingChallenges.Strings.Test
{
    public class BackspaceStringCompareTest
    {
        [Fact]
        public void Test1()
        {
            string inputS = "ab##";
            string inputT = "a#b#";
            bool expected = true;

            var output = BackspaceStringCompare.BackspaceCompare(inputS, inputT);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test2()
        {
            string inputS = "a#c";
            string inputT = "b";
            bool expected = false;

            var output = BackspaceStringCompare.BackspaceCompare(inputS, inputT);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test3()
        {
            string inputS = "y#fo##f";
            string inputT = "y#f#o##f";
            bool expected = true;

            var output = BackspaceStringCompare.BackspaceCompare(inputS, inputT);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test4()
        {
            string inputS = "ab##";
            string inputT = "c#d#";
            bool expected = true;

            var output = BackspaceStringCompare.BackspaceCompare(inputS, inputT);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test5()
        {
            string inputS = "bxj##tw";
            string inputT = "bxo#j##tw";
            bool expected = true;

            var output = BackspaceStringCompare.BackspaceCompare(inputS, inputT);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test6()
        {
            string inputS = "bbbextm";
            string inputT = "bbb#extm";
            bool expected = false;

            var output = BackspaceStringCompare.BackspaceCompare(inputS, inputT);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test7()
        {
            string inputS = "nzp#o#g";
            string inputT = "b#nzp#o#g";
            bool expected = true;

            var output = BackspaceStringCompare.BackspaceCompare(inputS, inputT);

            Assert.Equal(expected, output);
        }

    }
}
