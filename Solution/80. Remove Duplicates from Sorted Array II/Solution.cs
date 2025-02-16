using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            var count = 0;
            if (nums.Length < 3)
            {
                return nums.Length;
            }
            for (int i = 1; i < nums.Length - 1 - count; i++)
            {
                if (nums[i] == nums[i - 1] && nums[i] == nums[i + 1])
                {
                    count++;
                    for (int j = i + 1; j < nums.Length - 1; j++)
                    {
                        nums[j] = nums[j + 1];
                    }
                    i--;
                }
            }

            return nums.Length - count;
        }
    }
}