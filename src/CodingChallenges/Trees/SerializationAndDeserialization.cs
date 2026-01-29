using DataStructures;

namespace CodingChallenges.Trees;

// Live Coding from Amazon 2025-01-12
public class SerializationAndDeserialization
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

    public static string SerializeBinaryTree_InOrder(TreeNode? treeHead)
    {
        if (treeHead == null)
            return "";

        return $"[{treeHead.val},{SerializeBinaryTree(treeHead.left)},{SerializeBinaryTree(treeHead.right)}]";
    }

}
