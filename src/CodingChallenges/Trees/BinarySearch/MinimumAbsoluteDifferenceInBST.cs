using DataStructures;

namespace CodingChallenges.Trees.BinarySearch;

/// <summary>
/// Related   : Binary Search Tree, Depth-First Search
/// Title     : 530. Minimum Absolute Difference in BST / Mesmo que o "783. Minimum Distance Between BST Nodes"
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/minimum-absolute-difference-in-bst / Mesmo que o https://leetcode.com/problems/minimum-distance-between-bst-nodes
/// Companies : 
/// </summary>
public class MinimumAbsoluteDifferenceInBST
{
    private int minDiff = int.MaxValue;
    private TreeNode prev = null;

    // Leetcode: Beats 100.00% / 74.29%
    // CG
    public int GetMinimumDifference(TreeNode root)
    {
        InOrder(root);
        return minDiff;
    }

    private void InOrder(TreeNode node)
    {
        if (node == null) return;

        InOrder(node.left);

        if (prev != null)
        {
            minDiff = Math.Min(minDiff, node.val - prev.val);
        }
        prev = node;

        InOrder(node.right);
    }
}
/*
Esse problema pede para encontrar a menor diferença absoluta entre quaisquer dois nós em uma BST (Binary Search Tree).
A ideia é simples:
- Em uma BST, o in-order traversal (percurso em ordem) gera os valores em ordem crescente.
- Assim, basta comparar valores consecutivos durante o percurso, pois a menor diferença sempre estará entre eles.

🔑 Explicação
- InOrder percorre a árvore em ordem crescente.
- prev guarda o último nó visitado.
- A cada passo, calculamos a diferença entre o nó atual e prev.
- Atualizamos minDiff se encontrarmos uma diferença menor.

⏱ Complexidade
- Tempo: O(n), pois percorremos todos os nós uma vez.
- Espaço: O(h), onde h é a altura da árvore (pilha de recursão).
 */