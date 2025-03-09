using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int NumIslands(char[][] grid)
        {
            int count = 0;
            int m = grid.Length;
            int n = grid[0].Length;

            var directions = new (int X, int Y)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1') // Found an island
                    {
                        count++; // Once find an island check for another island near by and add that to the queue
                        var queue = new Queue<(int X, int Y)>();
                        queue.Enqueue((i, j));
                        grid[i][j] = '0'; // Mark as visited, use 0 instead of hashset to save memory since 0 is useless in this

                        while (queue.Count > 0)
                        {
                            var (x, y) = queue.Dequeue();

                            foreach (var (dx, dy) in directions)
                            {
                                int newX = x + dx, newY = y + dy;

                                if (newX >= 0 && newX < m && newY >= 0 && newY < n && grid[newX][newY] == '1') // Valid location and is an island
                                {
                                    queue.Enqueue((newX, newY));
                                    grid[newX][newY] = '0'; // Mark as visited
                                }
                            }
                        }
                    }
                }
            }

            return count;
        }
    }
}