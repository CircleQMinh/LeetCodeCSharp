using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var result = new List<int>();
            var i = 0;
            var j = -1;
            var m = matrix.Length;
            var n = matrix[0].Length;
            var top = -1;
            var left = -1;
            var right = n;
            var bot = m;
            var dir = "right";
            var count = 0;
            while (count < m * n)
            {

                if (dir == "right")
                {
                    j++;
                    if (j == right)
                    {
                        top++;
                        dir = "down";
                        j--;
                        continue;
                    }
                }
                if (dir == "down")
                {
                    i++;
                    if (i == bot)
                    {
                        right--;
                        dir = "left";
                        i--;
                        continue;
                    }
                }
                if (dir == "left")
                {
                    j--;
                    if (j == left)
                    {
                        bot--;
                        dir = "up";
                        j++;
                        continue;
                    }
                }
                if (dir == "up")
                {
                    i--;
                    if (i == top)
                    {
                        left++;
                        dir = "right";
                        i++;
                        continue;
                    }
                }
                result.Add(matrix[i][j]);
                count++;
            }
            return result;
        }
    }
}