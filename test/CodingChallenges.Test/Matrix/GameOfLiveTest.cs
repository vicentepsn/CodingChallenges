namespace CodingChallenges.Matrix.Test
{
    public class GameOfLiveTest
    {
        [Fact]
        public void Test01()
        {
            int[][] board = [[0, 1, 0], [0, 0, 1], [1, 1, 1], [0, 0, 0]];
            int[][] expect = [[0, 0, 0], [1, 0, 1], [0, 1, 1], [0, 1, 0]];

            GameOfLifeClass.GameOfLife(board);

            Assert.Equal(expect, board);
        }

        [Fact]
        public void Test02()
        {
            int[][] board = [[1, 1], [1, 0]];
            int[][] expect = [[1, 1], [1, 1]];

            GameOfLifeClass.GameOfLife(board);

            Assert.Equal(expect, board);
        }
    }
}
