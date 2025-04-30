using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int LongestSubarray(int[] nums)
        {
            var n = nums.Length;
            var l = 0;
            var r = 0;
            var countOne = 0;
            var countZero = 0;
            var max = 0;
            while (l < n && r < n)
            {
                if (nums[r] == 0)
                {
                    countZero++;
                }
                else
                {
                    countOne++;
                    max = Math.Max(max, countOne);
                }
                if (countZero == 2)
                {
                    while (nums[l] != 0)
                    {
                        countOne--;
                        l++;
                    }
                    l++;
                    countZero--;
                }
                r++;
            }
            return countZero == 0 ? max - 1 : max;
        }
    }
}