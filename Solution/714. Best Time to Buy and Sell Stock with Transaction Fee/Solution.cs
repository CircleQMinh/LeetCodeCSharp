using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int MaxProfit(int[] prices, int fee)
        {
            var n = prices.Length;
            var hold = new int[n];
            var sell = new int[n];

            hold[0] = -prices[0];
            sell[0] = 0;

            for (int i = 1; i < n; i++)
            {
                hold[i] = Math.Max(hold[i - 1], sell[i - 1] - prices[i]);
                sell[i] = Math.Max(sell[i - 1], hold[i - 1] + prices[i] - fee);
            }
            return Math.Max(hold[n - 1], sell[n - 1]);
        }
    }
}