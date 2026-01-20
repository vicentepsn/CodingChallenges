namespace CodingChallenges.Cache;

/// <summary>
/// Groups    : Hash Table, Linked List, Design, Doubly-Linked List
/// Title     : 146. LRU Cache
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/lru-cache
/// Approach  : -
/// Leetcode  : Beats 46.05% / 59.00%
/// </summary>
public class LRUCache
{
    private class Node
    {
        public int Key; public int Value;
        public Node Next;
        public Node Previous;
    }

    private readonly int _capacity;
    private Node _head;
    private Node _tail;
    private Dictionary<int, Node> _cache;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new Dictionary<int, Node>(capacity);
    }

    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out Node node))
            return -1;

        updateNodePosition(node);

        return node.Value;
    }

    private void updateNodePosition(Node node)
    {
        if (node == _head)
            return;

        node.Previous.Next = node.Next;

        if (node == _tail)
        {
            _tail = _tail.Previous;
            _tail.Next = null;
        }
        else
            node.Next.Previous = node.Previous;

        _head.Previous = node;
        node.Next = _head;
        _head = node;
        _head.Previous = null;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out Node node))
        {
            node.Value = value;
            updateNodePosition(node);
            return;
        }

        if (_cache.Count == _capacity)
        {
            _cache.Remove(_tail.Key);
            if(_capacity == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                Node newTail = _tail.Previous;
                newTail.Next = null;
                _tail = newTail;
            }
        }

        node = new Node() { Key = key, Value = value };
        _cache[key] = node;

        if (_head != null)
        {
            _head.Previous = node;
            node.Next = _head;
        }
        else
            _tail = node;

        _head = node;
    }
}
