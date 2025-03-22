using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int UniquePathsWithObstacles(int[][] grid)
        {
            if (grid[0][0] == 1)
            {
                return 0;
            }
            var m = grid.Length;
            var n = grid[0].Length;

            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
            }
            var directions = new (int X, int Y)[] { (-1, 0), (0, -1) };

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var top = 0;
                    var left = 0;
                    var current = grid[i][j];
                    var newX = i + directions[0].X;
                    var newY = j + directions[0].Y;

                    if (newX >= 0 && newX < m && newY >= 0 && newY < n)
                    {
                        top = dp[newX][newY];
                    }

                    newX = i + directions[1].X;
                    newY = j + directions[1].Y;

                    if (newX >= 0 && newX < m && newY >= 0 && newY < n)
                    {
                        left = dp[newX][newY];
                    }


                    dp[i][j] = current == 1 ? 0 : top + left;
                    if (i == 0 && j == 0)
                    {
                        dp[i][j] = 1;
                    }

                }
            }

            return dp[m - 1][n - 1];
        }
    }
}