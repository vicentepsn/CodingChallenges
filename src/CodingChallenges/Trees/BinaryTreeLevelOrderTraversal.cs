using DataStructures;
using System.Collections.Generic;

namespace CodingChallenges.Trees
{
    /// <summary>
    /// Groups    : Tree
    /// Title     : 102. Binary Tree Level Order Traversal
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/binary-tree-level-order-traversal/
    /// Approach  : BFS (Breadth-first search)
    /// Complexity: T: O(N)  /  S: O(N)
    /// </summary>
    public static class BinaryTreeLevelOrderTraversal
    {
        // Solution from udemy instructor
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            var levelOrder = new List<IList<int>>();

            if (root == null)
                return levelOrder;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int totalNodesLevel = queue.Count;
                int nodesCount = 0;

                var currentLevel = new List<int>();

                while(nodesCount < totalNodesLevel)
                {
                    var node = queue.Dequeue();

                    currentLevel.Add(node.val);

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);

                    nodesCount++;
                }

                levelOrder.Add(currentLevel);
            }

            return levelOrder;
        }

        public static IList<IList<int>> LevelOrder_MySolution(TreeNode root)
        {
            var levelOrder = new List<IList<int>>();

            if (root == null)
                return levelOrder;

            var levelQueue = new Queue<TreeNode>();
            levelQueue.Enqueue(root);

            LevelOrder(levelOrder, levelQueue);

            return levelOrder;
        }

        private static void LevelOrder(IList<IList<int>> levelOrder, Queue<TreeNode> levelQueue)
        {
            var levelList = new List<int>();
            var nextLevelQueue = new Queue<TreeNode>();

            while (levelQueue.Count > 0)
            {
                var node = levelQueue.Dequeue();

                levelList.Add(node.val);

                if(node.left != null)
                    nextLevelQueue.Enqueue(node.left);
                if(node.right != null)
                    nextLevelQueue.Enqueue(node.right);
            }

            levelOrder.Add(levelList);

            if(nextLevelQueue.Count > 0)
                LevelOrder(levelOrder, nextLevelQueue);
        }
    }
}
