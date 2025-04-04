using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int Tribonacci(int n)
        {
            var dp = new int[Math.Max(n + 1, 3)];
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 1;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
            }
            return dp[n];
        }
    }
}