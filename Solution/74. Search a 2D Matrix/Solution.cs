using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;

            int left = 0;
            int right = (m * n) - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                int x = middle / n;
                int y = middle % n;

                if (matrix[x][y] == target)
                {
                    return true;
                }

                if (matrix[x][y] < target)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return false;
        }
    }
}