using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int FindMin(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            int middle = 0;
            //while (left <= right)
            //{
            //    middle = left + (right - left) / 2;
            //    if (left == right)
            //    {
            //        return nums[middle];
            //    }

            //    if (nums[middle] < nums[left] && nums[middle] < nums[right])
            //    {
            //        left = left + 1;
            //        right = right - 1;
            //        continue;
            //    }

            //    if (nums[middle] > nums[right])
            //    {
            //        left = middle + 1;
            //        continue;
            //    }
            //    else
            //    {
            //        right = middle - 1;
            //        continue;
            //    }
            //}

            //return nums[middle];

            while (left < right)
            {
                middle = left + (right - left) / 2;
                if (nums[middle] > nums[right])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }
            return nums[left];
        }
    }
}