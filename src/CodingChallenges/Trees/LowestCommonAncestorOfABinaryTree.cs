using DataStructures;

namespace CodingChallenges.Trees;

/// <summary>
/// Groups    : Birary Tree, Depth First Search
/// Title     : 236. Lowest Common Ancestor of a Binary Tree
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree
/// Approach  : -
/// </summary>
public class LowestCommonAncestorOfABinaryTree
{
    // Versão bem melhor e mais enchuta! Usar essa
    // Leetcode: Beats 53.61% / 25.77%
    public TreeNode LowestCommonAncestor_ChatGPT(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || root == p || root == q)
        {
            return root;
        }

        TreeNode left = LowestCommonAncestor_ChatGPT(root.left, p, q);
        TreeNode right = LowestCommonAncestor_ChatGPT(root.right, p, q);

        if (left != null && right != null)
        {
            return root; // p e q estão em lados diferentes
        }

        return left ?? right; // retorna o lado não-nulo
    }


    TreeNode result;
    // Leetcode: Beats 44.33% / 69.07%
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        result = null;
        bool found = LowestCommonAncestor_A(root, p, q);
        return result;
    }

    public bool LowestCommonAncestor_A(TreeNode node, TreeNode p, TreeNode q)
    {
        bool foundLeft = false;
        if (node.left != null)
        {
            foundLeft = LowestCommonAncestor_A(node.left, p, q);
            if (result != null) return false;

            if (foundLeft && (node.val == p.val || node.val == q.val))
            {
                result = node;
                return false;
            }
        }

        bool foundRight = false;
        if (node.right != null)
        {
            foundRight = LowestCommonAncestor_A(node.right, p, q);
            if (result != null) return false;

            if ((foundLeft && foundRight) || ((foundLeft || foundRight) && (node.val == p.val || node.val == q.val)))
            {
                result = node;
                return false;
            }
        }

        return foundLeft || foundRight || node.val == p.val || node.val == q.val;
    }

}
