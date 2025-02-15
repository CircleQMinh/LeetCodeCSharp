using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public void Rotate(int[][] matrix)
        {
            var n = matrix.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    var t = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = t;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    var t = matrix[i][j];
                    matrix[i][j] = matrix[i][n - 1 - j];
                    matrix[i][n - 1 - j] = t;
                }
            }
        }
    }
}