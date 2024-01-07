using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Arrays.Test
{
    public class ShortestDistanceTest
    {
        [Fact]
        public void test01()
        {
            var words = new string[] { "the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            var word1 = "fox";
            var word2 = "dog";

            int expected = 5;

            int output = ShortestDistanceClass.shortestDistance(words, word1, word2);

            Assert.Equal(expected, output);
        }
    }
}
