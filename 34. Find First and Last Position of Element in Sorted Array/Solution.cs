using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        var l = -1;
        var r = -1;

        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;

            if (nums[middle] == target)
            {
                var index = middle;
                for (int i = index; i>= 0; i--)
                {
                    if(nums[i] == target){
                        l = i;
                    }
                }
                for (int i = index; i <nums.Length; i++)
                {
                    if (nums[i] == target)
                    {
                        r = i;
                    }
                }
                break;
            }

            if (nums[middle] < target)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }
        return [l, r];
    }
}
}