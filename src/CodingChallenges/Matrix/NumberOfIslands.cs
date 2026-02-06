using System.Collections.Generic;

namespace CodingChallenges.Matrix;

/// <summary>
/// Groups    : Matrix / 2D Array (2DArray), 
/// Title     : 200. Number of Islands
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/number-of-islands/
/// Approach  : BFS (Breadth First Search) / DFS
/// </summary>
/// USAR A VERSÃO DO CG ABAIXO QUE É MAIS EFICIENTE
public class NumberOfIslands
{
    private static readonly int[][] directions =
    [
        [-1,0], // up
        [0,1],  // right
        [1,0],  // down
        [0,-1]  // left
    ];

    // udemy solution with BFS
    // Complexity: T: O(M x N) / S: O(max(M,N))
    //
    // For DFS soluction (see: https://replit.com/@ZhangMYihua/Number-of-Islands-DFS#index.js), complexity: T: O(M x N) / S: O(M x N)
    public int NumIslands(char[][] grid)
    {
        var inLand = new Queue<int[]>();

        const char land = '1';
        const char water = '0';

        var numIslands = 0;

        for(int row = 0; row < grid.Length; row++)
        {
            for(int col = 0; col < grid[row].Length; col++)
            {
                if(grid[row][col] == land)
                {
                    numIslands++;
                    inLand.Enqueue(new int[] { row, col });
                    grid[row][col] = water;

                    while (inLand.Count > 0)
                    {
                        var currentLand = inLand.Dequeue();
                        foreach (var direction in directions)
                        {
                            int rowAdj = currentLand[0] + direction[0];
                            int colAdj = currentLand[1] + direction[1];
                            if ((!isValidPosition(grid, rowAdj, colAdj)) || grid[rowAdj][colAdj] == water)
                                continue;

                            if (grid[rowAdj][colAdj] == land)
                                inLand.Enqueue(new int[] { rowAdj, colAdj });

                            grid[rowAdj][colAdj] = water;
                        }
                    }
                }
            }
        }

        return numIslands;
    }

    // Versão muito complicada e verbosa. Não usar
    public int NumIslands_MySolution(char[][] grid)
    {
        var seen = new bool[grid.Length, grid[0].Length];
        var inLand = new Queue<int[]>();
        var inWater = new Queue<int[]>();

        const char land = '1';
        const char water = '0';

        var numIslands = 0;

        if (grid[0][0] == land)
        {
            inLand.Enqueue(new int[] { 0, 0 });
            numIslands++;
        }
        else
            inWater.Enqueue(new int[] { 0, 0 });

        seen[0, 0] = true;

        while (inLand.Count > 0 || inWater.Count > 0)
        {
            if (inLand.Count > 0)
            {
                var currentLand = inLand.Dequeue();
                foreach (var direction in directions)
                {
                    int row = currentLand[0] + direction[0];
                    int col = currentLand[1] + direction[1];
                    if ((!isValidPosition(grid, row, col)) || seen[row, col])
                        continue;

                    if (grid[row][col] == land)
                        inLand.Enqueue(new int[] { row, col });
                    else
                        inWater.Enqueue(new int[] { row, col });

                    seen[row, col] = true;
                }
            }
            else
            {
                var currentWater = inWater.Dequeue();
                foreach (var direction in directions)
                {
                    int row = currentWater[0] + direction[0];
                    int col = currentWater[1] + direction[1];
                    if ((!isValidPosition(grid, row, col)) || seen[row, col])
                        continue;

                    seen[row, col] = true;

                    if (grid[row][col] == land)
                    {
                        inLand.Enqueue(new int[] { row, col });
                        numIslands++;
                        break;
                    }
                    else
                        inWater.Enqueue(new int[] { row, col });
                }
            }
        }

        return numIslands;
    }

    private bool isValidPosition(char[][] grid, int row, int col)
        => row >= 0 && col >= 0 && row < grid.Length && col < grid[0].Length;
}


// Leetcode: Beats 31.72% / 5.83%
// Basicamente igual a solução implementada acima
public class NumberOfIslandsV2
{
    private static readonly int[][] directions =
    [
        [-1,0], // up
        [0,1],  // right
        [1,0],  // down
        [0,-1]  // left
    ];
    const char unnexploredLand = '1';
    const char water = '0';
    const char exploredLand = 'I';

    public int NumIslands(char[][] grid)
    {
        Queue<int[]> inLand = [];
        int islandCount = 0;

        for (int row = 0; row < grid.Length; row++)
        {
            for (int col = 0; col < grid[0].Length; col++)
            {
                if (grid[row][col] == unnexploredLand)
                {
                    grid[row][col] = exploredLand;
                    inLand.Enqueue([row, col]);
                    islandCount++;

                    while (inLand.Count > 0)
                    {
                        int[] point = inLand.Dequeue();
                        foreach (int[] direction in directions)
                        {
                            int[] neighbor = [point[0] + direction[0], point[1] + direction[1]];
                            if (IsValidPosition(grid, neighbor) && grid[neighbor[0]][neighbor[1]] == unnexploredLand)
                            {
                                inLand.Enqueue(neighbor);
                                grid[neighbor[0]][neighbor[1]] = exploredLand;
                            }
                        }
                    }
                }

            }
        }

        return islandCount;
    }

    private static bool IsValidPosition(char[][] grid, int[] position)
        => position[0] >= 0 && position[0] < grid.Length && position[1] >= 0 && position[1] < grid[0].Length;
}

// Leetcode: Beats 84.57% / 85.06%
public class NumberOfIslandsCGPT
{
    const char unnexploredLand = '1';
    const char water = '0';
    const char exploredLand = 'I';

    public int NumIslands(char[][] grid)
    {
        if (grid == null || grid.Length == 0) return 0;

        int rows = grid.Length;
        int cols = grid[0].Length;
        int count = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (grid[row][col] == unnexploredLand)
                {
                    ExploreIsland(grid, row, col);
                    count++;
                }
            }
        }

        return count;
    }

    private void ExploreIsland(char[][] grid, int row, int col) // CG nomeou essa função como "DFS" (Deep-First Search)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        if (row < 0 || col < 0 || row >= rows || col >= cols || grid[row][col] != unnexploredLand)
            return;

        grid[row][col] = exploredLand; // marca como visitado

        ExploreIsland(grid, row + 1, col); // baixo
        ExploreIsland(grid, row - 1, col); // cima
        ExploreIsland(grid, row, col + 1); // direita
        ExploreIsland(grid, row, col - 1); // esquerda
    }
}
