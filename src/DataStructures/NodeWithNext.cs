namespace DataStructures;

public class NodeWithNext
{
    public int Value;
    public NodeWithNext? Next;

    public NodeWithNext(int _val)
    {
        Value = _val;
    }

    public NodeWithNext(int _val, NodeWithNext next)
    {
        Value = _val;
        this.Next = next;
    }
}
