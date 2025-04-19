using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int LongestOnes(int[] nums, int k)
        {
            int n = nums.Length;
            int l = 0;
            int r = -1;
            var max = 0;
            var fliped = 0;
            if (n == 1)
            {
                return (k >= 1) ? 1 : 0;
            }
            while (l < n - 1 && r < n - 1)
            {
                r++;
                if (nums[r] == 1)
                {

                }
                if (nums[r] == 0)
                {

                    fliped++;


                    while (!(fliped <= k))
                    {
                        var last = nums[l];
                        fliped -= last == 1 ? 0 : 1;
                        l++;
                    }

                }
                max = Math.Max(max, r - l + 1);
            }
            return max;
        }
    }
}