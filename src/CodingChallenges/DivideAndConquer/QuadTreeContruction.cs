namespace CodingChallenges.DivideAndConquer;

/// <summary>
/// Related   : Divide and Conquer, Linked List, Sorting, Merge Sort
/// Title     : 427. Construct Quad Tree
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/construct-quad-tree
/// Approachs : Divide and Conquer
/// </summary>
public class QuadTreeContruction // CG
{
    public Node Construct(int[][] grid)
    {
        return Build(grid, 0, 0, grid.Length);
    }

    private Node Build(int[][] grid, int row, int col, int size)
    {
        if (IsUniform(grid, row, col, size))
        {
            return new Node(grid[row][col] == 1, true);
        }

        int newSize = size / 2;
        Node topLeft = Build(grid, row, col, newSize);
        Node topRight = Build(grid, row, col + newSize, newSize);
        Node bottomLeft = Build(grid, row + newSize, col, newSize);
        Node bottomRight = Build(grid, row + newSize, col + newSize, newSize);

        return new Node(true, false, topLeft, topRight, bottomLeft, bottomRight);
    }

    private bool IsUniform(int[][] grid, int row, int col, int size)
    {
        int val = grid[row][col];
        for (int i = row; i < row + size; i++)
        {
            for (int j = col; j < col + size; j++)
            {
                if (grid[i][j] != val) return false;
            }
        }
        return true;
    }
}

// Definition for a QuadTree node.
public class Node
{
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node()
    {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }

    public Node(bool _val, bool _isLeaf)
    {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }

    public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
    {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}

