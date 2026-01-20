using DataStructures;
using DataStructures.Extensions;

namespace CodingChallenges.Trees.Test
{
    public class CountCompleteTreeNodesTest
    {


        [Fact]
        public void test1()
        {
            var tree = new TreeNode();
            tree.Insert(new int?[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, null, null, null});

            var expected = 12;
            var counter = new CountCompleteTreeNodes();
            var output = counter.CountNodes_ChatGPT(tree);

            Assert.Equal(expected, output);
        }
    }


}
