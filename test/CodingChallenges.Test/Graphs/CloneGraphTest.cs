using Node = DataStructures.GraphNode2;

namespace CodingChallenges.Graphs.Test;

public class CloneGraphTest
{
    [Fact]
    public void Test01()
    {
        Node node1 = new Node(1, []);
        Node node2 = new Node(2, []);
        Node node3 = new Node(3, []);
        Node node4 = new Node(4, []);

        node1.neighbors.Add(node2);
        node1.neighbors.Add(node4);

        node2.neighbors.Add(node1);
        node2.neighbors.Add(node2);

        node3.neighbors.Add(node4);
        node3.neighbors.Add(node2);

        node4.neighbors.Add(node3);
        node4.neighbors.Add(node1);

        var cloneGraph = new CloneGraphClass();
        var clonedNode1 = cloneGraph.CloneGraph(node1);

        Assert.Equal(node1.val, clonedNode1.val);
        Assert.NotEqual(node1, clonedNode1);
    }
}
