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
            var b1 = int.MinValue;
            var s1 = int.MinValue;
            var b2 = int.MinValue;
            var s2 = int.MinValue;
            for (int i = 0; i < prices.Length; i++)
            {
                var price = prices[i];
                b1 = Math.Max(b1, -price);
                s1 = Math.Max(s1, b1 + price);
                b2 = Math.Max(b2, s1 - price);
                s2 = Math.Max(s2, b2 + price);
            }

            return s2;
        }
    }
}