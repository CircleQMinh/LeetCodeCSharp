using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int MaxSubarraySumCircular(int[] nums)
        {
            var n = nums.Length;
            var max = int.MinValue;
            var min = int.MaxValue;
            var currentMax = 0;
            var currentMin = 0;
            var total = 0;
            var set = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {

                currentMax = Math.Max(nums[i], currentMax + nums[i]);
                max = Math.Max(max, currentMax);


                currentMin = Math.Min(nums[i], currentMin + nums[i]);
                min = Math.Min(min, currentMin);

                total += nums[i];
            }
            return max > 0 ? Math.Max(max, total - min) : max;
        }
    }
}