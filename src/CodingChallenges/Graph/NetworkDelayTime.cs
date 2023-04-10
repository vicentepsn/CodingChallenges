using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataStructures;

namespace CodingChallenges.Graph
{
    /// <summary>
    /// Groups    : Graph
    /// Title     : 743. Network Delay Time
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/network-delay-time/
    /// Approach  : Dijkstra
    /// Complexity: T: 2N + E + E.log N + N.log N => E.log N  /  S: O(E + N)
    /// </summary>
    public class NetworkDelayTime
    {
        // using PriorityQueue
        public static int networkDelayTime(int[][] times, int n, int k)
        {
            var distances = new int[n];
            for (int i = 0; i < n; i++)
                distances[i] = int.MaxValue;
            distances[k - 1] = 0;

            var adjList = new List<(int v, int w)>[n];

            var heap = new PriorityQueue<(int v, int w)>(new DistancesComparer());
            heap.Push((k - 1, 0));

            for (var i = 0; i < times.Length; i++)
            {
                var source = times[i][0];
                var target = times[i][1];
                var weight = times[i][2];
                if (adjList[source - 1] == null)
                    adjList[source - 1] = new List<(int v, int w)>() { (target - 1, weight) };
                else
                    adjList[source - 1].Add((target - 1, weight));
            }

            while (heap.Size > 0)
            {
                var currentVertex = heap.Pop();

                var adjacent = adjList[currentVertex.v];
                for (var i = 0; i < (adjacent?.Count ?? 0); i++)
                {
                    var neighboringVertex = adjacent[i].v;
                    var weight = adjacent[i].w;
                    if (distances[currentVertex.v] + weight < distances[neighboringVertex])
                    {
                        distances[neighboringVertex] = distances[currentVertex.v] + weight;
                        heap.Push((neighboringVertex, distances[neighboringVertex]));
                    }
                }
            }

            var ans = distances.Max();

            return ans == int.MaxValue ? -1 : ans;
        }

        public static int networkDelayTime_MySolution(int[][] times, int n, int k)
        {
            var delayTime = -1;
            var adjList = new List<(int v, int w)>[n];
            k--;

            foreach (var time in times)
            {
                if (adjList[time[0] - 1] == null)
                    adjList[time[0] - 1] = new List<(int v, int w)>() { (time[1] - 1, time[2]) };
                else
                    adjList[time[0] - 1].Add((time[1] - 1, time[2]));
            }

            var timesFromK = new int[n];
            for (int i = 0; i < n; i++)
                timesFromK[i] = int.MaxValue;

            timesFromK[k] = 0;
            var closed = new bool[n];
            var closedCount = 0;

            var curMinIdx = k;

            while (curMinIdx >= 0)
            {
                delayTime = timesFromK[curMinIdx];
                if (adjList[curMinIdx] != null)
                    foreach (var vertex in adjList[curMinIdx])
                    {
                        if (timesFromK[vertex.v] > timesFromK[curMinIdx] + vertex.w)
                            timesFromK[vertex.v] = timesFromK[curMinIdx] + vertex.w;
                    }
                closed[curMinIdx] = true;
                closedCount++;

                var nexMinW = int.MaxValue;
                curMinIdx = -1;
                for (int i = 0; i < n; i++)
                {
                    if (!closed[i] && timesFromK[i] < nexMinW)
                    {
                        nexMinW = timesFromK[i];
                        curMinIdx = i;
                    }
                }
            }

            return closedCount == n ? delayTime : -1;
        }
    }

    public class DistancesComparer : Comparer<(int v, int w)>
    {
        public override int Compare((int v, int w) x, (int v, int w) y)
        {
            if (x.w < y.w)
                return 1;
            if (x.w > y.w)
                return -1;
            return 0;
        }
    }


}
