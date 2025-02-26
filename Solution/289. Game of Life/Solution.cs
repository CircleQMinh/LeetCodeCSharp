using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public void GameOfLife(int[][] board)
        {
            var m = board.Length;
            var n = board[0].Length;

            for (var i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    CheckElement(i, j, board);
                }
            }
            ReAssignBoard(board);

        }

        public void ReAssignBoard(int[][] board)
        {
            var deadToDead = 2;
            var deadToAlive = 3;
            var aliveToDead = 4;
            var aliveToAlive = 5;
            var m = board.Length;
            var n = board[0].Length;

            for (var i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == deadToDead || board[i][j] == aliveToDead)
                    {
                        board[i][j] = 0;
                    }
                    if (board[i][j] == aliveToAlive || board[i][j] == deadToAlive)
                    {
                        board[i][j] = 1;
                    }
                }
            }
        }

        public void CheckElement(int x, int y, int[][] board)
        {
            var m = board.Length;
            var n = board[0].Length;

            var dirI = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            var dirJ = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };


            var deadToDead = 2;
            var deadToAlive = 3;
            var aliveToDead = 4;
            var aliveToAlive = 5;

            var numberAlive = 0;
            var numberDead = 0;

            for (int i = 0; i < 8; i++)
            {
                var row = x + dirI[i];
                var col = y + dirJ[i];

                if (row < 0 || col < 0 || row > m - 1 || col > n - 1)
                {
                    continue;
                }

                if (board[row][col] == 0 || board[row][col] == deadToDead || board[row][col] == deadToAlive)
                {
                    numberDead++;
                }
                if (board[row][col] == 1 || board[row][col] == aliveToDead || board[row][col] == aliveToAlive)
                {
                    numberAlive++;
                }
            }
            board[x][y] = board[x][y] == 0
                ? numberAlive == 3 ? deadToAlive : deadToDead
                : numberAlive == 2 || numberAlive == 3 ? aliveToAlive : aliveToDead;
        }
    }
}