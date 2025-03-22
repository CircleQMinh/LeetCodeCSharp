using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var m = triangle.Count;
            var dp = new List<List<int>>();
            dp.Add(triangle[0].ToList());
            for (int i = 1; i < m; i++)
            {
                var rowAbove = dp[i - 1];
                var currentRow = triangle[i];
                var n = currentRow.Count;
                var currentDp = new List<int>();

                for (int j = 0; j < n; j++)
                {
                    var val = currentRow[j];
                    var min = int.MaxValue;
                    var startIndex = j - 1 < 0 ? j : j - 1;
                    var endIndex = Math.Min(rowAbove.Count, j + 1);
                    for (int k = startIndex; k < endIndex; k++)
                    {
                        var total = val + rowAbove[k];
                        min = Math.Min(min, total);
                    }
                    currentDp.Add(min);
                }
                dp.Add(currentDp);
            }

            var result = dp.Last().Min();
            return result;
        }
    }
}