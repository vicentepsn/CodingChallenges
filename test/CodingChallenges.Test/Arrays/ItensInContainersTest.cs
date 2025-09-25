using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Arrays.Test
{
    public class ItensInContainersTest
    {
        [Fact]
        public void test01()
        {
            var s = "|**|*|*";
            var startIndices = new List<int>() { 1, 1 };
            var endtIndices = new List<int>() { 5, 6 };

            var expectedResult = new List<int>() { 2, 3 };

            var output = ItensInContainers.numberOfItems(s, startIndices, endtIndices);

            Assert.Equal(expectedResult, output);
        }

        [Fact]
        public void test02()
        {
            var s = "*|*|";
            var startIndices = new List<int>() { 1 };
            var endtIndices = new List<int>() { 3 };

            var expectedResult = new List<int>() { 0 };

            var output = ItensInContainers.numberOfItems(s, startIndices, endtIndices);

            Assert.Equal(expectedResult, output);
        }

        [Fact]
        public void test03()
        {
            var s = "*|*|*|";
            var startIndices = new List<int>() { 1 };
            var endtIndices = new List<int>() { 6 };

            var expectedResult = new List<int>() { 2 };

            var output = ItensInContainers.numberOfItems(s, startIndices, endtIndices);

            Assert.Equal(expectedResult, output);
        }
    }
}
