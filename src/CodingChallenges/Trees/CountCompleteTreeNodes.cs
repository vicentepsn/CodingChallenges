using DataStructures;
using System;

namespace CodingChallenges.Trees
{
    /// <summary>
    /// Groups    : Tree
    /// Title     : 222. Count Complete Tree Nodes
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/count-complete-tree-nodes/
    /// Approach  : DFS (Depth First Search), Birary Search
    /// Complexity: T: O(h²) or O(log²N)  /  S: O(1)
    /// </summary>
    public class CountCompleteTreeNodes
    {
        public int CountNodes(TreeNode root)
        {
            if (root == null)
                return 0;

            int height = GetHeigth(root);

            if (height == 0)
                return 1;

            int upperCount = (int)Math.Pow(2, height) - 1;

            int left = 0, right = upperCount;

            while (left < right)
            {
                int idxToFind = (int)Math.Ceiling((left + right) / 2.0);

                if (nodeExists(root, height, idxToFind))
                    left = idxToFind;
                else
                    right = idxToFind - 1;
            }

            return upperCount + left + 1;
        }

        private bool nodeExists(TreeNode node, int height, int idxToFind)
        {
            int count = 0, left = 0, right = (int)Math.Pow(2, height) - 1; ;

            while (count < height)
            {
                int midOfNode = (int)Math.Ceiling((left + right) / 2.0);
                if (midOfNode <= idxToFind)
                {
                    left = midOfNode;
                    node = node.right;
                }
                else
                {
                    right = midOfNode - 1;
                    node = node.left;
                }
                count++;
            }

            return node != null;
        }

        public int GetHeigth(TreeNode node)
        {
            int height = 0;

            while (node.left != null)
            {
                height++;
                node = node.left;
            }

            return height;
        }
    }
}
