using DataStructures;
using System.Collections.Generic;

namespace CodingChallenges.Trees
{
    /// <summary>
    /// Groups    : Tree
    /// Title     : 199. Binary Tree Right Side View
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/binary-tree-right-side-view/
    /// Approach  : BFS (Breadth First Search), DFS (Depth First Search)
    /// Complexity: T: O(N)  /  S: O(N)
    /// </summary>
    public static class BinaryTreeRightSideView
    {
        public static IList<int> RightSideView(TreeNode root)
        {
            var rightSideView = new List<int>();

            if (root == null)
                return rightSideView;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int totalNodesLevel = queue.Count;
                int nodesCount = 0;

                TreeNode node;
                do
                {
                    node = queue.Dequeue();

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);

                    nodesCount++;
                } while (nodesCount < totalNodesLevel);

                rightSideView.Add(node.val);
            }

            return rightSideView;
        }

        public static IList<int> RightSideView_DFS(TreeNode root)
        {
            var rightSideView = new List<int>();

            if (root == null)
                return rightSideView;

            RightSideView_DFS(root, 1, rightSideView);

            return rightSideView;
        }

        private static void RightSideView_DFS(TreeNode node, int level, IList<int> rightSideView)
        {
            if(rightSideView.Count < level)
            {
                rightSideView.Add(node.val);
            }

            level++;
            if (node.right != null)
                RightSideView_DFS(node.right, level, rightSideView);
            if (node.left != null)
                RightSideView_DFS(node.left, level, rightSideView);
        }
    }
}
