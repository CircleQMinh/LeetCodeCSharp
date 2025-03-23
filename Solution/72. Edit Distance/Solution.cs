using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int MinDistance(string word1, string word2)
        {
            var m = word1.Length;
            var n = word2.Length;

            var dp = new int[m + 1, n + 1];
            dp[0, 0] = 0;
            //step to convert i char from w1 to empty string
            for (int i = 1; i <= m; i++)
            {
                dp[i, 0] = i;
            }
            // step to convert empty string to j char from w2
            for (int j = 1; j <= n; j++)
            {
                dp[0, j] = j;
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        var insert = dp[i, j - 1] + 1;
                        var replace = dp[i - 1, j - 1] + 1;
                        var delete = dp[i - 1, j] + 1;

                        dp[i, j] = Math.Min(insert, Math.Min(replace, delete));
                    }
                }
            }
            return dp[m, n];
        }
    }
}