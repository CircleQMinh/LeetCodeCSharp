using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int FirstMissingPositive(int[] nums) {
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= 0 || nums[i] > nums.Length)
            {
                nums[i] = nums.Length + 1;
            }

        }

        for (int i = 0; i < nums.Length; i++)
        {
            int value = Math.Abs(nums[i]);
            if (value > nums.Length)
            {
                continue;
            }
            value = value - 1; // array start at 0, result start at 1
            if (nums[value] > 0) // convert cell at [value] to a negative number
            {
                nums[value] = nums[value] * -1;
            }

        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
            {
                return i + 1;
            }
        }
        return nums.Length + 1;
    }
        // public int FirstMissingPositive(int[] nums)
        // {
        //     var n = nums.Length;
        //     var set = new HashSet<int>();
        //     for (int i = 0; i < n; i++)
        //     {
        //         var cell = nums[i];
        //         if (cell <= 0 || cell > n)
        //         {
        //             continue;
        //         }
        //         set.Add(nums[i]);
        //     }

        //     for (int i = 1; i <= n; i++)
        //     {
        //         if (!set.Contains(i))
        //         {
        //             return i;
        //         }
        //     }

        //     return n + 1;
        // }
    }
}