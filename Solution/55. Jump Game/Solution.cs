using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public bool CanJump(int[] nums)
        {
            var current = 0;
            var currentMaxPos = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                currentMaxPos = Math.Max(currentMaxPos, i + nums[i]);
                if (i == current)
                {
                    current = currentMaxPos;
                }
                if (current >= nums.Length - 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}