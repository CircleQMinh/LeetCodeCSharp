using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var result = new int[nums.Length];
            var current = 1;
            result[0] = current;
            for (int i = 1; i < nums.Length; i++)
            {
                current = current * nums[i - 1];
                result[i] = current;
            }
            current = 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                current = current * nums[i + 1];
                result[i] = result[i] * current;
            }

            return result;
        }
    }
}