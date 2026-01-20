using DataStructures;
namespace CodingChallenges.Trees;

/// <summary>
/// Groups    : Hash Table, Linked List, Design, Doubly-Linked List
/// Title     : 105. Construct Binary Tree from Preorder and Inorder Traversal
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal
/// Approach  : -
/// </summary>
public class ConstructBinaryTreeFromPreorderAndInorderTraversal
{
    private Dictionary<int, int> inorderIndexMap;
    private int preorderIndex;

    // Leetcode: Beats 92.29% / 41.95%
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        inorderIndexMap = [];
        for (int i = 0; i < inorder.Length; i++)
            inorderIndexMap[inorder[i]] = i;

        preorderIndex = 0;
        return ArrayToTree(preorder, 0, inorder.Length - 1);
    }

    private TreeNode ArrayToTree(int[] preorder, int left, int right)
    {
        if (left > right) return null;

        // O próximo elemento do preorder é a raiz
        int rootValue = preorder[preorderIndex++];
        TreeNode root = new(rootValue);

        // Construir subárvore esquerda e direita
        root.left = ArrayToTree(preorder, left, inorderIndexMap[rootValue] - 1);
        root.right = ArrayToTree(preorder, inorderIndexMap[rootValue] + 1, right);

        return root;
    }

    // Definition for a binary tree node.
    //public class TreeNode {
    //    public int val;
    //    public TreeNode left;
    //    public TreeNode right;
    //    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
    //        this.val = val;
    //        this.left = left;
    //        this.right = right;
    //    }
    //}
}
