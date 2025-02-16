using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        // public void Rotate(int[] nums, int k) // too slow
        // {
        //     var time = k < nums.Length ? k : k%nums.Length;
        //     for (int i = 0; i < time; i++) {
        //         RotateArrayToTheRight(nums);
        //     }
        // }

        // public void RotateArrayToTheRight(int[] nums)
        // {
        //     var last = nums[nums.Length-1];
        //     for (int i = nums.Length - 1; i > 0; i--) {
        //         nums[i] = nums[i-1];
        //     }
        //     nums[0] = last;
        // }
        public void Rotate(int[] nums, int k)
        {
            var time = k < nums.Length ? k : k % nums.Length;

            ReverseArray(nums, 0, nums.Length - 1);
            ReverseArray(nums, 0, time - 1);
            ReverseArray(nums, time, nums.Length - 1);

        }

        public void ReverseArray(int[] nums, int start, int end)
        {
            while (start < end)
            {
                (nums[start], nums[end]) = (nums[end], nums[start]);
                start++;
                end--;
            }

        }
    }
}