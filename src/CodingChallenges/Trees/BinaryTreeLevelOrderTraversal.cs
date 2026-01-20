using DataStructures;

namespace CodingChallenges.Trees;

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
    // Leetcode: Beats 100.00% / 37.06%
    public static IList<IList<int>> LevelOrder_CGPT(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root == null) return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int size = queue.Count;
            var level = new List<int>();

            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();
                level.Add(node.val);

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            result.Add(level);
        }

        return result;
    }

    // Leetcode: Beats 29.67% / 15.28%
    public static IList<IList<int>> LevelOrder_vNew(TreeNode root)
    {
        IList<IList<int>> levelOrder = new List<IList<int>>();
        if (root == null) return levelOrder;

        Queue<TreeNode> currLevelNodes = new();
        currLevelNodes.Enqueue(root);

        while (currLevelNodes.Count > 0)
        {
            IList<int> currLevelNodesValues = new List<int>();
            Queue<TreeNode> nextLevelNodes = new();
            while (currLevelNodes.Count > 0)
            {
                TreeNode currNode = currLevelNodes.Dequeue();
                currLevelNodesValues.Add(currNode.val);
                if (currNode.left != null)
                    nextLevelNodes.Enqueue(currNode.left);
                if (currNode.right != null)
                    nextLevelNodes.Enqueue(currNode.right);
            }
            levelOrder.Add(currLevelNodesValues);
            currLevelNodes = nextLevelNodes;
        }

        return levelOrder;
    }

    // Solution from udemy instructor
    // Solução similar a de cima mais usando contadores
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
