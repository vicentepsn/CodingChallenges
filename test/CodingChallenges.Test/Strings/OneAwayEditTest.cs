using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Strings.Test
{
    public class OneAwayEditTest
    {
        [Theory()]
        [InlineData("pale", "ple", true)]
        [InlineData("pales", "pale", true)]
        [InlineData("pale", "bale", true)]
        [InlineData("pale", "bake", false)]
        public void Test(string A, string B, bool expectedResult) 
        {
            OneAwayEdit oneAwayEdit = new OneAwayEdit();

            bool output = oneAwayEdit.CheckOneAwayEdit(A, B);

            Assert.Equal(expectedResult, output);
        }
    }
}
