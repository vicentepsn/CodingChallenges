using Graph = Algoritmos.Graphs.Dijkstra2.Graph;
using ShortestDistance = Algoritmos.Graphs.Dijkstra2.ShortestDistance;

namespace Algoritmos.Graphs.Test;

public class Dijkstra2Test
{
    [Fact]
    public void Test01()
    {
        Graph input = new (
            [
                new (0, [1,2,3]),
                new(1, [0,2,5]),
                new(2, [0,1,3,4]),
                new(3, [0,2,4]),
                new(4, [2,3,5]),
                new(5, [1,4]),
            ], 
            [
                new (0,1,14),
                new (0,2,9),
                new (0,3,7),
                new (1,2,2),
                new (1,5,9),
                new (2,3,10),
                new (2,4,11),
                new (3,4,15),
                new (4,5,6),
            ]);

        var output = Dijkstra2.FindShortestDistance(input, 0);

        ShortestDistance[] expected = [
            new (0,-1, 0),
            new (1,2, 11),
            new (2,0,9),
            new (3,0,7),
            new (4,2,20),
            new (5,1,20)];

        Assert.Equal(expected, output);
    }
}
