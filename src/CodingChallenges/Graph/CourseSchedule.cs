using System.Collections.Generic;

namespace CodingChallenges.Graph
{
    public class GNode
    {
        public int inDegrees = 0;
        public LinkedList<int> outNodes = new LinkedList<int>();
    }

    /// <summary>
    /// Related   : Graph, Depth First Search DFS, Breadth First Search BFS, Topological Sort
    /// Title     : 207. Course Schedule
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/course-schedule/
    /// Approach  : Topological Order
    /// Companies : Amazon 28, Facebook 11, Microsoft 10, tiktok 7, Google 6,
    /// Doc       : docs\207 Course Schedule.docx
    /// </summary>
    public class CourseSchedule
    {
        /// Approach: Topological Sort
        /// Complexity: 
        /// Time Complexity: O(∣E∣+∣V∣) where ∣V∣ is the number of courses, and ∣E∣ is the number of dependencies.
        ///         - As in the previous algorithm, it would take us ∣E∣ time complexity to build a graph in the first step.
        ///         - Similar with the above postorder DFS traversal, we would visit each vertex and each edge once and only once in the worst case, i.e. ∣E∣+∣V∣.
        ///         - As a result, the overall time complexity of the algorithm would be O(2⋅∣E∣+∣V∣) = O(∣E∣+∣V∣).
        /// Space Complexity: O(∣E∣+∣V∣), with the same denotation as in the above time complexity.
        ///         - We built a graph data structure in the algorithm, which would consume ∣E∣+∣V∣ space.
        ///         - In addition, we use a container to keep track of the courses that have no prerequisite, and the size of the container would be bounded by ∣V∣.
        ///         - As a result, the overall space complexity of the algorithm would be O(∣E∣+2⋅∣V∣) = O(∣E∣+∣V∣).
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var connections = new List<int>[numCourses];
            var inDegree = new int[numCourses];

            foreach (var prereq in prerequisites)
            {
                inDegree[prereq[0]]++;
                if (connections[prereq[1]] == null)
                    connections[prereq[1]] = new List<int> { prereq[0] };
                else
                    connections[prereq[1]].Add(prereq[0]);
            }

            var topQueue = new Queue<int>();
            for (int i = 0; i < numCourses; i++)  // 1xV
            {
                if(inDegree[i] == 0)
                    topQueue.Enqueue(i);
            }
            var topZeroCount = 0;

            while(topQueue.Count > 0) // max 1xV
            {
                var current = topQueue.Dequeue();
                topZeroCount++;
                if (connections[current] != null)
                    foreach (var v in connections[current]) // E of that V
                    {
                        inDegree[v]--;
                        if (inDegree[v] == 0)
                            topQueue.Enqueue(v);
                    }
            }

            return topZeroCount == numCourses;
        }

        // Topological Sort without adjacency list (anwer from udemy instructor)
        // Complexity: T: O(V.E) / S: O(V)   => V = nº courses
        public bool CanFinish_Udemy(int numCourses, int[][] prerequisites) 
        { 
            var inDegree = new int[numCourses];

            for (var i = 0; i < prerequisites.Length; i++)
            {
                inDegree[prerequisites[i][0]]++;
            }

            var stack = new Stack<int>();

            for (var i = 0; i < inDegree.Length; i++)
            {
                if (inDegree[i] == 0)
                    stack.Push(i);
            }

            var count = 0;

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                count++;

                for (var i = 0; i < prerequisites.Length; i++)
                {
                    var pair = prerequisites[i];
                    if (pair[1] == current)
                    {
                        inDegree[pair[0]]--;
                        if (inDegree[pair[0]] == 0)
                        {
                            stack.Push(pair[0]);
                        }
                    }
                }
            }

