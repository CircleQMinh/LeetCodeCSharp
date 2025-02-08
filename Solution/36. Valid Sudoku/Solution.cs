using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution {
        public bool IsValidSudoku(char[][] board) {
            var set = new HashSet<string>();
            for (int i = 0; i < 9; i++) { 
                for (int j = 0; j < 9; j++)
                {
                    var c = board[i][j];
                    if (!c.Equals('.'))
                    {
                        if (!(
                        set.Add($"Number {c} on row {i}")
                        && set.Add($"Number {c} on col {j}")
                        && set.Add($"Number {c} on box {i / 3},{j / 3}")
                        ))
                        {
                            return false;
                        }

                    }
                }
            }
            return true;
        }

        public bool IsValidSudoku2(char[][] board)
        {
            // Each index will store bits 0-8 corresponding to numbers 1-9.
            int[] rows = new int[9];
            int[] cols = new int[9];
            int[] boxes = new int[9];
            
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char c = board[i][j];
                    if (c == '.')
                        continue;
                    
                    // Convert char digit to integer (e.g., '1' becomes 1)
                    int num = c - '0';
                    
                    // Create a bit mask for this number.
                    // We shift by (num - 1) because number 1 corresponds to bit 0.
                    int bitMask = 1 << (num - 1);
                    
                    int boxIndex = (i / 3) * 3 + (j / 3);
                    
                    // Check if this number has already been seen in the current row, column, or box.
                    if ((rows[i] & bitMask) != 0 ||
                        (cols[j] & bitMask) != 0 ||
                        (boxes[boxIndex] & bitMask) != 0)
                    {
                        return false;
                    }
                    
                    // Mark this number as seen in the current row, column, and box.
                    rows[i] |= bitMask;
                    cols[j] |= bitMask;
                    boxes[boxIndex] |= bitMask;
                }
            }
            
            return true;
        }

    }
}