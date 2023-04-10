using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.Trees
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node parent;
    }

    /// <summary>
    /// Related   : HashTable, Tree, Binary Tree
    /// Title     : 1650. Lowest Common Ancestor of a Binary Tree III
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-iii/
    /// Companies : Facebook 149, Microsoft 5, LinkedIn 5, Amazon 3, Google 3 (2022-05-03)
    /// </summary>
    public class BinaryTreeLowestCommonAncestor3
    {
        public Node LowestCommonAncestor(Node p, Node q)
        {
            var pAncestors = new HashSet<Node>();

            var currentP = p;
            while (currentP != null)
            {
                pAncestors.Add(currentP);
                currentP = currentP.parent;
            }

            var currentQ = q;
            while (currentQ.parent != null)
            {
                if (pAncestors.Contains(currentQ))
                    return currentQ;
                currentQ = currentQ.parent;
            }

            return currentQ;
        }
    }
}
