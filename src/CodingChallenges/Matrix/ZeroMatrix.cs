using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Matrix
{
    public class ZeroMatrix
    {
        public void GetZeroMatrix(int[][] matrix) 
        {
            bool firstRowHasZeros = false;
            bool firstColumnHasZeros = false;

            for (int column = 0; column < matrix[0].Length; column++)
            {
                if (matrix[0][column] == 0)
                {
                    firstRowHasZeros = true;
                    break;
                }
            }
            for (int row = 0; row < matrix.Length; row++)
            {
                if (matrix[row][0] == 0)
                {
                    firstColumnHasZeros = true;
                    break;
                }
            }

            for (int row = 1; row < matrix.Length; row++)
            {
                for (int column = 1; column < matrix[row].Length; column++)
                {
                    if (matrix[row][column] == 0)
                    {
                        matrix[0][column] = 0;
                        matrix[row][0] = 0;
                    }
                }
            }

            for (int column = 0; column < matrix[0].Length; column++)
            {
                if (matrix[0][column] == 0)
                    setZerosToColumn(matrix, column);
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                if (matrix[row][0] == 0)
                    setZerosToRow(matrix, row);
            }

            if (firstRowHasZeros)
                setZerosToRow(matrix, 0);

            if (firstColumnHasZeros)
                setZerosToColumn(matrix, 0);
        }

        private void setZerosToRow(int[][] matrix, int row)
        {
            for (int i = 0; i < matrix[0].Length; i++)
                matrix[row][i] = 0;
        }

        private void setZerosToColumn(int[][] matrix, int column)
        {
            for (int j = 0; j < matrix.Length; j++)
                matrix[j][column] = 0;
        }
    }
}
