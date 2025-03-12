using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int SnakesAndLadders(int[][] board)
        {
            var result = int.MaxValue;
            var n = board.Length;
            var flatten = new int[(n * n) + 1];
            int count = 1;
            var reverse = false;
            for (int i = n - 1; i >= 0; i--)
            {
                if (reverse)
                {
                    for (int j = n - 1; j >= 0; j--)
                    {
                        flatten[count++] = board[i][j];

                    }
                }
                else
                {
                    for (int j = 0; j < n; j++)
                    {
                        flatten[count++] = board[i][j];

                    }
                }
                reverse = !reverse;

            }
            result = FindShortestPathForSnakeAndLadder(flatten);
            return result;
        }
        public int FindShortestPathForSnakeAndLadder(int[] board)
        {
            var distance = new int[board.Length];
            Array.Fill(distance, -1);
            var queue = new Queue<int>();
            queue.Enqueue(1);
            distance[1] = 0;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                for (int next = current + 1; next <= Math.Min(current + 6, board.Length - 1); next++) // [curr + 1, min(curr + 6, n2)]
                {
                    var dest = board[next] == -1 ? next : board[next];

                    if (distance[dest] == -1 || distance[current] + 1 < distance[dest])
                    {
                        distance[dest] = distance[current] + 1;
                        queue.Enqueue(dest);
                    }
                }
            }
            return distance[board.Length - 1];
        }
    }
}