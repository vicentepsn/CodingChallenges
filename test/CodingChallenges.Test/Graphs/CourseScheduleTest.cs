namespace CodingChallenges.Graphs.Test;

public class CourseScheduleTest
{
    [Fact]
    public void Test01()
    {
        int numCourses = 2;
        int[][] prerequisites = [[1, 0]];

        bool expected = true;

        bool actual = CourseScheduleCGPT.CanFinish(numCourses, prerequisites);

        Assert.Equal(expected, actual);
    }
}
