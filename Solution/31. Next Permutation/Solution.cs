using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution {
    public void NextPermutation(int[] nums) {
        var left = nums.Length - 2;
        var right = nums.Length - 1;
        var limit = right - 1;
        var isSwap = false;
        while (left >= limit && right >= 1 && limit >=0) {
            if (nums[right] > nums[left])
            {
                var t = nums[left];
                nums[left] = nums[right];
                nums[right] = t;
                isSwap = true;
                break;
            }
            else { 
                left--;

            }
            if (left < limit) { 
                right--;
                left = right - 1;
            }
            if (right == limit)
            {
                right = nums.Length - 1;
                left = right - 1;
                limit--;
            }
        }

        if (!isSwap)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        var t = nums[i];
                        nums[i] = nums[j];
                        nums[j] = t;
                    }
                }
            }
        }
        else
        {
            for (int i = left+1; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        var t = nums[i];
                        nums[i] = nums[j];
                        nums[j] = t;
                    }
                }
            }
        }
    }
}
}