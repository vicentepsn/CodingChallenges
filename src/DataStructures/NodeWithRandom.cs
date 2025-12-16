namespace DataStructures;

public class NodeWithRandom
{
    public int val;
    public NodeWithRandom? next;
    public NodeWithRandom? random;

    public NodeWithRandom(int _val)
    {
        val = _val;
    }

    public NodeWithRandom(int _val, NodeWithRandom next, NodeWithRandom random)
    {
        val = _val;
        this.next = next;
        this.random = random;
    }
}
