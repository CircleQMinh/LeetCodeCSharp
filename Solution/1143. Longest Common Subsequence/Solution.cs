using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
            var m = text2.Length + 1;
            var n = text1.Length + 1;
            var dp = new int[m, n];
            dp.Initialize();
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (text2[i - 1] == text1[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}