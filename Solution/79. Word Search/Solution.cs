using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public bool Exist(char[][] board, string word)
        {
            var m = board.Length;
            var n = board[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (word[0].Equals(board[i][j]))
                    {
                        if (DFSWordInBoard(board, word, (i, j), 0))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool DFSWordInBoard(char[][] board, string word, (int X, int Y) currentPos, int currentIndex)
        {
            var c = board[currentPos.X][currentPos.Y];
            if (word.Length == currentIndex + 1)
            {
                return word[currentIndex] == c;
            }


            if (word[currentIndex] != c)
            {
                return false;
            }

            var directions = new (int X, int Y)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            var m = board.Length;
            var n = board[0].Length;

            board[currentPos.X][currentPos.Y] = '#';
            foreach (var dir in directions)
            {
                var newX = currentPos.X + dir.X;
                var newY = currentPos.Y + dir.Y;
                if (newX >= 0 && newX < m && newY >= 0 && newY < n && board[newX][newY] != '#')
                {
                    if (DFSWordInBoard(board, word, (newX, newY), currentIndex + 1))
                    {
                        return true;
                    }
                }
            }
            board[currentPos.X][currentPos.Y] = c;

            return false;
        }
    }
}