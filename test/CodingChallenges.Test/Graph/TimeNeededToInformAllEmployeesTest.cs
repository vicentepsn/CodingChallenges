namespace CodingChallenges.Graph.Test
{
    public class TimeNeededToInformAllEmployeesTest
    {
        [Fact]
        public void test1()
        {
            var timeNeed = new TimeNeededToInformAllEmployees();

            int n = 6, headID = 2;
            var manager = new int[] { 2, 2, -1, 2, 2, 2 };
            var informTime = new int[] { 0, 0, 1, 0, 0, 0 };
            var expected = 1;

            var outputDFS = timeNeed.NumOfMinutes_DFS(n, headID, manager, informTime);

            Assert.Equal(expected, outputDFS);

            var output = timeNeed.NumOfMinutes(n, headID, manager, informTime);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void test2()
        {
            var timeNeed = new TimeNeededToInformAllEmployees();

            int n = 11, headID = 4;
            var manager = new int[] { 5, 9, 6, 10, -1, 8, 9, 1, 9, 3, 4 };
            var informTime = new int[] { 0, 213, 0, 253, 686, 170, 975, 0, 261, 309, 337 };
            var expected = 2560;

            var outputDFS = timeNeed.NumOfMinutes_DFS(n, headID, manager, informTime);

            Assert.Equal(expected, outputDFS);

            var output = timeNeed.NumOfMinutes(n, headID, manager, informTime);

            Assert.Equal(expected, output);
        }
    }
}
