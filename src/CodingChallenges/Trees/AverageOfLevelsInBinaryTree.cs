using DataStructures;

namespace CodingChallenges.Trees;

/// <summary>
/// Groups    : Binary Tree, Depth-First Search, Breadth-First Search
/// Title     : 637. Average of Levels in Binary Tree
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/average-of-levels-in-binary-tree
/// Approach  : BFS (Breadth First Search)
/// Complexity: T: O(N)  /  S: O(N)
/// </summary>
public class AverageOfLevelsInBinaryTree
{
    // Leetcode: Beats 96.13% / 20.44%
    // BFS (Breadth First Search)
    public IList<double> AverageOfLevels(TreeNode root)
    {
        IList<double> averageOfLevels = new List<double>();
        Queue<TreeNode> currLevelNodes = [];
        currLevelNodes.Enqueue(root);

        while (currLevelNodes.Count > 0)
        {
            int levelNodeCount = currLevelNodes.Count;
            double levelNodeSum = 0;
            Queue<TreeNode> nextLevelNodes = [];
            while (currLevelNodes.Count > 0)
            {
                TreeNode currNode = currLevelNodes.Dequeue();
                levelNodeSum += currNode.val;
                if (currNode.left != null)
                    nextLevelNodes.Enqueue(currNode.left);
                if (currNode.right != null)
                    nextLevelNodes.Enqueue(currNode.right);
            }
            currLevelNodes = nextLevelNodes;

            averageOfLevels.Add(levelNodeSum / levelNodeCount);
        }

        return averageOfLevels;
    }

    // Leetcode: Beats 96.13% / 40.33%
    public IList<double> AverageOfLevels_CGPT(TreeNode root)
    {
        var result = new List<double>();
        if (root == null) return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int size = queue.Count;
            double sum = 0;

            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();
                sum += node.val;

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            result.Add(sum / size);
        }

        return result;
    }

}
