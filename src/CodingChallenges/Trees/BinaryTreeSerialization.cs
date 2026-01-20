using DataStructures;
using System.Text;

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
//         1
//       /   \
//     2       5
//   /       /  \
//  3       6    7
//   \       \
//    4       8
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

        return DeserializeBinaryTree(tree, ref position);
    }

    private static TreeNode? DeserializeBinaryTree(string tree, ref int leftIndex)
    {
        leftIndex++; // skip the open bracket '['

        int nextCommaIdx = tree.IndexOf(',', leftIndex + 1);
        string valueStr = tree.Substring(leftIndex, nextCommaIdx - leftIndex);
        int value = int.Parse(valueStr);

        TreeNode? result = new() { val = value };

        leftIndex = nextCommaIdx + 1; // skip first comma

        if (tree[leftIndex] == '[')
            result.left = DeserializeBinaryTree(tree, ref leftIndex);

        leftIndex++; // skip second comma

        if (tree[leftIndex] == '[')
            result.right = DeserializeBinaryTree(tree, ref leftIndex);

        leftIndex++; // skip the close bracket ']'

        return result;
    }
}

/* 
"1,3,null,null,5,7,null,null,2,null,null,"
    1
   / \
  3   5
     / \
    7   2

"1,3,null,null,5,7,null,null,2,null,null,"
    4
   / \
  2   6
 /   / \
1   5   7
*/
// Mais eficiente
public class CodecDFS
{
    // Serializa a árvore para string
    public string Serialize(TreeNode root)
    {
        StringBuilder sb = new StringBuilder();
        SerializeHelper(root, sb);
        return sb.ToString();
    }

    private void SerializeHelper(TreeNode? node, StringBuilder sb)
    {
        if (node == null)
        {
            sb.Append("null,");
            return;
        }
        sb.Append(node.val).Append(",");
        SerializeHelper(node.left, sb);
        SerializeHelper(node.right, sb);
    }

    // Desserializa a string para árvore
    public TreeNode? Deserialize(string data)
    {
        Queue<string> nodes = new Queue<string>(data.Split(',', StringSplitOptions.RemoveEmptyEntries));
        return DeserializeHelper(nodes);
    }

    private TreeNode? DeserializeHelper(Queue<string> nodes)
    {
        if (nodes.Count == 0) return null;
        string val = nodes.Dequeue();
        if (val == "null") return null;

        TreeNode node = new TreeNode(int.Parse(val));
        node.left = DeserializeHelper(nodes);
        node.right = DeserializeHelper(nodes);
        return node;
    }
}

/*
[1,3,5,null,null,7,2]
    1
   / \
  3   5
     / \
    7   2

[4,2,6,1,null,5,7]
    4
   / \
  2   6
 /   / \
1   5   7
*/
public class CodecBFS
{
    // Serializa para formato de array
    public string Serialize(TreeNode root)
    {
        if (root == null) return "[]";

        List<string> result = new List<string>();
        Queue<TreeNode?> queue = new Queue<TreeNode?>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode? node = queue.Dequeue();
            if (node == null)
            {
                result.Add("null");
            }
            else
            {
                result.Add(node.val.ToString());
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
        }

        // Remove nulls finais desnecessários
        int i = result.Count - 1;
        while (i >= 0 && result[i] == "null") i--;
        result = result.GetRange(0, i + 1);

        return "[" + string.Join(",", result) + "]";
    }

    // Desserializa do formato de array
    public TreeNode? Deserialize(string data)
    {
        if (data == "[]" || string.IsNullOrEmpty(data)) return null;

        string[] values = data.Trim('[', ']').Split(',');
        TreeNode root = new TreeNode(int.Parse(values[0]));
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int i = 1;
        while (queue.Count > 0 && i < values.Length)
        {
            TreeNode node = queue.Dequeue();

            if (values[i] != "null")
            {
                node.left = new TreeNode(int.Parse(values[i]));
                queue.Enqueue(node.left);
            }
            i++;

            if (i < values.Length && values[i] != "null")
            {
                node.right = new TreeNode(int.Parse(values[i]));
                queue.Enqueue(node.right);
            }
            i++;
        }

        return root;
    }
}