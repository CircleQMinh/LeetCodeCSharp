using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public void SolveSudoku(char[][] board)
        {
            InsertToBoard(board);
        }
        public bool InsertToBoard(char[][] board)
        {

            var (i, j) = FindFirstEmptySpace(board);
            if (i < 0)
            {
                return true;
            }
            for (char num = '1'; num <= '9'; num++)
            {
                if (IsValidPlacement(board, i, j, num))
                {
                    board[i][j] = num;
                    //if (IsValidSudoku(board) && InsertToBoard(board)) // too slow
                    if (InsertToBoard(board))
                    {
                        return true;
                    }
                }
                board[i][j] = '.';
            }

            return false;
        }

        public bool IsValidPlacement(char[][] board, int row, int col, char c)
        {
            for (int i = 0; i < 9; i++)
            {
                // check the row.
                if (board[row][i] == c)
                {
                    return false;
                }
                // check the column.
                if (board[i][col] == c)
                {
                    return false;
                }
                //  3x3 box.
                int boxRow = 3 * (row / 3) + i / 3;
                int boxCol = 3 * (col / 3) + i % 3;
                if (board[boxRow][boxCol] == c)
                {
                    return false;
                }
            }
            return true;
        }

        public (int curI, int curJ) FindFirstEmptySpace(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j].Equals('.'))
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1);
        }


    }
}