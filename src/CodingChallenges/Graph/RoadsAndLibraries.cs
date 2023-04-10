using System;
using System.Collections.Generic;

namespace CodingChallenges.Graph
{

    /// <summary>
    /// Roads and Libraries
    /// Medium
    /// https://www.hackerrank.com/challenges/torque-and-development/problem
    /// </summary>
    public static class RoadsAndLibraries
    {
        public static long roadsAndLibraries(int n, int c_lib, int c_road, int[][] roads)
        {
            long totalCost = 0;
            long numDisconected = n;

            Node[] cities = new Node[n];
            for (var i = 0; i < n; i++)
            {
                cities[i] = new Node(i);
            }

            List<Graph> graphs = new List<Graph>();
            var lastGraphId = 0;

            foreach (var road in roads)
            {
                var cityA = cities[road[0] - 1];
                var cityB = cities[road[1] - 1];

                if (cityA.Graph == null && cityB.Graph == null)
                {
                    lastGraphId++;
                    var graph = new Graph(lastGraphId);
                    graph.AddNodes(cityA);
                    graph.AddNodes(cityB);
                    graphs.Add(graph);

                    numDisconected -= 2;
                }
                else if (cityA.Graph != null && cityB.Graph == null)
                {
                    cityA.Graph.AddNodes(cityB);
                    numDisconected--;
                }
                else if (cityA.Graph == null && cityB.Graph != null)
                {
                    cityB.Graph.AddNodes(cityA);
                    numDisconected--;
                }
                else
                {
                    if (cityA.Graph != cityB.Graph)
                    {
                        var index = graphs.BinarySearch(cityB.Graph);
                        graphs.RemoveAt(index);
                        //graphs.Remove(cityB.Graph);
                        cityA.Graph.AddNodes(cityB.Graph);
                    }
                }
            }

            foreach (var graph in graphs)
            {
                var numCities = graph.Nodes.Count;
                if (numCities * c_lib < c_lib + (numCities - 1) * c_road)
                {
                    totalCost += numCities * c_lib;
                }
                else
                {
                    totalCost += c_lib + (numCities - 1) * c_road;
                }
            }

            return totalCost + numDisconected * c_lib;
        }

        static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());

            long[] resultado = new long[q];

            for (int qItr = 0; qItr < q; qItr++)
            {
                string[] nmC_libC_road = Console.ReadLine().Split(' ');

                int n = Convert.ToInt32(nmC_libC_road[0]);

                int m = Convert.ToInt32(nmC_libC_road[1]);

                int c_lib = Convert.ToInt32(nmC_libC_road[2]);

                int c_road = Convert.ToInt32(nmC_libC_road[3]);

                int[][] cities = new int[m][];

                for (int i = 0; i < m; i++)
                {
                    cities[i] = Array.ConvertAll(Console.ReadLine().Split(' '), citiesTemp => Convert.ToInt32(citiesTemp));
                }

                resultado[qItr] = roadsAndLibraries(n, c_lib, c_road, cities);
            }

            foreach (long result in resultado)
                Console.WriteLine(result);
            Console.ReadLine();
        }
    }

    public class Node
    {
        public Node(int id) => Id = id;
        public int Id;
        public List<Node> Links = new List<Node>();
        public int numLinks = 0;
        public Graph Graph;

        public void addLink(Node node)
        {
            Links.Add(node);
            numLinks++;
        }
    }

    public class Graph : IComparable
    {
        public int Id;
        public List<Node> Nodes = new List<Node>();

        public Graph(int id) => Id = id;

        public void AddNodes(Graph graph)
        {
            foreach (var node in graph.Nodes)
            {
                AddNodes(node);
            }
        }
        public void AddNodes(Node node)
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
}
