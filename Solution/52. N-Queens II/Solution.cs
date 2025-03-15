using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int TotalNQueens(int n)
        {
            var board = new int[n, n];
            board.Initialize();
            var result = new HashSet<List<int[]>>();
            FindSolutionForNQueen(board, new List<int[]>(), result);
            return result.Count;
        }
        public void FindSolutionForNQueen(int[,] board, List<int[]> currentQ, HashSet<List<int[]>> result)
        {
            var n = board.GetLength(0);
            if (currentQ.Count == n)
            {
                result.Add(new List<int[]>(currentQ));
            }
            var lastQPlaceX = currentQ.Count > 0 ? currentQ.Last()[0] : -1;
            var lastQPlaceY = currentQ.Count > 0 ? currentQ.Last()[1] : -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i > lastQPlaceX || (i == lastQPlaceX && j > lastQPlaceY)) && IsValidPlacementForQ(board, currentQ, i, j))
                    {
                        currentQ.Add([i, j]);
                        board[i, j] = 1;

                        FindSolutionForNQueen(board, currentQ, result);

                        currentQ.RemoveAt(currentQ.Count - 1);
                        board[i, j] = 0;
                    }
                }
            }
        }
        public bool IsValidPlacementForQ(int[,] board, List<int[]> currentQ, int placeX, int placeY)
        {
            var n = board.GetLength(0);
            if (board[placeX, placeY] == 1)
            {
                return false;
            }
            var directions = new (int X, int Y)[] { (-1, 0), (1, 0), (0, -1), (0, 1), (-1, -1), (-1, 1), (1, -1), (1, 1) };
            foreach (var dir in directions)
            {
                var newX = placeX + dir.X;
                var newY = placeY + dir.Y;
                while (newX >= 0 && newX < n && newY >= 0 && newY < n)
                {
                    if (board[newX, newY] == 1)
                    {
                        return false;
                    }
                    newX += dir.X;
                    newY += dir.Y;
                }

            }
            return true;
        }
    }
}