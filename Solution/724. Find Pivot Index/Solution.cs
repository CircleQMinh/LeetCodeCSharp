using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int PivotIndex(int[] nums)
        {
            var n = nums.Length;
            var sum = nums.Sum(x => x);
            var leftSum = 0;
            for (var i = 0; i < n; i++)
            {
                if (leftSum == sum - nums[i])
                {
                    return i;
                }
                leftSum += nums[i];
                sum -= nums[i];
            }
            return -1;
        }
    }
}