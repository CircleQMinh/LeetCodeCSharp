using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int NearestExit(char[][] maze, int[] entrance)
        {
            var m = maze.Length;
            var n = maze[0].Length;
            var startX = entrance[0];
            var startY = entrance[1];

            var dic = new Dictionary<(int X, int Y), int>();
            var directions = new (int X, int Y)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            var queue = new Queue<(int X, int Y)>();

            queue.Enqueue((startX, startY));
            maze[startX][startY] = '+';
            var step = 0;

            while (queue.Count > 0)
            {
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var current = queue.Dequeue();

                    if ((current.X == 0 || current.X == m - 1 || current.Y == 0 || current.Y == n - 1) && (current.X != startX || current.Y != startY))
                    {
                        return step;
                    }

                    if (!dic.ContainsKey(current))
                    {
                        dic.Add(current, int.MaxValue);
                    }
                    dic[current] = Math.Min(dic[current], step);
                    foreach (var (dx, dy) in directions)
                    {
                        int newX = current.X + dx, newY = current.Y + dy;

                        if (newX >= 0 && newX < m && newY >= 0 && newY < n && maze[newX][newY] == '.')
                        {
                            queue.Enqueue((newX, newY));
                            maze[newX][newY] = '+';
                        }
                    }
                }
                step++;
            }

            return -1;
        }
    }
}