using DataStructures;

namespace CodingChallenges.Trees;

/// <summary>
/// Related   : Tree, Breadth-First Search, Binary Tree
/// Title     : 103. Binary Tree Zigzag Level Order Traversal
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
/// Companies : Amazon 31, Facebook 21, Microsoft 14, Bloomberg 6, Google 4, LinkedIn 4 (2022-04-08)
/// </summary>
public class BinaryTreeZigzagLevelOrderTraversal
{
    // Leetcode: Beats 100.00% / 23.28%
    public IList<IList<int>> ZigzagLevelOrder_ChatGPT(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root == null) return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        bool leftToRight = true;

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

            if (!leftToRight)
            {
                level.Reverse();
            }

            result.Add(level);
            leftToRight = !leftToRight; // alterna a direção
        }

        return result;
    }

    // Leetcode: Beats 100.00% / 35.98%
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root == null)
            return result;

        var stack = new Stack<TreeNode>();
        stack.Push(root);
        bool isFromLeftToRight = false;
        result.Add(new List<int> { root.val });

        while (stack.Count > 0)
        {
            var newStack = new Stack<TreeNode>();
            var levelResult = new List<int>();

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();

                var first = isFromLeftToRight ? currentNode.left : currentNode.right;
                var last = isFromLeftToRight ? currentNode.right : currentNode.left;

                if (first != null)
                {
                    levelResult.Add(first.val);
                    newStack.Push(first);
                }
                if (last != null)
                {
                    levelResult.Add(last.val);
                    newStack.Push(last);
                }
            }

            isFromLeftToRight = !isFromLeftToRight;
            if (levelResult.Count > 0)
                result.Add(levelResult);
            stack = newStack;
        }

        return result;
    }

    // Complexity:  T => O(N)   /   S => O(N)  (2.L => N)
    public IList<IList<int>> ZigzagLevelOrder_Leedcode_BFS(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root == null)
            return result;

        // add the root element with a delimiter to kick off the BFS loop
        var node_queue = new Queue<TreeNode>();
        node_queue.Enqueue(root);
        TreeNode delimiter = null;
        node_queue.Enqueue(delimiter);
        
        var level_list = new List<int>();
        bool is_order_left = true;

        while (node_queue.Count > 0)
        {
            TreeNode curr_node = node_queue.Dequeue();
            if (curr_node != null)
            {
                level_list.Add(curr_node.val);        //    <= Added to avoid insert in the beggining of the list
                //if (is_order_left)                  //    <= Removed
                //    level_list.Add(curr_node.val);  //    <= Removed
                //else                                //    <= Removed
                //    level_list.Add(curr_node.val);  //    <= Removed

                if (curr_node.left != null)
                    node_queue.Enqueue(curr_node.left);
                if (curr_node.right != null)
                    node_queue.Enqueue(curr_node.right);

            }
            else
            {
                // we finish the scan of one level
                if (is_order_left)           //    <= Added to avoid insert in the beggining of the list
                    level_list.Reverse();    //    <= 
                result.Add(level_list);
                level_list = new List<int>();
                // prepare for the next level
                if (node_queue.Count > 0)
                    node_queue.Enqueue(null);
                is_order_left = !is_order_left;
            }
        }
        return result;
    }

    // Complexity:  T => O(N)   /   S => O(H)
    // Leetcode: Beats 100.00% / 51.32%
    public IList<IList<int>> ZigzagLevelOrder_Leedcode_DFS(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root == null)
            return result;

        DFS(root, 0, result);

        for(int level = 0; level < result.Count; level++)    //    <= Added to avoid insert in the beggining of the list
            if (level % 2 != 0)                              //    <= 
                ((List<int>)result[level]).Reverse();        //    <=

        return result;
    }

    protected void DFS(TreeNode node, int level, IList<IList<int>> results)
    {
        if (level >= results.Count)
        {
            var newLevel = new List<int>();
            newLevel.Add(node.val);
            results.Add(newLevel);
        }
        else
        {
            results[level].Add(node.val);               //    <= Added to avoid insert in the beggining of the list

            //if (level % 2 == 0)                       //    <= Removed
            //    results[level].Add(node.val);         //    <= Removed
            //else                                      //    <= Removed
            //    results[level].Insert(0, node.val);   //    <= Removed
        }

        if (node.left != null) DFS(node.left, level + 1, results);
        if (node.right != null) DFS(node.right, level + 1, results);
    }
}
