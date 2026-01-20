using System.Collections.Generic;

namespace CodingChallenges.Cache;

/// <summary>
/// Groups    : Hash Table, Linked List, Design, Doubly-Linked List
/// Title     : 146. LRU Cache
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/lru-cache
/// Approach  : -
/// Leetcode  : Beats 71.03% / 44.06%
/// </summary>
public class LRUCache_CGPT_MelhorVersao
{
    private readonly int capacity;
    private readonly Dictionary<int, LinkedListNode<NodePayload>> cache;
    private readonly LinkedList<NodePayload> lruList;

    public LRUCache_CGPT_MelhorVersao(int capacity)
    {
        this.capacity = capacity;
        cache = [];
        lruList = new ();
    }

    public int Get(int key)
    {
        if (!cache.TryGetValue(key, out var node))
            return -1;

        // Move o nó acessado para frente (mais recentemente usado)
        lruList.Remove(node);
        lruList.AddFirst(node);

        return node.Value.Data;
    }

    public void Put(int key, int value)
    {
        if (cache.TryGetValue(key, out var node))
        {
            // Atualiza valor e move para frente
            node.Value.Data = value;
            lruList.Remove(node);
            lruList.AddFirst(node);
        }
        else
        {
            if (cache.Count == capacity)
            {
                // Remove o menos recentemente usado (último da lista)
                var lruNode = lruList.Last;
                lruList.RemoveLast();
                cache.Remove(lruNode!.Value.Key);
            }

            var newNode = new LinkedListNode<NodePayload>(new (key, value));
            lruList.AddFirst(newNode);
            cache[key] = newNode;
        }
    }
    private class NodePayload(int key, int data)
    {
        public int Key = key;
        public int Data = data;
    }
}

// Leetcode  : Beats 46.05% / 17.78%
public class LRUCache_CGPT
{
    private int capacity;
    private Dictionary<int, LinkedListNode<(int key, int value)>> cache;
    private LinkedList<(int key, int value)> lruList;

    public LRUCache_CGPT(int capacity)
    {
        this.capacity = capacity;
        cache = new Dictionary<int, LinkedListNode<(int key, int value)>>();
        lruList = new LinkedList<(int key, int value)>();
    }

    public int Get(int key)
    {
        if (!cache.ContainsKey(key))
            return -1;

        // Move o nó acessado para frente (mais recentemente usado)
        var node = cache[key];
        lruList.Remove(node);
        lruList.AddFirst(node);

        return node.Value.value;
    }

    public void Put(int key, int value)
    {
        if (cache.ContainsKey(key))
        {
            // Atualiza valor e move para frente
            var node = cache[key];
            lruList.Remove(node);
            // node.Value.value = value; Não é possível atualizar o valor do node
            var newNode = new LinkedListNode<(int key, int value)>((key, value));
            lruList.AddFirst(newNode);
            cache[key] = newNode;
        }
        else
        {
            if (cache.Count == capacity)
            {
                // Remove o menos recentemente usado (último da lista)
                var lruNode = lruList.Last;
                lruList.RemoveLast();
                cache.Remove(lruNode.Value.key);
            }

            var newNode = new LinkedListNode<(int key, int value)>((key, value));
            lruList.AddFirst(newNode);
            cache[key] = newNode;
        }

        LinkedListNode<int> test = new LinkedListNode<int>(19);
        test.Value = value;

    }
}
