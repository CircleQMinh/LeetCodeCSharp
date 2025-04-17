using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public bool IncreasingTriplet(int[] nums)
        {
            var n = nums.Length;
            if (n < 3)
            {
                return false;
            }
            var first = nums[0];
            var second = int.MaxValue;

            for (int i = 1; i < n; i++)
            {
                var current = nums[i];
                if (current <= first)
                {
                    first = current;
                }
                else if (current <= second)
                {
                    second = current;
                }
                else if (current > second)
                {
                    return true;
                }

            }
            return false;
        }
    }
}