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
    }
}