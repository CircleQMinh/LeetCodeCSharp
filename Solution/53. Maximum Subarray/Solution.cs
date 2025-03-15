using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution // Kadane’s Algorithm
    {
        public int MaxSubArray(int[] nums)
        {
            var max = int.MinValue;
            var current = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                current += nums[i];
                max = Math.Max(max, current);
                current = Math.Max(0, current);
            }
            return max;
        }
    }
}