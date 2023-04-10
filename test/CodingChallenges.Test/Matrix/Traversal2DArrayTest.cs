namespace CodingChallenges.Matrix.Test
{
    public class Traversal2DArrayTest
    {
        [Fact]
        public void TraversarDFS()
        {
            int[,] inputMatrix = {
              { 1, 2, 3, 4, 5 },
              { 6, 7, 8, 9, 10 },
              { 11, 12, 13, 14, 15 },
              { 16, 17, 18, 19, 20 }
            };

            var expected = new int[] { 1, 2, 3, 4, 5, 10, 15, 20, 19, 14, 9, 8, 13, 18, 17, 12, 7, 6, 11, 16 };

            var traversalDFS = new Traversal2DArray();

            var output = traversalDFS.TraversalDFS(inputMatrix);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void TraversarBFS()
        {
            int[,] inputMatrix = {
              {  1,  2,  3,  4,  5 },
              {  6,  7,  8,  9, 10 },
              { 11, 12, 13, 14, 15 },
              { 16, 17, 18, 19, 20 }
            };

            var expected = new int[] { 13, 8, 14, 18, 12, 3, 9, 7, 15, 19, 17, 11, 4, 2, 10, 6, 20, 16, 5, 1 };

            var traversalDFS = new Traversal2DArray();

            var output = traversalDFS.TraversalBFS(inputMatrix, 2, 2);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void TraversarBFS2()
        {
            int[,] inputMatrix = {
              {  1,  2,  3,  4,  5 },
              {  6,  7,  8,  9, 10 },
              { 11, 12, 13, 14, 15 },
              { 16, 17, 18, 19, 20 }
            };

            var expected = new int[] { 1, 2, 6, 3, 7, 11, 4, 8, 12, 16, 5, 9, 13, 17, 10, 14, 18, 15, 19, 20 };

            var traversalDFS = new Traversal2DArray();

            var output = traversalDFS.TraversalBFS(inputMatrix);

            Console.WriteLine($"output: [{string.Join(", ", output)}]");

            Assert.Equal(expected, output);
        }
    }
}
