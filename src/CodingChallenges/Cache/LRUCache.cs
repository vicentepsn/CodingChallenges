using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Cache
{
    public class SolutionMicrosoft
    {
        const int NUMBER_SISE_IN_STRING = 3;
        public int solution(string S)
        {
            int result = 0;
            int position = 0;

            if (S[0] != '-')
            {
                result += getNumber(string.Concat("+", S.AsSpan(position, 3)), position);
                position += 3;
            }

            while (position < S.Length)
            {
                result += getNumber(S, position);
                position += 4;
            }

            return result;
        }

        private int getNumber(string S, int start)
        {
            int signedResult = S[start] == '-' ? -1 : 1;
            return signedResult * (S.Substring(start + 1, NUMBER_SISE_IN_STRING) == "one" ? 1 : 2);
        }

        public bool solution_evenAndOdds(int[] A)
        {
            int countOdds = 0;
            int countEvens = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                    countEvens++;
                else
                    countOdds++;
            }

            return countEvens == countOdds;
        }

        public class Tree
        {
            public int x;
            public Tree l;
            public Tree r;
        };

        private HashSet<int> visited = new HashSet<int>();

        public int solution_binaryTree(Tree T)
        {
            int concatValue = 0;
            int result = 0;
            if (T.l != null && (T.l.l != null || T.l.r != null))
            {
                if (T.l.l != null)
                {
                    concatValue = T.x * 100 + T.l.x * 10 + T.l.l.x;
                    if (!visited.Contains(concatValue))
                    {
                        visited.Add(concatValue);
                        result++;
                    }
                }
                if (T.l.r != null)
                {
                    concatValue = T.x * 100 + T.l.x * 10 + T.l.r.x;
                    if (!visited.Contains(concatValue))
                    {
                        visited.Add(concatValue);
                        result++;
                    }
                }
                result += solution_binaryTree(T.l);
            }
            if (T.r != null && (T.r.l != null || T.r.r != null))
            {
                if (T.r.l != null)
                {
                    concatValue = T.x * 100 + T.r.x * 10 + T.r.l.x;
                    if (!visited.Contains(concatValue))
                    {
                        visited.Add(concatValue);
                        result++;
                    }
                }
                if (T.r.r != null)
                {
                    concatValue = T.x * 100 + T.r.x * 10 + T.r.r.x;
                    if (!visited.Contains(concatValue))
                    {
                        visited.Add(concatValue);
                        result++;
                    }
                }
                result += solution_binaryTree(T.r);
            }

            return result;
        }
    }


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


}
