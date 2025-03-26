using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int NumTilings(int n)
        {
            var dp = new long[Math.Max(n + 1, 3)];
            dp[0] = 1;
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = (2 * dp[i - 1]) % (1000000007) + (dp[i - 3]) % (1000000007);
            }
            return (int)(dp[n] % (1000000007));
        }
    }
}