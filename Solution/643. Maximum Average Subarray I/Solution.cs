using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public double FindMaxAverage(int[] nums, int k)
        {
            var n = nums.Length;
            var j = k;
            double result = 0;
            double max = 0;
            for (int i = 0; i < k; i++)
            {
                result += nums[i];
            }
            max = result / k;
            while (j < n)
            {
                result -= nums[j - k];
                result += nums[j];
                max = Math.Max(max, result / k);
                j++;
            }
            return max;
        }
    }
}