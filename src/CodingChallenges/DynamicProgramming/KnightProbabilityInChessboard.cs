namespace CodingChallenges.DynamicProgramming
{
    /// <summary>
    /// Related   : Dynamic Programming
    /// Title     : 688. Knight Probability in Chessboard
    /// Difficult : Medium
    /// Link      : https://leetcode.com/problems/knight-probability-in-chessboard/
    /// Companies : Amazon 3 (2022-04-22)
    /// </summary>

    public class KnightProbabilityInChessboard
    {
        int[,] directions = new int[,] { { -2, 1 }, { -2, -1 }, { 2, 1 }, { 2, -1 }, { 1, -2 }, { -1, -2 }, { 1, 2 }, { -1, 2 } };

        // O(N²K) / O(N²)
        public double KnightProbability_leetcode(int n, int k, int row, int column)
        {
            double[,] dp = new double[n,n];
            //int[] dr = new int[] { 2, 2, 1, 1, -1, -1, -2, -2 };
            //int[] dc = new int[] { 1, -1, 2, -2, 2, -2, 1, -1 };

            dp[row,column] = 1;
            for (; k > 0; k--)
            {
                double[,] dp2 = new double[n,n];
                for (int r = 0; r < n; r++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        for (int d = 0; d < directions.GetLength(0); d++)
                        {
                            int cr = r + directions[d, 0];
                            int cc = c + directions[d, 1];
                            if (0 <= cr && cr < n && 0 <= cc && cc < n)
                            {
                                dp2[cr,cc] += dp[r,c] / 8.0;
                            }
                        }
                    }
                }
                dp = dp2;
            }
            double ans = 0.0;
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++) 
                    ans += dp[i,j];
            }
            return ans;
        }

        // O(N²K) / O(N²K)    => brute force will be O(8^k) / O(8^k)
        public double KnightProbability(int n, int k, int row, int column)
        {
            if (n <= 2)
                return 0;

            var probabilities = new double?[k, n, n];

            return KnightProbability_aux(n, k, row, column, probabilities);
        }

        private double KnightProbability_aux(int n, int k, int row, int column, double?[,,] probabilities)
        {
            if (k == 0)
                return 1;

            if (probabilities[k, row, column] != null)
                return (double)probabilities[k, row, column];

            double prob = 0.0;
            for (int i = 0; i < directions.GetLength(0); i++)
            {
                int newRow = row + directions[i, 0];
                int newCol = row + directions[i, 1];
                if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < n)
                    prob += KnightProbability_aux(n, k - 1, newRow, newCol, probabilities);
            }

            return prob / 8;
        }
    }
}
