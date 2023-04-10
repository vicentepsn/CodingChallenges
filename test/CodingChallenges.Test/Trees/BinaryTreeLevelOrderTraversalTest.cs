using DataStructures;

namespace CodingChallenges.Trees.Test
{
    public class BinaryTreeLevelOrderTraversalTest
    {
        [Fact]
        public void Test1()
        {
            var root = new TreeNode()
            {
                val = 3,
                left = new TreeNode()
                {
                    val = 9
                },
                right = new TreeNode()
                {
                    val = 20,
                    left = new TreeNode()
                    {
                        val = 15
                    },
                    right = new TreeNode()
                    {
                        val = 7
                    }
                }
            };

            var expect = new List<IList<int>>()
            {
                new List<int>() { 3 },
                new List<int>() { 9,20 },
                new List<int>() { 15,7 },
            };

            var result = BinaryTreeLevelOrderTraversal.LevelOrder(root);

            Assert.True(ListOfListIsEqual(expect, result));
        }

        private bool ListOfListIsEqual(IList<IList<int>> a, IList<IList<int>> b)
        {
            if (a.Count != b.Count)
                return false;
            for(int i = 0; i < a.Count; i++)
            {
                if (a[i].Count != b[i].Count)
                    return false;

                for(int j = 0; j < a[i].Count; j++)
                {
                    if(a[i][j] != b[i][j])
                        return false;
                }
            }

            return true;
        }

    }
}
