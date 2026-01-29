using static Algoritmos.Graphs.Dijkstra;
//using GraphNode = Algoritmos.Graphs.Dijkstra.GraphNode;

namespace Algoritmos.Graphs.Test;

public class DijkstraTest
{
    [Fact]
    public void Test01()
    {
        Neighbor[][] input = [
            [new (1, 14), new (2, 9), new (3, 7)],
            [new (0, 14), new (2, 2), new (5, 9)],
            [new (1,2), new (0,9), new (3,10), new (4,11)],
            [new (0,7), new (2, 10), new (4,15)],
            [new (2,11), new (3,15), new (5,6)],
            [new (1,9), new (4,6)],
            ];

        var output = Dijkstra.FindShortestDistance(input, 0);

        ShortestDistance[] expected = [
            new (-1, 0),
            new (2, 11),
            new (0,9),
            new (0,7),
            new (2,20),
            new (1,20)];

        Assert.Equal(expected, output);
    }
}
