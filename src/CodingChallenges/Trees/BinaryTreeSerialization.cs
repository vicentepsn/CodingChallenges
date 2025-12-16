using DataStructures;

namespace CodingChallenges.Trees;
/*
public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
*/

// Amazon interview Live Coding 2025-12-12
// [1,[2,[3,,[4,,]],],[5,[6,,[8,,]],[7,,]]]
public class BinaryTreeSerialization
{
    public static string SerializeBinaryTree(TreeNode? treeHead)
    {
        if (treeHead == null)
            return "";

        return $"[{treeHead.val},{SerializeBinaryTree(treeHead.left)},{SerializeBinaryTree(treeHead.right)}]";
    }

    public static TreeNode? DeserializeBinaryTree(string tree)
    {
        if (string.IsNullOrEmpty(tree))
            return null;

        int position = 0;

        return DeserializaBinaryTree(tree, ref position);
    }

    private static TreeNode? DeserializaBinaryTree(string tree, ref int leftIndex)
    {
        leftIndex++; // skip the open bracket '['

        int nextCommaIdx = tree.IndexOf(',', leftIndex + 1);
        string valueStr = tree.Substring(leftIndex, nextCommaIdx - leftIndex);
        int value = int.Parse(valueStr);

        TreeNode? result = new() { val = value };

        leftIndex = nextCommaIdx + 1; // skip first comma

        if (tree[leftIndex] == '[')
            result.left = DeserializaBinaryTree(tree, ref leftIndex);

        leftIndex++; // skip second comma

        if (tree[leftIndex] == '[')
            result.right = DeserializaBinaryTree(tree, ref leftIndex);

        leftIndex++; // skip the close bracket ']'

        return result;
    }
}
