using DataStructures;

namespace CodingChallenges.Trees.BinarySearch;

/// <summary>
/// Groups    : Binary Tree, Design, Stack
/// Title     : 173. Binary Search Tree Iterator
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/binary-search-tree-iterator
/// Approach  : -
/// Leetcode  : Beats 100.00% / 66.17%
/// </summary>
public class BinarySearchTreeIterator // Leetcode: class name = "BSTIterator"
{
    Stack<TreeNode> nodeStack; // O(h) space /  => h is the max hight of the tree

    // O(h)
    public BinarySearchTreeIterator(TreeNode root)
    {
        nodeStack = [];

        FillStack(root);
    }

    private void FillStack(TreeNode currNode)
    {
        while (currNode != null)
        {
            nodeStack.Push(currNode);
            currNode = currNode.left;
        }
    }

    // O(1) to O(h)
    public int Next()
    {
        TreeNode currNode = nodeStack.Pop();
        int result = currNode.val;

        FillStack(currNode.right);

        return result;
    }

    // O(1)
    public bool HasNext()
        => nodeStack.Count > 0;
}

// CG
public class BSTIterator
{
    private Stack<TreeNode> stack;

    public BSTIterator(TreeNode root)
    {
        stack = new Stack<TreeNode>();
        PushLeft(root);
    }

    /** @return the next smallest number */
    public int Next()
    {
        TreeNode node = stack.Pop();
        int result = node.val;
        if (node.right != null)
        {
            PushLeft(node.right);
        }
        return result;
    }

    /** @return whether we have a next smallest number */
    public bool HasNext()
    {
        return stack.Count > 0;
    }

    private void PushLeft(TreeNode node)
    {
        while (node != null)
        {
            stack.Push(node);
            node = node.left;
        }
    }
}
/*
Esse problema pede para implementar um iterador de BST que percorre a árvore em ordem (in-order traversal).
A chave para resolver com O(h) memória e O(1) tempo médio por operação é usar uma pilha que guarda o caminho até o próximo nó.

 🔑 Explicação
- Construtor (BSTIterator): inicializa a pilha com todos os nós à esquerda do root.
- Next():
- Remove o nó do topo da pilha (o menor disponível).
- Se esse nó tiver filho à direita, empilha todos os nós à esquerda desse filho.
- HasNext(): retorna true se ainda houver nós na pilha.
- PushLeft(): função auxiliar que empilha todos os nós à esquerda de um dado nó.

⏱ Complexidade
- Tempo médio por operação: O(1).
- Cada nó é empilhado e desempilhado uma única vez.
- Memória: O(h), onde h é a altura da árvore (profundidade máxima da pilha).
*/