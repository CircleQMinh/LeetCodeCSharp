using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public void Solve(char[][] board)
        {
            int m = board.Length;
            int n = board[0].Length;


            for (int i = 0; i < m; i++)
            {
                if (board[i][0] == 'O')
                {
                    MarkCantBeSurroundedRegion(board, i, 0);
                }
                if (board[i][n - 1] == 'O')
                {
                    MarkCantBeSurroundedRegion(board, i, n - 1);
                }
            }
            for (int i = 1; i < n - 1; i++)
            {

                if (board[0][i] == 'O')
                {
                    MarkCantBeSurroundedRegion(board, 0, i);
                }
                if (board[m - 1][i] == 'O')
                {
                    MarkCantBeSurroundedRegion(board, m - 1, i);
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == 'O')
                    {
                        board[i][j] = 'X';
                    }
                    if (board[i][j] == 'Q')
                    {
                        board[i][j] = 'O';
                    }
                }
            }

        }
        public void MarkCantBeSurroundedRegion(char[][] board, int i, int j)
        {
            int m = board.Length;
            int n = board[0].Length;
            var directions = new (int X, int Y)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            var queue = new Queue<(int X, int Y)>();
            queue.Enqueue((i, j));
            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();
                board[x][y] = 'Q'; // Mark 
                foreach (var (dx, dy) in directions)
                {
                    int newX = x + dx, newY = y + dy;

                    if (newX >= 0 && newX < m && newY >= 0 && newY < n && board[newX][newY] == 'O') // Valid location and is a region
                    {
                        queue.Enqueue((newX, newY));
                        board[newX][newY] = 'Q'; // Mark 
                    }
                }
            }
        }
    }
}