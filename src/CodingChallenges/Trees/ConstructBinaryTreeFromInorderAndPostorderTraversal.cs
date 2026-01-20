using DataStructures;

namespace CodingChallenges.Trees;

/// <summary>
/// Groups    : Binary Tree, Hash Table, Divide and Conquer, Array
/// Title     : 106. Construct Binary Tree from Inorder and Postorder Traversal
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal
/// Approach  : -
/// </summary>
public class ConstructBinaryTreeFromInorderAndPostorderTraversal
{
    int postorderIndex;
    Dictionary<int, int> indorderIndexMap;

    // Leetcode: Beats 97.35% / 96.83%
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        indorderIndexMap = [];
        for (int i = 0; i < inorder.Length; i++)
            indorderIndexMap[inorder[i]] = i;

        // no postorder percorre do início para o final
        postorderIndex = inorder.Length - 1;

        return BuildTree(postorder, 0, inorder.Length - 1);
    }

    public TreeNode BuildTree(int[] postorder, int left, int right)
    {
        if (left > right) return null;

        // O próximo elemento (direita para esquerda) do postorder é a raiz
        int nodeValue = postorder[postorderIndex--];
        TreeNode treeNode = new(nodeValue);

        // Construir subárvore direita e esquerda
        treeNode.right = BuildTree(postorder, indorderIndexMap[nodeValue] + 1, right);
        treeNode.left = BuildTree(postorder, left, indorderIndexMap[nodeValue] - 1);

        return treeNode;
    }
}
