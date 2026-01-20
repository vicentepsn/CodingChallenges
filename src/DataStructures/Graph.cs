namespace DataStructures;

public class GraphNode
{
    public GraphNode(int id) => Id = id;
    public int Id;
    public List<GraphNode> Links = new List<GraphNode>();
    public int numLinks = 0;
    public Graph Graph;

    public void addLink(GraphNode node)
    {
        Links.Add(node);
        numLinks++;
    }
}

public class Graph : IComparable
{
    public int Id;
    public List<GraphNode> Nodes = new List<GraphNode>();

    public Graph(int id) => Id = id;

    public void AddNodes(Graph graph)
    {
        foreach (var node in graph.Nodes)
        {
            AddNodes(node);
        }
    }
    public void AddNodes(GraphNode node)
    {
        Nodes.Add(node);
        node.Graph = this;
    }

    public int CompareTo(object obj)
    {
        var otherGraph = (Graph)obj;
        if (this.Id == otherGraph.Id)
            return 0;
        else if (this.Id < otherGraph.Id)
            return -1;
        else
            return 1;
    }
}

public class GraphNode2
{
    public int val;
    public IList<GraphNode2> neighbors;

    public GraphNode2()
    {
        val = 0;
        neighbors = new List<GraphNode2>();
    }

    public GraphNode2(int _val)
    {
        val = _val;
        neighbors = new List<GraphNode2>();
    }

    public GraphNode2(int _val, List<GraphNode2> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}
