using System.Collections.Generic;

namespace CodingChallenges.Cache
{
    /// <summary>
    /// Groups: LinkedList, Hash
    /// Title: 146. LRU Cache
    /// Difficult: Medium
    /// Link: https://leetcode.com/problems/lru-cache/
    /// Approach: -
    /// </summary>
    public class LRUCache1 // last => oldest / first => newest
    {
        private readonly IDictionary<int, LinkedListNode<CacheItem>> cacheDictionary;
        private readonly LinkedList<CacheItem> cacheList;
        private readonly int capacity;

        private class CacheItem
        {
            public int key;
            public int data;
        }

        public LRUCache1(int capacity)
        {
            cacheDictionary = new Dictionary<int, LinkedListNode<CacheItem>>(capacity);
            cacheList = new LinkedList<CacheItem>();
            this.capacity = capacity;
        }

        public int Get(int key)
        {
            if (cacheDictionary.TryGetValue(key, out var item))
            {
                UpdateLRU(item);
                return item.Value.data;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (cacheDictionary.TryGetValue(key, out var item))
            {
                item.Value.data = value;
                UpdateLRU(item);
                return;
            }

            if (cacheList.Count == capacity)
            {
                cacheDictionary.Remove(cacheList.Last.Value.key);
                cacheList.RemoveLast();
            }

            var newItem = new LinkedListNode<CacheItem>(new CacheItem() { key = key, data = value });
            cacheList.AddFirst(newItem);
            cacheDictionary.Add(key, newItem);
        }

        private void UpdateLRU(LinkedListNode<CacheItem> item)
        {
            cacheList.Remove(item);
            cacheList.AddFirst(item);
        }


    }

    public class LRUCache_usingKeyValuePair // last => newest / first => oldest
    {
        private readonly int _capacity;
        private readonly LinkedList<KeyValuePair<int, int>> list;
        private readonly Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> dict;

        public LRUCache_usingKeyValuePair(int capacity)
        {
            _capacity = capacity;
            list = new LinkedList<KeyValuePair<int, int>>();
            dict = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>(capacity);
        }

        public int Get(int key)
        {
            if (dict.ContainsKey(key))
            {
                update(key);
                return dict[key].Value.Value;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key].Value = new KeyValuePair<int, int>(key, value);
                update(key);
                return;
            }

            if (list.Count == _capacity)
            {
                dict.Remove(list.First.Value.Key);
                list.RemoveFirst();
            }

            var node = new LinkedListNode<KeyValuePair<int, int>>(new KeyValuePair<int, int>(key, value));
            dict[key] = node;
            list.AddLast(node);
        }

        private void update(int key)
        {
            var node = dict[key];
            list.Remove(node);
            list.AddLast(node);
        }
    }




    public class LRUCache_customLinkedList
    {
        class LRUNode
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public LRUNode Previous { get; set; }
            public LRUNode Next { get; set; }
            public LRUNode() { }
            public LRUNode(int k, int v)
            {
                this.Key = k;
                this.Value = v;
            }
        }

        class LRUDoubleLinkedList
        {
            private LRUNode Head;
            private LRUNode Tail;

            public LRUDoubleLinkedList()
            {
                //Head = new LRUNode();
                //Tail = new LRUNode();
                //Head.Next = Tail;
                //Tail.Previous = Head;
            }

            public void AddToTop(LRUNode node)
            {
                //node.Next = Head.Next;
                //Head.Next.Previous = node;
                //node.Previous = Head;
                //Head.Next = node;
                Head.Next = node;
                Head = node;
            }

            public void RemoveNode(LRUNode node)
            {
                //node.Previous.Next = node.Next;
                //node.Next.Previous = node.Previous;
                //node.Next = null;
                //node.Previous = null;

            }

            public LRUNode RemoveLRUNode()
            {
                LRUNode target = Tail.Previous;
                RemoveNode(target);
                return target;
            }
        }

        private int capacity;
        private int count;
        Dictionary<int, LRUNode> map;
        LRUDoubleLinkedList doubleLinkedList;
        public LRUCache_customLinkedList(int capacity)
        {
            this.capacity = capacity;
            this.count = 0;
            map = new Dictionary<int, LRUNode>();
            doubleLinkedList = new LRUDoubleLinkedList();
        }

        // each time when access the node, we move it to the top
        public int Get(int key)
        {
            if (!map.ContainsKey(key)) return -1;
            LRUNode node = map[key];
            doubleLinkedList.RemoveNode(node);
            doubleLinkedList.AddToTop(node);
            return node.Value;
        }

        public void Put(int key, int value)
        {
            // just need to update value and move it to the top
            if (map.ContainsKey(key))
            {
                LRUNode node = map[key];
                doubleLinkedList.RemoveNode(node);
                node.Value = value;
                doubleLinkedList.AddToTop(node);
            }
            else
            {
                // if cache is full, then remove the least recently used node
                if (count == capacity)
                {
                    LRUNode lru = doubleLinkedList.RemoveLRUNode();
                    map.Remove(lru.Key);
                    count--;
                }

                // add a new node
                LRUNode node = new LRUNode(key, value);
                doubleLinkedList.AddToTop(node);
                map[key] = node;
                count++;
            }

        }

    }


    public static class LRUCacheParser
    {
        public static int?[] CallOperations(string[] operations, int[][] values)
        {
            var result = new int?[operations.Length];
            LRUCache_customLinkedList obj = new LRUCache_customLinkedList(values[0][0]);

            for (int i = 0; i < result.Length; i++)
            {
                switch (operations[i])
                {
                    case "LRUCache":
                        result[i] = null;
                        //obj = new LRUCache(values[i][0]);
                        break;
                    case "put":
                        result[i] = null;
                        obj.Put(values[i][0], values[i][1]);
                        break;
                    case "get":
                        result[i] = obj.Get(values[i][0]);
                        break;
                }
            }

            return result;
        }
    }
}