            return count == numCourses;
        }

        // Topological Sort
        public bool CanFinish_Leetcode(int numCourses, int[][] prerequisites)
        {
            if (prerequisites.Length == 0)
                return true; // no cycle could be formed in empty graph.

            // course -> list of next courses
            var graph = new Dictionary<int, GNode>();

            // build the graph first
            foreach (int[] relation in prerequisites)
            {
                // relation[1] -> relation[0]
                GNode prevCourse = this.getCreateGNode(graph, relation[1]);
                GNode nextCourse = this.getCreateGNode(graph, relation[0]);

                prevCourse.outNodes.AddLast(relation[0]);
                nextCourse.inDegrees += 1;
            }

            // We start from courses that have no prerequisites.
            int totalDeps = prerequisites.Length;
            var nodepCourses = new Queue<int>();
            foreach (KeyValuePair<int, GNode> entry in graph)
            {
                GNode node = entry.Value;
                if (node.inDegrees == 0)
                    nodepCourses.Enqueue(entry.Key);
            }

            int removedEdges = 0;
            while (nodepCourses.Count > 0)
            {
                int course = nodepCourses.Dequeue();

                foreach (int nextCourse in graph[course].outNodes)
                {
                    GNode childNode = graph[nextCourse];
                    childNode.inDegrees -= 1;
                    removedEdges += 1;
                    if (childNode.inDegrees == 0)
                        nodepCourses.Enqueue(nextCourse);
                }
            }

            return removedEdges == totalDeps; // if there are still some edges left, then there exist some cycles
                // Due to the dead-lock (dependencies), we cannot remove the cyclic edges
        }

        // Retrieve the existing <key, value> from graph, otherwise create a new one.
        protected GNode getCreateGNode(Dictionary<int, GNode> graph, int course)
        {
            if (!graph.ContainsKey(course))
                graph[course] = new GNode();

            return graph[course];
        }

        /// Leetcode_backtracking
        /// Complexity
        /// Time Complexity: O(∣E∣+∣V∣²) where ∣E∣ is the number of dependencies, ∣V∣ is the number of courses and dd is the maximum length of acyclic paths in the graph.
        ///     - First of all, it would take us |E|∣E∣ steps to build a graph in the first step.
        ///     - For a single round of backtracking, in the worst case where all the nodes chained up in a line, it would take us maximum |V|∣V∣ steps to terminate the backtracking.
        ///     - Again, follow the above worst scenario where all nodes are chained up in a line, it would take us in total 
        ///         \sum_{ i = 1}^{|V|} { i} = \frac{ (1 +| V |)\cdot | V |}{ 2}∑ i = 1∣V∣​ i =2(1 +∣V∣)⋅∣V∣  steps to finish the check for all nodes.
        ///     - As a result, the overall time complexity of the algorithm would be \mathcal{O}(| E | + | V | ^2)O(∣E∣+∣V∣²).
        /// Space Complexity: O(∣E∣+∣V∣), with the same denotation as in the above time complexity.
        ///     - We built a graph data structure in the algorithm, which would consume ∣E∣+∣V∣ space.
        ///     - In addition, during the backtracking process, we employed a sort of bitmap (path) to keep track of all visited nodes, which consumes |V|∣V∣ space.
        ///     - Finally, since we implement the function in recursion, which would incur additional memory consumption on call stack. 
        ///       In the worst case where all nodes are chained up in a line, the recursion would pile up |V|∣V∣ times.
        ///     - Hence the overall space complexity of the algorithm would be O(∣E∣+3⋅∣V∣) = O(∣E∣+∣V∣).
        public bool CanFinish_Leetcode_backtracking(int numCourses, int[][] prerequisites)
        {

            // course -> list of next courses
            var courseDict = new Dictionary<int, List<int>>();

            // build the graph first
            foreach (int[] relation in prerequisites)
            {
                // relation[0] depends on relation[1]
                if (courseDict.ContainsKey(relation[1]))
                {
                    courseDict[relation[1]].Add(relation[0]);
                }
                else
                {
                    var nextCourses = new List<int>();
                    nextCourses.Add(relation[0]);
                    courseDict[relation[1]] = nextCourses;
                }
            }

            bool[] path = new bool[numCourses];

            for (int currCourse = 0; currCourse < numCourses; ++currCourse)
            {
                if (this.isCyclic(currCourse, courseDict, path))
                {
                    return false;
                }
            }

            return true;
        }

        // backtracking method to check that no cycle would be formed starting from currCourse
        protected bool isCyclic(int currCourse, Dictionary<int, List<int>> courseDict, bool[] path)
        {
            if (path[currCourse])
                return true; // come across a previously visited node, i.e. detect the cycle

            // no following courses, no loop.
            if (!courseDict.ContainsKey(currCourse))
                return false;

            // before backtracking, mark the node in the path
            path[currCourse] = true;

            // backtracking
            bool ret = false;
            foreach (int nextCourse in courseDict[currCourse])
            {
                ret = this.isCyclic(nextCourse, courseDict, path);
                if (ret)
                    break;
            }
            // after backtracking, remove the node from the path
            path[currCourse] = false;
            return ret;
        }

        /// Leetcode DFS
        /// Complexity
        /// Time Complexity: O(∣E∣+∣V∣) where ∣V∣ is the number of courses, and ∣E∣ is the number of dependencies.
        ///     - As in the previous algorithm, it would take us ∣E∣ time complexity to build a graph in the first step.
        ///     - Since we perform a postorder DFS traversal in the graph, we visit each vertex and each edge once and only once in the worst case, i.e. ∣E∣+∣V∣.
        /// Space Complexity: O(∣E∣+∣V∣), with the same denotation as in the above time complexity.
        ///     - We built a graph data structure in the algorithm, which would consume ∣E∣+∣V∣ space.
        ///     - In addition, during the backtracking process, we employed two bitmaps (path and visited) to keep track of the 
        ///       visited path and the status of check respectively, which consumes 2⋅∣V∣ space.
        ///     - Finally, since we implement the function in recursion, which would incur additional memory consumption on call stack.
        ///       In the worst case where all nodes chained up in a line, the recursion would pile up ∣V∣ times.
        ///     - Hence the overall space complexity of the algorithm would be O(∣E∣+4⋅∣V∣) = O(∣E∣+∣V∣).
        public bool CanFinish_Leetcode_DFS(int numCourses, int[][] prerequisites)
        {

            // course -> list of next courses
            var courseDict = new Dictionary<int, List<int>>();

            // build the graph first
            foreach (int[] relation in prerequisites)
            {
                // relation[0] depends on relation[1]
                if (courseDict.ContainsKey(relation[1]))
                {
                    courseDict[relation[1]].Add(relation[0]);
                }
                else
                {
                    var nextCourses = new List<int>();
                    nextCourses.Add(relation[0]);
                    courseDict[relation[1]] = nextCourses;
                }
            }

            bool[] isChecked = new bool[numCourses];
            bool[] path = new bool[numCourses];

            for (int currCourse = 0; currCourse < numCourses; ++currCourse)
            {
                if (this.isCyclic(currCourse, courseDict, isChecked, path))
                    return false;
            }

            return true;
        }

        // postorder DFS check that no cycle would be formed starting from currCourse
        protected bool isCyclic(int currCourse, Dictionary<int, List<int>> courseDict, bool[] isChecked, bool[] path)
        {

            // bottom cases
            if (isChecked[currCourse])
                // this node has been checked, no cycle would be formed with this node.
                return false;
            if (path[currCourse])
                // come across a previously visited node, i.e. detect the cycle
                return true;

            // no following courses, no loop.
            if (!courseDict.ContainsKey(currCourse))
                return false;

            // before backtracking, mark the node in the path
            path[currCourse] = true;

            bool ret = false;
            // postorder DFS, to visit all its children first.
            foreach (int child in courseDict[currCourse])
            {
                ret = this.isCyclic(child, courseDict, isChecked, path);
                if (ret)
                    break;
            }

            // after the visits of children, we come back to process the node itself
            // remove the node from the path
            path[currCourse] = false;

            // Now that we've visited the nodes in the downstream,
            // we complete the check of this node.
            isChecked[currCourse] = true;
            return ret;
        }


        public bool CanFinish_TryBruteForce_not_working(int numCourses, int[][] prerequisites)
        {
            var connections = new List<int>[numCourses];

            foreach (var prereq in prerequisites)
            {
                if (connections[prereq[1]] == null)
                    connections[prereq[1]] = new List<int> { prereq[0] };
                else
                    connections[prereq[1]].Add(prereq[0]);
            }

            var reachableFrom = new int[numCourses];
            var reached = new bool[numCourses];

            //var reached = 0;

            for (int i = 0; i < numCourses; i++)
            {
                if (!reached[i] && !CanFinish(connections, reachableFrom, reached, i, -1))
                    return false;
            }

            return true;
        }

        private bool CanFinish(List<int>[] connections, int[] reachableFrom, bool[] reached, int current, int prev)
        {
            if (reached[current] && reachableFrom[current] == prev)
                return false;

            //if (reached[current])
            //    return true;

            reached[current] = true;
            reachableFrom[current] = prev;

            if (connections[current] != null)
                foreach (var courseIdx in connections[current])
                {
                    if (!CanFinish(connections, reachableFrom, reached, courseIdx, current))
                        return false;
                }

            return true;
        }
    }
}
