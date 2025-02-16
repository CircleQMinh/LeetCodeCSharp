using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int MajorityElement(int[] nums)
        {
            var result = nums[0];
            var count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != result)
                {
                    count--;
                }
                else
                {
                    count++;
                }
                if (count == 0)
                {
                    result = nums[i];
                    count = 1;
                }
            }
            return result;
        }
    }
}