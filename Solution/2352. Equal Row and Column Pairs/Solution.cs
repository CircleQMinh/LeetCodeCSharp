using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int EqualPairs(int[][] grid)
        {
            var n = grid.Length;
            var count = 0;
            var rows = new HashSet<(int Index, string Content)>();
            var cols = new HashSet<(int Index, string Content)>();
            for (int i = 0; i < n; i++)
            {
                var row = "";
                var col = "";
                for (int j = 0; j < n; j++)
                {
                    row = $"{row}*{grid[i][j]}";
                    col = $"{col}*{grid[j][i]}";
                }
                rows.Add((i, row));
                cols.Add((i, col));
            }
            foreach (var row in rows)
            {
                foreach (var col in cols)
                {
                    if (row.Content == col.Content)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}