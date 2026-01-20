using DataStructures;
using System;

namespace CodingChallenges.Trees;

/// <summary>
/// Groups    : Birary Search, Birary Tree, Bit Manipulation
/// Title     : 222. Count Complete Tree Nodes
/// Difficult : Easy (se contar em O(n) / Medium (se contar em O(log²N))
/// Link      : https://leetcode.com/problems/count-complete-tree-nodes/
/// Approach  : DFS (Depth First Search), Birary Search
/// </summary>
public class CountCompleteTreeNodes
{
    // Leetcode: Beats 100.00% / 35.84%
    // O(log²N) / O(h) => h is the max hight of the tree
    public int CountNodes(TreeNode root) // Versão otimizada para não contar novamente o lado esquerdo da árvore
    {
        if (root == null) return 0;

        int leftHeight = GetHeight(root.left);
        int rightHeight = GetHeight(root.right);

        // Subárvore esquerda é perfeita
        if (leftHeight == rightHeight)
            return (1 << leftHeight) + CountNodes(root.right, rightHeight - 1);
        // O operador (1 << h) equivale a 2^h
        // A soma de uma árvore completa é (2^h -1), mas como já está somando o nó root com a árvore completa de um lado, seria ((2^h -1) + 1), que resulta em 2^h, e depois soma o que contar do outro lado

        // Subárvore direita é perfeita
        return (1 << rightHeight) + CountNodes(root.left, leftHeight - 1);
    }

    private int CountNodes(TreeNode root, int leftHeight)
    {
        if (root == null) return 0;

        int rightHeight = GetHeight(root.right);

        // Subárvore esquerda é perfeita
        if (leftHeight == rightHeight)
            return (1 << leftHeight) + CountNodes(root.right, rightHeight - 1); // O operador (1 << h) equivale a 2^h
        
        // Subárvore direita é perfeita
        return (1 << rightHeight) + CountNodes(root.left, leftHeight - 1);
    }

    // Leetcode: Beats 100.00% / 35.84%
    // O(log²N) / O(h) => h is the max hight of the tree
    public int CountNodes_ChatGPT(TreeNode root)
    {
        if (root == null) return 0;

        int leftHeight = GetHeight(root.left);
        int rightHeight = GetHeight(root.right);

        // Subárvore esquerda é perfeita
        if (leftHeight == rightHeight)
            return (1 << leftHeight) + CountNodes_ChatGPT(root.right); // O operador (1 << h) equivale a 2^h

        // Subárvore direita é perfeita
        return (1 << rightHeight) + CountNodes_ChatGPT(root.left);
    }

    private int GetHeight(TreeNode node)
    {
        int height = 0;
        while (node != null)
        {
            height++;
            node = node.left;
        }
        return height;
    }

    // Versão antiga, bem mais complicada de entender
    // T: O(h²) or O(log²N)  /  S: O(1)  (Supostamente)
    public int CountNodes_v2(TreeNode root)
    {
        if (root == null)
            return 0;

        int height = GetHeight(root);

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
}
