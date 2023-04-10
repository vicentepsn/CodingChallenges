using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Extensions
{
    public static class TreeNodeExtension
    {
        public static TreeNode Insert(this TreeNode treeNode, int?[] values)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(treeNode);

            var i = 0;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.left == null)
                {
                    if (values[i] != null)
                    {
                        current.left = new TreeNode((int)values[i]);
                    }
                    i++;
                    if (i >= values.Length)
                        return treeNode;
                }
                if (current.left != null)
                    queue.Enqueue(current.left);

                if (current.right == null)
                {
                    if (values[i] != null)
                    {
                        current.right = new TreeNode((int)values[i]);
                    }
                    i++;
                    if (i >= values.Length)
                        return treeNode;
                }
                if (current.right != null)
                    queue.Enqueue(current.right);
            }
            return treeNode;
        }
    }
}
