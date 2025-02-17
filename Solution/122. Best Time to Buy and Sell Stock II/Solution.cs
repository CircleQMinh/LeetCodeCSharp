using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
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
    }
}