namespace CodingChallenges.Arrays.Test;

public class MinimumServersRequiredToRunJobsTest
{
    [Fact]
    public void Test01()
    {
        List<(int start, int duration)> input = [ 
            new (60, 120), new (150, 60), new (0, 90),
            ]; 

        int expected = 2;

        int ouput = MinimumServersRequiredToRunJobs.MinServersRequired(input);

        Assert.Equal(expected, ouput);
    }

    [Fact]
    public void Test02()
    {
        List<(int start, int duration)> input = [ 
            new (0, 90), new (90, 30), new (150, 60),
            ];

        int expected = 1;

        int ouput = MinimumServersRequiredToRunJobs.MinServersRequired(input);

        Assert.Equal(expected, ouput);
    }

    [Fact]
    public void Test03()
    {
        List<(int start, int duration)> input = [ 
            new (0, 120), new (60, 60), new (90, 60), new (300, 60),
            ]; 

        int expected = 3;

        int ouput = MinimumServersRequiredToRunJobs.MinServersRequired(input);

        Assert.Equal(expected, ouput);
    }

    [Fact]
    public void Test04()
    {
        List<(int start, int duration)> input = [ 
            new (0, 120), new (60, 60), new (90, 60), new (300, 60),new (310, 60),new (320, 60),new (330, 60),
            ]; 

        int expected = 4;

        int ouput = MinimumServersRequiredToRunJobs.MinServersRequired(input);

        Assert.Equal(expected, ouput);
    }

    [Fact]
    public void Test05()
    {
        List<(int start, int duration)> input = [ 
            new (0, 60), new (10, 60), new (61, 60), new (62, 60),new (63, 60),new (320, 60),new (330, 60),
            ]; 

        int expected = 4;

        int ouput = MinimumServersRequiredToRunJobs.MinServersRequired(input);

        Assert.Equal(expected, ouput);
    }

    [Fact]
    public void Test06()
    {
        List<(int start, int duration)> input = [ 
            new (0, 100), new (30,30), new (45,30), new (80, 40),
            ]; 

        int expected = 3;

        int ouput = MinimumServersRequiredToRunJobs.MinServersRequired(input);

        Assert.Equal(expected, ouput);
    }

    [Fact]
    public void Test07()
    {
        List<(int start, int duration)> input = [ 
            new (0, 5000), new (30,30)
            ];

        int expected = 5;

        int ouput = MinimumServersRequiredToRunJobs.MinServersRequired(input);

        Assert.Equal(expected, ouput);
    }

    [Fact]
    public void Test08()
    {
        List<(int start, int duration)> input = [ 
            new (1400, 100), new (30,30)
            ];

        int expected = 2;

        int ouput = MinimumServersRequiredToRunJobs.MinServersRequired(input);

        Assert.Equal(expected, ouput);
    }
}
