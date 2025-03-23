using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            var m = s1.Length;
            var n = s2.Length;
            if (s3.Length != s1.Length + s2.Length)
            {
                return false;
            }
            bool[][] dp = new bool[m + 1][];
            for (int i = 0; i <= m; i++)
            {
                dp[i] = new bool[n + 1];
            }
            // dp[i][j] = using i char from s1 and j char from s2 to create i+j char from s3
            dp[0][0] = true;
            //if using 0 char from s2 and i char from s1
            for (int i = 1; i <= m; i++)
            {
                dp[i][0] = s1[i - 1] == s3[i - 1] && dp[i - 1][0];
            }
            // if using 0 char from s1 and j char from s2
            for (int j = 1; j <= n; j++)
            {
                dp[0][j] = s2[j - 1] == s3[j - 1] && dp[0][j - 1];
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    dp[i][j] =
                        (dp[i][j - 1] && s2[j - 1] == s3[i + j - 1])
                        ||
                        (dp[i - 1][j] && s1[i - 1] == s3[i + j - 1]);
                }
            }

            return dp[m][n];
        }
    }
}