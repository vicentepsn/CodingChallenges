using DataStructures;

namespace CodingChallenges.Trees;

/// <summary>
/// Groups    : Binary Tree, Depth-First Search, Breadth-First Search
/// Title     : 199. Binary Tree Right Side View
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/binary-tree-right-side-view/
/// Approach  : BFS (Breadth First Search), DFS (Depth First Search)
/// Complexity: T: O(N)  /  S: O(N)
/// </summary>
public static class BinaryTreeRightSideView
{
    // Leetcode: Beats 100.00% / 40.00%
    // BFS (Breadth First Search)
    public static IList<int> RightSideView_(TreeNode root)
    {
        IList<int> rightSideView = new List<int>();
        if (root == null) return rightSideView;

        Queue<TreeNode> currLevelNodes = [];
        currLevelNodes.Enqueue(root);

        while (currLevelNodes.Count > 0)
        {
            TreeNode node = null;
            Queue<TreeNode> nextLevelNodes = [];
            while (currLevelNodes.Count > 0)
            {
                node = currLevelNodes.Dequeue();
                if (node.left != null)
                    nextLevelNodes.Enqueue(node.left);
                if (node.right != null)
                    nextLevelNodes.Enqueue(node.right);
            }
            rightSideView.Add(node.val);

            currLevelNodes = nextLevelNodes;
        }

        return rightSideView;
    }

    // Abordagem parecida com a de cima, mas trabalhando com contadores ao invés de duas Filas
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

    // Leetcode: Beats 100.00% / 40.00%
    public static IList<int> RightSideView_DFS(TreeNode root)
    {
        var rightSideView = new List<int>();

        if (root == null)
            return rightSideView;

        RightSideView_DFS(root, 1, rightSideView);

        return rightSideView;
    }

    // Fazendo a busca em profundidade sempre iniciando pelo lado direito, o primeiro que aparecer naquele nível entre na lista
    private static void RightSideView_DFS(TreeNode node, int level, IList<int> rightSideView)
    {
        if(rightSideView.Count < level)
            rightSideView.Add(node.val);

        level++;
        if (node.right != null)
            RightSideView_DFS(node.right, level, rightSideView);
        if (node.left != null)
            RightSideView_DFS(node.left, level, rightSideView);
    }
}
