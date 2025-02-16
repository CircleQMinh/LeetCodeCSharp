using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution {
        public int MaxProfit(int[] prices) {
            var profit = 0;
            var dayToBuy = 0;
            for (int i = 1; i < prices.Length; i++) {
                if (prices[dayToBuy] < prices[i])
                {
                    profit = prices[i] - prices[dayToBuy] > profit ? prices[i] - prices[dayToBuy] : profit;
                }
                else
                {
                    dayToBuy = i;
                }
            }

            return profit;
        }
    }
}