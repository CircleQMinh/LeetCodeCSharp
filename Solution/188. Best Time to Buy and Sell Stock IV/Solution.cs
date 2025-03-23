using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int MaxProfit(int k, int[] prices)
        {
            if (k >= prices.Length / 2)
            {
                var profit = 0;
                for (int i = 1; i < prices.Length; i++)
                {
                    if (prices[i] > prices[i - 1])
                    {
                        profit -= prices[i - 1];
                        profit += prices[i];
                    }
                }
                return profit;
            }
            var n = prices.Length;
            var dp = new int[k + 1, n];
            dp[0, 0] = 0;
            for (int i = 1; i <= k; i++)
            {
                dp[i, 0] = 0;
            }
            for (int j = 1; j < n; j++)
            {
                dp[0, j] = 0;
            }

            for (int i = 1; i <= k; i++)
            {
                int maxDiff = -prices[0];
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = Math.Max(dp[i, j - 1], prices[j] + maxDiff);
                    maxDiff = Math.Max(maxDiff, dp[i - 1, j] - prices[j]);
                }
            }
            return dp[k, n - 1];
        }
    }
}