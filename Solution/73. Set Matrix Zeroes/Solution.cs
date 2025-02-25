using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public void SetZeroes(int[][] matrix)
        {
            var row = new HashSet<int>();
            var col = new HashSet<int>();
            var m = matrix.Length;
            var n = matrix[0].Length;


            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        row.Add(i);
                        col.Add(j);
                    }
                }
            }

            foreach (var item in row)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[item][i] = 0;
                }
            }

            foreach (var item in col)
            {
                for (int i = 0; i < m; i++)
                {
                    matrix[i][item] = 0;
                }
            }
        }
    }
}