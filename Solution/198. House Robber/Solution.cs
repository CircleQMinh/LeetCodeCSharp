using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int Rob(int[] nums)
        {
            var n = nums.Length;
            var amount = new int[n + 1];
            amount[0] = 0;
            amount[1] = nums[0];
            for (var i = 1; i < n; i++)
            {
                var val = nums[i];
                var amountIndex = i + 1;
                amount[amountIndex] = Math.Max(amount[amountIndex - 2] + val, amount[amountIndex - 1]);
            }
            return amount[n];
        }
    }
}