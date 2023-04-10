using System;
using System.Collections.Generic;

namespace CodingChallenges.Graph
{

    /// <summary>
    /// Groups    : Graph
    /// Title     : 1376. Time Needed to Inform All Employees
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/time-needed-to-inform-all-employees/
    /// Approach  : BFS (Breadth First Search) / DFS ...
    /// </summary>
    public class TimeNeededToInformAllEmployees
    {
        // BFS
        public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            var numOfMinutes = 0;
            if (manager.Length == 1)
                return numOfMinutes;

            var connections = new List<int> [manager.Length];

            for (int i = 0; i < manager.Length; i++)
            {
                if (manager[i] >= 0)
                {
                    if (connections[manager[i]] == null)
                        connections[manager[i]] = new List<int>();
                    connections[manager[i]].Add(i);
                }
            }

            var queue = new Queue<int>();
            queue.Enqueue(headID);

            int numInLevel = queue.Count;
            int inLevelCount = 0;
            int maxMinutesAtLevel = 0;
            while (queue.Count > 0)
            {
                var managerId = queue.Dequeue();
                maxMinutesAtLevel = Math.Max(maxMinutesAtLevel, informTime[managerId]);

                if (connections[managerId] != null)
                    foreach (var employeeId in connections[managerId])
                    {
                        informTime[employeeId] += informTime[managerId];
                        queue.Enqueue(employeeId);
                    }

                inLevelCount++;

                if (inLevelCount == numInLevel)
                {
                    numInLevel = queue.Count;
                    inLevelCount = 0;
                    numOfMinutes = Math.Max(numOfMinutes, maxMinutesAtLevel);
                    maxMinutesAtLevel = 0;
                }
            }

            return numOfMinutes;
        }

        // Complexity: T/S: O(3N) => O(N)
        public int NumOfMinutes_DFS(int n, int headID, int[] manager, int[] informTime)
        {
            var numOfMinutes = 0;
            if (manager.Length == 1)
                return numOfMinutes;

            var connections = new List<int>[manager.Length];

            for (int i = 0; i < manager.Length; i++)
            {
                if (manager[i] >= 0)
                {
                    if (connections[manager[i]] == null)
                        connections[manager[i]] = new List<int>();
                    connections[manager[i]].Add(i);
                }
            }

            numOfMinutes = NumOfMinutes_DFS(connections, headID, informTime);

            return numOfMinutes;
        }

        private int NumOfMinutes_DFS(List<int>[] connections, int managerId, int[] informTime)
        {
            int maxEmployeeTime = 0;

            foreach(var employeeId in connections[managerId])
            {
                if(informTime[employeeId] > 0)
                    maxEmployeeTime = Math.Max(maxEmployeeTime, NumOfMinutes_DFS(connections, employeeId, informTime));
            }
            
            return informTime[managerId] + maxEmployeeTime;
        }

    }
}
