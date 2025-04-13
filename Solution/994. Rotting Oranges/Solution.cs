using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int OrangesRotting(int[][] grid)
        {
            var daysPass = -1;
            var m = grid.Length;
            var n = grid[0].Length;
            var directions = new (int X, int Y)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            var queue = new Queue<(int X, int Y)>();
            var numberOfFresh = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        queue.Enqueue((i, j));
                    }
                    if (grid[i][j] == 1)
                    {
                        numberOfFresh++;
                    }
                }
            }
            if (numberOfFresh == 0)
            {
                return 0;
            }
            while (queue.Count > 0)
            {
                daysPass++;
                var inQueue = queue.Count();
                for (int i = 0; i < inQueue; i++)
                {
                    var (x, y) = queue.Dequeue();
                    foreach (var item in directions)
                    {
                        var newX = x + item.X;
                        var newY = y + item.Y;
                        if (newX >= 0 && newX < m && newY >= 0 && newY < n && grid[newX][newY] == 1)
                        {
                            grid[newX][newY] = 2;
                            queue.Enqueue((newX, newY));
                        }
                    }


                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        return -1;
                    }
                }
            }

            return daysPass;
        }
    }
}